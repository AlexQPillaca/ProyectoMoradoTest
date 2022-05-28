using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using test2.Data;
using test2.Models;
using Microsoft.EntityFrameworkCore;


namespace test2.Controllers
{
    public class PagoController: Controller
    {
        
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public PagoController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Create(Decimal monto)
        {
            Pago pago = new Pago();
            pago.UserId = _userManager.GetUserName(User);
            pago.MontoTotal = monto;
            return View(pago);
        }

        [HttpPost]
        public IActionResult Pagar(Pago pago)
        {
            pago.PaymentDate = DateTime.UtcNow;
            _context.Add(pago);

            var itemsProforma = from o in _context.DataProforma select o;
            itemsProforma = itemsProforma.
                Include(p => p.producto).
                Where(s => s.UserID.Equals(pago.UserId) && s.Status.Equals("PENDIENTE"));

            Pedido pedido = new Pedido();
            pedido.UserID = pago.UserId;
            pedido.Total = pago.MontoTotal;
            pedido.pago = pago;
            pedido.Status = "PENDIENTE";
            _context.Add(pedido);


            List<DetallePedido> itemsPedido = new List<DetallePedido>();
            foreach(var item in itemsProforma.ToList()){
                DetallePedido detallePedido = new DetallePedido();
                detallePedido.pedido=pedido;
                detallePedido.Precio = item.Price;
                detallePedido.Producto = item.producto;
                detallePedido.Cantidad = item.Quantity;
                itemsPedido.Add(detallePedido);
            }

            _context.AddRange(itemsPedido);

            foreach (Proforma p in itemsProforma.ToList())
            {
                p.Status="PROCESADO";
            }
            _context.UpdateRange(itemsProforma);

            _context.SaveChanges();

            ViewData["Message"] = "El pago se ha registrado";
            return View("Create");
        }

        


    }
}

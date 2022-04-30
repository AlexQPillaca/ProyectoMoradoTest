using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using test2.Models;
using test2.Data; //Importamos para usar el DbContext
using Microsoft.EntityFrameworkCore;

namespace test2.Controllers
{
    public class CatalogoController : Controller
    {
        
            
        private readonly ILogger<CatalogoController> _logger;

        private readonly ApplicationDbContext _context;

        public CatalogoController(ApplicationDbContext context, ILogger<CatalogoController> logger)
        {
            _context = context;
            _logger = logger;      
        }

        public async Task<IActionResult> Index()
        {
            var productos = from o in _context.DatProductos select o;
            return View(await productos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id){
            Producto objProd = await _context.DatProductos.FindAsync(id);

            if(objProd == null){
                return NotFound();
            }
            return View(objProd);
        }



    }
}
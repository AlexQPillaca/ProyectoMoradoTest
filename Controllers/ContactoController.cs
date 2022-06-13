using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using test2.Models;
using test2.Data; //Importamos para usar el DbContext
using test2.Integration.Sengrid;


namespace test2.Controllers
{
    public class ContactoController : Controller
    {

     private readonly ILogger<ContactoController> _logger;

     private readonly ApplicationDbContext _context;

     private readonly SendMailIntegration _sendgrid;

    public ContactoController(ApplicationDbContext context, ILogger<ContactoController> logger,SendMailIntegration sendgrid)
    {
        _context = context;
        _logger = logger;      
         _sendgrid = sendgrid;  
    }

    public IActionResult Index()
    {
        return View();
    }


    //Recibir la data que nos llega con un objecto de tipo contacto para eso debemos importar el models
    [HttpPost]
    public async Task<IActionResult> Create(Contacto objContacto)
    {
        _context.Add(objContacto);
        _context.SaveChanges();
        await _sendgrid.SendMail(objContacto.Email,
                objContacto.Name,
                "Bienvenido al e-comerce",
                "Revisaremos su consulta en breves momentos y le responderemos",
                SendMailIntegration.SEND_SENDGRID);            
                    
        ViewData["Message"] = "Se registro el contacto";
        
        return View("Index");
    }
        
    }
}
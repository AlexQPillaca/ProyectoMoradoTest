using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using test2.Models;
using test2.Data; //Importamos para usar el DbContext


namespace test2.Controllers
{
    public class ContactoController : Controller
    {

     private readonly ILogger<ContactoController> _logger;

     private readonly ApplicationDbContext _context;

    public ContactoController(ApplicationDbContext context, ILogger<ContactoController> logger)
    {
        _context = context;
        _logger = logger;      
    }

    public IActionResult Index()
    {
        return View();
    }


    //Recibir la data que nos llega con un objecto de tipo contacto para eso debemos importar el models
    [HttpPost]
    public IActionResult Create(Contacto objContacto)
    {
        _context.Add(objContacto);
        _context.SaveChanges();
        ViewData["Message"] = "Se registro el contacto";
        
        return View("Index");
    }

        
    }
}
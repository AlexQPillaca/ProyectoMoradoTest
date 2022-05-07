using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using test2.Models;


namespace test2.Data;

public class ApplicationDbContext : IdentityDbContext
{
    // Constructor de este objeto
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<test2.Models.Contacto> DataContactos { get; set;}

     public DbSet<test2.Models.Producto> DatProductos { get; set;}
     public DbSet<test2.Models.Proforma> DataProforma { get; set;}

}

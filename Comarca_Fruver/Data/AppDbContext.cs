using Comarca_Fruver.Models;
using Microsoft.EntityFrameworkCore;

namespace Comarca_Fruver.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cargamento> cargamentos { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}

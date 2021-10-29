using COAChallenge.Entidades;
using Microsoft.EntityFrameworkCore;

namespace COAChallenge.Datos
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
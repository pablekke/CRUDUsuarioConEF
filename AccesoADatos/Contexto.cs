using Microsoft.EntityFrameworkCore;
using Dominio;
namespace AccesoADatos
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public Contexto(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasKey(u => u.UsuarioId);
            modelBuilder.Entity<Usuario>().HasIndex(u => u.Email).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}

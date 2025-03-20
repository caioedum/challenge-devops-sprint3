using Microsoft.EntityFrameworkCore;
using WebApiChallenge.Models;

namespace WebApiChallenge.Context
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options)
        {
        }

        public DbSet<Imagem> T_IMAGEM_USUARIO_ODONTOPREV { get; set; }
        public DbSet<Previsao> T_PREVISAO_USUARIO_ODONTOPREV { get; set; }
        public DbSet<Usuario> T_USUARIO_ODONTOPREV { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .Property(u => u.UsuarioId)
                .ValueGeneratedOnAdd();
        }
    }
}

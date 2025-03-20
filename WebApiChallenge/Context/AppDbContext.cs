using Microsoft.EntityFrameworkCore;
using WebApiChallenge.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<ImagemUsuario> ImagensUsuarios { get; set; }
    public DbSet<PrevisaoUsuario> PrevisoesUsuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração de chaves estrangeiras
        modelBuilder.Entity<ImagemUsuario>()
            .HasOne(i => i.Usuario)
            .WithMany()
            .HasForeignKey(i => i.UsuarioId);

        modelBuilder.Entity<PrevisaoUsuario>()
            .HasOne(p => p.ImagemUsuario)
            .WithMany()
            .HasForeignKey(p => p.ImagemUsuarioId);

        modelBuilder.Entity<PrevisaoUsuario>()
            .HasOne(p => p.Usuario)
            .WithMany()
            .HasForeignKey(p => p.UsuarioId);

        modelBuilder.Entity<Usuario>().ToTable("t_usuario_odontoprev");
        modelBuilder.Entity<ImagemUsuario>().ToTable("t_imagem_usuario_odontoprev");
        modelBuilder.Entity<PrevisaoUsuario>().ToTable("t_previsao_usuario_odontoprev");

        base.OnModelCreating(modelBuilder);
    }
}

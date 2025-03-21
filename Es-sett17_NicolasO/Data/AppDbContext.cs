using Es_sett17_NicolasO.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Cliente> Clienti { get; set; }
    public DbSet<Camera> Camere { get; set; }
    public DbSet<Prenotazione> Prenotazioni { get; set; }


    public AppDbContext() { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Prenotazione>()
            .HasOne(p => p.Cliente)
            .WithMany(c => c.Prenotazioni)
            .HasForeignKey(p => p.ClienteId);

        modelBuilder.Entity<Prenotazione>()
            .HasOne(p => p.Camera)
            .WithMany(c => c.Prenotazioni)
            .HasForeignKey(p => p.CameraId);
    }
}

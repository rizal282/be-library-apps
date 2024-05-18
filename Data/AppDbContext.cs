using apilibraryapps.Models;
using Microsoft.EntityFrameworkCore;

namespace apilibraryapps.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Mahasiswa> Mahasiswas { get; set; }
    public DbSet<Buku> Bukus { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<TransaksiBuku> TransaksiBukus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TransaksiBuku>()
            .HasKey(tb => new {tb.IdBuku, tb.IdMhs});

        modelBuilder.Entity<TransaksiBuku>()
            .HasOne(tb => tb.Buku)
            .WithMany(s => s.TransaksiBukus)
            .HasForeignKey(fk => fk.IdBuku);

        modelBuilder.Entity<TransaksiBuku>()
            .HasOne(tb => tb.Mahasiswa)
            .WithMany(s => s.TransaksiBukus)
            .HasForeignKey(fk => fk.IdMhs);
    }
}
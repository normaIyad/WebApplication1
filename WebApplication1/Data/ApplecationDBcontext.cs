using Microsoft.EntityFrameworkCore;
using WebApplication1.Module;

namespace WebApplication1.Data
{
    public class ApplecationDBcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=library;Trusted_Connection=True;TrustServerCertificate=True");
            //optionsBuilder.UseSqlServer("Server=.;Database=library;Trusted_Connection=True;TrustedServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(p => p.Name)
                .HasColumnType("varchar").HasMaxLength(50);
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Price)
                  .HasColumnType("decimal(6,2)");
            });
        }

        public DbSet<Book> Books { get; set; }
    }
}

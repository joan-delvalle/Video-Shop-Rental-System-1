using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Video_Shop_Rental_System.Models;

namespace Video_Shop_Rental_System.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<RentalHeader> RentalHeaders { get; set; }
        public DbSet<RentalDetail> RentalDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<RentalHeader>(entity =>
            {
                entity.HasOne(rh => rh.Customer)
                      .WithMany()
                      .HasForeignKey(rh => rh.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RentalDetail>(entity =>
            {
                entity.HasOne(rd => rd.RentalHeader)
                      .WithMany(rh => rh.RentalDetails)
                      .HasForeignKey(rd => rd.RentalHeaderId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(rd => rd.Movie)
                      .WithMany()
                      .HasForeignKey(rd => rd.MovieId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}

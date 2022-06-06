using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base (opt)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>()                                       // 1:1 
                .HasOne(address => address.Cinema)
                .WithOne(cinema => cinema.Address)
                .HasForeignKey<Cinema>(cinema => cinema.AddressId);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Manager> Managers { get; set; }
    }
}

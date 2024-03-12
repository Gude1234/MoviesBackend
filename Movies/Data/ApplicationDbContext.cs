using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<coupons> Coupons { get; set; }
        public DbSet<MovieDetail> MoviesDetails { get; set; }
        public DbSet<TheatreDetails> TheatreDetail { get; set; }
        public DbSet<SeatType> SeatTypes { get; set; }
        public DbSet<seats> seats { get; set; }
    }
}

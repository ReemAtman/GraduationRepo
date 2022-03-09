using Microsoft.EntityFrameworkCore;

namespace AppAPIs.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options ) : base( options )
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Countrie> Countries { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Citie> Cities { get; set; }
        public DbSet<Journey> Journeys { get; set; }
    }
}

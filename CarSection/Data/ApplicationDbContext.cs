using CarSection.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSection.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 

        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public DbSet<CarModel> Cars { get; set; }

    }
}

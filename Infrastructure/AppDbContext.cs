using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions opt) : base(opt) { }

        public DbSet<Person> Persons { get; set; }
    }
}

using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions opt) : base(opt) { }

        public DbSet<Person> Person { get; set; }
    }
}

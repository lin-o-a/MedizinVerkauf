using Microsoft.EntityFrameworkCore;
using MedizinVerkauf.Models;

namespace MedizinVerkauf.DomainLogic
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Medicine> Medicine { get; set; }
    }
}
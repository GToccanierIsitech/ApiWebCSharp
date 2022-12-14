using Microsoft.EntityFrameworkCore;
using ToccanierGregoryApiWeb.Entity;

namespace ToccanierGregoryApiWeb.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
    }
}

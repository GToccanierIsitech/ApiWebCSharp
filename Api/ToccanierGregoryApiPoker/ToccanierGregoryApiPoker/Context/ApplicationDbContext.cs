using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ToccanierGregoryApiPoker.Entity;

namespace ToccanierGregoryApiPoker.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                .HasOne(p => p.player)
                .WithMany(b => b.card)
                .HasForeignKey(k => k.player_id);

            modelBuilder.Entity<Card>()
                .HasOne(p => p.game)
                .WithMany(b => b.card)
                .HasForeignKey(k => k.game_id);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.game)
                .WithMany(b => b.player)
                .HasForeignKey(k => k.game_id);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.user)
                .WithOne(b => b.player)
                .HasForeignKey<Player>(k => k.user_id);
        }
    }
}

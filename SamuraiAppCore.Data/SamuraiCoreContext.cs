using Microsoft.EntityFrameworkCore;
using SamuraiAppCore.Domain;

namespace SamuraiAppCore.Data
{
    public class SamuraiCoreContext : DbContext
    {
        public SamuraiCoreContext(DbContextOptions<SamuraiCoreContext> options)       
            : base(options)
        { 
        }

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>()
                .HasKey(key => new { key.BattleId, key.SamuraiId });
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = SamuraiAppData; Trusted_Connection = True; ");
        //   // base.OnConfiguring(optionsBuilder);
        //}
    }
}

using Learn_CQRS.Entities;
using Microsoft.EntityFrameworkCore;

namespace Learn_CQRS.Data
{
    public class HeroDbContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }
        public HeroDbContext(DbContextOptions<HeroDbContext> options) 
            : base(options) 
        {
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseInMemoryDatabase("Learn-CQRS");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>()
                        .Property(entity => entity.Id)
                        .ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);
        }
    }
}

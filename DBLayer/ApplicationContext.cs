using Microsoft.EntityFrameworkCore;
using PathOfRegexDB.Models;

namespace DBLayer
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Affix> Affixes { get; set; }
        public DbSet<ItemTypeMaster> ItemTypeMasters { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> dbContext) : base(dbContext) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<Affix>().ToTable("Affixes");
            modelBuilder.Entity<ItemTypeMaster>().ToTable("ItemTypeMasters");
        }
    }
}

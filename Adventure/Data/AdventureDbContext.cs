using System;
using System.Data.Entity;

namespace Adventure.Data
{
    public class AdventureDbContext : DbContext
    {

        public AdventureDbContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AdventureDbContext>());
        }

        public DbSet<GameObject> GameObjects { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameObject>().HasMany(m => m.Aliases).WithMany();
            modelBuilder.Entity<GameObject>().HasMany(m => m.Statuses).WithMany();
            base.OnModelCreating(modelBuilder);
        }
    }
}

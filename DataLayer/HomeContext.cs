using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models.Entities;

namespace DataLayer
{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions<HomeContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }

        
        #region Ovveride methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(e => e.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(e => e.Phone).IsUnique();
        }
        
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            UpdateDate(ChangeTracker);

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            UpdateDate(ChangeTracker);

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateDate(ChangeTracker);

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override int SaveChanges()
        {
            UpdateDate(ChangeTracker);

            return base.SaveChanges();
        }
        
        #endregion
        
        
        #region | Private methods |

        private static void UpdateDate(ChangeTracker changeTracker)
        {
            var entries = changeTracker
                .Entries()
                .Where(e =>
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                entityEntry.Property("Modified").CurrentValue = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                    entityEntry.Property("Created").CurrentValue = DateTime.Now;
            }
        }

        #endregion
    }
}
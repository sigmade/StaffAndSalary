using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sigmade.Domain.Identity;
using Sigmade.Domain.Models;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sigmade.Domain
{
    public class ApplicationDbContext : IdentityDbContext<
        User,
        Role,
        Guid,
        IdentityUserClaim<Guid>,
        UserRole,
        IdentityUserLogin<Guid>,
        IdentityRoleClaim<Guid>,
        IdentityUserToken<Guid>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(b =>
            {
                b.HasMany(e => e.Roles)
                .WithOne(e => e.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            });

            builder.Entity<Role>(b =>
            {
                b.HasMany(e => e.Users)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
            });
        }

        public DbSet<Position> Positions { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkLocation> WorkLocations { get; set; }
        public DbSet<WorkTime> WorkTimes { get; set; }

        public override int SaveChanges()
        {
            AddTimeStamp();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimeStamp();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimeStamp()
        {
            var entities = ChangeTracker
                .Entries()
                .Where(x => x.Entity is Worker && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((Worker)entity.Entity).DateCreate = DateTime.UtcNow;
                }

                ((Worker)entity.Entity).DateUpdate = DateTime.UtcNow;
            }
        }
    }
}

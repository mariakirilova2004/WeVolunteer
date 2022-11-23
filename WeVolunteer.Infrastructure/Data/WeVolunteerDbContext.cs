using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeVolunteer.Infrastructure.Data.Entities;
using WeVolunteer.Infrastructure.Data.Entities.Account;
using WeVolunteer.Infrastructure.Data.Configuration;
using WeVolunteer.Infrastructure.Data.Entities;

namespace WeVolunteer.Infrastructure.Data
{
    public class WeVolunteerDbContext : IdentityDbContext<User>
    {
        public WeVolunteerDbContext(DbContextOptions<WeVolunteerDbContext> options)
            : base(options)
        {
            base.Database.Migrate();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Cause> Causes { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<PhotoCause> PhotosCauses { get; set; }
        public DbSet<PhotoOrganization> PhotosOrganizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PhotoCauseConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new PhotoOrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CauseConfiguration());

            modelBuilder.Entity<Organization>()
               .HasKey(o => o.Id);

            modelBuilder.Entity<Category>()
               .HasKey(c => c.Id);

            modelBuilder.Entity<Cause>()
                .HasOne(e => e.Organization)
                .WithMany(o => o.Causes)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Cause>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Cause>()
                .HasMany(e => e.Photos)
                .WithOne(o => o.Cause)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Cause>()
                .HasKey(e => e.Id); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
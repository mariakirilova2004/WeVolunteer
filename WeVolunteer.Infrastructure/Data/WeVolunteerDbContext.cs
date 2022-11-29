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
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            //modelBuilder.ApplyConfiguration(new PhotoCauseConfiguration());
            //modelBuilder.ApplyConfiguration(new PhotoOrganizationConfiguration());
            //modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new CauseConfiguration());

            modelBuilder.Entity<Organization>()
               .HasKey(o => o.Id);
            modelBuilder.Entity<Organization>()
               .HasMany(o => o.Photos)
               .WithOne(p => p.Organization)
               .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Organization>()
               .HasMany(o => o.Causes)
               .WithOne(c => c.Organization)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PhotoOrganization>()
               .HasOne(po => po.Organization)
               .WithMany(o => o.Photos)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PhotoCause>()
               .HasOne(pc => pc.Cause)
               .WithMany(o => o.Photos)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>()
               .HasKey(c => c.Id);

            modelBuilder.Entity<Cause>()
                .HasOne(c => c.Organization)
                .WithMany(o => o.Causes)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Cause>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Cause>()
                .HasMany(c => c.Photos)
                .WithOne(o => o.Cause)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Cause>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Causes)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Cause>()
            .HasMany(x => x.Users)
            .WithMany(x => x.Causes);

            modelBuilder.Entity<User>()
            .HasMany(x => x.Causes)
            .WithMany(x => x.Users)
            .UsingEntity<Dictionary<string, object>>(
            "JoinUserWithCause",
            j => j.HasOne<Cause>().WithMany().OnDelete(DeleteBehavior.Cascade),
            j => j.HasOne<User>().WithMany().OnDelete(DeleteBehavior.ClientCascade));


            base.OnModelCreating(modelBuilder);
        }
    }
}
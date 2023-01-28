using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeVolunteer.Infrastructure.Data.Entities;
using WeVolunteer.Infrastructure.Data.Entities.Account;
using WeVolunteer.Infrastructure.Data.Configuration;
using WeVolunteer.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace WeVolunteer.Infrastructure.Data
{
    public class WeVolunteerDbContext : IdentityDbContext<User>
    {
        private bool seedDb;
        private User userAdmin { get; set; }
        private Organization organizationAdmin { get; set; }

        public WeVolunteerDbContext(DbContextOptions<WeVolunteerDbContext> options, bool seed = true)
            : base(options)
        {
            this.seedDb = seed;
            if (this.Database.IsRelational())
            {
                this.Database.Migrate();
            }
            else
            {
                this.Database.EnsureCreated();
            }
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Cause> Causes { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<PhotoCause> PhotosCauses { get; set; }
        public DbSet<PhotoOrganization> PhotosOrganizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if(this.seedDb)
            {
                modelBuilder.ApplyConfiguration(new CategoryConfiguration());
                //modelBuilder.ApplyConfiguration(new UserConfiguration());
                //modelBuilder.ApplyConfiguration(new PhotoCauseConfiguration());
                //modelBuilder.ApplyConfiguration(new PhotoOrganizationConfiguration());
                //modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
                //modelBuilder.ApplyConfiguration(new CauseConfiguration());

                SeedAdminUser();
                SeedAdminOrganization();

                modelBuilder.Entity<User>()
                .HasData(this.userAdmin);

                modelBuilder.Entity<Organization>()
                .HasData(this.organizationAdmin);
            }
            

            modelBuilder.Entity<User>()
            .HasMany(x => x.Causes)
            .WithMany(x => x.Users)
            .UsingEntity<Dictionary<string, object>>(
            "JoinUserWithCause",
            j => j.HasOne<Cause>().WithMany().OnDelete(DeleteBehavior.Cascade),
            j => j.HasOne<User>().WithMany().OnDelete(DeleteBehavior.ClientCascade));


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

            base.OnModelCreating(modelBuilder);
        }

        //Hard coded data for the Admin role

        void SeedAdminUser()
        {
            var hasher = new PasswordHasher<User>();

            this.userAdmin = new User()
            {
                Id = "deal12856 - c198 - 4129 - b3f3 - b893d8395082",
                FirstName = "User",
                LastName = "Userov",
                Email = "user@mail.com",
                NormalizedEmail = "USER@MAIL.COM",
                UserName = "USERQ",
                NormalizedUserName = "USERQ",
                PhoneNumber = "0888888888",
                BirthDate = new DateTime(2000, 1, 1),
                Causes = new List<Cause>()
            };

            this.userAdmin.PasswordHash = hasher.HashPassword(this.userAdmin, "user123");
        }

        void SeedAdminOrganization()
        {
            this.organizationAdmin = new Organization()
            {
                Id = 1,
                Name = "Admin organization",
                Headquarter = "Sofia, Bulgaria",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.",
                Photos = new List<PhotoOrganization>(),
                Causes = new List<Cause>(),
                UserId = this.userAdmin.Id
            };
        }
    }
}


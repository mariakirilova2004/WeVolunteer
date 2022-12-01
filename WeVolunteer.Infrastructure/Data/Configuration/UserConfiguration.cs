using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Infrastructure.Data.Entities;
using WeVolunteer.Infrastructure.Data.Entities.Account;

namespace WeVolunteer.Infrastructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(CreateUser());
        }

        private User CreateUser()
        {
            var hasher = new PasswordHasher<User>();

            var user = new User()
            {
                Id = "deal12856-c198-4129-b3f3-b893d8395082",
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

            user.PasswordHash = hasher.HashPassword(user, "user123");
            return user;
        }
    }
}

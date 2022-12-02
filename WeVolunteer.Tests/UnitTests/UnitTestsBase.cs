using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Core.Services;
using WeVolunteer.Core.Services.Category;
using WeVolunteer.Core.Services.User;
using WeVolunteer.Infrastructure.Data;
using WeVolunteer.Infrastructure.Data.Entities;
using WeVolunteer.Infrastructure.Data.Entities.Account;
using WeVolunteer.Tests.Mocks;

namespace WeVolunteer.Tests.UnitTests
{
    public class UnitTestsBase
    {
        protected WeVolunteerDbContext context;
        protected IRepository repository;
        protected ICategoryService categoryService;
        protected IUserService userService;

        [OneTimeSetUp]

        public void SetUpBase()
        {
            this.context = DatabaseMock.Instance;
            this.repository = DatabaseMock.Repository;
            this.categoryService = DatabaseMock.CategoryService;
            this.userService = DatabaseMock.UserService;
            this.SeedDabase();
        }

        [OneTimeTearDown]
        public void TearDownBase()
        {
            this.context.Dispose();
        }

        public User User { get; private set; }
        public Organization Organization { get; private set; }

        private void SeedDabase()
        {
            var category1 = new Category()
            {
                Id = 1,
                Name = "Environmental Work",
                Description = "Permaculture Projects, Farming, Ecovillages and Environmental Conservation",

            };

            this.context.Categories.Add(category1);

            var category2 = new Category()
            {
                Id = 2,
                Name = "Animals",
                Description = "Animal Farms, Wildlife Conservation, Animal Rescue and Animal Care"
            };

            this.context.Categories.Add(category2);

            var category3 = new Category()
            {
                Id = 3,
                Name = "Social Impact",
                Description = "Children and Youth NGOs, Education & Teaching, Community Development, Women’s Empowerment"
            };

            this.context.Categories.Add(category3);

            var category4 = new Category()
            {
                Id = 4,
                Name = "Health Care",
                Description = "Health Care, Holistic Centers"
            };

            this.context.Categories.Add(category4);

            var category5 = new Category()
            {
                Id = 5,
                Name = "Tourism",
                Description = "Hostel/Guest House Administration, Digital Marketing, SEO and Web Development"
            };

            this.context.Categories.Add(category5);

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
            this.User =  user;

            this.Organization = new Organization()
            {
                Id = 1,
                Name = "Admin organization",
                Headquarter = "Sofia, Bulgaria",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.",
                Photos = new List<PhotoOrganization>(),
                Causes = new List<Cause>(),
                UserId = "deal12856-c198-4129-b3f3-b893d8395082"
            };

            var cause1 = new Cause()
            {
                Id = 1,
                Name = "Get in the network",
                Place = "Sofia, Bulgaria",
                Time = new DateTime(2001, 1, 1, 10, 0, 0),
                OrganizationId = 1,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                Photos = new List<PhotoCause>(),
                Users = new List<User>(),
                CategoryId = 3
            };

            var cause2 = new Cause()
            {
                Id = 2,
                Name = "Gift giving",
                Place = "Sofia, Bulgaria",
                Time = new DateTime(2001, 2, 1, 10, 0, 0),
                OrganizationId = 1,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                Photos = new List<PhotoCause>(),
                Users = new List<User>(),
                CategoryId = 4
            };

            this.context.Users.Add(this.User);
            this.context.Organizations.Add(this.Organization);
            this.context.Causes.Add(cause1);
            this.context.Causes.Add(cause2);

        }
    }
}

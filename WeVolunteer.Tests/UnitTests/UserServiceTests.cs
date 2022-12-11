using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeVolunteer.Core.Services.User;

namespace WeVolunteer.Tests.UnitTests
{
    [TestFixture]
    public class UserServiceTests : UnitTestsBase
    {
        private IUserService userService;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.userService = new UserService(this.repository);
        }

        [Test]
        public void UserForget_ShouldDeleteUser()
        {
            Assert.IsTrue(this.userService.Forget("proba").IsCompleted);
            this.userService.Forget(this.User.Id);
            Assert.IsTrue(this.context.Users.Find(this.User.Id) == null);
            Assert.IsTrue(this.userService.Forget(this.User.Id).IsCompleted);
        }

        [Test]
        public void EmailExists_ShouldReturnCorrectBoolValue()
        {

            var result1 = this.userService.EmailExists("user@mail.com");
            var result2 = this.userService.EmailExists("user2000@mail.com");

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [Test]
        public void IdExists_ShouldReturnCorrectBoolValue()
        {

            var result1 = this.userService.IdExists(this.User.Id);
            var result2 = this.userService.IdExists("proba");

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [Test]
        public void NameExists_ShouldReturnCorrectBoolValue()
        {

            var result1 = this.userService.NameExists(this.User.UserName);
            var result2 = this.userService.NameExists("Petarski");

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [Test]
        public void All_ShouldReturnCorrectUserCountValue()
        {

            var result = this.userService.All();

            Assert.IsTrue(result.Count() == 1);
            Assert.IsTrue(result.First().Id == "deal12856-c198-4129-b3f3-b893d8395082");
        }
    }
}

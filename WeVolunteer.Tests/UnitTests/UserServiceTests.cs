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
            var result2 = this.userService.IdExists("bdb19aab - d6b3 - 4329 - abd0 - 16a8b1c02f3f");

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
    }
}

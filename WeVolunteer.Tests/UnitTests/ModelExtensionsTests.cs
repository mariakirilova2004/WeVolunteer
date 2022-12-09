using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeVolunteer.Core.Extensions;
using WeVolunteer.Core.Services.Cause;
using WeVolunteer.Core.Services.User;

namespace WeVolunteer.Tests.UnitTests
{
    [TestFixture]
    public class ModelExtensionsTests : UnitTestsBase
    {

        [OneTimeSetUp]
        public void SetUp()
        {
            this.causeService = new CauseService(this.repository, this.organizationService);
        }

        [Test]
        public void GetInformation_ShouldReturnCorrectBoolValue()
        {
            var cause = causeService.CauseDetailsById(3);
            var result = ModelExtensions.GetInformation(cause);

            Assert.AreEqual("Get-in-the-network-2_Sofia-Bulgaria", result);
        }
    }
}

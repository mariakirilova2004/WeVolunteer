using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Core.Services.Organization;

namespace WeVolunteer.Tests.UnitTests
{
    [TestFixture]
    public class OrganizationServiceTests : UnitTestsBase
    {
        private IOrganizationService organizationService;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.organizationService = new OrganizationService(this.repository, this.categoryService);
        }

        [Test]
        public void 
    }
}

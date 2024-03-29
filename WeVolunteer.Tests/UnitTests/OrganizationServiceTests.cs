﻿using NUnit.Framework;
using System.Linq;
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

        //[Test]
        //public void All_ShouldReturnCorrectOrganizations()
        //{
        //    string searchTerm1 = "Sofia";
        //    string searchTerm2 = "Plovdiv";

        //    var result1 = this.organizationService.All(null, searchTerm1, 1, 1).Organizations.FirstOrDefault();
        //    var result2 = this.organizationService.All(null, searchTerm2, 1, 1).Organizations.FirstOrDefault();
        //    var result3 = this.organizationService.All(null, searchTerm1, 1, 1);
        //    var result4 = this.organizationService.All(null, searchTerm1, 2, 1);

        //    Assert.AreEqual(this.Organization.Id, result1.Id);
        //    Assert.AreEqual(null, result2);
        //    Assert.AreEqual(1, result3.TotalOrganizationsCount);
        //    Assert.AreEqual(0, result4.Organizations.Count());
        //}

        [Test]
        public async Task Create_ShouldReturnCorrectOrganizations()
        {

            await this.organizationService.CreateAsync("kspjidshfiugiuygeiuhjnasd", 
                                                       "We Help", 
                                                       "Las Vegas", 
                                                       "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas lectus lacus, malesuada sed leo in, luctus pretium leo. Morbi sed metus ex. Nunc ullamcorper lacinia commodo. Maecenas sit amet accumsan odio, quis varius nisi. Quisque porttitor tempus rhoncus. Nullam fermentum finibus metus, in malesuada quam sagittis sit amet. Duis vel finibus nisl. Nulla id neque sapien. Fusce eget ligula quis nibh convallis volutpat ac at felis. Sed a elit augue. Suspendisse sit amet sagittis arcu. Duis volutpat lorem nibh, vitae convallis nunc sodales eu. Phasellus tristique, metus et ult",
                                                       null);

            Assert.AreEqual(2, this.repository.All<Infrastructure.Data.Entities.Account.Organization>().Count());
            Assert.IsFalse(this.organizationService.CreateAsync("kspjidshfiugiuygeiuhjnasd",
                                                       "We Help",
                                                       "Las Vegas",
                                                       "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas lectus lacus, malesuada sed leo in, luctus pretium leo. Morbi sed metus ex. Nunc ullamcorper lacinia commodo. Maecenas sit amet accumsan odio, quis varius nisi. Quisque porttitor tempus rhoncus. Nullam fermentum finibus metus, in malesuada quam sagittis sit amet. Duis vel finibus nisl. Nulla id neque sapien. Fusce eget ligula quis nibh convallis volutpat ac at felis. Sed a elit augue. Suspendisse sit amet sagittis arcu. Duis volutpat lorem nibh, vitae convallis nunc sodales eu. Phasellus tristique, metus et ult",
                                                       null).IsCanceled);
        }

        //[Test]
        //public async Task CreateAsync_ShouldCreateAndAddOrganizationAsync()
        //{
        //    int initialCount = 1;

        //    await this.organizationService.CreateAsync("bdb19aab-d6b3-4329-abd0-16a8b1c02f3f", "Help us", "Gabrovo, Bulgraia", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris pellentesque, sapien id tristique consequat, est metus placerat nibh, eu dignissim urna lectus suscipit ligula. Duis venenatis nec tortor eget iaculis. In sit amet feugiat leo. Integer pulvinar sapien sit amet ante hendrerit porttitor.", new IFormFile() { this.Organization.Photos.First() });

        //    Assert.IsTrue(this.organizationService.ExistsById("bdb19aab-d6b3-4329-abd0-16a8b1c02f3f"));
        //}

        [Test]
        public void ExistsById_ShouldReturnCorrectBoolValue()
        {
            var result1 = this.organizationService.ExistsById(this.Organization.UserId);
            var result2 = this.organizationService.ExistsById("bdb19aab-d6b3-4329-abd0-16a8b1c02f3f");
            var result3 = this.organizationService.ExistsById(null);

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [Test]
        public void GetOrganizationById_ShouldReturnCorrectOrganization()
        {
            var result1 = this.organizationService.GetOrganizationById(this.Organization.Id).Result;
            var result2 = this.organizationService.GetOrganizationById(12).Result;

            Assert.AreEqual(this.Organization, result1);
            Assert.AreEqual(null, result2);
        }

        [Test]
        public void GetOrganizationByUserId_ShouldReturnCorrectOrganization()
        {
            var result1 = this.organizationService.GetOrganizationByUserId(this.Organization.UserId);
            var result2 = this.organizationService.GetOrganizationByUserId("bdb19aab-d6b3-4329-abd0-16a8b1c02f3f");

            Assert.AreEqual(this.Organization, result1);
            Assert.AreEqual(null, result2);
        }

        [Test]
        public void GetOrganizationCategory_ShouldReturnCorrectCategotyOfOrganization()
        {
            var result = this.organizationService.GetOrganizationCategory(1);

            Assert.AreEqual("Social Impact", result);
        }

        [Test]
        public void GetOrganizationName_ShouldReturnCorrectOrganizationName()
        {
            var result = this.organizationService.GetOrganizationName(this.Organization.UserId);

            Assert.AreEqual(this.Organization.Name, result);
        }

        [Test]
        public void HasCauses_ShouldReturnCorrectBoolValue()
        {
            var result = this.organizationService.HasCauses(this.Organization.Id).Result;

            Assert.IsTrue(result);
        }

        [Test]
        public void GetPhotoOrganizationByOrganizationId_ShouldReturnCorrectPhotoOrganization()
        {
            var result = this.organizationService.GetPhotoOrganizationByOrganizationId(this.Organization.Id);

            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void GetOrganizationNameById_ShouldReturnCorrectOrganizationName()
        {
            var result = this.organizationService.GetOrganizationNameById(this.Organization.Id);

            Assert.AreEqual("Admin organization", result);
        }

        [Test]
        public void NameExists_ShouldReturnCorrectBoolValue ()
        {
            var result1 = this.organizationService.NameExists(this.Organization.Name);
            var result2 = this.organizationService.NameExists("Invalid");

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }
    }
}

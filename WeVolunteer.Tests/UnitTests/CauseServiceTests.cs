using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using WeVolunteer.Core.Services.Cause;

namespace WeVolunteer.Tests.UnitTests
{
    [TestFixture]
    public class CauseServiceTests : UnitTestsBase
    {
        private ICauseService causeService;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.causeService = new CauseService(this.repository, this.organizationService);
        }

        [Test]
        public void All_ShouldReturnCorrectCauses()
        {
            string searchTerm1 = "Sofia";
            string searchTerm2 = "Plovdiv";

            var result1 = this.causeService.All(null, searchTerm1,Core.Models.Cause.CauseSorting.Newest, 1, 1).TotalCausesCount;
            var result2 = this.causeService.All(null, searchTerm2, Core.Models.Cause.CauseSorting.Newest, 1, 1).TotalCausesCount;

            Assert.AreEqual(3, result1);
            Assert.AreEqual(0, result2);
        }

        [Test]
        public async Task UserCauseCreate_ShouldCreateCorrectCauses()
        {
            await this.causeService.CreateAsync(4,
                                                "Proba", 
                                                "Varna", 
                                                System.DateTime.Now.AddYears(1),
                                                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas lectus lacus, malesuada sed leo in, luctus pretium leo. Morbi sed metus ex. Nunc ullamcorper lacinia commodo. Maecenas sit amet accumsan odio, quis varius nisi. Quisque porttitor tempus rhoncus. Nullam fermentum finibus metus, in malesuada quam sagittis sit amet. Duis vel finibus nisl. Nulla id neque sapien. Fusce eget ligula quis nibh convallis volutpat ac at felis. Sed a elit augue. Suspendisse sit amet sagittis arcu.",
                                                null,
                                                2);

            Assert.AreEqual(3, this.repository.All<Infrastructure.Data.Entities.Cause>().Count());
        }

        [Test]
        public void Edit_ShouldEditCorrectCauses()
        {
            this.causeService.Edit(2,
                                   "Proba PROBA",
                                   "Varna",
                                   System.DateTime.Now.AddYears(1),
                                   "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas lectus lacus, malesuada sed leo in, luctus pretium leo. Morbi sed metus ex. Nunc ullamcorper lacinia commodo. Maecenas sit amet accumsan odio, quis varius nisi. Quisque porttitor tempus rhoncus. Nullam fermentum finibus metus, in malesuada quam sagittis sit amet. Duis vel finibus nisl. Nulla id neque sapien. Fusce eget ligula quis nibh convallis volutpat ac at felis. Sed a elit augue. Suspendisse sit amet sagittis arcu.",
                                   null,
                                   2);

            Assert.AreEqual(2, this.repository.All<Infrastructure.Data.Entities.Cause>().Count());
            Assert.IsTrue(this.repository.GetByIdAsync<Infrastructure.Data.Entities.Cause>(2) != null);
        }

        [Test]
        public void BecomePartAsync_ShouldReturnCorrectCauses()
        {
            this.causeService.BecomePartAsync(1, this.User.Id);

            Assert.IsTrue(this.User.Causes.Any(x => x.Id == 1));
        }

        [Test]
        public void CauseDeatilsById_ShouldReturnCorrectCauses()
        {
            var result = this.causeService.Mine("", "", Core.Models.Cause.CauseSorting.Newest, 1, 1, this.User.Id).TotalCausesCount;

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Mine_ShouldReturnCorrectCauses()
        {
            var result = this.causeService.Mine("", "", Core.Models.Cause.CauseSorting.Newest, 1, 1, this.User.Id).TotalCausesCount;

            Assert.AreEqual(2, result);
        }

        [Test]
        public void CauseDetailsById_ShouldReturnCorrectCauses()
        {
            var result = this.causeService.CauseDetailsById(3);

            Assert.AreEqual(3, result.Id);
            Assert.AreEqual("Get in the network 2", result.Name);
            Assert.AreEqual("Sofia, Bulgaria", result.Place);
            Assert.AreEqual("1/1/2001", result.Time.ToShortDateString());
            Assert.AreEqual("Admin organization", result.OrganizationName);
            Assert.AreEqual("Lorem ipsum dolor sit amet, consectetur adipiscing elit.", result.Description);
            Assert.AreEqual(0, result.Users.Count);
            Assert.AreEqual("Social Impact", result.CategoryName);
        }

        [Test]
        public void Exists_ShouldReturnCorrectBoolValue()
        {
            var result1 = this.causeService.Exists(1).Result;
            var result2 = this.causeService.Exists(15).Result;

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [Test]
        public void GetPhotosByCauseId_ShouldReturnCorrectPhotosCause()
        {
            var result = this.causeService.GetPhotosByCauseId(1).Count;

            Assert.AreEqual(1, result);
        }

        [Test]
        public void IsMadeBy_ShouldReturnCorrectBoolValue()
        {
            var result1 = this.causeService.IsMadeBy(1, this.User.Id).Result;
            var result2 = this.causeService.IsMadeBy(1, "bdb19aab-d6b3-4329-abd0-16a8b1c02f3f").Result;

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }


        [Test]
        public void CauseWithNameExists_ShouldReturnCorrectBoolValue()
        {
            var result1 = this.causeService.CauseWithNameExists("Get in the network 2", this.User.Id);
            var result2 = this.causeService.CauseWithNameExists("Help us", this.User.Id);

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [Test]
        public void Delete_ShouldReturnLowerCountValue()
        {
            int initialValue = 3;

            this.causeService.Delete(2);

            var causesCount = this.causeService.All("", "", Core.Models.Cause.CauseSorting.Newest, 1, 1).TotalCausesCount;

            Assert.AreEqual(initialValue - 1, causesCount);
        }

        [Test]
        public void Cancel_ShouldReturnLowerCountValueForVolunteersInCause()
        {
            int initialValue = 1;

            this.causeService.Cancel(3, this.User.Id);

            var causesCount = this.causeService.CauseDetailsById(3).Users.Count;

            Assert.AreEqual(initialValue - 1, causesCount);
        }

        [Test]
        public void IsAlreadyPart_ShouldReturnLowerCountValueForVolunteersInCause()
        {
            var result = this.causeService.IsAlreadyPart(this.User.Id, 2);

            Assert.IsFalse(result);
        }
    }
}

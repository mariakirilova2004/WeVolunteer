using NUnit.Framework;
using System.Linq;
using WeVolunteer.Core.Services.Category;
using WeVolunteer.Core.Services.Organization;

namespace WeVolunteer.Tests.UnitTests
{
    [TestFixture]
    public class CategoryServiceTests : UnitTestsBase
    {
        private ICategoryService categoryService;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.categoryService = new CategoryService(this.repository);
        }

        [Test]
        public void GetAll_ShouldReturnCorrectNumberCategories()
        {
            var result = this.categoryService.GetAll().Count;

            Assert.AreEqual(5, result);
        }

        [Test]
        public void GetCategoryIdByCategoryName_ShouldReturnCorrectIdValues()
        {
            var result1 = this.categoryService.GetCategoryIdByCategoryName("Social Impact");
            var result2 = this.categoryService.GetCategoryIdByCategoryName("Health Care");

            Assert.AreEqual(3, result1);
            Assert.AreEqual(4, result2);
        }

        [Test]
        public void CategoryExists_ShouldReturnCorrectBoolValue()
        {
            var result1 = this.categoryService.CategoryExists(1);
            var result2 = this.categoryService.CategoryExists(6);

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [Test]
        public void AllCategoriesNames_ShouldReturnCorrectCategoriesNames()
        {
            var result = this.categoryService.AllCategoriesNames();

            Assert.AreEqual("Environmental Work", result.First());
            Assert.AreEqual(5, result.Count());
        }

        [Test]
        public void MineCategoriesNames_ShouldReturnCorrectOrganizations()
        {
            var result = this.categoryService.MineCategoriesNames(this.User.Id);

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Social Impact", result.First());
            Assert.AreEqual("Health Care", result.Last());
        }
    }
}

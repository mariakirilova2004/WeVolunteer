using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeVolunteer.Extensions;
using WeVolunteer.Core.Services.Organization;
using WeVolunteer.Core.Models.Organization;
using WeVolunteer.Core.Constants;
using WeVolunteer.Core.Services.Category;
using WeVolunteer.Core.Services.User;

namespace WeVolunteer.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize]
    public class OrganizationController : Controller
    {
        private readonly IOrganizationService organizationService;
        private readonly ICategoryService categoryService;
        private readonly IUserService userService;
        private readonly ILogger logger;

        public OrganizationController(IOrganizationService _organizationService, 
                                      ICategoryService _categoryService,
                                      IUserService _userService,
                                      ILogger<OrganizationController> _logger)
        {
            this.organizationService = _organizationService;
            this.categoryService = _categoryService;
            this.userService = _userService;
            this.logger = _logger;
        }

        [HttpGet]
        public IActionResult Become()
        {
            if (this.organizationService.ExistsById(this.User.Id()))
            {
                TempData[MessageConstant.WarningMessage] = "You are already an organization!";
                this.logger.LogInformation("User {0} tried to become organization again!", this.User.Id());
                return RedirectToAction(nameof(CauseController.All), "Cause");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeOrganizationFormModel model)
        {
            var userId = this.User.Id();

            if (this.organizationService.ExistsById(userId))
            {
                TempData[MessageConstant.WarningMessage] = "You are already an organization!";
                this.logger.LogInformation("User {0} tried to become organization again!", this.User.Id());
                return RedirectToAction(nameof(CauseController.All), "Cause");
            }

            if (this.organizationService.NameExists(model.Name))
            {
                TempData[MessageConstant.ErrorMessage] = "Organization with such name already exists. Enter another one.";
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Invalid registration of organization";
                return View(model);
            }

            try
            {
                await this.organizationService.CreateAsync(userId,
                                            model.Name,
                                            model.Headquarter,
                                            model.Description,
                                            model.Image);
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Unsuccessfully becoming an organization";
            }
            
            TempData[MessageConstant.SuccessMessage] = "You have become an organization.";

            return RedirectToAction(nameof(CauseController.All), "Cause");
        }

        [AllowAnonymous]
        public IActionResult All([FromQuery] AllOrganizationsQueryModel query)
        {
            var queryResult = this.organizationService.All(
                query.Category,
                query.SearchTerm,
                query.CurrentPage,
                AllOrganizationsQueryModel.OrganizationsPerPage);

            query.TotalOrganizationsCount = queryResult.TotalOrganizationsCount;
            query.Organizations = queryResult.Organizations;

            var organizationCategories = this.categoryService.AllCategoriesNames();
            query.Categories = organizationCategories;

            return View(query);
        }
    }
}

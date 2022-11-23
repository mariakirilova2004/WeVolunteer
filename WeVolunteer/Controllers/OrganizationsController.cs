using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeVolunteer.Extensions;
using WeVolunteer.Core.Services.Organization;
using WeVolunteer.Core.Models.Organization;
using WeVolunteer.Core.Constants;

namespace WeVolunteer.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize]
    public class OrganizationsController : Controller
    {
        private readonly IOrganizationService organizationService;

        public OrganizationsController(IOrganizationService _organizationService)
        {
            this.organizationService = _organizationService;
        }

        public IActionResult Become()
        {
            if (this.organizationService.ExistsById(this.User.Id()))
            {
                TempData[MessageConstant.WarningMessage] = "You are already an organization!";

                return RedirectToAction(nameof(CausesController.All), "Causes");
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

                return RedirectToAction(nameof(CausesController.All), "Causes");
            }

            if (this.organizationService.UserWithNameExists(model.Name))
            {
                TempData[MessageConstant.ErrorMessage] = "Organization with such name already exists. Enter another one.";
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Invalid registration of organization";
                return View(model);
            }

            await this.organizationService.CreateAsync(userId,
                                            model.Name,
                                            model.Headquarter,
                                            model.Description);

            TempData[MessageConstant.SuccessMessage] = "You have become an organization.";

            return RedirectToAction(nameof(CausesController.All), "Causes");
        }

        public IActionResult All([FromQuery] AllOrganizationsQueryModel query)
        {
            var queryResult = this.organizationService.All(
                query.Category,
                query.SearchTerm,
                query.CurrentPage,
                AllOrganizationsQueryModel.OrganizationsPerPage);

            query.TotalOrganizationsCount = queryResult.TotalOrganizationsCount;
            query.Organizations = queryResult.Organizations;

            var organizationCategories = this.organizationService.AllCategoriesNames();
            query.Categories = organizationCategories;

            return View(query);
        }
    }
}

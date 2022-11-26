using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeVolunteer.Core.Models.Cause;
using WeVolunteer.Core.Services.Cause;
using WeVolunteer.Core.Extensions;
using WeVolunteer.Core.Constants;
using WeVolunteer.Extensions;
using WeVolunteer.Core.Services.User;
using WeVolunteer.Core.Services.Organization;
using WeVolunteer.Core.Services.Category;

namespace WeVolunteer.Controllers
{
    [AutoValidateAntiforgeryToken]
    [AllowAnonymous]
    public class CauseController : Controller
    {
        private readonly ICauseService causeService;
        private readonly IUserService userService;
        private readonly IOrganizationService organizationService;
        private readonly ICategoryService categoryService;

        public CauseController(ICauseService _causeService, 
                               IUserService _userService, 
                               IOrganizationService _organizationService,
                               ICategoryService _categoryService)
        {
            this.causeService = _causeService;
            this.userService = _userService;
            this.organizationService = _organizationService;
            this.categoryService = _categoryService;
        }
        public IActionResult All([FromQuery] AllCausesQueryModel query)
        {
            var queryResult = this.causeService.All(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllCausesQueryModel.CausesPerPage);

            query.TotalCausesCount = queryResult.TotalCausesCount;
            query.Causes = queryResult.Causes;

            var causeCategories = this.causeService.AllCategoriesNames();
            query.Categories = causeCategories;

            return View(query);
        }

        public async Task<IActionResult> Details(int id, string information)
        {
            if (!await this.causeService.Exists(id))
            {
                TempData[MessageConstant.WarningMessage] = "There is no such cause!";
                return RedirectToAction(nameof(All));
            }

            var causeModel = this.causeService.CauseDeatilsById(id);

            if (information != causeModel.GetInformation())
            {
                TempData[MessageConstant.WarningMessage] = "There is no such cause!";
                return RedirectToAction(nameof(All));
            }

            return View(causeModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (!this.organizationService.ExistsById(this.User.Id()))
            {
                TempData[MessageConstant.WarningMessage] = "You should become an organization!";
                return RedirectToAction("Become", "Organization");
            }

            AddCauseFormModel model = new AddCauseFormModel { Categories = categoryService.GetAll() };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCauseFormModel model)
        {
            var userId = this.User.Id();

            model.Categories = categoryService.GetAll();

            if (!this.organizationService.ExistsById(userId))
            {
                TempData[MessageConstant.WarningMessage] = "You should become an organization!";
                return RedirectToAction("Become", "Organization");
            }

            if (this.causeService.CauseWithNameExists(model.Name, userId))
            {
                TempData[MessageConstant.ErrorMessage] = "Cause with such name from your organization already exists. Enter another one.";
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Invalid registration of a new cause";
                return View(model);
            }

            await this.causeService.CreateAsync(this.organizationService.GetOrganizationByUserId(userId).Id,
                                            model.Name,
                                            model.Place,
                                            model.Time,
                                            model.Description,
                                            model.Image,
                                            model.CategoryId);

            TempData[MessageConstant.SuccessMessage] = "You have successfully made a cause!";

            return RedirectToAction(nameof(CauseController.Mine), "Cause");
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> TakePart(int id)
        {
            if (await this.causeService.IsMadeBy(id, this.User.Id()))
            {
                TempData[MessageConstant.WarningMessage] = "You cannot take part in your own cause!";
                return RedirectToAction(nameof(All));
            }

            if (! await this.causeService.Exists(id))
            {
                TempData[MessageConstant.WarningMessage] = "There is no such cause!";
                return RedirectToAction(nameof(All));
            }

            if (!this.userService.IdExists(this.User.Id()))
            {
                TempData[MessageConstant.WarningMessage] = "You should log into your account!";
                return RedirectToAction("Login", "User");
            }

            await this.causeService.BecomePartAsync(id, this.User.Id());

            return RedirectToAction(nameof(All));
        
        }

        [Authorize]
        public IActionResult Mine([FromQuery] MineCausesQueryModel query)
        {

            var userId = this.User.Id();

            if (this.organizationService.ExistsById(userId))
            {
                var queryResult = this.causeService.Mine(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                MineCausesQueryModel.CausesPerPage,
                userId);

                query.TotalCausesCount = queryResult.TotalCausesCount;
                query.Causes = queryResult.Causes;

                var causeCategories = this.causeService.MineCategoriesNames(userId);
                query.Categories = causeCategories;

                return View(query);
            }
            else
            {
                TempData[MessageConstant.WarningMessage] = "You should become an organization!";
                return RedirectToAction("Become", "Organization");
            }
        }
    }
}

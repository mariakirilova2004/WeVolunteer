﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeVolunteer.Core.Models.Cause;
using WeVolunteer.Core.Services.Cause;
using WeVolunteer.Core.Extensions;
using WeVolunteer.Core.Constants;
using WeVolunteer.Extensions;
using WeVolunteer.Core.Services.User;
using WeVolunteer.Core.Services.Organization;
using WeVolunteer.Core.Services.Category;
using System.Globalization;

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
        private readonly ILogger logger;

        public CauseController(ICauseService _causeService, 
                               IUserService _userService, 
                               IOrganizationService _organizationService,
                               ICategoryService _categoryService,
                               ILogger<CauseController> _logger)
        {
            this.causeService = _causeService;
            this.userService = _userService;
            this.organizationService = _organizationService;
            this.categoryService = _categoryService;
            this.logger = _logger;
        }

        [ResponseCache(Duration = 60)]
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

            var causeCategories = this.categoryService.AllCategoriesNames();
            query.Categories = causeCategories;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            if (!await this.causeService.Exists(id))
            {
                TempData[MessageConstant.WarningMessage] = "There is no such cause!";
                this.logger.LogInformation("User {0} tried to access invalid cause!", this.User.Id());
                return RedirectToAction(nameof(All));
            }

            var causeModel = this.causeService.CauseDetailsById(id);

            if (information != causeModel.GetInformation())
            {
                TempData[MessageConstant.WarningMessage] = "There is no such cause!";
                this.logger.LogInformation("User {0} tried to access invalid cause!", this.User.Id());
                return RedirectToAction(nameof(All));
            }

            return View(causeModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            if (!this.organizationService.ExistsById(this.User.Id()) && !this.User.IsAdmin())
            {
                TempData[MessageConstant.WarningMessage] = "You should become an organization!";
                this.logger.LogInformation("User {0} tried to add cause without being an organization!", this.User.Id());
                return RedirectToAction("Become", "Organization");
            }

            AddCauseFormModel model = new AddCauseFormModel { Categories = categoryService.GetAll() };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddCauseFormModel model)
        {
            var userId = this.User.Id();

            model.Categories = categoryService.GetAll();

            if (!this.organizationService.ExistsById(userId) && !this.User.IsAdmin())
            {
                TempData[MessageConstant.WarningMessage] = "You should become an organization!";
                this.logger.LogInformation("User {0} tried to add cause without being an organization!", this.User.Id());
                return RedirectToAction("Become", "Organization");
            }

            if (this.causeService.CauseWithNameExists(model.Name, userId) && !this.User.IsAdmin())
            {
                TempData[MessageConstant.ErrorMessage] = "Cause with such name from your organization already exists. Enter another one.";
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Invalid registration of a new cause";
                return View(model);
            }

            try
            {
                await this.causeService.CreateAsync(this.organizationService.GetOrganizationByUserId(userId).Id,
                                            model.Name,
                                            model.Place,
                                            model.Time,
                                            model.Description,
                                            model.Image,
                                            model.CategoryId);
            }
            catch (Exception)
            {
                this.logger.LogInformation("User {0} did not manage to create cause!", this.User.Id());
                TempData[MessageConstant.ErrorMessage] = "Unsuccessful adding of a new cause";
            }
            

            TempData[MessageConstant.SuccessMessage] = "You have successfully made a cause!";

            return RedirectToAction(nameof(CauseController.Mine), "Cause");
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> TakePart(int id)
        {
            if (await this.causeService.IsMadeBy(id, this.User.Id()) && !this.User.IsAdmin())
            {
                TempData[MessageConstant.WarningMessage] = "You cannot take part in your own cause!";
                return RedirectToAction(nameof(All));
            }

            if (! await this.causeService.Exists(id))
            {
                TempData[MessageConstant.WarningMessage] = "There is no such cause!";
                this.logger.LogInformation("User {0} tried to access invalid cause!", this.User.Id());
                return RedirectToAction(nameof(All));
            }

            if (!this.userService.IdExists(this.User.Id()) && !this.User.IsAdmin())
            {
                TempData[MessageConstant.WarningMessage] = "You should log into your account!";
                return RedirectToAction("Login", "User");
            }

            try
            {
                await this.causeService.BecomePartAsync(id, this.User.Id());
            }
            catch (Exception ex)
            {
                this.logger.LogInformation("{0} did not manage to take part!", this.User.Id());
                TempData[MessageConstant.WarningMessage] = "Unsuccessfully taking part";
            }
            

            return RedirectToAction(nameof(All));
        
        }

        [Authorize]
        [HttpGet]
        public IActionResult Mine([FromQuery] MineCausesQueryModel query)
        {

            var userId = this.User.Id();

            if (this.organizationService.ExistsById(userId) || this.User.IsAdmin())
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

                var causeCategories = this.categoryService.MineCategoriesNames(userId);
                query.Categories = causeCategories;

                return View(query);
            }
            else
            {
                TempData[MessageConstant.WarningMessage] = "You should become an organization!";
                return RedirectToAction("Become", "Organization");
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.causeService.Exists(id))
            {
                TempData[MessageConstant.WarningMessage] = "There is no such cause!";
                this.logger.LogInformation("User {0} tried to access invalid cause!", this.User.Id());
                return RedirectToAction(nameof(All));
            }

            if (! await this.causeService.IsMadeBy(id, this.User.Id()) && !this.User.IsAdmin())
            {
                TempData[MessageConstant.WarningMessage] = "You do not have access to that cause!";
                this.logger.LogInformation("User {0} tried to access cause without having permission to!", this.User.Id());
                return RedirectToAction("Mine", "Cause");
            }

            var cause = this.causeService.CauseDetailsById(id);
            var causeCategoryId = this.categoryService.GetCategoryIdByCategoryName(cause.CategoryName);

            var causeModel = new AddCauseFormModel()
            {
                Name = cause.Name,
                Place = cause.Place,
                Time = cause.Time,
                Description = cause.Description,
                Image = null,
                CategoryId = causeCategoryId,
                Categories = this.categoryService.GetAll()
            };

            return View(causeModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult>  Edit(int id, AddCauseFormModel model)
        {
            if (!await this.causeService.Exists(id))
            {
                TempData[MessageConstant.WarningMessage] = "There is no such cause!";
                this.logger.LogInformation("User {0} tried to access invalid cause!", this.User.Id());
                return RedirectToAction(nameof(All));
            }

            if (!await this.causeService.IsMadeBy(id, this.User.Id()) && !this.User.IsAdmin())
            {
                TempData[MessageConstant.WarningMessage] = "You do not have access to that cause!";
                this.logger.LogInformation("User {0} tried to access cause without having permission to!", this.User.Id());
                return RedirectToAction("Mine", "Cause");
            }

            if (!this.categoryService.CategoryExists(model.CategoryId))
            {
                TempData[MessageConstant.ErrorMessage] = "Category does not exists!";
                model.Categories = this.categoryService.GetAll();
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                model.Categories = this.categoryService.GetAll();
                TempData[MessageConstant.ErrorMessage] = "Invalid edit!";
                return View(model);
            }

            try
            {
                await this.causeService.Edit(id, model.Name, model.Place,
                                   model.Time, model.Description,
                                   model.Image, model.CategoryId);
            }
            catch (Exception)
            {
                this.logger.LogInformation("Cause {0} did not manage to be edited!", id);
                TempData[MessageConstant.ErrorMessage] = "Unsuccessful editing of a cause";
            }

            return RedirectToAction(nameof(Details), new { id = id, information = model.GetInformation() });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.causeService.Exists(id))
            {
                TempData[MessageConstant.WarningMessage] = "There is no such cause!";
                this.logger.LogInformation("User {0} tried to access invalid cause!", this.User.Id());
                return RedirectToAction(nameof(All));
            }

            if (!await this.causeService.IsMadeBy(id, this.User.Id()) && !this.User.IsAdmin())
            {
                TempData[MessageConstant.WarningMessage] = "You do not have access to that cause!";
                this.logger.LogInformation("User {0} tried to access cause without having permission to!", this.User.Id());
                return RedirectToAction("Mine", "Cause");
            }

            var cause = this.causeService.CauseDetailsById(id);


            return View(cause);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(CauseDetailsViewModel model)
        {
            if (!await this.causeService.Exists(model.Id))
            {
                TempData[MessageConstant.WarningMessage] = "There is no such cause!";
                this.logger.LogInformation("User {0} tried to access invalid cause!", this.User.Id());
                return RedirectToAction(nameof(All));
            }

            if (!await this.causeService.IsMadeBy(model.Id, this.User.Id()) && !this.User.IsAdmin())
            {
                TempData[MessageConstant.WarningMessage] = "You do not have access to that cause!";
                this.logger.LogInformation("User {0} tried to access cause without having permission to!", this.User.Id());
                return RedirectToAction("Mine", "Cause");
            }

            try
            {
                 await this.causeService.Delete(model.Id);
            }
            catch (Exception)
            {
                this.logger.LogInformation("Cause {0} did not manage to be deleted!", model.Id);
                TempData[MessageConstant.ErrorMessage] = "Unsuccessful delete of a cause";
            }

            return RedirectToAction(nameof(Mine));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Cancel(CauseDetailsViewModel model)
        {
            if (!await this.causeService.Exists(model.Id))
            {
                TempData[MessageConstant.WarningMessage] = "There is no such cause!";
                this.logger.LogInformation("User {0} tried to access invalid cause!", this.User.Id());
                return RedirectToAction(nameof(All));
            }

            if (!this.causeService.IsAlreadyPart(this.User.Id(), model.Id))
            {
                TempData[MessageConstant.WarningMessage] = "You are not part of this cause!";
                return RedirectToAction(nameof(Details), new { id = model.Id, information = model.GetInformation() });
            }

            try
            {
                await this.causeService.Cancel(model.Id, this.User.Id());
            }
            catch (Exception)
            {
                this.logger.LogInformation("{0} did not cancel participation in a cause!", this.User.Id());
                TempData[MessageConstant.ErrorMessage] = "Unsuccessful cancelation of a participation";
            }

            return RedirectToAction(nameof(All));
        }
    }
}

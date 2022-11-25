using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeVolunteer.Core.Models.Cause;
using WeVolunteer.Core.Services.Cause;
using WeVolunteer.Core.Extensions;
using WeVolunteer.Core.Constants;
using WeVolunteer.Extensions;
using WeVolunteer.Core.Services.User;

namespace WeVolunteer.Controllers
{
    [AutoValidateAntiforgeryToken]
    [AllowAnonymous]
    public class CauseController : Controller
    {
        private readonly ICauseService causeService;
        private readonly IUserService userService;

        public CauseController(ICauseService _causeService, IUserService _userService)
        {
            this.causeService = _causeService;
            this.userService = _userService;
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
    }
}

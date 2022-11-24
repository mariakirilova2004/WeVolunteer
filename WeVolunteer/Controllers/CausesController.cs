using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeVolunteer.Core.Models.Cause;
using WeVolunteer.Core.Services.Cause;
using WeVolunteer.Core.Extensions;
using WeVolunteer.Core.Constants;
using WeVolunteer.Extensions;

namespace WeVolunteer.Controllers
{
    [AutoValidateAntiforgeryToken]
    [AllowAnonymous]
    public class CausesController : Controller
    {
        private readonly ICauseService causeService;

        public CausesController(ICauseService _causeService)
        {
            this.causeService = _causeService;
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

        public IActionResult Details(int id, string information)
        {
            if (!this.causeService.Exists(id))
            {
                TempData[MessageConstant.WarningMessage] = "There is not such cause!";
                return RedirectToAction(nameof(All));
            }

            var causeModel = this.causeService.CauseDeatilsById(id);

            if (information != causeModel.GetInformation())
            {
                TempData[MessageConstant.WarningMessage] = "There is not such cause!";
                return RedirectToAction(nameof(All));
            }

            return View(causeModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Rent(int id)
        {
            if (!this.causeService.Exists(id))
            {
                return BadRequest();
            }

            //if (this.causeService.ExistsById(this.User.Id()))
            //{
            //    return Unauthorized();
            //}

            //this.causeService.Rent(id, this.User.Id());

            return RedirectToAction(nameof(All));
        }
    }
}

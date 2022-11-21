using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeVolunteer.Core.Models.Cause;
using WeVolunteer.Core.Services.Cause;

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
    }
}

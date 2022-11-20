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
        public IActionResult All([FromQuery] List<CauseAllViewModel> listOfCauses)
        {
            var result = this.causeService.GetAllCauses();

            return View(result);
        }
    }
}

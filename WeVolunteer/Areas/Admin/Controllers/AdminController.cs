using Microsoft.AspNetCore.Mvc;

namespace WeVolunteer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

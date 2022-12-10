using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WeVolunteer.Controllers
{
    [AllowAnonymous]
    public class WeController : Controller
    {
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }
    }
}

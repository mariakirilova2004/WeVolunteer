using Microsoft.AspNetCore.Mvc;
using WeVolunteer.Core.Services.User;

namespace WeVolunteer.Areas.Admin.Controllers
{
    
    public class UserController : AdminController
    {
        private readonly IUserService users;
        public UserController(IUserService users)
        {
            this.users = users;
        }

        [Route("Admin/User/All")]
        public IActionResult All()
        {
            var users = this.users.All();
            return View(users);
        }
    }
}

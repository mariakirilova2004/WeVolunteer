﻿using Microsoft.AspNetCore.Mvc;

namespace WeVolunteer.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using ImageUpload.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImageUpload.Controllers;

public class UserController : Controller
{
    public UserController(UserContext userContext)
    {
        UserContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
    }

    public UserContext UserContext { get; }

    public IActionResult Index(int id)
    {
        var user = UserContext.Users.Single(user => user.Id == id);

        var viewModel = new UserDisplayViewModel { Name = user.Name };
        viewModel.Picture = Convert.ToBase64String(user.Picture);
        viewModel.PictureFormat = user.PictureFormat;

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Profile()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Profile(UserViewModel userViewModel)
    {
        if (userViewModel is null)
        {
            throw new ArgumentNullException(nameof(userViewModel));
        }

        if (!ModelState.IsValid)
        {
            return View();

        }

        var user = new User
        {
            Name = userViewModel.Name,

            PictureFormat = userViewModel.Picture.ContentType
        };

        var memoryStream = new MemoryStream();
        userViewModel.Picture.CopyTo(memoryStream);
        user.Picture = memoryStream.ToArray();

        UserContext.Add(user);
        UserContext.SaveChanges();

        return RedirectToAction("Index", new { Id = user.Id});
    }
}

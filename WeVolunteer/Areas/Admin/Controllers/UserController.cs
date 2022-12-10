using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WeVolunteer.Core.Models.User;
using WeVolunteer.Core.Services.User;

namespace WeVolunteer.Areas.Admin.Controllers
{
    
    public class UserController : AdminController
    {
        private readonly IUserService users;
        private readonly IMemoryCache cache;
        public UserController(IUserService _users,
                              IMemoryCache _cache)
        {
            this.users = _users;
            this.cache = _cache;
        }

        [Route("Admin/User/All")]
        public IActionResult All()
        {
            var users = this.cache.Get<IEnumerable<UserServiceModel>>("UsersCacheKey");
            if(users == null)
            {
                users = this.users.All();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                this.cache.Set("UsersCacheKey", users, cacheOptions);
            }
            return View(users);
        }
    }
}

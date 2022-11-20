using Microsoft.EntityFrameworkCore;
using WeVolunteer.Core.Services;
using WeVolunteer.Core.Services.Cause;
using WeVolunteer.Core.Services.User;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WeVolunteerServiceCollectionExtension
    {
        public static IServiceCollection AddWeVolunteerServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ICauseService, CauseService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}

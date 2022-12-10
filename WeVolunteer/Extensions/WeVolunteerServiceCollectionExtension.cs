using Microsoft.EntityFrameworkCore;
using WeVolunteer.Controllers;
using WeVolunteer.Core.Services;
using WeVolunteer.Core.Services.Category;
using WeVolunteer.Core.Services.Cause;
using WeVolunteer.Core.Services.Organization;
using WeVolunteer.Core.Services.User;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WeVolunteerServiceCollectionExtension
    {
        public static IServiceCollection AddWeVolunteerServices(this IServiceCollection services)
        {
            services.AddScoped<ILogger, Logger<UserController>>();
            services.AddScoped<ILogger, Logger<CauseController>>();
            services.AddScoped<ILogger, Logger<OrganizationController>>();
            services.AddScoped<ILogger, Logger<CauseService>>();
            services.AddScoped<ILogger, Logger<OrganizationService>>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ICauseService, CauseService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}

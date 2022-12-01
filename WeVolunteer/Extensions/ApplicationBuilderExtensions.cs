﻿using Microsoft.AspNetCore.Identity;
using WeVolunteer.Infrastructure.Data.Entities.Account;

namespace WeVolunteer.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var services = scopedServices.ServiceProvider;

            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync("Admin"))
                {
                    return;
                }

                var role = new IdentityRole { Name = "Admin" };

                await roleManager.CreateAsync(role);

                var admin = await userManager.FindByEmailAsync("user@mail.com");
                await userManager.AddToRoleAsync(admin, role.Name);
            })
            .GetAwaiter()
            .GetResult();

            return app;
        }
    }
}

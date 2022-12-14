using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WeVolunteer.Infrastructure.Data.Entities.Account;
using WeVolunteer.Infrastructure.Data;
using WeVolunteer.ModelBinders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using WeVolunteer.Core.Services;
using WeVolunteer.Core.Services.Cause;
using WeVolunteer.Core.Services.User;
using WeVolunteer.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WeVolunteerDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddWeVolunteerServices();

builder.Services.AddResponseCaching();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:RequireConfirmedAccount");
    options.SignIn.RequireConfirmedEmail = builder.Configuration.GetValue<bool>("Identity:RequireConfirmedEmail"); ;
    options.SignIn.RequireConfirmedPhoneNumber = builder.Configuration.GetValue<bool>("Identity:RequireConfirmedPhoneNumber"); ;
    options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:RequiredLength"); ;
    options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:RequireNonAlphanumeric"); ;
    options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:RequireUppercase"); ;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<WeVolunteerDbContext>();


builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
        options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
    });

builder.Services.AddAuthentication()
    .AddFacebook(options =>
    {
        options.AppId = "804716717426485";
        options.AppSecret = "bf1b20a12e4df3608bbf147388927945";
    });

builder.Services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = "/User/Login";
        options.LogoutPath = "/User/Logout";
    });

var app = builder.Build();

app.SeedAdmin();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "House Details",
//        pattern: "/Houses/Details/{id}/{information}",
//        defaults: new { Controller = "Houses", Action = "Details" });

//    app.MapDefaultControllerRoute();
//    app.MapRazorPages();
//});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "Cause Details",
        pattern: "/Cause/Details/{id}/{information}",
        defaults: new { Controller = "Cause", Action = "Details" });

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();
});

app.UseResponseCaching();

app.Run();

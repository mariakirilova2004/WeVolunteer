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

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WeVolunteerDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddWeVolunteerServices();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:RequireConfirmedAccount");
    options.SignIn.RequireConfirmedEmail = builder.Configuration.GetValue<bool>("Identity:RequireConfirmedEmail"); ;
    options.SignIn.RequireConfirmedPhoneNumber = builder.Configuration.GetValue<bool>("Identity:RequireConfirmedPhoneNumber"); ;
    options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:RequiredLength"); ;
    options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:RequireNonAlphanumeric"); ;
})
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

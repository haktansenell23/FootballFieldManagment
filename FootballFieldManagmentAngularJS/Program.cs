using Autofac;
using Autofac.Extensions.DependencyInjection;
using FootballFieldManagment.Core.Entities;
using FootballFieldManagment.Repository;
using FootballFieldManagmentAngularJS.Cache;
using FootballFieldManagmentAngularJS.DI;
using FootballFieldManagmentAngularJS.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Identity.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<RedisService>(sp =>
{
    return new RedisService(builder.Configuration["Redis:connectionString"]);
});





builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.Cookie = new CookieBuilder
    {
        Name = "FMSCookie",
        HttpOnly = false,
        SameSite = SameSiteMode.Lax,
        SecurePolicy = CookieSecurePolicy.Always,
    };
    options.LoginPath = new PathString("/Home/Index");
    options.AccessDeniedPath = new PathString("/Home/Index"); 
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
});
builder.Services.Configure<RapidApi>(builder.Configuration.GetSection("RapidApi"));

//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(30);
//    options.Cookie.Name = "";
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = false;
//    //options.Cookie.SameSite = SameSiteMode.None;
//    //options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
//});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<AppDbContext>();


builder.Services.Configure<IdentityOptions>(options =>
{

    options.Password.RequireDigit = false;  
    options.Password.RequireUppercase = false;  
    options.Password.RequireLowercase = false;  
    options.Password.RequireNonAlphanumeric = true;  
    options.Password.RequiredLength = 10;
    //options.Lockout.AllowedForNewUsers = true;

});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

var profileImages = builder.Configuration["userFiles:userProfileImages"];

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(profileImages)),
   RequestPath = "/Profile"
});



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Main}/{action=Index}");

app.MapControllerRoute(
    name: "SignUp",
    pattern: "{controller=Home}/{action=SignUp})");

app.Run();

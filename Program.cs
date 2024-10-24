using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HRMS.Areas.HRMS.Models;
using core.Areas.Auth.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure PostgreSQL with Entity Framework Core
builder.Services.AddDbContext<HRMSContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection")));

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AuthPostgreSqlConnection")));

// Add Identity services
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders(); // Add this to enable token generation for features like password resets

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/Auth/Login"; // Set the path for the login page
    options.AccessDeniedPath = "/Auth/Auth/Login"; // Redirect if access is denied
});

// Add authorization
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable authentication middleware
app.UseAuthentication();  // This must be added before UseAuthorization
app.UseAuthorization();

// Map default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map area routes
app.MapControllerRoute(
    name: "areaRoute",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "authRoute",
    pattern: "auth/{action=Index}/{id?}",
    defaults: new { area = "Auth", controller = "Auth" });

app.Run();

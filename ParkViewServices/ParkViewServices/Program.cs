using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkViewServices.Data;
using ParkViewServices.Helpers;
using ParkViewServices.Models;
using ParkViewServices.Models.Bookings;
using ParkViewServices.Repositories;
using ParkViewServices.Repositories.Interfaces;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings")); 
builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddScoped<BookingCart>(sp => BookingCart.GetCart(sp));
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddAuthentication().AddGoogle(
    GoogleOptions =>
    {
        GoogleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        GoogleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    });
builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest)
   .AddRazorPagesOptions(options =>
{
options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();




app.Run();

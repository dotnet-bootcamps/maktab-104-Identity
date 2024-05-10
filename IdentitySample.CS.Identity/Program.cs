using IdentitySample.CS.Identity.Data;
using IdentitySample.CS.Identity.Infrastructures;
using IdentitySample.CS.Identity.Infrastructures.Auth;
using IdentitySample.CS.Identity.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("IdentityDb") ?? throw new InvalidOperationException("Connection string 'IdentityDb' not found.");
builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(connectionString));

//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanAskDriverLicense", policy =>
        policy.Requirements.AddRange(new[]
        {
            new MinimumAgeRequirement(18),
            //new GenderRequirement(1)
        }));
});
builder.Services.AddSingleton<IAuthorizationHandler, MinimumAgeRequirementHandler>();

builder.Services
    //.AddDefaultIdentity<AppUser>(options => { options.SignIn.RequireConfirmedAccount = true; })
    .AddIdentity<AppUser,AppRole>(options =>
    {
    })
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<AppIdentityDbContext>();

builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();


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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
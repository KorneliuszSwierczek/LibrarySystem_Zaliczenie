using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Data;
using LibrarySystem.Models;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("LibrarySystemContextConnection") ?? throw new InvalidOperationException("Connection string 'LibrarySystemContextConnection' not found.");
//var secondtconnectionString = builder.Configuration.GetConnectionString("BookDbConnection") ?? throw new InvalidOperationException("Connection string 'LibrarySystemContextConnection' not found.");


builder.Services.AddDbContext<LibrarySystemContext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddDbContext<BookDbContext>(options =>
//  options.UseSqlServer(secondtconnectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibrarySystemContext>();


builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;
app.MapRazorPages();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
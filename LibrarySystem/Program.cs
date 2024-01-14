using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Data;
using LibrarySystem.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LibrarySystemContextConnection") ?? throw new InvalidOperationException("Connection string 'LibrarySystemContextConnection' not found.");

builder.Services.AddDbContext<LibrarySystemContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
})
    .AddRoles<IdentityRole>() 
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
app.UseAuthentication();
app.UseAuthorization();

// Inicjalizacja roli "Admin" i przypisanie u¿ytkownika do tej roli
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    var adminUser = await userManager.FindByNameAsync("jan.kowalski@gmail.com");

    if (adminUser == null)
    {
        adminUser = new IdentityUser
        {
            UserName = "jan.kowalski@gmail.com",
            Email = "jan.kowalski@gmail.com"
        };

        await userManager.CreateAsync(adminUser, "Password123$");
    }

    if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
    {
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }

    var adminUser2 = await userManager.FindByNameAsync("krystian.zak@gmail.com");

    if (adminUser2 == null)
    {
        adminUser2 = new IdentityUser
        {
            UserName = "krystian.zak@gmail.com",
            Email = "krystian.zak@gmail.com"
        };

        await userManager.CreateAsync(adminUser2, "Password456$");
    }

    if (!await userManager.IsInRoleAsync(adminUser2, "Admin"))
    {
        await userManager.AddToRoleAsync(adminUser2, "Admin");
    }

    var adminUser3 = await userManager.FindByNameAsync("korneliusz.swierczek@gmail.com");

    if (adminUser3 == null)
    {
        adminUser3 = new IdentityUser
        {
            UserName = "korneliusz.swierczek@gmail.com",
            Email = "korneliusz.swierczek@gmail.com"
        };

        await userManager.CreateAsync(adminUser3, "Password789$");
    }

    if (!await userManager.IsInRoleAsync(adminUser3, "Admin"))
    {
        await userManager.AddToRoleAsync(adminUser3, "Admin");
    }
}


app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

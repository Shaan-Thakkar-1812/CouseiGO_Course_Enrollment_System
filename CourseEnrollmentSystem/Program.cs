using CourseEnrollmentSystem.Data;
using CourseEnrollmentSystem.Models; // For ApplicationUser
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

// Configure Database Connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add Identity Services with ApplicationUser
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// ✅ Configure cookie settings (important for redirects)
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.SlidingExpiration = true;
});

var app = builder.Build();

// ✅ Create roles and a default admin user
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        await CreateRolesAndAdminUserAsync(services, logger);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while creating roles and the admin user.");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ✅ Show status pages like 403/404
app.UseStatusCodePages();

app.UseAuthentication();
app.UseAuthorization();

// Route setup
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();

// 👇 Role Seeder
async Task CreateRolesAndAdminUserAsync(IServiceProvider serviceProvider, ILogger logger)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    string[] roles = { "Admin", "Student" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
            logger.LogInformation("Created role: {Role}", role);
        }
    }

    // Create a default admin user
    var adminEmail = "shaanthakkar4@gmail.com";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        var newAdmin = new ApplicationUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            FullName = "Super Admin",
            Address = "Admin Address",
            DateOfBirth = DateTime.Parse("1990-01-01")
        };

        var result = await userManager.CreateAsync(newAdmin, "Shaan1812");

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(newAdmin, "Admin");
            logger.LogInformation("Default admin user created: {Email}", adminEmail);
        }
        else
        {
            logger.LogError("Failed to create default admin user: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    }
}

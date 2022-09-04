using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ReverseEnginereeing.Data;

internal class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        Cofiguration(builder);
        var app = builder.Build();

        try
        {
            Authentication(app);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
            app.UseMigrationsEndPoint();
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapRazorPages();
        app.Run();
    }

    private static void Authentication(WebApplication app) // Identity & Admin Seed 7
    {
        var scope = app.Services.CreateScope();

        var ctx = scope.ServiceProvider.GetRequiredService<NadlanDbContext>();
        var userMngr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var roleMngr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        ctx.Database.EnsureCreated();


        var adminRole = new IdentityRole("Admin");
        if (!ctx.Roles.Any())
        {
            // Create role
            roleMngr.CreateAsync(adminRole).GetAwaiter().GetResult();
        }

        if (!ctx.Users.Any(u => u.UserName == "admin@test.com"))
        {
            var adminUser = new IdentityUser
            {
                UserName = "admin@test.com",
                Email = "admin@test.com",
            };
            var result = userMngr.CreateAsync(adminUser, "password").GetAwaiter().GetResult();
            // add role to user
            userMngr.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
        }
    }

    private static void Cofiguration(WebApplicationBuilder builder)
    {
        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<NadlanDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
        })
            //.AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<NadlanDbContext>(); // Authentication

        builder.Services.Configure<PasswordHasherOptions>(options =>
            options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2
            );
        builder.Services.ConfigureApplicationCookie(config =>
        {
            config.LoginPath = "/Login";
        });

        builder.Services.AddRazorPages();
        builder.Services.AddDbContext<NadlanDbContext>(options =>
                    options.UseLazyLoadingProxies()
                           .UseSqlServer(builder.Configuration.GetConnectionString("NADLAN_EF")));
    }
}
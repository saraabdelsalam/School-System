using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using School_System.Data.Entities;
using School_System.Infrastructure.Context;

public static class ServiceRegisteration
{
    public static IServiceCollection AddServiceRegisteration(this IServiceCollection services)
    {
        services.AddIdentityCore<ApplicationUser>(option =>
        {
            // Password settings.
            option.Password.RequireDigit = true;
            option.Password.RequireLowercase = true;
            option.Password.RequireNonAlphanumeric = true;
            option.Password.RequireUppercase = true;
            option.Password.RequiredUniqueChars = 1;

            // Lockout settings.
            option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            option.Lockout.MaxFailedAccessAttempts = 5;
            option.Lockout.AllowedForNewUsers = true;

            // User settings.
            option.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            option.User.RequireUniqueEmail = true;
            option.SignIn.RequireConfirmedEmail = false;

        }).AddEntityFrameworkStores<AppDbContext>();

        return services;
    }
}
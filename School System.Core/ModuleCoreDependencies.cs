using Microsoft.Extensions.DependencyInjection;
using School_System.Infrastructure.Implementation;
using School_System.Infrastructure.Interfaces;
using System.Reflection;

namespace School_System.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection CoreDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
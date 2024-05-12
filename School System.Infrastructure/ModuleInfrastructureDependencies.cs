using Microsoft.Extensions.DependencyInjection;
using School_System.Infrastructure.Implementation;
using School_System.Infrastructure.Interfaces;

namespace School_System.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection InfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddTransient<IStudentRepository, StudentRepository>();
            return services;
        }
    }
}
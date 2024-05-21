using Microsoft.Extensions.DependencyInjection;
using School_System.Service.Implementation;
using School_System.Service.Interfaces;

namespace School_System.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection ServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            return services;
        }
    }
}
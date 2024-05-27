using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using School_System.Core.Bases;
using School_System.Core.Behaviors;
using System.Reflection;

namespace School_System.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection CoreDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<ResponseHandler>();
            return services;
        }
    }
}
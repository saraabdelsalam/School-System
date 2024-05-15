
using Microsoft.EntityFrameworkCore;
using School_System.Core;
using School_System.Infrastructure;
using School_System.Infrastructure.Context;
using School_System.Service;
using School_System.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using School_System.Core.Middleware;

namespace School_System.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddDbContext<AppDbContext>
                (
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"))
                );
            #region DI
            builder.Services.InfrastructureDependencies()
                            .ServiceDependencies()
                            .CoreDependencies();
            #endregion
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseRouting();
            app.MapControllers();
            app.Run();
        }
    }
}
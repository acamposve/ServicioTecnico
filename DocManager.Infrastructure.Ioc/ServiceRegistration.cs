using ServicioTecnico.Application.Interfaces;
using ServicioTecnico.Application.Services;
using ServicioTecnico.Domain.Settings;
using ServicioTecnico.Infrastructure.Interfaces;
using ServicioTecnico.Infrastructure.Repositories;
using ServicioTecnico.Infrastructure.Shared.Interfaces;
using ServicioTecnico.Infrastructure.Shared.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ServicioTecnico.Infrastructure.Ioc
{
    public static class ServiceRegistration
    {
        public static void AddServicesInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<MailSettings>(_config.GetSection("MailSettings"));
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ILoggerManager, LoggerManager>();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //repositories
            services.AddScoped<IDapper, Dapperr>();

            services.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
            services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();


            //services
            // configure DI for application services
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}

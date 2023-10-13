using Microsoft.Extensions.DependencyInjection;
using Timelogger.Application.Services;

namespace Timelogger.Application
{
    public static class StartupExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ProjectsService>();
            services.AddScoped<TimeRegistrationService>();
            services.AddScoped<CustomersService>();
            services.AddAutoMapper(typeof(StartupExtensions));
        }
    }
}

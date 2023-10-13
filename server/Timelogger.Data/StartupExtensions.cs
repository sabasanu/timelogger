using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Timelogger.Data
{
    public static class StartupExtensions
    {
        public static void AddDataContext(this IServiceCollection services)
        {
            services.AddDbContext<TimeloggerDbContext>(options =>
            {
                options.UseInMemoryDatabase("TimeloggerDb");
            });
        }
    }
}

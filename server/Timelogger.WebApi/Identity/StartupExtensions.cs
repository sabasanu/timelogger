using Timelogger.Data;

namespace Timelogger.WebApi.Identity
{
    public static class StartupExtensions
    {
        public static void AddIdentityProvider(this IServiceCollection services)
        {
            services.AddSingleton<IIdentityProvider, IdentityProvider>();
        }
    }
}

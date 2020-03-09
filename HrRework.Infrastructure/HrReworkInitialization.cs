using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HrRework.Infrastructure
{
    public static class HrReworkInitialization
    {
        public static void EnsureDatabaseIsCreated(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<HrReworkContext>();

                dbContext.Database.EnsureCreated();
            }
        }
    }
}

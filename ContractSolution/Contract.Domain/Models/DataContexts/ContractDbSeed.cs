using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Contract.Domain.Models.DataContexts
{
    public static class ContractDbSeed
    {
        public static IApplicationBuilder Seed(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ContractDbContext>();
                db.Database.Migrate();

            }
            return builder;
        }
    }

    
}

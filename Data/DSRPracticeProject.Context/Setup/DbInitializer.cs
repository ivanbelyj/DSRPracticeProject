using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPracticeProject.Context.Setup
{
    public static class DbInitializer
    {
        public static void Execute(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider
                .GetService<IServiceScopeFactory>()
                ?.CreateScope())
            {
                ArgumentNullException.ThrowIfNull(scope);

                using (var context = scope.ServiceProvider
                    .GetRequiredService<IDbContextFactory<MainDbContext>>()
                    .CreateDbContext())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}

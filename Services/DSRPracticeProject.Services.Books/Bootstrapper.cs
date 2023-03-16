using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPracticeProject.Services.Books
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBooksService(
            this IServiceCollection services)
        {
            services.AddSingleton<IBookService, BookService>();

            return services;
        }
    }
}

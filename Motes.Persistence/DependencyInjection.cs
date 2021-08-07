using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Interfaces;

namespace Motes.Persistence
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Метод расширения для добавления контекста базы данных и регистрация его в веб приложении
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddPersistence(this IServiceCollection services, 
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<NotesDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<INotesDbContext>(provider => provider.GetService<NotesDbContext>());
            return services;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Internal;
using zy.webcore.share.Repository.EntitiesBase;
using zy.webcore.share.Repository.IRepositories;
using zy.webcore.Share.Extensions;

namespace zy.webcore.Share.Application.Registrar
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddZyEfCoreMySql(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsBuilder)
        {

            if (services.HasRegistered(nameof(AddZyEfCoreMySql)))
                return services;

            services.TryAddScoped<IUnitOfWork, MySqlUnitOfWork<MySqlDbContext>>();
            services.TryAddScoped(typeof(IEfRepository<>), typeof(EfRepository<>));
            services.TryAddScoped(typeof(IEfBasicRepository<>), typeof(EfBasicRepository<>));
            services.AddDbContext<DbContext, MySqlDbContext>(optionsBuilder);

            return services;
        }
    }
}

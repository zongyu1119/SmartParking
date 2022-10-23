using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SmartParking.Share.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.ObjExt
{
    public static class EfCoreMySqlServiceCollectionExtension
    {
        public static IServiceCollection AddInfraEfCoreMySql(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsBuilder)
        {
            //if (services.HasRegistered("EfCoreMySql"))
            //{
            //    return services;
            //}

            //services.TryAddScoped<IUnitOfWork, MySqlUnitOfWork<MySqlDbContext>>();
            //services.TryAddScoped(typeof(IEfRepository<>), typeof(EfRepository<>));
            //services.AddDbContext<DbContext, MySqlDbContext>(optionsBuilder);
            return services;
        }

    }
}

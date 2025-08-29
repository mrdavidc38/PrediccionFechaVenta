using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesDatePrediction.Model.Contexto;
using SalesDatePrediction.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.IOC
{
    public static class Dependencias
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreSampleContext>(options =>
            {
                var con = configuration.GetConnectionString("cadenaSQL");
                options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });

            services.AddAutoMapper(typeof(AutoMapperProfile));
        }

        }
}

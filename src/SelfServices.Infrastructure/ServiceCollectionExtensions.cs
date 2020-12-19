using Microsoft.Extensions.DependencyInjection;
using SelfServices.Core.Repositories;
using SelfServices.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServices.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ILoalityCardsRepository, LoalityCardsRepository>();
            services.AddTransient<IGulfCardRepository, GulfCardRepository>();

            return services;
        }
    }
}

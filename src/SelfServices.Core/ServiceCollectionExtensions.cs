using System.Reflection;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SelfServices.Core.Common.Behaviours;
using SelfServices.Core.Mapping;

namespace SelfServices.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            var currAssembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(typeof(MappingProFile));
            services.AddValidatorsFromAssembly(currAssembly);
            services.AddMediatR(currAssembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
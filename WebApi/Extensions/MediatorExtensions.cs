using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Sigmade.WebApi.Extensions
{
    public static class MediatorExtenisons
    {
        public static IServiceCollection AddMediatorHandlers(this IServiceCollection services, Assembly assembly)
        {
            services.AddMediatR(typeof(Startup));

            var types = assembly.DefinedTypes
                .Select(type => type.GetTypeInfo())
                .Where(type => type.IsClass && !type.IsAbstract);

            foreach (var implementationType in types)
            {
                var handlerInterfaces = implementationType.ImplementedInterfaces
                    .Select(i => i.GetTypeInfo())
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));

                foreach (var interfaceType in handlerInterfaces)
                {
                    services.AddTransient(interfaceType.AsType(), implementationType.AsType());
                }
            }

            services.AddTransient<IMediator, Mediator>();

            return services;
        }
    }
}

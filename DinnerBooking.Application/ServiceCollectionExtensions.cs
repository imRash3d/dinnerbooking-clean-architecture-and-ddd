using DinnerBooking.Application.Services.AuthenticationService;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerBooking.Api.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);
            serviceCollection.AddSingleton<IAuthenticationService, AuthenticationService>();
            return serviceCollection;
        }
    }
}

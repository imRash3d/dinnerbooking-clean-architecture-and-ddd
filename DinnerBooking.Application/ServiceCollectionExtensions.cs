using DinnerBooking.Application.Services.AuthenticationService;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerBooking.Api.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAuthenticationService, AuthenticationService>();
            return serviceCollection;
        }
    }
}

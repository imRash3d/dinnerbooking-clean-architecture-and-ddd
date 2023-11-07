using DinnerBooking.Application.Services.AuthenticationService;

namespace DinnerBooking.Api.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAuthenticationService, AuthenticationService>();
            return serviceCollection;
        }
    }
}

using DinnerBooking.Application.Common.Authentication;
using DinnerBooking.Application.Common.Interfaces.Persistance;
using DinnerBooking.Infrastructure.Abstraction;
using DinnerBooking.Infrastructure.Authentication;
using DinnerBooking.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;


namespace DinnerBooking.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddSingleton <IIdentityService, IdentityService> ();
            serviceCollection.AddSingleton<IRepository, Repository>();
            serviceCollection.AddSingleton<IUserRepository , UserRepository>();
            return serviceCollection;
        }
    }
}

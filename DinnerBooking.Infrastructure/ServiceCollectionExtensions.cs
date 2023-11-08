using DinnerBooking.Application.Common.Authentication;
using DinnerBooking.Application.Common.Interfaces.Persistance;
using DinnerBooking.Infrastructure.Adapter;
using DinnerBooking.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;


namespace DinnerBooking.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddSingleton <IIdentityService, IIdentityService> ();
            serviceCollection.AddSingleton<IRepository, Repository>();
            serviceCollection.AddSingleton<IUserRepository , UserRepository>();
            return serviceCollection;
        }
    }
}

using CarShop.Data.Layer.Common;
using CarShop.Data.Layer.Repositories;
using CarShop.Data.Layer.Repositories.Default;
using Microsoft.Extensions.DependencyInjection;

namespace CarShop.Data.Layer
{
    public static class DependencyLoader
    {
        public static void Load(IServiceCollection services)
        {
            services.AddSingleton<DatabaseConnection>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICallbackRepository, CallbackRepository>();
            services.AddScoped<ICarsDetailsRepository, CarDetailsRepository>();
            services.AddScoped<ICompanyServicesRepository, CompanyServiceRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IReviewsRepository, ReviewsRepository>();

        }
    }
}

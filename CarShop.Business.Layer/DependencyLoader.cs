using CarShop.Business.Layer.Serveces;
using CarShop.Business.Layer.Services;
using CarShop.Business.Layer.Services.Default;
using Microsoft.Extensions.DependencyInjection;

namespace CarShop.Business.Layer
{
    public static class DependencyLoader
    {
        public static void Load(IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICompanyServices, CompanyServices>();
            services.AddScoped<ICallbackService, CallbackService>();
            services.AddScoped<ICarsDetailsService, CarDetailsService>();
            services.AddScoped<IContactsService, ContactService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IReviewsService, ReviewService>();



        }
    }
}

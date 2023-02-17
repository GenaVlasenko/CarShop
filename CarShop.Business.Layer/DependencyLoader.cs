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
            services.AddScoped<IService, ServiceService>();
            services.AddScoped<IUserApplicationService, UserApplicationService>();
            services.AddScoped<ICarDetailService, CarDetailService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IReviewService, ReviewService>();



        }
    }
}

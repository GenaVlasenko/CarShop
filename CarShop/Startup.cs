using CarShop.Data.Interfaces;
using CarShop.Data.Mocks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            Business.Layer.DependencyLoader.Load(services);
            Data.Layer.DependencyLoader.Load(services);

            services.AddRazorPages();
            services.AddControllersWithViews(view => view.EnableEndpointRouting = false);
            services.AddTransient<IAllCars, DataCars>();
            services.AddTransient<IContacts, DataContacts>();
            services.AddTransient<IReviews, DataReviews>();
            services.AddTransient<IServices, DataServices>();
            services.AddTransient<IOrders, DataOrder>();
            services.AddTransient<ICarsDetails, DataCarDetails>();
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo1.Framework.Repository;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Demo1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(option => option.EnableEndpointRouting = false);

            //services.AddSignalR();

            services.AddDbContext<Demo1Context>(options =>
            {
                //string connectionString = Configuration.GetConnectionString("SQLiteConnection");
                options.UseSqlite(Configuration.GetConnectionString("SQLiteConnection"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapHub<HomeHub>("/hub");
            });

            if (HybridSupport.IsElectronActive)
            {
                ElectronBootstrap();
            }
        }

        public async void ElectronBootstrap()
        {
            var browserWindow = await Electron.WindowManager.CreateWindowAsync(new BrowserWindowOptions
            {
                Width = 1152,
                Height = 864,
                Show = true,
                //Icon = "./Assets/thunderCrawlerElectron.ico",
                Title = "DEMO1",
                //TitleBarStyle=TitleBarStyle.customButtonsOnHover
            });

            //ElectronNetµÄÒ»¸öbug
            //https://github.com/ElectronNET/Electron.NET/issues/361
            browserWindow.OnReadyToShow += () =>
            {
                Console.WriteLine("ready to show");
                browserWindow.Show();
            };

        }
    }
}

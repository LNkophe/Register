using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Login.Models;
using Microsoft.EntityFrameworkCore;

namespace Login
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://techmechanics.visualstudio.com/_git/TrainingTasks
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();
            var conn = @"Data Source=146.232.200.69;Initial Catalog=Litha;User ID=sa;Password=TutuServer$99;";
            services.AddDbContext<OurDbContext> (options => options.UseSqlServer(conn));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            else
                app.UseExceptionHandler("Home/Error");
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes => 
            {
                routes.MapRoute(
                    name:"default",
                    template:"{controller=Home}/{action=Login}/{id?}"
                    );
            });
        }
    }
}

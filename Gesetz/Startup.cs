using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Gesetz
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            // Für SessionState-Handling
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Die Anwender machen ziemlich lange nichts mit der App, daher muss der TimeOut relativ hoch sein.
                options.Cookie.HttpOnly = true; // Cookie ist auf dem Client nicht lesbar
                options.Cookie.IsEssential = true; // Aus Doku abgeschrieben, unklar wofür
            });
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Für SessionState (soll laut Doku zwischen UseRouting und UseEndpoints stehen)
            app.UseSession();


            app.UseEndpoints(endpoints => {
                endpoints.MapRazorPages();
            });

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using tclk.Data;

namespace tclk
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env) {
            Environment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            
            services.AddDbContext<TclkContext>(options => {
                var connectionString = Configuration.GetConnectionString("TclkContext");
                if (Environment.IsDevelopment())
                {
                    options.UseNpgsql(connectionString);
                }
                else if (Environment.IsProduction())
                {
                    options.UseNpgsql(connectionString);
                }
                else
                {
                    options.UseNpgsql(connectionString);
                }
            });

            // services.AddDbContext<TclkContext>(options =>
            //     options.UseNpgsql(Configuration.GetConnectionString("TclkContext"))
            // );

            services.AddRouting(options => {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } else {
                // app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}

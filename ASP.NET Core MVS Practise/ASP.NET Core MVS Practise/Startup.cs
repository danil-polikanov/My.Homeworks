using ASP.NET_Core_MVS_Practise.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ASP.NET_Core_MVS_Practise.Data;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using ASP.NET_Core_MVS_Practise.Models;

namespace ASP.NET_Core_MVS_Practise
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IServiceCollection _services;
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                   .AddInMemoryCollection(new Dictionary<string, string>
                   {
                    {"author.name", "Danil"},
                   });
            builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            Configuration = builder.Build();

        }
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<UsersContext>(options => options.UseSqlServer(connection));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                });
            services.AddRazorPages();
            _services = services;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<HeadMiddleware>(Configuration);

            app.UseMiddleware<QueryRedirectMiddleware>(Configuration);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("<a href = /hello> Link /hello </a>");
                });
                endpoints.MapGet("/hello", async context =>
                {
                    await context.Response.WriteAsync("Hello");
                });
                endpoints.MapGet("/hello.json", async context =>
                {
                    await context.Response.WriteAsync($"{Configuration["author.name"]}");
                });
               

            });

        }

    }
}

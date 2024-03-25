using C41_G02_MVC03.BLL.Interfaces;
using C41_G02_MVC03.BLL.Repositories;
using C41_G02_MVC03.DAL.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C41_G02_MVC03.PL
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the DepInj container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(); // Required by MVC


            //services.AddTransient<ApplicationDbContext>(); //(Every object) has (request and connections)


            //services.AddSingleton<ApplicationDbContext>(); //Connection with Data base will be opened for time 

            //services.AddScoped<DbContextOptions<ApplicationDbContext>>();

            // Dependence Injection
            services.AddDbContext<ApplicationDbContext>(Options =>
            {
                
                Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IDepartmentRepository, DepartmentRepository>(); // (One Object) for (requests)
            services.AddScoped<IEmployeeRepository, EmployeeRepository>(); // (One Object) for (requests)
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

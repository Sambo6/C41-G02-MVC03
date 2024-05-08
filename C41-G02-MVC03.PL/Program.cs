using C41_G02_MVC03.DAL.Data;
using C41_G02_MVC03.PL.Extensions;
using C41_G02_MVC03.PL.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace C41_G02_MVC03.PL
{
	public class Program
	{
		//Entry Point
		public static void Main(string[] args)
		{
			var webApplicationBuilder = WebApplication.CreateBuilder(args);

			#region Configure Services

			webApplicationBuilder.Services.AddMvc();
			webApplicationBuilder.Services.AddControllersWithViews(); // Required by MVC
																	  // Dependence Injection
			webApplicationBuilder.Services.AddDbContext<ApplicationDbContext>(Options =>
			{
				Options.UseSqlServer(webApplicationBuilder.Configuration.GetConnectionString("DefaultConnection"));
			});
			webApplicationBuilder.Services.AddApplicationServices(); //Extension method
			webApplicationBuilder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));

			#endregion

			var app = webApplicationBuilder.Build();

			#region Configure Kestrel pipeline
			if (app.Environment.IsDevelopment())
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

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
			#endregion

			app.Run(); // Application is Ready for request
		}

	}
}

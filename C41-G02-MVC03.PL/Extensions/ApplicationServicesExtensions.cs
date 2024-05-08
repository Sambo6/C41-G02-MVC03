using C41_G02_MVC03.BLL.Interfaces;
using C41_G02_MVC03.BLL.Repositories;
using C41_G02_MVC03.DAL.Data;
using C41_G02_MVC03.DAL.Models;
using C41_G02_MVC03.PL.Services.EmailSender;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace C41_G02_MVC03.PL.Extensions
{
	public static class ApplicationServicesExtensions
    {
		public static void AddApplicationServices(this IServiceCollection services)
		{

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddTransient<IEmailSender, EmailSender>();
			services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			{
				options.Password.RequiredUniqueChars = 2;
				options.Password.RequireDigit = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
				options.Password.RequireLowercase = true;
				options.Password.RequiredLength = 5;
				options.Lockout.AllowedForNewUsers = true;
				options.Lockout.MaxFailedAccessAttempts = 5;
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(5);
				options.User.RequireUniqueEmail = true;
			})
					.AddEntityFrameworkStores<ApplicationDbContext>()
					.AddDefaultTokenProviders();

			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "/Account/SignIn";
				options.ExpireTimeSpan = TimeSpan.FromDays(1);
				options.AccessDeniedPath = "/Home/Error";
			});

			services.AddAuthentication(options =>
			{
				//options.DefaultAuthenticateScheme = "Identity.Application";
			}).AddCookie( options =>
			{
				options.LoginPath = "/Account/SignIn";
				options.ExpireTimeSpan = TimeSpan.FromDays(1);
				options.AccessDeniedPath = "/Home/Error";
			});
		}

	}
}

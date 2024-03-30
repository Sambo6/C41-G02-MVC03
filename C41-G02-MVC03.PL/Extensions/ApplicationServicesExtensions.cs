using C41_G02_MVC03.BLL.Interfaces;
using C41_G02_MVC03.BLL.Repositories;
using C41_G02_MVC03.PL.Helper;
using Microsoft.Extensions.DependencyInjection;

namespace C41_G02_MVC03.PL.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            //services.AddScoped<IDepartmentRepository, DepartmentRepository>(); // (One Object) for (requests)

            //services.AddScoped<IEmployeeRepository, EmployeeRepository>(); // (One Object) for (requests)
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));
            return services;
        }

    }
}

using AutoMapper;
using C41_G02_MVC03.PL.ViewModels;
using C41_G02_MVC03.DAL.Models;

namespace C41_G02_MVC03.PL.Helper
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles() 
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap(); 
        }
    }
}

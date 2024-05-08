using C41_G02_MVC03.DAL.Models;
using System.Linq;

namespace C41_G02_MVC03.BLL.Interfaces
{
	public interface IEmployeeRepository :IGenericRepository<Employee>
    {
        IQueryable<Employee> GetEmployeesByAddress(string address);
        IQueryable<Employee> SearchByName(string name);
    }
}

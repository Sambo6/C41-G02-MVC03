using C41_G02_MVC03.BLL.Interfaces;
using C41_G02_MVC03.DAL.Data;
using C41_G02_MVC03.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C41_G02_MVC03.BLL.Repositories
{
	public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {  
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext) { }
        public IQueryable<Employee> GetEmployeesByAddress(string address)
        {
            return _dbContext.Employees.Where(E => E.Address.ToLowerInvariant() == address.ToLowerInvariant());
            //Fast Way ::    .Where(E => E.Address.Equals(address));
        }
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _dbContext.Employees.Include(E => E.Department).ToListAsync();
        
        }

        public IQueryable<Employee> SearchByName(string name)
            => _dbContext.Employees.Where(E => E.Name.ToLower().Contains(name));
    }
}

using C41_G02_MVC03.BLL.Interfaces;
using C41_G02_MVC03.DAL.Data;
using C41_G02_MVC03.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C41_G02_MVC03.BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {  
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext) { }
        public IQueryable<Employee> GetEmployeesByAddress(string address)
        {
            return _dbContext.Employees.Where(E => E.Address.Equals(address, StringComparison.OrdinalIgnoreCase));
            //Fast Way ::    .Where(E => E.Address.Equals(address));
        }
        public override IEnumerable<Employee> GetAll()
        => _dbContext.Employees.Include(E => E.Department).ToList();

        public IQueryable<Employee> SearchByName(string name)
            => _dbContext.Employees.Where(E => E.Name.ToLower().Contains(name));
    }
}

using C41_G02_MVC03.BLL.Interfaces;
using C41_G02_MVC03.DAL.Data;
using C41_G02_MVC03.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace C41_G02_MVC03.BLL.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private protected  readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext) //Ask CLR to create Object from "ApplicationDbContext"
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
             => _dbContext.Set<T>().Add(entity);

        public void Update(T entity)
           => _dbContext.Set<T>().Update(entity); //EF 3.1

        public async Task<T> GetAsync(int id)
            => await _dbContext.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Employee))

                return (IEnumerable<T>) _dbContext.Employees.Include(E => E.Department).AsNoTracking().ToList();
            else
                return await _dbContext.Set<T>().AsNoTracking().ToListAsync();

        }
        public void Delete(T entity)
            => _dbContext.Set<T>().Remove(entity);
    }
}

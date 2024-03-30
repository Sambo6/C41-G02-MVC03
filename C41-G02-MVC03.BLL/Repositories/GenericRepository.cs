using C41_G02_MVC03.BLL.Interfaces;
using C41_G02_MVC03.DAL.Data;
using C41_G02_MVC03.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
               => _dbContext.Add(entity);

        public void Update(T entity)
           => _dbContext.Update(entity); //EF 3.1
        public T Get(int id)
        {

            return _dbContext.Find<T>(id); // EF CORE 3.1 Feature
        }
         public IEnumerable<T> GetAll()
        {
            if (typeof(T) == typeof(Employee))
            {
                return (IEnumerable<T>) _dbContext.Employees.Include(E => E.Department).AsNoTracking().ToList();
            }
            else
            {
                return _dbContext.Set<T>().AsNoTracking().ToList();
            }
        }
        public void Delete(T entity)
            => _dbContext.Remove(entity);
    }
}

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
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private protected  readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext) //Ask CLR to create Object from "ApplicationDbContext"
        {
            _dbContext = dbContext;
        }

        public int Add(T entity)
        {
            //_dbContext.Set<T>().Add(entity);
            _dbContext.Add(entity);
            return _dbContext.SaveChanges();
        }
        public int Update(T entity)
        {
            //_dbContext.Set<T>().Update(entity); ;
            _dbContext.Update(entity); //EF 3.1
            return _dbContext.SaveChanges();
        }
        public T Get(int id)
        {
            //Find Have Overloaded 
            //return _dbContext.Set<T>().Find(id);

            return _dbContext.Find<T>(id); // EF CORE 3.1 Feature
        }
        public IEnumerable<T> GetAll()
        {

            return _dbContext.Set<T>().AsNoTracking().ToList();
        }
        public int Delete(T entity)
        {
            //_dbContext.Set<T>().Remove(entity);
            _dbContext.Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}

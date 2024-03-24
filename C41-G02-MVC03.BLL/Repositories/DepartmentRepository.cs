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
    public class DepartmentRepository : IDepartmentRepository
    {
         private readonly ApplicationDbContext _dbContext;
        public DepartmentRepository(ApplicationDbContext dbContext) //Ask CLR to create Object from "ApplicationDbContext"
        {
            _dbContext = dbContext;
        }

        public int Add(Department entity)
        {
            _dbContext.Departments.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Update(Department entity)
        {
            _dbContext.Departments.Update(entity); ;
            return _dbContext.SaveChanges();
        }


        public Department Get(int id)
        {
            //Find Have Overloaded 
            //return _dbContext.Departments.Find(id);

            return _dbContext.Find<Department>(id); // EF CORE 3.1 Feature
        }

        public IEnumerable<Department> GetAll()
        {

            return _dbContext.Departments.AsNoTracking().ToList();
        }

        public int Delete(Department entity)
        {
            _dbContext.Departments.Remove(entity);
            return _dbContext.SaveChanges();
        }


    }
}

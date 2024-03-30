﻿using C41_G02_MVC03.BLL.Interfaces;
using C41_G02_MVC03.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C41_G02_MVC03.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly ApplicationDbContext _dbContext;

        public IEmployeeRepository EmployeeRepository { get; set; } = null;
        public IDepartmentRepository DepartmentRepository { get ; set ; } = null;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            EmployeeRepository = new EmployeeRepository(_dbContext);
            DepartmentRepository = new  DepartmentRepository(_dbContext);
        }
        public int Complete()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.Dispose(); //Close Connections
        }


    }
}

﻿using C41_G02_MVC03.BLL.Interfaces;
using C41_G02_MVC03.DAL.Data;
using C41_G02_MVC03.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C41_G02_MVC03.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly ApplicationDbContext _dbContext;

        private Hashtable _Repositories;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _Repositories = new Hashtable();
        }
        public IGenericRepository<T> Repository<T>() where T : ModelBase
        {
            var key = typeof(T).Name; // Employee

            if (!_Repositories.ContainsKey(key))
            {

                if (key == nameof(Employee))
                {
                    var repository = new EmployeeRepository(_dbContext);
                    _Repositories.Add(key, repository);

                }
                else
                {
                    var repository = new GenericRepository<T>(_dbContext);
                    _Repositories.Add(key, repository);

                }
            }

            return _Repositories[key] as IGenericRepository<T>;
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
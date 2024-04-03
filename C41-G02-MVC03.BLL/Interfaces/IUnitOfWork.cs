using C41_G02_MVC03.DAL.Models;
using System;

namespace C41_G02_MVC03.BLL.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        
        IGenericRepository<T> Repository<T>() where T : ModelBase;
        public int Complete();

    }
}

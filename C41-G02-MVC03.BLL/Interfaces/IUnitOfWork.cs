using C41_G02_MVC03.DAL.Models;
using System;
using System.Threading.Tasks;

namespace C41_G02_MVC03.BLL.Interfaces
{
    public interface IUnitOfWork :IAsyncDisposable
    {
        
        IGenericRepository<T> Repository<T>() where T : ModelBase;
        Task<int> Complete();

    }
}

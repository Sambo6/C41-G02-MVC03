using C41_G02_MVC03.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C41_G02_MVC03.BLL.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        
        IGenericRepository<T> Repository<T>() where T : ModelBase;
        public int Complete();

    }
}

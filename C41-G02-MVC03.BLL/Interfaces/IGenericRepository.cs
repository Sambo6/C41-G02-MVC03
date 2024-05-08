using C41_G02_MVC03.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C41_G02_MVC03.BLL.Interfaces
{
	public interface IGenericRepository<T> where T : ModelBase
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

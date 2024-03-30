using C41_G02_MVC03.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C41_G02_MVC03.BLL.Interfaces
{
    public interface IGenericRepository<T> where T : ModelBase
    {
        public IEnumerable<T> GetAll();
        public T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

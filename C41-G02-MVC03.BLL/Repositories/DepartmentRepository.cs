using C41_G02_MVC03.BLL.Interfaces;
using C41_G02_MVC03.DAL.Data;
using C41_G02_MVC03.DAL.Models;

namespace C41_G02_MVC03.BLL.Repositories
{
	public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C41_G02_MVC03.BLL.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        //Property Signature
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }

        int Complete();

    }
}

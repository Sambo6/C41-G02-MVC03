using C41_G02_MVC03.BLL.Interfaces;
using C41_G02_MVC03.DAL.Models;
using Microsoft.AspNetCore.Mvc;
namespace C41_G02_MVC03.PL.Controllers
{
    // Inheritance :  DepartmentController is a Controller
    // Composition :  DepartmentController is DepartmentRepository
    public class DepartmentController : Controller
    {

        private readonly IDepartmentRepository _departmentRepo;


        //Dependence injection
        public DepartmentController(IDepartmentRepository departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        // /Department/Index
        public IActionResult Index()
        {
            // 4 Overload
            var departments = _departmentRepo.GetAll();
            return View(departments);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {

            if (ModelState.IsValid) // Server Side Validation
            {
                var count = _departmentRepo.Add(department);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(department);
        }
    }
}

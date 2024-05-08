using C41_G02_MVC03.BLL.Interfaces;
using C41_G02_MVC03.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
namespace C41_G02_MVC03.PL.Controllers
{
	// Inheritance :  DepartmentController is a Controller
	// Composition :  DepartmentController is DepartmentRepository
	[Authorize]
	public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;



        //Dependence injection
        public DepartmentController(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        // /Department/Index
        public async Task<IActionResult> Index()
        {
            // 4 Overload
            var departments = await  _unitOfWork.Repository<Department>().GetAllAsync();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                _unitOfWork.Repository<Department>().Add(department);
                var count = await _unitOfWork.Complete();
                if (count > 0)
                    TempData["Message"] = "Department is Created Successfully";
                else
                    TempData["Message"] = "Error While Creating the Department";

                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id, string ViewName = "Details")
        {
            if (id is null)
                return BadRequest();
            var department = await _unitOfWork.Repository<Department>().GetAsync(id.Value);
            if (department is null)
            {
                return NotFound();
            }
            return View(ViewName, department);
        }
        // /Department/Edit/
        [HttpGet]

        public async Task<IActionResult> Edit(int? id)
        {
            return await Details(id, "Edit");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, Department department)
        {
            if (id != department.Id)
                return BadRequest();

            if (!ModelState.IsValid) //Server Side Validation 
                return View(department);
            try
            {
                _unitOfWork.Repository<Department>().Update(department);
                await _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                //1.Log Exception
                //2. Type Friendly message
                if (_env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "There are an Error during Updating the Department");
                return View(department);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int? id, Department department)
        {

            try
            {
                _unitOfWork.Repository<Department>().Delete(department);
                await _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "Error during Deleting the Department");
                return View(department);
            }
        }
    }

}

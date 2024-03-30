using C41_G02_MVC03.BLL.Interfaces;
using C41_G02_MVC03.DAL.Data.Migrations;
using C41_G02_MVC03.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
namespace C41_G02_MVC03.PL.Controllers
{
    // Inheritance :  DepartmentController is a Controller
    // Composition :  DepartmentController is DepartmentRepository
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
        public IActionResult Index()
        {
            // 4 Overload
            var departments = _unitOfWork.Repository<Department>().GetAll();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                _unitOfWork.Repository<Department>().Add(department);
                var count = _unitOfWork.Complete();
                if (count > 0)
                    TempData["Message"] = "Department is Created Successfully";
                else
                    TempData["Message"] = "Error While Creating the Department";

                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Details(int? id, string ViewName = "Details")
        {
            if (id is null)
                return BadRequest();
            var department = _unitOfWork.Repository<Department>().Get(id.Value);
            if (department is null)
            {
                return NotFound();
            }
            return View(ViewName, department);
        }
        // /Department/Edit/
        [HttpGet]

        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Department department)
        {
            if (id != department.Id)
                return BadRequest();

            if (!ModelState.IsValid) //Server Side Validation 
                return View(department);
            try
            {
                _unitOfWork.Repository<Department>().Update(department);
                _unitOfWork.Complete();
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
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        public IActionResult Delete([FromRoute] int? id, Department department)
        {

            try
            {
                _unitOfWork.Repository<Department>().Delete(department);
                _unitOfWork.Complete();
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

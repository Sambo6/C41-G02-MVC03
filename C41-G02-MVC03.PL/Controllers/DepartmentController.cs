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

        private readonly IDepartmentRepository _departmentRepo;
        private readonly IWebHostEnvironment _env;



        //Dependence injection
        public DepartmentController(IDepartmentRepository departmentRepo, IWebHostEnvironment env)
        {
            _departmentRepo = departmentRepo;
            _env = env;
        }

        // /Department/Index
        public IActionResult Index()
        {
            // 4 Overload
            var departments = _departmentRepo.GetAll();
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
                var count = _departmentRepo.Add(department);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Details(int? id, string ViewName = "Details")
        {
            if (id is null)
                return BadRequest();
            var department = _departmentRepo.Get(id.Value);
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
            //// خلي بالك هنا نغسها نفس ال  (Details )
            ///if (!id.HasValue)
            ///    return BadRequest(); //400            
            ///var department = _departmentRepo.Get(id.Value);
            ///if(department is null)
            ///    return NotFound(); //404
            ///return View(department);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Edit([FromRoute] int id, Department department)
        {
            if (id != department.Id)
                return BadRequest();

            if (!ModelState.IsValid) //Server Side Validation 
                return View(department);
            try
            {
                _departmentRepo.Update(department);
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
                _departmentRepo.Delete(department);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "Error during Update the Department");
                return View(department);
            }
        }
    }

}

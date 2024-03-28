using C41_G02_MVC03.BLL.Interfaces;
using C41_G02_MVC03.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace C41_G02_MVC03.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IWebHostEnvironment _env;



        //Dependence injection
        public EmployeeController(IEmployeeRepository employeeRepo, IWebHostEnvironment env)
        {
            _employeeRepo = employeeRepo;
            _env = env;

        }

        // /Employee/Index
        public IActionResult Index(string SearchInput)
        {
            var employees = Enumerable.Empty<Employee>();
            if (string.IsNullOrEmpty(SearchInput))
                 employees = _employeeRepo.GetAll();
                
            else
                 employees =_employeeRepo.SearchByName(SearchInput.ToLower() );

            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                var count = _employeeRepo.Add(employee);

                //3.TempData

                if (count > 0)
                {
                    TempData["Message"] = "Employee is Created Successfully";
                }
                else
                {
                    TempData["Message"] = "Employee is Not Created";
                }
                return RedirectToAction(nameof(Index));

            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Details(int? id, string ViewName = "Details")
        {
            if (id is null)
                return BadRequest();
            var employee = _employeeRepo.Get(id.Value);
            if (employee is null)
                return NotFound();

            return View(ViewName, employee);
        }
        // /Employee/Edit/
        [HttpGet]

        public IActionResult Edit(int? id)
        {

            return Details(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(employee);

            try
            {
                _employeeRepo.Update(employee);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                //1.Log Exception
                //2. Type Friendly message
                if (_env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "There are an Error during Updating the Employee");
                return View(employee);
            }
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        public IActionResult Delete([FromRoute] int? id, Employee employee)
        {

            try
            {
                _employeeRepo.Delete(employee);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "Error during Update the Employee");
                return View(employee);
            }
        }
    }
}

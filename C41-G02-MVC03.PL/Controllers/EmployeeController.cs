using AutoMapper;
using C41_G02_MVC03.BLL.Interfaces;
using C41_G02_MVC03.BLL.Repositories;
using C41_G02_MVC03.DAL.Data.Migrations;
using C41_G02_MVC03.DAL.Models;
using C41_G02_MVC03.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using Employee = C41_G02_MVC03.DAL.Models.Employee;

namespace C41_G02_MVC03.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        //Dependence injection
        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper,IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
        }
        // /Employee/Index
        public IActionResult Index(string SearchInput)
        {
            var employees = Enumerable.Empty<Employee>();
            var employeeRepo = _unitOfWork.Repository<Employee>() as EmployeeRepository;
            if (string.IsNullOrEmpty(SearchInput))
                employees = employeeRepo.GetAll();
            else
                employees = employeeRepo.SearchByName(SearchInput.ToLower());

            var mappedEmps = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);

            return View(mappedEmps);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid) // Server Side Validation
            {

                 var mappedEmp = _mapper.Map<EmployeeViewModel,Employee>(employeeVM);

                _unitOfWork.Repository<Employee>().Add(mappedEmp);
                var count = _unitOfWork.Complete();
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
            return View(employeeVM);
        }
        public IActionResult Details(int? id, string ViewName = "Details")
        {
            if (id is null)
                return BadRequest();
            var employee = _unitOfWork.Repository<Employee>().Get(id.Value);
            var mappedEmp = _mapper.Map<Employee, EmployeeViewModel>(employee);
            if (employee is null)
                return NotFound();

            return View(ViewName, mappedEmp);
        }
        // /Employee/Edit/
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, EmployeeViewModel employeeVM)
        {

            if (id != employeeVM.Id)
                return BadRequest();
            if (!ModelState.IsValid)
                return View(employeeVM);
            try
            {
                var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);

                _unitOfWork.Repository<Employee>().Update(mappedEmp);
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
                    ModelState.AddModelError(string.Empty, "There are an Error during Updating the Employee");
                return View(employeeVM);
            }
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        public IActionResult Delete([FromRoute] int? id, EmployeeViewModel employeeVM)
        {
            try
            {
                var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);

                _unitOfWork.Repository<Employee>().Delete(mappedEmp);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "Error during Update the Employee");

                return View(employeeVM);
            }
        }
    }
}

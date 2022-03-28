using Microsoft.AspNetCore.Mvc;
using WebApplication7.BL.Repository;
using WebApplication7.BL.Interface;
using WebApplication7.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspGraduateProjAdminPan.Controllers
{
    public class EmployeeController : Controller
        
    {
        private readonly IEmployeeRep employee;
        private readonly IDepartmentRep department;

        public EmployeeController(IEmployeeRep employee,IDepartmentRep department)
        {
            this.employee = employee;
            this.department = department;
        }
        public IActionResult Index()
        {

        var d=    employee.Get();

            return View(d);
        }

        [HttpGet]
        public IActionResult Create()
        {


  var data=department.Get();



            ViewBag.Deps = new SelectList(data,"Id");
 
                return View();

            
            

        }



        [HttpPost]
        public IActionResult Create(EmployeeVM emp)
        {

            var data = department.Get();



            ViewBag.Deps = new SelectList(data, "Id","DepartmentName");
            try
            {
                if (ModelState.IsValid)
                {


                    employee.Add(emp);
                    return RedirectToAction("Index");


                }
                else return View(emp);


            }
            catch (Exception r)
            {
                Console.WriteLine(r.Message);
                return View();
            }




        }


    }
}

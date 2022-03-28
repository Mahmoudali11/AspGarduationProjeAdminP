using Microsoft.AspNetCore.Mvc;
using WebApplication7.BL.Repository;
using WebApplication7.BL.Interface;
using WebApplication7.Models;
using System;

namespace AspGraduateProjAdminPan.Controllers
{
    public class EmployeeController : Controller
        
    {
        private readonly IEmployeeRep employee;

        public EmployeeController(IEmployeeRep employee)
        {
            this.employee = employee;
        }
        public IActionResult Index()
        {

        var d=    employee.Get();

            return View(d);
        }

        [HttpGet]
        public IActionResult Create()
        {
 
                return View();

            
            

        }



        [HttpPost]
        public IActionResult Create(EmployeeVM emp)
        {

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

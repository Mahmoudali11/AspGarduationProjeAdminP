using Microsoft.AspNetCore.Mvc;
using WebApplication7.BL.Repository;
using WebApplication7.BL.Interface;
using WebApplication7.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using AspGraduateProjAdminPan.BL.Interface;

namespace AspGraduateProjAdminPan.Controllers
{
    public class EmployeeController : Controller

    {
        private readonly IEmployeeRep employee;
        private readonly IDepartmentRep department;
        private readonly ICityRep city;
        private readonly ICountryRep country;
        private readonly IDistrictRep district;

        public EmployeeController(IEmployeeRep employee, IDepartmentRep department,ICityRep city,ICountryRep country,IDistrictRep district)
        {
            this.employee = employee;
            this.department = department;
            this.city = city;
            this.country = country;
            this.district = district;
        }
        public IActionResult Index()
        {

            var d = employee.Get();

            return View(d);
        }

        [HttpGet]
        public IActionResult Create()
        {


            var data = department.Get();



            ViewBag.Deps = new SelectList(data, "Id", "DepartmentName");



            var countries = country.Get();

            ViewBag.country = new SelectList(countries, "Id", "Name");

            

            return View();




        }




        [HttpPost]
        public IActionResult Create(EmployeeVM emp)
        {
             



            var countries = country.Get();

            ViewBag.country = new SelectList(countries, "Id", "Name");



            var data = department.Get();



            ViewBag.Deps = new SelectList(data, "Id", "DepartmentName");
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
        public IActionResult Edit(int id)
        {
            var d = employee.GetById(id);

            ViewBag.Deps = new SelectList(department.Get(), "Id", "DepartmentName");

            return View(d);
        }

        /// <summary>
        /// ////////
        /// </summary>
        /// <param name="dep"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(EmployeeVM dep)
        {
            try
            {
                if (ModelState.IsValid)
                {



                    employee.Edit(dep);
                    return RedirectToAction("Index", "Employee");
                }
                else
                {


                    return View(dep);
                }
            }
            catch (Exception ex)
            {


                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry("bbbbs", EventLogEntryType.Error);

                return View(dep);




            }
        }


        ///delete emp
        public IActionResult Delete(int id)
        {
            var data = employee.GetById(id);
            //if(data == null)
            //{

            //}
            return View(data);
        }
        //note that action name chane name of action at run time!
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int ID)
        {
            try
            {
                employee.Delete(ID);
                return RedirectToAction("Index", "Employee");
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View();
            }
        }


  

     

    }
  



}



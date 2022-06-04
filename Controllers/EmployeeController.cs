using AspGraduateProjAdminPan.BL.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Diagnostics;
using System.IO;
using WebApplication7.BL.Interface;
using WebApplication7.Models;

namespace AspGraduateProjAdminPan.Controllers
{
    [Authorize]
    public class EmployeeController : Controller

    {
        private readonly IEmployeeRep employee;
        private readonly IDepartmentRep department;
        private readonly ICityRep city;
        private readonly ICountryRep country;
        private readonly IDistrictRep district;

        public EmployeeController(IEmployeeRep employee, IDepartmentRep department, ICityRep city, ICountryRep country, IDistrictRep district)
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
        public IActionResult IndexDataT()
        {

            var d = employee.Get();

            return View(d);
        }
        public IActionResult Details(int id)
        {



            var d = employee.Get();
            var selectedDep = employee.GetById(id);
            ViewBag.Deps = new SelectList(department.Get(), "Id", "DepartmentName", selectedDep.DepId);
            var countries = country.Get();
            var cityr = city.Get();
            var districts = district.Get();
            var empdistrict = district.GetById(selectedDep.DistrictId);
            var empcity = city.GetById(empdistrict.CityId);
            var empCountry = country.GetById(empcity.CountryId);
            ViewBag.district = new SelectList(districts, "Id", "Name", empdistrict.Id);

            ViewBag.city = new SelectList(cityr, "Id", "Name", empcity.Id);

            ViewBag.country = new SelectList(countries, "Id", "Name", empCountry.Id);

            return View(selectedDep);

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




            try
            {
                if (ModelState.IsValid)
                {


               

                    employee.Add(emp);
                    return RedirectToAction("Index");


                }
                else
                {

                    var countries = country.Get();

                    ViewBag.country = new SelectList(countries, "Id", "Name");



                    var data = department.Get();
                    ViewBag.Deps = new SelectList(data, "Id", "DepartmentName");


                    return View(emp);
                }



            }
            catch (Exception r)
            {
                Console.WriteLine(r.Message);

                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(r.Message, EventLogEntryType.Error);
                return View(emp);
            }




        }
        public IActionResult Edit(int id)
        {

            var selectedDep = employee.GetById(id);
            var d = employee.GetById(id);

            ViewBag.Deps = new SelectList(department.Get(), "Id", "DepartmentName", selectedDep.DepId);

            var countries = country.Get();
            /*
            Console.WriteLine("???????????????????????"+d.DistId);
            var empdistrict = district.GetById(d.DistId);
            var empcity = city.GetById(empdistrict.CityId);
            var empCountry = country.GetById(empcity.CountryId);*/


            ViewBag.country = new SelectList(countries, "Id", "Name");

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


            /*    var empdistrict = district.GetById(dep.DistId);
                var empcity = city.GetById(empdistrict.CityId);
                var empCountry = country.GetById(empcity.CountryId);*/




            try
            {
                if (ModelState.IsValid)
                {
                    Console.WriteLine("saved");


                    employee.Edit(dep);
                    return RedirectToAction("Index");
                }
                else
                {
                    Console.WriteLine("Error in edit ation");

                    var selectedDep = employee.GetById(dep.Id);

                    ViewBag.Deps = new SelectList(department.Get(), "Id", "DepartmentName", selectedDep.DepId);

                    var countries = country.Get();
                    ViewBag.country = new SelectList(countries, "Id", "Name"/*, empCountry.Id*/);



                    return View(dep);
                }
            }
            catch (Exception ex)
            {


                Console.WriteLine(ex.Message);


                EventLog log = new EventLog();
                log.Source = "mrwerwer";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

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



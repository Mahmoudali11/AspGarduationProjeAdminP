using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.BL.Repository;
using WebApplication7.DAL.Database;
using WebApplication7.Models;
 using System.Diagnostics;

namespace WebApplication7.Controllers
{
    public class DepartmentController : Controller
    {


        private DepartmentRep department = new DepartmentRep();

        public IActionResult Index()
        {

            //// View Data ==> Object
            //ViewData["x"] = "Hi I'm View Data";


            //// View Bag ==> Dynamic
            //ViewBag.y = "Hi I'm View Bag";

            //// Temp Data
            //TempData["z"] = "Hi I'm Temp Data";


            //string[] arr = { "Islam", "Aya", "Ahmed", "Samy" };

            //ViewBag.data = arr;


            //DepartmentVM dpt1 = new DepartmentVM() { Id = 1, DepartmentName = "HR", DepartmentCode = "A100" };
            //DepartmentVM dpt2 = new DepartmentVM() { Id = 2, DepartmentName = "IT", DepartmentCode = "A200" };
            //DepartmentVM dpt3 = new DepartmentVM() { Id = 3, DepartmentName = "Sales", DepartmentCode = "A300" };

            //List<DepartmentVM> DptData = new List<DepartmentVM>();
            //DptData.Add(dpt1);
            //DptData.Add(dpt2);
            //DptData.Add(dpt3);


            //var data = DptData;

            var data = department.Get();

            return View(data);
            //return RedirectToAction("Index", "Home");
            //return Redirect("/Home/Index");
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentVM dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    department.Add(dpt);
                    return RedirectToAction("Index", "Department");
                }
                else
                {


                    return View(dpt);
                }
            }
            catch (Exception ex)
            {


                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry("bbbbs", EventLogEntryType.Error);

                return View(dpt);
            }
               

                 
            
            


        }
        public IActionResult Edit(int id)
        {
               var d=department.GetById(id);

            return View(d);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentVM dep)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    department.Edit(dep);
                    return RedirectToAction("Index", "Department");
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




        public IActionResult Delete(int id)
        {
            var data = department.GetById(id);
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
                    department.Delete(ID);
                    return RedirectToAction("Index", "Department");
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

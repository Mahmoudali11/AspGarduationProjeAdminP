using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AspGraduateProjAdminPan.BL.Interface;
using AspGraduateProjAdminPan.BL.Repository;


namespace AspGraduateProjAdminPan.BL.Service
{/// <summary>
/// Used for ajax Call............. for good practice
/// </summary>
    public class EmployeeServiceControllercs : Controller
       
    {
        private readonly ICityRep city;
        private readonly IDistrictRep district;

        public EmployeeServiceControllercs(ICityRep city,IDistrictRep district)
        {
            this.city = city;
            this.district = district;
        }

 
        [HttpPost]
        [Route("/EmployeeService/getCitiesByCountryId")]
        public JsonResult getCitiesByCountryId(int id)
        {


            var data = city.Get().Where(a => a.CountryId == id);


            return Json(data);

            /* catch (Exception ex)
             {
                 EventLog log = new EventLog();
                 log.Source = "Admin Dashboard";
                 log.WriteEntry(ex.Message, EventLogEntryType.Error);


                 return Json("");
             }*/
        }
        [HttpPost]
        [Route("/EmployeeService/getDistrictsByCitiyId")]

        public JsonResult getDistrictsByCitiyId(int id)
        {

            var data = district.Get().Where(a => a.CityId == id);


            return Json(data);


        }
    }
}

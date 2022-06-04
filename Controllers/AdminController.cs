using AspGraduateProjAdminPan.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace AspGraduateProjAdminPan.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        /// <summary>
        /// by default  method type is GET 
        /// </summary>
        /// <returns></returns>
        
        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var data = roleManager.Roles.Select(a => new RolesVM { Id = a.Id ,RoleName = a.Name }) ;
            
            return View(data);
        }
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RolesVM model)
        {


            if (ModelState.IsValid)
            {

                var role =new  IdentityRole{ Name=model.RoleName};
                var identityResult = await roleManager.CreateAsync(role);


                if(identityResult.Succeeded)
                {
                    return RedirectToAction("CreateRole");
                }
                else
                {



                    foreach(var item in identityResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);

                    }
                }

                return View(model);


            }
            return View(model);
        }
        public  async  Task<IActionResult> EditRole(string id)
        {

            var data =  await roleManager.FindByIdAsync(id);
            
            
            return View(new RolesVM { RoleName=data.Name,Id=data.Id});
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(RolesVM model)
        {
            if (ModelState.IsValid)
            {
                var data = await roleManager.FindByIdAsync(model.Id);
                data.Name = model.RoleName;
                //for delete use DeleteAsync
            var result=    await roleManager.UpdateAsync(data);
                if(result.Succeeded)
                return RedirectToAction("Index");
                else
                {

                  foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }


            return View(model);
        }

    }
}

using LibraryManagementSystem.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class RoleController(
        RoleManager<AppRole>roleManager,
        UserManager<AppUser> userManager
        ) : Controller
    {
        // GET: RoleController
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
       
            return View("~/Views/Admin/Admin.cshtml");

        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RoleCreate(string roleName)
        {
            var newRole = new AppRole()
            {
                Name = roleName,
            };
            var response = await roleManager.CreateAsync(newRole);

            return View("~/Views/Admin/Admin.cshtml");


        }

        // GET: RoleController/Details/5
        [Authorize(Roles = "Admin")]
        public async Task <IActionResult> GetRoles()
        {
            var appRoles = roleManager.Roles.ToList();
            if (appRoles==null)
            {
                ModelState.AddModelError(string.Empty, "Rol Bulunamadı");
            }
            return View("Roles",appRoles);
        }


        // GET: RoleController/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task <IActionResult> Update(Guid id)
        {
            var appRole = await roleManager.FindByIdAsync(id.ToString());
            if (appRole == null)
            {
                ModelState.AddModelError(string.Empty, "Rol Bulunamadı");
            }
            var role = new AppRole()
            {
                Id = appRole.Id,
                Name = appRole.Name,
            };
            return View(role);
        }

        // POST: RoleController/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async  Task <IActionResult> Update(AppRole role)
        {
            var appRole = await roleManager.FindByIdAsync(role.Id.ToString());
            if (appRole == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı Bulunamadı");
                return RedirectToAction("GetUsers");
            }
            appRole.Name = role.Name;

            var result = await roleManager.UpdateAsync(appRole);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Güncelleme işlemi başarısız oldu.");
                return View(role);
            }

            return RedirectToAction("GetRoles");
        }

        // POST: RoleController/Delete/5
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task <IActionResult> Delete(Guid id)
        {
            var appRole = await roleManager.FindByIdAsync(id.ToString());

            var result = await roleManager.DeleteAsync(appRole);
            if (result.Succeeded) {
                ModelState.AddModelError(string.Empty, "kullanıcı Silme başarısız");
            }
            return RedirectToAction("GetRoles");
        }
    }
}

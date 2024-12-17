using LibraryManagementSystem.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
namespace LibraryManagementSystem.Controllers
{
    public class UserController(
        UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager,
        SignInManager<AppUser> signInManager) : Controller
    {
        // GET: UserController
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View("~/Views/Admin/Admin.cshtml");
        }

        [Authorize(Roles = "Admin")]
        public async Task <IActionResult> UserCreate(string email,string password,string userName,string City,string role)
        {
            var hasUser = await userManager.FindByEmailAsync(email);
            if (hasUser != null)
            {
                ModelState.AddModelError(string.Empty, "Bu eposta adresiyle kullanıcı var");
            }

            var appUser = new AppUser()
            {
                UserName = userName,
                Email = email,
                City = City,

            };

            var identityREsult = await userManager.CreateAsync(appUser, password);

            if (identityREsult.Succeeded)
            {
                // Rol ataması
                if (!string.IsNullOrEmpty(role))
                {
                    await userManager.AddToRoleAsync(appUser, role);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı oluşturulamadı.");
            }
            return View("~/Views/Admin/Admin.cshtml");

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddRoleToUser(string role, string userId)
        {

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı.");
                return RedirectToAction("GetUsers");
            }
            if (!await roleManager.RoleExistsAsync(role))
            {
                ModelState.AddModelError(string.Empty, "Geçerli bir rol bulunamadı.");
                return RedirectToAction("GetUsers");
            }
            var result = await userManager.AddToRoleAsync(user, role);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Rol atama başarısız.");
            }

            return RedirectToAction("UpdateUser", new { id = userId });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> RemoveRoleFromUser(string userId, string role)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı.");
                return RedirectToAction("GetUsers");
            }

            if (!await roleManager.RoleExistsAsync(role))
            {
                ModelState.AddModelError(string.Empty, "Geçerli bir rol bulunamadı.");
                return RedirectToAction("GetUsers");
            }

            var result = await userManager.RemoveFromRoleAsync(user, role);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Rol silme başarısız.");
            }

            return RedirectToAction("UpdateUser", new { id = userId });
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task <IActionResult> GetUsers(Guid id)
        {
            
            var appUsers = userManager.Users.ToList();
            var roles = roleManager.Roles.Select(r => r.Name).ToList();

            var userRoles = new Dictionary<string, IList<string>>();
            foreach (var user in appUsers)
            {
                userRoles[user.Id.ToString()] = await userManager.GetRolesAsync(user);
            }

            ViewBag.UserRoles = userRoles;
            ViewBag.Roles = roles;

            if (appUsers==null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı Bulunamadı");
            }
            return View("~/Views/User/Users.cshtml", appUsers);
        }
        
        //public async Task<IActionResult> AddClaimToUser()
        //{
        //    var user = await userManager.FindByNameAsync("burak1");
        //    await userManager.AddClaimAsync( user, 
        //        new Claim("BirthDate", DateTime.Now.AddYears(-10).ToShortDateString()));
        //    return RedirectToAction("Index");
        //}

        // POST: UserController/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task <IActionResult> UpdateUser(Guid id)
        {

            var appUser = await userManager.FindByIdAsync(id.ToString());
            
            if (appUser == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı Bulunamadı");
            }

            var userRole = await userManager.GetRolesAsync(appUser);
            ViewBag.UserRoles = userRole;

            var user = new AppUser()
            {
                Id = appUser.Id,
                UserName = appUser.UserName,
                Email= appUser.Email,
                City = appUser.City,
            };
           
            return View(user);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateUser(AppUser user)
        {
            var appUser = await userManager.FindByIdAsync(user.Id.ToString());
           

            if (appUser == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı Bulunamadı");
                return RedirectToAction("GetUsers");
            }
                appUser.UserName = user.UserName;
                appUser.Email = user.Email;
                appUser.City = user.City;

            var result = await userManager.UpdateAsync(appUser);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Güncelleme işlemi başarısız oldu.");
                return View(user);
            }

            return RedirectToAction("GetUsers");

        }


        // POST: UserController/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult >Delete(Guid id)
        {
            var appUser = await userManager.FindByIdAsync(id.ToString());

            var result = await userManager.DeleteAsync(appUser);
            if (result.Succeeded) {
                ModelState.AddModelError(string.Empty, "Kullanıcı Silme yetkisine sahip değilsiniz");
            }
            return RedirectToAction("GetUsers");

        }
    }
}

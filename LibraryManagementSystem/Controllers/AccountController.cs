using LibraryManagementSystem.Models.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class AccountController(
        RoleManager<AppRole> roleManager,
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager
        ) : Controller
    {
        // GET: AccountController
        public ActionResult Index()
        {
            var claims = User.Claims; //Cookie içindeki datalara erişim

            return Redirect("/Identity/Account/Login");
            //return View();
        }
        [HttpPost]
        public async Task <IActionResult> Login(string email,string password)
        {
            //var email = "burak1@outlook.com";
            //var password = "Password12*";

            var hasUser =await userManager.FindByEmailAsync( email );
            if (hasUser== null)
            {
                ModelState.AddModelError(string.Empty, "Email veya şifre yanlış");
            }
            var passwordCheck = await userManager.CheckPasswordAsync(hasUser, password);

            if (!passwordCheck)
            {
                ModelState.AddModelError(string.Empty, "Email veya şifre yanlış");

            }
            await signInManager.SignInAsync(hasUser, new AuthenticationProperties()
            {
                IsPersistent = true,
            });
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> Register(string email, string password,string userName)
        {
            //var email = "burak1@outlook.com";
            //var password = "Password12*";


            var hasUser = await userManager.FindByEmailAsync(email);
            if (hasUser != null)
            {
                ModelState.AddModelError(string.Empty, "Bu Eposta adresi kullanılıyor");
            }

            var newUser = new AppUser()
            {
                UserName= userName,
                Email = email,
            };
            var createdUser = await userManager.CreateAsync(newUser, password);
            if (!createdUser.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı Oluşturulamadı");
                return RedirectToAction("Index", "Home");

            }
            await signInManager.SignInAsync(newUser, isPersistent: false);
            return Redirect("/Identity/Account/Login");


        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Hiçbir şey yapmaz, sadece simüle eder.
            return Task.CompletedTask;
        }


        /*
        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}

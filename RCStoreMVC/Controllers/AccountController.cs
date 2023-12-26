using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RCStoreMVC.Identity;
using RCStoreMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using RCStoreMVC.Entity;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RCStoreMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext db = new DataContext();
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly RoleManager<ApplicationRole> RoleManager;


        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);

        }


        [Authorize]
        public async Task<ActionResult> Index()
        {
            var orders = await db.Orders
                .Where(i => i.UserName == User.Identity.Name)
                .OrderByDescending(i => i.OrderDate)
                .Select(i => new UserOrderModel()
                {
                    Id = i.Id,
                    OrderNumber = i.OrderNumber,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    Total = i.Total
                })
                .ToListAsync();

            return View(orders);
        }


        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new ApplicationUser
            {
                Name = model.Name,
                SurName = model.SurName,
                Email = model.EMail,
                UserName = model.UserName
            };

            var result = UserManager.Create(user, model.Password);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası.");
                return View(model);
            }

            if (RoleManager.RoleExists("user"))
                UserManager.AddToRole(user.Id, "user");

            return RedirectToAction("Login", "Account");
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = UserManager?.Find(model.UserName, model.Password);
            if (user == null)
            {
                ModelState.AddModelError("LoginUserError", "Geçersiz kullanıcı adı veya parola.");
                return View(model);
            }

            var identityClaims = UserManager?.CreateIdentity(user, "ApplicationCookie");
            if (HttpContext?.GetOwinContext()?.Authentication != null && identityClaims != null)
            {
                HttpContext.GetOwinContext().Authentication.SignIn(
                    new AuthenticationProperties { IsPersistent = model.RememberMe }, identityClaims);
            }

            return Redirect(returnUrl ?? Url.Action("Index", "Home"));
        }


        public ActionResult Logout()
        {

            HttpContext.GetOwinContext().Authentication?.SignOut();

            return RedirectToAction("Index", "Home");
        }

    }
}
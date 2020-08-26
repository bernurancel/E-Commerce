using E_Commerce.DAL;
using E_Commerce.Identity;
using E_Commerce.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace E_Commerce.Controllers
{
    public class AccountController : Controller
    {
        //private UserManager<ApplicationUser> UserManager;
        //private RoleManager<ApplicationRole> RoleManager;
        //// GET: Account
        //public AccountController()
        //{
        //    var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
        //    UserManager = new UserManager<ApplicationUser>(userStore);

        //    var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
        //    RoleManager = new RoleManager<ApplicationRole>(roleStore);
        //}

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
                if (model.Name != null && model.Password != null && model.Email != null)
                {
                    try
                    {
                        OrnekSite dt = new OrnekSite();
                        var user = new DAL.user1();
                        user.Name = model.Name;
                        user.Surname = model.Surname;
                        user.UserName = model.Username;
                        user.Password = model.Password;
                        user.Email = model.Email;
                        user.RoleId = 2;


                        dt.user1.Add(user);
                        dt.SaveChanges();
                        return RedirectToAction("Login", "Account");
                    }
                    catch (Exception ex)
                    {

                        ModelState.AddModelError("RegisterUserError", ex.Message);
                    }

                }
            return View();

        }


            //if (ModelState.IsValid)
            //{
            //    var user = new ApplicationUser();
            //    user.Name = model.Name;
            //    user.Surname = model.Surname;
            //    user.Email = model.Email;
            //    user.UserName = model.Username;
            //    var result = UserManager.Create(user, model.Password);
            //    if (result.Succeeded)
            //    {
            //        if (RoleManager.RoleExists("user"))
            //        {
            //            UserManager.AddToRole(user.Id, "user");
            //        }
            //        return RedirectToAction("Login", "Account");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası...");
            //    }
            //}
           
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login model ,string returnUrl)
        {

            if (model.Username != null && model.Password != null)
            {
                OrnekSite db = new OrnekSite();
                var a = db.user1.Where(d=>d.UserName==model.Username&& d.Password==model.Password).ToList();
                if (a.Count >= 1)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("Product", "Home");
                }
                else
                {
                    ViewBag.Mesaj = "Geçersiz Kullanıcı";
                    ModelState.AddModelError("LoginUserError", "Böyle Kullanıcı bulunmamaktadır");
                    return View();
                }
            }
          
            //if (ModelState.IsValid)
            //{
            //    var user = UserManager.Find(model.Username, model.Password);
            //    if (user != null)
            //    {
            //        var authManager = HttpContext.GetOwinContext().Authentication;
            //        var Identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
            //        var authProperties = new AuthenticationProperties();
            //        authProperties.IsPersistent = model.RememberMe;
            //        authManager.SignIn(authProperties, Identityclaims);
            //        if (!String.IsNullOrEmpty(returnUrl))
            //        {
            //            return Redirect(returnUrl);
            //        }
            //        return RedirectToAction("Index", "Home");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("LoginUserError", "Böyle Kullanıcı bulunmamaktadır");
            //    }
            //}
            return View(model);
        }
   

        //public ActionResult LoginPartial(DAL.Users us)
        //{
        //    DAL.OrnekSite db = new DAL.OrnekSite();
        //    var p = db.Users.Where(i => i.RoleId == 2);
            
        //    if (us.Roles2.RoleName == "admin")
        //    {
        //        Session.Add("Admin",us.Roles2.RoleName);
        //    }
        //    return RedirectToAction("Index", "Account");
        //}


        public ActionResult Index()
        {
            return View();
        }

       
    }
}
using System.Web.Mvc;
using System.Web.Security;
using Models;
using Tedu.OnlineShop.Areas.Admin.Code;
using Tedu.OnlineShop.Areas.Admin.Models;

namespace Tedu.OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        //// Login using session
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(LoginModel model)
        //{
        //    var result = (new AccountModel()).Login(model.UserName, model.Password);

        //    if (result && ModelState.IsValid)
        //    {
        //        SessionHelper.SetSession(new UserSession()
        //        {
        //            UserName = model.UserName
        //        });

        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "User name or password is incorrect. Please try again");
        //    }
        //    return View(model);
        //}

        // Login using CustomMembershipProvider
        // Login using session

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            if (Membership.ValidateUser(model.UserName, model.Password) && ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "User name or password is incorrect. Please try again");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}
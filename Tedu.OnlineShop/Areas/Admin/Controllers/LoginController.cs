using System.Web.Mvc;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var result = (new AccountModel()).Login(model.UserName, model.Password);

            if (result && ModelState.IsValid)
            {
                SessionHelper.SetSession(new UserSession()
                {
                    UserName = model.UserName
                });
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "User name or password is incorrect. Please try again");
            }
            return View(model);
        }
    }
}
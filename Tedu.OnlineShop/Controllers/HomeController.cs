using System.Web.Mvc;
using Tedu.OnlineShop.Models;

namespace Tedu.OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // Binding message to View from Controller to View by ViewBag
            ViewBag.WelcomeMessage = "Hello world from ViewBag";

            // Binding message to View from Controller to View by Model
            var messageModel = new MessageModel();
            messageModel.Welcome = "Hello world from Model";   
            return View(messageModel); // Pass to View
			
        }
    }
}
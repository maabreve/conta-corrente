using System.Web.Mvc;

namespace ContaCorrente.Web.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
    }
}
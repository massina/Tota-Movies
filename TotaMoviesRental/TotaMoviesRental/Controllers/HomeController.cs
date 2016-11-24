using System.Web.Mvc;

namespace TotaMoviesRental.Controllers
{
    public class HomeController : Controller
    {
        // [OutputCache(Duration = 60, Location = OutputCacheLocation.Client)]
        // [OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)] // Disable caching for this action.
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
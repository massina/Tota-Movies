using System.Web.Mvc;

namespace TotaMoviesRental.Controllers
{
    public class RentalsController : Controller
    {
        public ActionResult New()
        {
            return View();
        }
    }
}
using System.Web.Mvc;
using TotaMoviesRental.Core;
using TotaMoviesRental.Core.Models;
using TotaMoviesRental.Core.ViewModels;

namespace TotaMoviesRental.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = _unitOfWork.MembershipTypes.GetAll()
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _unitOfWork.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel(customer)
            {
                MembershipTypes = _unitOfWork.MembershipTypes.GetAll()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel(customer)
                {
                    MembershipTypes = _unitOfWork.MembershipTypes.GetAll()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _unitOfWork.Customers.Add(customer);
            else
            {
                var customerInDb = _unitOfWork.Customers.Single(m => m.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var customer = _unitOfWork.Customers.GetCustomerWithGenre(id);
            if (customer == null)
                return HttpNotFound("The customer you are looing for is not exsists");
            return View(customer);
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
        }
    }
}
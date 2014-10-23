using System.Linq;
using System.Threading;
using System.Net;
using System.Web.Mvc;
using MVC.Demo.Models;
using MVC.Demo.Repositories;

namespace MVC.Demo.Controllers
{
    [AllowAnonymous]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _repository;

        public CustomersController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View(_repository.GetCustomers().ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _repository.GetCustomerById(id.GetValueOrDefault(0));
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            if (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "nl")
            {
                return View(@"~\Views\nl\Customers\Create.cshtml");
            }

            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,FirstName,LastName,Email,Age,RequiredIntField")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(customer);
                return RedirectToAction("Index");
            }

            if (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "nl")
            {
                return View(@"~\Views\nl\Customers\Create.cshtml", customer);
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _repository.GetCustomerById(id.GetValueOrDefault(0));
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,FirstName,LastName,Email,Age,RequiredIntField")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _repository.GetCustomerById(id.GetValueOrDefault(0));
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = _repository.GetCustomerById(id);
            _repository.Delete(customer);

            return RedirectToAction("Index");
        }
    }
}

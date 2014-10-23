using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC.Demo.Controllers;
using MVC.Demo.Models;
using MVC.Demo.Repositories;
using MVC.Demo.Tests.Repositories;

namespace MVC.Demo.Tests.Controllers
{
    [TestClass]
    public class CustomersControllerTest
    {
        Customer GetCustomer(int id, string fName, string lName)
        {
            return new Customer
            {
                CustomerId = id,
                FirstName = fName,
                LastName = lName,
                Email = string.Format("{0}.{1}@realdolmen.com", fName, lName)
            };
        }

        private static CustomersController GetController(ICustomerRepository repository)
        {
            var controller = new CustomersController(repository);

            controller.ControllerContext = new ControllerContext()
            {
                Controller = controller,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };
            return controller;
        }

        [TestMethod]
        public void Index_Action_Retrieves_All_Customers_From_Repository()
        {
            // Arrange
            var customer1 = GetCustomer(1, "Wesley", "Cabus");
            var customer2 = GetCustomer(2, "Chuck", "Norris");
            var repository = new InMemCustomerRepository();

            repository.Create(customer1);
            repository.Create(customer2);
            var controller = GetController(repository);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            var model = ((IEnumerable<Customer>)result.ViewData.Model).ToList();
            CollectionAssert.Contains(model, customer1);
            CollectionAssert.Contains(model, customer2);
        }

        [TestMethod]
        public void Create_Post_ReturnsViewIfModelStateIsNotValid()
        {
            // Arrange
            var controller = GetController(new InMemCustomerRepository());

            // Simply executing a method during a unit test does just that - executes a method, and no more. 
            // The MVC pipeline doesn't run, so binding and validation don't run.
            controller.ModelState.AddModelError("", "mock error message");
            var model = GetCustomer(1, "", "");

            // Act
            var result = controller.Create(model);

            // Assert
            // Can't check if the ViewName equals "Create" unless we specifically say this in the controller action.
            // We can however check if the result is a ViewResult and not a RedirectToRouteResult (that would be returned if the save was successfull).
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Create_Post_PutsValidCustomerIntoRepository()
        {
            // Arrange
            var repository = new InMemCustomerRepository();
            var controller = GetController(repository);
            var contact = GetCustomer(1, "Wesley", "Cabus");

            // Act
            var result = controller.Create(contact);

            // Assert
            IEnumerable<Customer> contacts = repository.GetCustomers();
            Assert.IsTrue(contacts.Contains(contact));
        }

        [TestMethod]
        public void Create_Post_RedirectsToIndexAfterPuttingValidCustomerIntoRepository()
        {
            // Arrange
            var repository = new InMemCustomerRepository();
            var controller = GetController(repository);
            var contact = GetCustomer(1, "Wesley", "Cabus");

            // Act
            var result = controller.Create(contact) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        } 

        private class MockHttpContext : HttpContextBase
        {
            private readonly IPrincipal _user = new GenericPrincipal(
                     new GenericIdentity("someUser"), null /* roles */);

            public override IPrincipal User
            {
                get
                {
                    return _user;
                }
                set
                {
                    base.User = value;
                }
            }
        }
    }
}

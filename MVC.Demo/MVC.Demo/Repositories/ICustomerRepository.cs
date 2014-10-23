using System;
using System.Collections.Generic;
using MVC.Demo.Models;

namespace MVC.Demo.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();

        Customer GetCustomerById(int id);

        Customer Create(Customer entity);

        void Update(Customer entity);

        void Delete(Customer entity);
    }
}
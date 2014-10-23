using System.Collections.Generic;
using System.Data;
using System.Linq;
using MVC.Demo.Models;
using MVC.Demo.Repositories;

namespace MVC.Demo.Tests.Repositories
{
    public class InMemCustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _context = new List<Customer>();

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.ToList(); // Returns a copy, keeping our list in an original state
        }

        public Customer GetCustomerById(int id)
        {
            return _context.FirstOrDefault(c => c.CustomerId == id);
        }

        public Customer Create(Customer entity)
        {
            if (_context.Any(c => c.CustomerId == entity.CustomerId))
            {
                throw new ConstraintException("Primary Key violation");
            }

            _context.Add(entity);
            return entity;
        }

        public void Update(Customer entity)
        {
            _context.RemoveAll(c => c.CustomerId == entity.CustomerId);
            _context.Add(entity);
        }

        public void Delete(Customer entity)
        {
            _context.RemoveAll(c => c.CustomerId == entity.CustomerId);
        }
    }
}
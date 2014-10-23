using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MVC.Demo.Models;

namespace MVC.Demo.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly PoiDbContext _context;

        public CustomerRepository(PoiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers;
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public Customer Create(Customer entity)
        {
            _context.Customers.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Update(Customer entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Customer entity)
        {
            _context.Customers.Remove(entity);
            _context.SaveChanges();
        }
    }
}
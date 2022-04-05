using HMACAuthenticationDotNet5.Models;
using System;
using System.Linq;

namespace HMACAuthenticationDotNet5.Services
{
    public interface ICustomerService
    {
        public bool RegisterCustomer(string name, string identificationNo);
        public bool IsExist(string identificationNo);
    }

    public class CustomerService : ICustomerService
    {
        private readonly DatabaseContext _context;

        public CustomerService(DatabaseContext context)
        {
            _context = context;
        }

        public bool IsExist(string identificationNo)
        {
            return _context.Customers.Any(x => x.IdentificationNo.ToLower() == identificationNo.ToLower());
        }

        public bool RegisterCustomer(string name, string identificationNo)
        {
            try
            {
                _context.Customers.Add(new Customer()
                {
                    Id = Guid.NewGuid(),
                    IdentificationNo = identificationNo,
                    Name = name
                });
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

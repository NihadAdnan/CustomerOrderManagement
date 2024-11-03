using CustomerOrderManagement.Models.EntityModels;
using CustomerOrderManagement.Repository.Abstraction;
using CustomerOrderManagement.Repository.Repositories;
using CustomerOrderManagement.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Service
{
    public class CustomerService : Service<Customer>,ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository):base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
    }
}

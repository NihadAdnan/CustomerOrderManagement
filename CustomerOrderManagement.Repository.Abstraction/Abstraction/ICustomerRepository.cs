using CustomerOrderManagement.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Repository.Abstraction
{
    public interface ICustomerRepository:IRepository<Customer>
    {
    }
}

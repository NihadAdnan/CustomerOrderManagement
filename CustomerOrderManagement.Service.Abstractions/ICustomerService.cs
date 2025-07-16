using CustomerOrderManagement.Models.APIModels.Customer;
using CustomerOrderManagement.Models.EntityModels;

namespace CustomerOrderManagement.Service.Abstractions
{
    public interface ICustomerService : IService<Customer>
    {
        public List<Customer> GetAll(CustomerSearchDTO model);
    }
}

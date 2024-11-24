using CustomerOrderManagement.Models.APIModels.Customer;
using CustomerOrderManagement.Models.EntityModels;
using CustomerOrderManagement.Repository.Abstractions;
using CustomerOrderManagement.Service.Abstractions;

namespace CustomerOrderManagement.Service
{
    public class CustomerService : Service<Customer>,ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository):base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetAll(CustomerSearchDTO model)
        {
            var customers= _customerRepository.GetAll();
            if (!string.IsNullOrEmpty(model.FilterText))
            {
               customers= customers.Where(cu=>cu.Name.ToLower().Contains(model.FilterText.ToLower())
                ||cu.PhoneNo.ToLower().Contains(model.FilterText.ToLower())|| 
                cu.Address.ToLower().Contains(model.FilterText));
            }
            customers = customers.OrderBy(cu => cu.Name);
            var skipItems=(model.PageIndex-1) * model.PageSize;
            var takeItems = model.PageSize;
            var filteredCustomers=customers.Skip(skipItems<0?0:skipItems).Take(takeItems<=0?1:takeItems).ToList();
            return filteredCustomers;
        }
    }
}

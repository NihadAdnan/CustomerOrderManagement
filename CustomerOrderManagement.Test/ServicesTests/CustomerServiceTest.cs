using CustomerOrderManagement.Repository.Abstractions;
using CustomerOrderManagement.Service;
using Moq;

namespace CustomerOrderManagement.Test.ServicesTests
{
    public class CustomerServiceTest
    {
        private readonly CustomerService _service;
        private readonly Mock<ICustomerRepository> _customerServiceMock=new Mock<ICustomerRepository>();

        public CustomerServiceTest()
        {
            _service = new CustomerService(_customerServiceMock.Object);
        }

        [Fact]
        public async Task GetById_ShouldReturnCustomer_WhenCustomerExist()
        {
           /* var customer=await _service.GetById(cu=>cu.Id==4);
            if (customer != null)
            {
                Assert.Equal(customer.Id, 4);
            }*/
            
        }
    }
}

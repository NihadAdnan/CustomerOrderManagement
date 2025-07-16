using AutoMapper;
using CustomerOrderManagement.Models.APIModels.Customer;
using CustomerOrderManagement.Models.EntityModels;

namespace CustomerOrderManagement.API.Automapper
{
    public class AutoMapperConfiq : Profile
    {
        public AutoMapperConfiq()
        {
            CreateMap<CustomerCreateDTO, Customer>();
            CreateMap<Customer,CustomerCreateDTO>();
        }
    }
}

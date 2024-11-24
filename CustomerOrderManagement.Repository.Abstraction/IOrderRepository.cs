using CustomerOrderManagement.Models.APIModels.Order;
using CustomerOrderManagement.Models.EntityModels;

namespace CustomerOrderManagement.Repository.Abstractions
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<bool> PayNow(OrderCreateDTO orderCreateDTO);
    }
}

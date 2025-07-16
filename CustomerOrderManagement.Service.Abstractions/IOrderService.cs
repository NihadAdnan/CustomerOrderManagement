using CustomerOrderManagement.Models.APIModels.Order;
using CustomerOrderManagement.Models.EntityModels;

namespace CustomerOrderManagement.Service.Abstractions
{
    public interface IOrderService:IService<Order>
    {
        Task<bool> PayNow(OrderCreateDTO orderCreateDTO);
    }
}

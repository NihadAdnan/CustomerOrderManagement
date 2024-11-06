using CustomerOrderManagement.Models.EntityModels;
using CustomerOrderManagement.Repository.Abstractions;
using CustomerOrderManagement.Service.Abstractions;

namespace CustomerOrderManagement.Service
{
    public class OrderService:Service<Order>,IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository):base(orderRepository)
        {
            _orderRepository = orderRepository;
        }
    }
}

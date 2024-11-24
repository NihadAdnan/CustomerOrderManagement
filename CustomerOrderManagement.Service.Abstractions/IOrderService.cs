using CustomerOrderManagement.Models.APIModels.Order;
using CustomerOrderManagement.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Service.Abstractions
{
    public interface IOrderService:IService<Order>
    {
        Task<bool> PayNow(OrderCreateDTO orderCreateDTO);
    }
}

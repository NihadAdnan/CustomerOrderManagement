using CustomerOrderManagement.Models.APIModels.Order;
using CustomerOrderManagement.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Repository.Abstractions
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<bool> PayNow(OrderCreateDTO orderCreateDTO);
    }
}

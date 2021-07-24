using BlazorFunitureStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFunitureStore.Client.Sevices
{
    public interface IOrderService
    {
        Task SaveOrder(Order order);
        Task<int> GetNextNumber();
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetDetails(int id);
        Task DeleteOrder(int id);
    }
}

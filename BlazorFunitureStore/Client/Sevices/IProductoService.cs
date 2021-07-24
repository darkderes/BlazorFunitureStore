using BlazorFunitureStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFunitureStore.Client.Sevices
{
    public interface IProductoService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> GetByCategory(int productCategoryId);
        Task<Product> GetDetails(int id);

    }
}

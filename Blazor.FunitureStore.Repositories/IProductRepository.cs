using BlazorFunitureStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.FunitureStore.Repositories
{
    public  interface IProductRepository
    {
      Task<IEnumerable<Product>> GetByCategory(int prooductoCategoryId);
      Task<Product> GetDetails(int productId);
    }
}

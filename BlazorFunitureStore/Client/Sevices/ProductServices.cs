using BlazorFunitureStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorFunitureStore.Client.Sevices
{
    public class ProductServices : IProductoService
    {
        private readonly HttpClient _httpClient;
        public ProductServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<IEnumerable<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetByCategory(int productCategoryId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>($"api/product/GetByCategory/{productCategoryId}");
        }

        public async Task<Product> GetDetails(int id)
        {
             return await _httpClient.GetFromJsonAsync<Product>($"api/product/{ id }") ;
        }
    }
}

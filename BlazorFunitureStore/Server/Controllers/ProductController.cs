using Blazor.FunitureStore.Repositories;
using BlazorFunitureStore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFunitureStore.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet("GetByCategory/{productCategoryId}")]
        public async Task<IEnumerable<Product>> GetByCategory(int productCategoryId)
        { 
           return await _productRepository.GetByCategory(productCategoryId);
        }

        [HttpGet("{id}")]
        public async Task<Product> GetDetails(int id)
        {
            return await _productRepository.GetDetails(id);
        }
    }
}

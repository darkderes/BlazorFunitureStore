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
    public class ProductCategoryController : ControllerBase
    {   
        private readonly IproductCategoryRepository _productCategoryRepository;

        public ProductCategoryController(IproductCategoryRepository productCategoryRepository)
        {         
            _productCategoryRepository = productCategoryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductCategory>> Get()
        { 
            return await _productCategoryRepository.GetAll();
        }
    }
  
}

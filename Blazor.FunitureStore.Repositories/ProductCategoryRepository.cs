using BlazorFunitureStore.Shared;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.FunitureStore.Repositories
{
    public class ProductCategoryRepository : IproductCategoryRepository
    {
        private readonly IDbConnection _dbConecction;

        public ProductCategoryRepository(IDbConnection dbConnection)
        {
            _dbConecction = dbConnection;
                   
        }
        public async Task<IEnumerable<ProductCategory>> GetAll()
        {
            var sql = "Select Id,Name from ProductCategories";
            return await _dbConecction.QueryAsync<ProductCategory>(sql,new { });

        }
    }
}

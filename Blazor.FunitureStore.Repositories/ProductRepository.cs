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
    
    public class ProductRepository : IProductRepository
    {   
        private readonly IDbConnection _dbConecction;

         public ProductRepository(IDbConnection dbConnection)
         {
             _dbConecction = dbConnection;
         }
        public  async Task<IEnumerable<Product>> GetByCategory(int productoCategoryId)
        {
            var sql = @"select Id,Name,Price,CategoryId as ProductCategoryId from Products where CategoryId = @Id ";

            return await _dbConecction.QueryAsync<Product>(sql,new { Id = productoCategoryId });
        }

        public async Task<Product> GetDetails(int productId)
        {
            var sql = @"select Id,Name,Price,CategoryId as ProductCategoryId from Products where Id = @Id ";

            return await _dbConecction.QueryFirstOrDefaultAsync<Product>(sql, new { Id = productId });
        }
    }
}

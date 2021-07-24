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
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly IDbConnection _dbConecction;

        public OrderProductRepository(IDbConnection dbConnection)
        {
            _dbConecction = dbConnection;
        }

        public async Task<bool> DeleteOrderProductByOrder(int orderId)
        {
            var sql = @"Delete from OrderProducts where OrderId = @Id";

            var result = await _dbConecction.ExecuteAsync(sql,new { Id = orderId });

            return result > 0;

        }

        public async Task<IEnumerable<Product>> GetByOrder(int orderId)
        {
            var sql = @"SELECT 
                          Id
	                     ,Name
	                     ,Price
                         ,CategoryId as ProductCategoryId
                         ,Quantity
                         FROM OrderProducts inner join Products p on p.Id = ProductId where OrderId = @Id";
            return await _dbConecction.QueryAsync<Product>(sql, new { Id = orderId });
        }

        public async Task<bool> InsertOrderProduct(int orderId, Product product)
        {
            var sql = @"Insert into OrderProducts (OrderId,ProductId,Quantity) Values (@OrderId,@ProductId,@Quantity)";
            var result = await _dbConecction.ExecuteAsync(sql, new
            {
                OrderId = orderId,
                ProductId = product.Id,
                product.Quantity
            });
            return result > 0;
        }
    }
}

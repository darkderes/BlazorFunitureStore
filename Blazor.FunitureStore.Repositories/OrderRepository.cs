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
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnection _dbConecction;

        public OrderRepository(IDbConnection dbConnection)
        {
            _dbConecction = dbConnection;
        }

        public async Task DeleteOrder(int id)
        {
            var sql = "Delete from Orders where Id = @Id";
            await _dbConecction.ExecuteAsync(sql, new { Id = id });

        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var sql = @"SELECT o.Id
	                           ,OrderNumber
	                           ,ClientId
	                           ,OrderDate
	                           ,DeliveryDate
	                           ,Total
	                           ,c.LastName + ', ' + c.FirstName As ClientName
                        FROM Orders o
	                        INNER JOIN Clients c ON o.ClientId = c.Id ";
            return await _dbConecction.QueryAsync<Order>(sql,new { });
        }

        public async Task<Order> GetDetails(int id)
        {
            var sql = @"  SELECT Id
	                           ,OrderNumber
	                           ,ClientId
	                           ,OrderDate
	                           ,DeliveryDate
	                           ,Total	                          
                        FROM Orders 
	                    WHERE Id = @Id ";
            return await _dbConecction.QueryFirstOrDefaultAsync<Order>(sql, new { Id = id });
        }

        public async Task<int> GetNextId()
        {
            var sql = @"Select IDENT_CURRENT('Orders') + 1  ";
            return await _dbConecction.QueryFirstAsync<int>(sql, new { });
        }

        public async Task<int> GetNextNumber()
        {
            var sql = @"Select max(OrderNumber) + 1 from Orders ";
            return await _dbConecction.QueryFirstAsync<int>(sql,new { });
        }

        public async Task<bool> InsertOrder(Order order)
        {
            var sql = @"insert into Orders(OrderNumber,ClientId,OrderDate,DeliveryDate,Total) values (@OrderNumber,@ClientId,@OrderDate,@DeliveryDate,@Total)";
            var result = await _dbConecction.ExecuteAsync(sql,new { 
            
                order.OrderNumber,
                order.ClientId,
                order.OrderDate,
                order.DeliveryDate,
                order.Total
            });

            return result > 0;
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            var sql = @"update Orders set ClientId = @ClientId,OrderDate = @OrderDate,DeliveryDate = @DeliveryDate where Id = @Id";
            var result = await _dbConecction.ExecuteAsync(sql, new
            {

                order.OrderNumber,
                order.ClientId,
                order.OrderDate,
                order.DeliveryDate,
                order.Total,
                order.Id
            });

            return result > 0;
        }
    }
}

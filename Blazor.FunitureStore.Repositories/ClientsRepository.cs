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
    public class ClientsRepository : IClientsRepository
    {
        private readonly IDbConnection _dbConecction;

        public ClientsRepository(IDbConnection dbConnection)
        {
            _dbConecction = dbConnection;
        }

        public async Task<IEnumerable<Clients>> GetAllClients()
        {
            var sql = @"SELECT Id
                     ,FirstName
                     ,LastName
                     ,BirthDate
                     ,Phone
                     ,Address
                     FROM Clients";
            return await _dbConecction.QueryAsync<Clients>(sql, new { });
        }
    }
}

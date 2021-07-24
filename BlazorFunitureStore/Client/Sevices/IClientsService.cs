using BlazorFunitureStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFunitureStore.Client.Sevices
{
    public interface IClientsService
    {
        Task<IEnumerable<Clients>> GetAllClients();
    }
}

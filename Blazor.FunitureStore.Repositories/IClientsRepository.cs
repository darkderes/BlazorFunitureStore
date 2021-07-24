using BlazorFunitureStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.FunitureStore.Repositories
{
    public interface IClientsRepository
    {
       Task<IEnumerable<Clients>> GetAllClients();
    }
}

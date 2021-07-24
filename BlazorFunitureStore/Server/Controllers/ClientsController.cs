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
    public class ClientsController : ControllerBase
    {
        private readonly IClientsRepository _clientsRepository;
        public ClientsController(IClientsRepository clientsRepository)
        {  
            _clientsRepository = clientsRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Clients>> GetClient()
        {
            return await _clientsRepository.GetAllClients(); 
        }

    }
}

using System;
using Microsoft.AspNetCore.Mvc;
using Timesheet.Core;

namespace Timesheet.Api.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly ClientService clientService;
        private readonly ClientsSearchFactory clientsSearchFactory;
        private readonly ClientsFactory clientsFactory;
        private readonly ClientDtoMapper clientDtoMapper;
        private readonly PagedClientsDtoMapper pagedClientsDtoMapper;

        public ClientsController(ClientService clientService, ClientsSearchFactory clientsSearchFactory, ClientsFactory clientsFactory, ClientDtoMapper clientDtoMapper, PagedClientsDtoMapper pagedClientsDtoMapper)
        {
            this.clientService = clientService;
            this.clientsSearchFactory = clientsSearchFactory;
            this.clientsFactory = clientsFactory;
            this.clientDtoMapper = clientDtoMapper;
            this.pagedClientsDtoMapper = pagedClientsDtoMapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ClientDto clientDto)
        {
            Client createdClient = clientsFactory.Create(clientDto);
            clientService.Add(createdClient);
            return Created($"/api/clients/{createdClient.Id}", createdClient.Id);
        }

        [HttpGet]
        public IActionResult Search([FromQuery] ClientSearchParamsDto query)
        {
            var clientSearchParams = clientsSearchFactory.Create(query);
            PagedClients pagedClients = clientService.Search(clientSearchParams);
            return Ok(pagedClientsDtoMapper.Map(pagedClients));
        }

        [HttpDelete("{Id}")]
        public void Delete(Guid Id)
        {
            clientService.Delete(Id);
        }

        [HttpPut("{Id}")]
        public IActionResult Update(Guid Id, [FromBody] ClientDto clientDto)
        {
            Client updatedClient = clientsFactory.Update(clientDto);
            clientService.Update(updatedClient, Id);
            return Created($"/api/clients/{updatedClient.Id}", clientDtoMapper.Map(updatedClient));
        }
    }
}

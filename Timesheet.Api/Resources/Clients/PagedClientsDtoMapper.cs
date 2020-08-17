using System.Linq;
using Timesheet.Core;

namespace Timesheet.Api.Controllers
{
    public class PagedClientsDtoMapper
    {
        private readonly ClientDtoMapper _clientDtoMapper;
        public PagedClientsDtoMapper(ClientDtoMapper clientDtoMapper)
        {
            _clientDtoMapper = clientDtoMapper;
        }
        public PagedClientsDto Map(PagedClients pagedClients)
        {
            PagedClientsDto pagedclientsDto = new PagedClientsDto();
            pagedclientsDto.Clients = pagedClients.Clients.Select(pagedClient => _clientDtoMapper.Map(pagedClient));
            pagedclientsDto.PageNumber = pagedClients.PageNumber;
            pagedclientsDto.PageSize = pagedClients.PageSize;
            pagedclientsDto.TotalItems = pagedClients.TotalItems;
            return pagedclientsDto;
        }
    }
}

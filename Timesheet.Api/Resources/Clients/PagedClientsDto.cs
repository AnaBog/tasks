using System;
using System.Collections.Generic;
namespace Timesheet.Api.Controllers
{
    public struct PagedClientsDto
    {
        public IEnumerable<ClientDto> Clients { get; set; }
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}

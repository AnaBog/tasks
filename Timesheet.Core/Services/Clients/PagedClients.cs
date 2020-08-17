using System.Collections.Generic;

namespace Timesheet.Core
{
    public class PagedClients
    {
        public IEnumerable<Client> Clients { get; set; }
        public int TotalItems { get; private set; }
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }

        public PagedClients(IEnumerable<Client> Clients, int TotalItems, int PageNumber, int PageSize)
        {
            this.Clients = Clients;
            this.TotalItems = TotalItems;
            this.PageNumber = PageNumber;
            this.PageSize = PageSize;
        }
    }
}
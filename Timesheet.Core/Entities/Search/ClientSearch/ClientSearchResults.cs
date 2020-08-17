using CSharpFunctionalExtensions;
using System.Collections.Generic;

namespace Timesheet.Core
{
    public class ClientSearchResults
    {
        private readonly List<Client> clients;
        private readonly int totalNumberOfClients;
        private readonly int pageLimit;

        public ClientSearchResults(List<Client> clients, int totalNumberOfClients, int pageLimit)
        {
            this.clients = clients;
            this.totalNumberOfClients = totalNumberOfClients;
            this.pageLimit = pageLimit;
        }

        public List<Client> Clients => clients;
        public int TotalNumberOfClients => totalNumberOfClients;
        public int PageLimit => pageLimit;
    }
}

using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Timesheet.Core;
using Timesheet.Core.Repositories;

namespace Timesheet.Infrastructure
{
    public class ClientRepository : IClientRepository
    {
        private readonly List<Client> clients;

        public ClientRepository()
        {
            this.clients = new List<Client>();
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000000c"), new ClientName("Googlic"), new Address("Palo Alto Road 4"), new City("San Diego"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000001c"), new ClientName("Watermelon"), new Address("Palo Alto Road 3"), new City("Field"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000002c"), new ClientName("Melon"), new Address("Palo Alto Road 2"), new City("Green Field"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000003c"), new ClientName("Strawberry"), new Address("Palo Alto Road 1"), new City("Purple Field"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000004c"), new ClientName("Neowise"), new Address("Palo Alto Road 7"), new City("Green Field Diego"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000005c"), new ClientName("Comet"), new Address("Palo Alto Road 8"), new City("Blue Field"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000006c"), new ClientName("Star"), new Address("Palo Alto Road 9"), new City("Cloud"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000007c"), new ClientName("Saturn"), new Address("Palo Alto Road 9"), new City("Cloud"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000008c"), new ClientName("Jupiter"), new Address("Palo Alto Road 9"), new City("Cloud"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000009c"), new ClientName("Mercury"), new Address("Palo Alto Road 9"), new City("Cloud"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000010c"), new ClientName("Neptune"), new Address("Palo Alto Road 9"), new City("Cloud"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000011c"), new ClientName("Pluto"), new Address("Palo Alto Road 9"), new City("Cloud"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000012c"), new ClientName("Earth"), new Address("Palo Alto Road 9"), new City("Cloud"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000013c"), new ClientName("Mars"), new Address("Palo Alto Road 9"), new City("Cloud"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000014c"), new ClientName("Moon"), new Address("Palo Alto Road 9"), new City("Cloud"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000015c"), new ClientName("MoonMoon"), new Address("Palo Alto Road 9"), new City("Cloud"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000016c"), new ClientName("Star1"), new Address("Palo Alto Road 9"), new City("Cloud"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000017c"), new ClientName("Star2"), new Address("Palo Alto Road 9"), new City("Cloud"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000018c"), new ClientName("Star3"), new Address("Palo Alto Road 9"), new City("Cloud"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000019c"), new ClientName("Star4"), new Address("Palo Alto Road 9"), new City("Cloud"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000020c"), new ClientName("Star5"), new Address("Palo Alto Road 9"), new City("Cloud"), new Country("Serbia"), new ZipCode("10000")));
            this.clients.Add(new Client(Guid.Parse("00000000-0000-0000-0000-00000000021c"), new ClientName("Star6"), new Address("Palo Alto Road 9"), new City("Cloud"), new Country("Serbia"), new ZipCode("10000")));
        }

        public void Add(Client client)
        {
            clients.Add(client);
        }

        public void Delete(Guid id)
        { 
            clients.RemoveAll(client => client.Id == id);
        }

        public Maybe<Client> GetById(Guid id)
        {
            return clients.Find(client => client.Id == id);
        }

        public Maybe<Client> GetByName(ClientName name)
        {
            return clients.Find(client => client.Name == name);
        }

        public PagedClients SearchClients(ClientSearchParams query)
        {
            var searchQuery = clients
                .Where(client => client.Name.Contains(query.SearchText))
                .Where(client => client.Name.StartsWith(query.FirstLetter));
            
            int foundClients = searchQuery.Count();

            IEnumerable<Client> filteredClients = searchQuery
                .Skip(Constants.PageSize * (query.PageNumber - 1))
                .Take(Constants.PageSize)
                .ToList();

            PagedClients pagedClients = new PagedClients(filteredClients, foundClients, query.PageNumber, Constants.PageSize);
            return pagedClients;
        }

        public Client Update(Client client, Guid id)
        {
            Client oldClient = clients.Find(client => client.Id == id);
            clients.Remove(oldClient);
            clients.Add(client);
            return client;
        }
    }
}

using System;
using Timesheet.Core;

namespace Timesheet.Api.Controllers
{
    public class ClientsFactory
    {
        public Client Create(ClientDto clientDto)
        {
            var clientId = Guid.NewGuid();
            return new Client(
                clientId, 
                new ClientName(clientDto.Name), 
                new Address(clientDto.Address), 
                new City(clientDto.City), 
                new Country(clientDto.Country), 
                new ZipCode(clientDto.ZipCode.ToString()
                ));
        }

        public Client Update(ClientDto clientDto)
        {
            return new Client(
                Guid.Parse(clientDto.Id), 
                new ClientName(clientDto.Name), 
                new Address(clientDto.Address), 
                new City(clientDto.City), 
                new Country(clientDto.Country), 
                new ZipCode(clientDto.ZipCode.ToString()
                ));
        }
    }
}
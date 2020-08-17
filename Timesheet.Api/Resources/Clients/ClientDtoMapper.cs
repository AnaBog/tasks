using Timesheet.Core;

namespace Timesheet.Api.Controllers
{
    public class ClientDtoMapper
    {
        public ClientDto Map(Client client)
        {
            ClientDto clientDto = new ClientDto();
            clientDto.Id = client.Id.ToString();
            clientDto.Name = client.Name;
            clientDto.Address = client.Address;
            clientDto.City = client.City;
            clientDto.Country = client.Country;
            clientDto.ZipCode = client.ZipCode;
            return clientDto;
        }
    }
}

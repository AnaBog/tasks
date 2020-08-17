using CSharpFunctionalExtensions;
using System;
using Timesheet.Core.Repositories;

namespace Timesheet.Core
{
    public class ClientService
    {
        private IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public void Add(Client client)
        {
            Maybe<Client> maybeClient = _clientRepository.GetByName(client.Name);

            if (maybeClient.HasValue)
            {
                throw new InvalidOperationException("You cannot add the same name again");
            }
            _clientRepository.Add(client);
        }

        public void Delete(Guid id)
        {
            Maybe<Client> maybeClient = _clientRepository.GetById(id);

            if (maybeClient.HasNoValue)
            {
                throw new InvalidOperationException("You cannot delete a non-existing client");
            }
            _clientRepository.Delete(id);
        }

        public PagedClients Search(ClientSearchParams query)
        {
            return _clientRepository.SearchClients(query);
        }

        public Client Update(Client client, Guid id)
        {
            Maybe<Client> maybeClient = _clientRepository.GetById(id);

            if (maybeClient.HasNoValue)
            {
                throw new InvalidOperationException("You cannot update a non-existing client.");
            }
            return _clientRepository.Update(client, id);
        }
    }
}

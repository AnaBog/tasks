using CSharpFunctionalExtensions;
using System;

namespace Timesheet.Core.Repositories
{
    public interface IClientRepository
    {
        void Add(Client client);
        void Delete(Guid Id);
        Client Update(Client client, Guid id);
        Maybe<Client> GetByName(ClientName name);
        Maybe<Client> GetById(Guid id);
        PagedClients SearchClients(ClientSearchParams query);
    }
}

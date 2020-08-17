using CSharpFunctionalExtensions;
using Timesheet.Core;

namespace Timesheet.Api.Controllers
{
    public class ClientsSearchFactory
    {
        public ClientSearchParams Create(ClientSearchParamsDto query)
        {
            Maybe<FirstLetter> firstLetter = string.IsNullOrEmpty(query.FirstLetter)
                ? Maybe<FirstLetter>.None
                : new FirstLetter(query.FirstLetter);

            return new ClientSearchParams(new SearchText(query.SearchText), firstLetter, new PageNumber(query.PageNumber));
        }
    }
}
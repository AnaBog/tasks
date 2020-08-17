using CSharpFunctionalExtensions;
using Timesheet.Core;

namespace Timesheet.Api.Controllers
{
    public class EmployeesSearchFactory
    {
        public EmployeeSearchParams Create(EmployeeSearchParamsDto query)
        {
            Maybe<FirstLetter> firstLetter = string.IsNullOrEmpty(query.FirstLetter)
                ? Maybe<FirstLetter>.None
                : new FirstLetter(query.FirstLetter);

            return new EmployeeSearchParams(new SearchText(query.SearchText), firstLetter, new PageNumber(query.PageNumber));
        }
    }
}

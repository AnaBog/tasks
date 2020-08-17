using CSharpFunctionalExtensions;
using Timesheet.Core;

namespace Timesheet.Api.Controllers
{
    public class ProjectsSearchFactory
    {
        public ProjectSearchParams Create(ProjectSearchParamsDto query)
        {
            Maybe<FirstLetter> firstLetter = string.IsNullOrEmpty(query.FirstLetter)
                ? Maybe<FirstLetter>.None
                : new FirstLetter(query.FirstLetter);

            return new ProjectSearchParams(new SearchText(query.SearchText), firstLetter, new PageNumber(query.PageNumber));
        }
    }
}
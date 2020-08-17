using CSharpFunctionalExtensions;

namespace Timesheet.Core
{
    public class ClientSearchParams
    {
        public ClientSearchParams(SearchText searchText, Maybe<FirstLetter> firstLetter, PageNumber pageNumber)
        {
            this.SearchText = searchText;
            this.FirstLetter = firstLetter;
            this.PageNumber = pageNumber;
        }

        public SearchText SearchText { get; }
        public Maybe<FirstLetter> FirstLetter { get; }
        public PageNumber PageNumber { get; }
    }
}

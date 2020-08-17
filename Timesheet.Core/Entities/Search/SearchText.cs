
namespace Timesheet.Core
{
    public class SearchText
    {
        private readonly string searchText;

        public bool IsEmpty => searchText.Length == 0;

        public SearchText(string searchText)
        {
            if (searchText == null)
            {
                this.searchText = string.Empty;
            }
            else
            {
                this.searchText = searchText;
            }
        }

        public static implicit operator string(SearchText text) => text.searchText;

        public override string ToString()
        {
            return searchText;
        }
    }
}
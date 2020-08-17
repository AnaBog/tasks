using System;

namespace Timesheet.Core
{
    public class PageNumber
    {
        private readonly int pageNumber;

        public PageNumber(int pageNumber)
        {
            if (pageNumber < 1)
            {
                throw new ArgumentException("Page number cannot be 0 or less.");
            }
            this.pageNumber = pageNumber;
        }
        public static implicit operator int(PageNumber pageNumber) => pageNumber.pageNumber;
    }
}
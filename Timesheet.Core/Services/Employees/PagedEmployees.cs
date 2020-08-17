using System;
using System.Collections.Generic;
using System.Text;

namespace Timesheet.Core
{
    public class PagedEmployees
    {
        public IEnumerable<Employee> Employees { get; set; }
        public int TotalItems { get; private set; }
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }

        public PagedEmployees(IEnumerable<Employee> Employees, int TotalItems, int PageNumber, int PageSize)
        {
            this.Employees = Employees;
            this.TotalItems = TotalItems;
            this.PageNumber = PageNumber;
            this.PageSize = PageSize;
        }
    }
}

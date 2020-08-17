using System.Linq;
using Timesheet.Core;

namespace Timesheet.Api.Controllers
{
    public class PagedEmployeesDtoMapper
    {
        private readonly EmployeeDtoMapper _employeeDtoMapper;
        public PagedEmployeesDtoMapper(EmployeeDtoMapper employeeDtoMapper)
        {
            _employeeDtoMapper = employeeDtoMapper;
        }
        public PagedEmployeesDto Map(PagedEmployees pagedEmployees)
        {
            PagedEmployeesDto pagedEmployeesDto = new PagedEmployeesDto();
            pagedEmployeesDto.Employees = pagedEmployees.Employees.Select(pagedEmployee => _employeeDtoMapper.Map(pagedEmployee));
            pagedEmployeesDto.PageNumber = pagedEmployees.PageNumber;
            pagedEmployeesDto.PageSize = pagedEmployees.PageSize;
            pagedEmployeesDto.TotalItems = pagedEmployees.TotalItems;
            return pagedEmployeesDto;
        }
    }
}

using System;
using Microsoft.AspNetCore.Mvc;
using Timesheet.Core;

namespace Timesheet.Api.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService employeeService;
        private readonly EmployeesSearchFactory employeesSearchFactory;
        private readonly EmployeesFactory employeesFactory;
        private readonly EmployeeDtoMapper employeeDtoMapper;
        private readonly PagedEmployeesDtoMapper pagedEmployeesDtoMapper;

        public EmployeesController(EmployeeService employeeService, EmployeesSearchFactory employeesSearchFactory, EmployeesFactory employeesFactory, EmployeeDtoMapper employeeDtoMapper, PagedEmployeesDtoMapper pagedEmployeesDtoMapper)
        {
            this.employeeService = employeeService;
            this.employeesSearchFactory = employeesSearchFactory;
            this.employeesFactory = employeesFactory;
            this.employeeDtoMapper = employeeDtoMapper;
            this.pagedEmployeesDtoMapper = pagedEmployeesDtoMapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] EmployeeDto employeeDto)
        {
            Employee createdEmployee = employeesFactory.Create(employeeDto);
            employeeService.Add(createdEmployee);
            return Created($"/api/employees/{createdEmployee.Id}", createdEmployee.Id);
        }

        //[HttpGet]
        //public IActionResult Search([FromQuery] EmployeeSearchParamsDto query)
        //{
        //    var employeeSearchParams = employeesSearchFactory.Create(query);
        //    PagedEmployees pagedEmployees = employeeService.Search(employeeSearchParams);
        //    return Ok(pagedEmployeesDtoMapper.Map(pagedEmployees));
        //}

        [HttpDelete("{Id}")]
        public void Delete(Guid Id)
        {
            employeeService.Delete(Id);
        }

        [HttpPut("{Id}")]
        public IActionResult Update(Guid Id, [FromBody] EmployeeDto employeeDto)
        {
            Employee updatedEmployee = employeesFactory.Update(employeeDto);
            employeeService.Update(updatedEmployee, Id);
            return Created($"/api/clients/{updatedEmployee.Id}", employeeDtoMapper.Map(updatedEmployee));
        }
    }
}
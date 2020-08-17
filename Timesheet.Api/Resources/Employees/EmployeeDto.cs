namespace Timesheet.Api.Controllers
{
    public struct EmployeeDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string HoursPerWeek { get; set; }
        public string Email { get; set; }
        public bool EmployeeStatus { get; set; }
        public string Role { get; set; }
    }
}

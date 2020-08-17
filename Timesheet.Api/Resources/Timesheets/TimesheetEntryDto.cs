namespace Timesheet.Api.Controllers
{
    public struct TimesheetEntryDto
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string ProjectId { get; set; }
        public string CategoryId { get; set; }
        public string EntryDescription { get; set; }
        public double Time { get; set; }
        public int Overtime { get; set; }
    }
}
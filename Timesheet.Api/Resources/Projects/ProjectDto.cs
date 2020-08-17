using System;

namespace Timesheet.Api.Controllers
{
    public struct ProjectDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ClientId { get; set; }
        public string Lead { get; set; }
        public string Status { get; set; }
    }
}
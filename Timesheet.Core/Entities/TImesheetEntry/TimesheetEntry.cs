using System;

namespace Timesheet.Core
{
    public class TimesheetEntry
    {
        private readonly Guid clientId;
        private readonly Guid projectId;
        private readonly EntryDescription entryDescription;
        private readonly Time time;
        private readonly Overtime overtime;

        public TimesheetEntry(Guid id, Guid clientId, Guid projectId, EntryDescription entryDescription, Time time, Overtime overtime)
        {
            this.Id = id;
            this.clientId = clientId;
            this.projectId = projectId;
            this.entryDescription = entryDescription;
            this.time = time;
            this.overtime = overtime;
        }

        public Guid Id { get; }
        public Guid ClientId => clientId;
        public Guid ProjectId => projectId;
        public EntryDescription EntryDescription => entryDescription;
        public Time Time => time;
        public Overtime Overtime => overtime;
    }
}
using System;

namespace Timesheet.Core
{
    public class Project
    {
        private readonly ProjectName name;
        private readonly Description description;
        private readonly Guid clientId;
        private readonly Lead lead;
        private readonly Status status;
        private readonly Guid id;

        public Project(Guid id, ProjectName name, Description description, Guid clientId, Lead lead, Status status)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.clientId = clientId;
            this.lead = lead;
            this.status = status;
        }
        public ProjectName Name => name;
        public Guid Id => id;
        public Description Description => description;
        public Lead Lead => lead;
        public Status Status => status;
        public Guid ClientId => clientId;
    }
}

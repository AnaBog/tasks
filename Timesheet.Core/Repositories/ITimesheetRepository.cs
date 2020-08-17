using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace Timesheet.Core.Repositories
{
    public interface ITimesheetRepository
    {
        void Add(DailyTimesheet dailyTimesheet);
        void Delete(Guid Id);
        DailyTimesheet Update(DailyTimesheet dailyTimesheet, Guid id);
        DailyTimesheet GetByDate(DateTime date);
        Maybe<DailyTimesheet> GetById(Guid id);
        IEnumerable<DailyTimesheet> GetByDateRange(DateTime from, DateTime to);
    }
}

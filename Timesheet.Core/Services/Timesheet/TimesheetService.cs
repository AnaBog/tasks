using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using Timesheet.Core.Repositories;

namespace Timesheet.Core
{
    public class TimesheetService
    {
        private ITimesheetRepository _timesheetRepository;

        public TimesheetService(ITimesheetRepository timesheetRepository)
        {
            _timesheetRepository = timesheetRepository;
        }

        public Guid CreateOrUpdate(DailyTimesheet dailyTimesheet, Guid id)
        {
            Maybe<DailyTimesheet> maybeDailyTimesheet = _timesheetRepository.GetById(dailyTimesheet.Id);

            if (maybeDailyTimesheet.HasNoValue)
            {
                _timesheetRepository.Add(dailyTimesheet);
            }
            else if(maybeDailyTimesheet.HasValue)
            {
                _timesheetRepository.Update(dailyTimesheet, id);
            }

            return dailyTimesheet.Id;
        }

        public DailyTimesheet GetByDate(DateTime date)
        {
            return _timesheetRepository.GetByDate(date);
        }

        public IEnumerable<DailyTimesheet> GetByDateRange(DateTime from, DateTime to)
        {
            return _timesheetRepository.GetByDateRange(from, to);
            
        }
    }
}

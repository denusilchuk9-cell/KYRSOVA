using System.Collections.Generic;
using System.Linq;
using ElectronicJournal.Models;

namespace ElectronicJournal.Business
{
    public class GradeCalculator
    {
        public double CalculateAverage(List<Grade> grades)
        {
            if (grades == null || grades.Count == 0)
                return 0;

            return grades.Average(g => g.Value);
        }

        public double CalculateAttendancePercentage(List<Attendance> attendances)
        {
            if (attendances == null || attendances.Count == 0)
                return 0;

            int present = attendances.Count(a => a.IsPresent);
            return (double)present / attendances.Count * 100;
        }
    }
}
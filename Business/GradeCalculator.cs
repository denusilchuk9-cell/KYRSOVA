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

        public double CalculateAverageByStudent(List<Grade> grades, int studentId)
        {
            var studentGrades = grades.Where(g => g.StudentId == studentId).ToList();
            if (studentGrades.Count == 0)
                return 0;
            return studentGrades.Average(g => g.Value);
        }

        public double CalculateAverageBySubject(List<Grade> grades, int subjectId)
        {
            var subjectGrades = grades.Where(g => g.SubjectId == subjectId).ToList();
            if (subjectGrades.Count == 0)
                return 0;
            return subjectGrades.Average(g => g.Value);
        }

        public double CalculateAttendancePercentage(List<Attendance> attendances)
        {
            if (attendances == null || attendances.Count == 0)
                return 0;
            int present = attendances.Count(a => a.IsPresent);
            return (double)present / attendances.Count * 100;
        }

        public double CalculateAttendancePercentageByStudent(List<Attendance> attendances, int studentId)
        {
            var studentAttendance = attendances.Where(a => a.StudentId == studentId).ToList();
            if (studentAttendance.Count == 0)
                return 0;
            int present = studentAttendance.Count(a => a.IsPresent);
            return (double)present / studentAttendance.Count * 100;
        }
    }
}

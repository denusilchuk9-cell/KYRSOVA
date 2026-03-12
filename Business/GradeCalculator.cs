using System.Collections.Generic;
using System.Linq;
using ElectronicJournal.Models;

namespace ElectronicJournal.Business
{
    public class GradeCalculator
    {
        private IAverageStrategy _strategy;

        public GradeCalculator()
        {
            _strategy = new SimpleAverageStrategy();
        }

        public void SetStrategy(IAverageStrategy strategy)
        {
            _strategy = strategy;
        }

        public string GetStrategyName()
        {
            if (_strategy is SimpleAverageStrategy)
                return "Проста (Simple)";
            else if (_strategy is WeightedAverageStrategy)
                return "Зважена (Weighted)";
            else
                return "Невідома";
        }

        public double CalculateAverage(List<Grade> grades)
        {
            return _strategy.Calculate(grades);
        }

        public double CalculateAverageByStudent(List<Grade> grades, int studentId)
        {
            var studentGrades = grades.Where(g => g.StudentId == studentId).ToList();
            return _strategy.Calculate(studentGrades);
        }

        public double CalculateAverageBySubject(List<Grade> grades, int subjectId)
        {
            var subjectGrades = grades.Where(g => g.SubjectId == subjectId).ToList();
            return _strategy.Calculate(subjectGrades);
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
using System.Collections.Generic;
using System.Linq;
using ElectronicJournal.Interfaces;
using ElectronicJournal.Models;

namespace ElectronicJournal.Data
{
    public class GradeRepository : IGradeRepository
    {
        private static List<Grade> _grades = new List<Grade>();
        private static int _nextId = 1;

        public List<Grade> GetAll() => _grades.ToList();
        public Grade GetById(int id) => _grades.FirstOrDefault(g => g.Id == id);

        public void Add(Grade grade)
        {
            grade.Id = _nextId++;
            _grades.Add(grade);
        }

        public void Update(Grade grade)
        {
            var existing = GetById(grade.Id);
            if (existing != null)
            {
                existing.StudentId = grade.StudentId;
                existing.SubjectId = grade.SubjectId;
                existing.Value = grade.Value;
                existing.Date = grade.Date;
                existing.GradeType = grade.GradeType;
            }
        }

        public void Delete(int id)
        {
            var g = GetById(id);
            if (g != null) _grades.Remove(g);
        }

        public List<Grade> GetByStudent(int studentId) => _grades.Where(g => g.StudentId == studentId).ToList();
        public List<Grade> GetBySubject(int subjectId) => _grades.Where(g => g.SubjectId == subjectId).ToList();

        public float GetAverage(int studentId, int subjectId)
        {
            var grades = _grades.Where(g => g.StudentId == studentId && g.SubjectId == subjectId).ToList();
            if (!grades.Any()) return 0;
            return (float)grades.Average(g => g.Value);
        }
    }
}
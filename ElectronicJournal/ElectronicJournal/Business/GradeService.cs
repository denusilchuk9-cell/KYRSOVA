using System.Collections.Generic;
using ElectronicJournal.Interfaces;
using ElectronicJournal.Models;

namespace ElectronicJournal.Business
{
    public class GradeService
    {
        private IGradeRepository _gradeRepository;
        private IStudentRepository _studentRepository;
        private ISubjectRepository _subjectRepository;
        private IAverageStrategy _strategy;

        public GradeService(IGradeRepository gradeRepo, IStudentRepository studentRepo, ISubjectRepository subjectRepo)
        {
            _gradeRepository = gradeRepo;
            _studentRepository = studentRepo;
            _subjectRepository = subjectRepo;
            _strategy = new SimpleAverageStrategy();
        }

        public void SetStrategy(IAverageStrategy strategy) => _strategy = strategy;

        public string GetStrategyName()
        {
            if (_strategy is SimpleAverageStrategy) return "Проста (Simple)";
            if (_strategy is WeightedAverageStrategy) return "Зважена (Weighted)";
            return "Невідома";
        }

        public List<Grade> GetGradesByStudent(int studentId) => _gradeRepository.GetByStudent(studentId);
        public void AddGrade(Grade grade) => _gradeRepository.Add(grade);
        public void DeleteGrade(int id) => _gradeRepository.Delete(id);
        public float GetStudentAverage(int studentId, int subjectId) => _gradeRepository.GetAverage(studentId, subjectId);
    }
}
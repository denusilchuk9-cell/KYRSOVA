using System;

namespace ElectronicJournal.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public string GradeType { get; set; }
    }
}
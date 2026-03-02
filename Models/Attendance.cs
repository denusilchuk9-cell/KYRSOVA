using System;

namespace ElectronicJournal.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        public string AbsenceReason { get; set; }
    }
}
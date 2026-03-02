namespace ElectronicJournal.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public int Hours { get; set; }
        public string ControlForm { get; set; } // "Залік" або "Іспит"
    }
}
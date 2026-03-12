using System.Data.SQLite;

namespace ElectronicJournal.Data
{
    public class DatabaseConnection
    {
        private string _connectionString;

        public DatabaseConnection()
        {
            _connectionString = "Data Source=journal.db;Version=3;";
            CreateDatabase();
        }

        private void CreateDatabase()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string studentTable = @"CREATE TABLE IF NOT EXISTS Students (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    FirstName TEXT NOT NULL,
                    LastName TEXT NOT NULL,
                    MiddleName TEXT,
                    RecordBookNumber TEXT,
                    Email TEXT,
                    Phone TEXT)";

                string subjectTable = @"CREATE TABLE IF NOT EXISTS Subjects (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    TeacherName TEXT,
                    Hours INTEGER,
                    ControlForm TEXT)";

                string gradeTable = @"CREATE TABLE IF NOT EXISTS Grades (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    StudentId INTEGER,
                    SubjectId INTEGER,
                    Value INTEGER,
                    Date TEXT,
                    GradeType TEXT,
                    FOREIGN KEY(StudentId) REFERENCES Students(Id),
                    FOREIGN KEY(SubjectId) REFERENCES Subjects(Id))";

                string attendanceTable = @"CREATE TABLE IF NOT EXISTS Attendance (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    StudentId INTEGER,
                    SubjectId INTEGER,
                    Date TEXT,
                    IsPresent INTEGER,
                    AbsenceReason TEXT,
                    FOREIGN KEY(StudentId) REFERENCES Students(Id),
                    FOREIGN KEY(SubjectId) REFERENCES Subjects(Id))";

                using (var cmd = new SQLiteCommand(studentTable, connection))
                    cmd.ExecuteNonQuery();
                using (var cmd = new SQLiteCommand(subjectTable, connection))
                    cmd.ExecuteNonQuery();
                using (var cmd = new SQLiteCommand(gradeTable, connection))
                    cmd.ExecuteNonQuery();
                using (var cmd = new SQLiteCommand(attendanceTable, connection))
                    cmd.ExecuteNonQuery();
            }
        }

        public SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
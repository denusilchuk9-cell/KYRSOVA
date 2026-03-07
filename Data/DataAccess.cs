using System;
using System.Collections.Generic;
using System.Data.SQLite;
using ElectronicJournal.Models;

namespace ElectronicJournal.Data
{
    public class DataAccess
    {
        private string connectionString;

        public DataAccess(string dbPath)
        {
            connectionString = $"Data Source={dbPath};Version=3;";
            CreateTables();
        }

        private void CreateTables()
        {
            using (var connection = new SQLiteConnection(connectionString))
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

        // ============ STUDENTS ============

        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Students";

                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            MiddleName = reader["MiddleName"].ToString(),
                            RecordBookNumber = reader["RecordBookNumber"].ToString(),
                            Email = reader["Email"]?.ToString(),
                            Phone = reader["Phone"]?.ToString()
                        });
                    }
                }
            }
            return students;
        }

        public void AddStudent(Student student)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Students 
                    (FirstName, LastName, MiddleName, RecordBookNumber, Email, Phone) 
                    VALUES (@fn, @ln, @mn, @rbn, @email, @phone)";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@fn", student.FirstName);
                    cmd.Parameters.AddWithValue("@ln", student.LastName);
                    cmd.Parameters.AddWithValue("@mn", student.MiddleName ?? "");
                    cmd.Parameters.AddWithValue("@rbn", student.RecordBookNumber ?? "");
                    cmd.Parameters.AddWithValue("@email", student.Email ?? "");
                    cmd.Parameters.AddWithValue("@phone", student.Phone ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateStudent(Student student)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE Students SET 
                    FirstName = @fn, LastName = @ln, MiddleName = @mn,
                    RecordBookNumber = @rbn, Email = @email, Phone = @phone
                    WHERE Id = @id";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", student.Id);
                    cmd.Parameters.AddWithValue("@fn", student.FirstName);
                    cmd.Parameters.AddWithValue("@ln", student.LastName);
                    cmd.Parameters.AddWithValue("@mn", student.MiddleName ?? "");
                    cmd.Parameters.AddWithValue("@rbn", student.RecordBookNumber ?? "");
                    cmd.Parameters.AddWithValue("@email", student.Email ?? "");
                    cmd.Parameters.AddWithValue("@phone", student.Phone ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteStudent(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Students WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ============ SUBJECTS ============

        public List<Subject> GetAllSubjects()
        {
            var subjects = new List<Subject>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Subjects";

                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        subjects.Add(new Subject
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            TeacherName = reader["TeacherName"].ToString(),
                            Hours = Convert.ToInt32(reader["Hours"]),
                            ControlForm = reader["ControlForm"].ToString()
                        });
                    }
                }
            }
            return subjects;
        }

        public void AddSubject(Subject subject)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Subjects (Name, TeacherName, Hours, ControlForm) 
                                VALUES (@name, @teacher, @hours, @form)";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", subject.Name);
                    cmd.Parameters.AddWithValue("@teacher", subject.TeacherName);
                    cmd.Parameters.AddWithValue("@hours", subject.Hours);
                    cmd.Parameters.AddWithValue("@form", subject.ControlForm);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSubject(Subject subject)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE Subjects SET 
                    Name = @name, TeacherName = @teacher, Hours = @hours, ControlForm = @form
                    WHERE Id = @id";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", subject.Id);
                    cmd.Parameters.AddWithValue("@name", subject.Name);
                    cmd.Parameters.AddWithValue("@teacher", subject.TeacherName);
                    cmd.Parameters.AddWithValue("@hours", subject.Hours);
                    cmd.Parameters.AddWithValue("@form", subject.ControlForm);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteSubject(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Subjects WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ============ GRADES ============

        public List<Grade> GetAllGrades()
        {
            var grades = new List<Grade>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Grades";

                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        grades.Add(new Grade
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            StudentId = Convert.ToInt32(reader["StudentId"]),
                            SubjectId = Convert.ToInt32(reader["SubjectId"]),
                            Value = Convert.ToInt32(reader["Value"]),
                            Date = Convert.ToDateTime(reader["Date"]),
                            GradeType = reader["GradeType"].ToString()
                        });
                    }
                }
            }
            return grades;
        }

        public List<Grade> GetGradesByStudent(int studentId)
        {
            var grades = new List<Grade>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Grades WHERE StudentId = @studentId";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            grades.Add(new Grade
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                StudentId = Convert.ToInt32(reader["StudentId"]),
                                SubjectId = Convert.ToInt32(reader["SubjectId"]),
                                Value = Convert.ToInt32(reader["Value"]),
                                Date = Convert.ToDateTime(reader["Date"]),
                                GradeType = reader["GradeType"].ToString()
                            });
                        }
                    }
                }
            }
            return grades;
        }

        public void AddGrade(Grade grade)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Grades (StudentId, SubjectId, Value, Date, GradeType) 
                                VALUES (@studentId, @subjectId, @value, @date, @type)";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@studentId", grade.StudentId);
                    cmd.Parameters.AddWithValue("@subjectId", grade.SubjectId);
                    cmd.Parameters.AddWithValue("@value", grade.Value);
                    cmd.Parameters.AddWithValue("@date", grade.Date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@type", grade.GradeType);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateGrade(Grade grade)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE Grades SET 
                    StudentId = @studentId, SubjectId = @subjectId, 
                    Value = @value, Date = @date, GradeType = @type
                    WHERE Id = @id";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", grade.Id);
                    cmd.Parameters.AddWithValue("@studentId", grade.StudentId);
                    cmd.Parameters.AddWithValue("@subjectId", grade.SubjectId);
                    cmd.Parameters.AddWithValue("@value", grade.Value);
                    cmd.Parameters.AddWithValue("@date", grade.Date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@type", grade.GradeType);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteGrade(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Grades WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ============ ATTENDANCE ============

        public List<Attendance> GetAllAttendance()
        {
            var attendances = new List<Attendance>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Attendance";

                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        attendances.Add(new Attendance
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            StudentId = Convert.ToInt32(reader["StudentId"]),
                            SubjectId = Convert.ToInt32(reader["SubjectId"]),
                            Date = Convert.ToDateTime(reader["Date"]),
                            IsPresent = Convert.ToBoolean(reader["IsPresent"]),
                            AbsenceReason = reader["AbsenceReason"]?.ToString()
                        });
                    }
                }
            }
            return attendances;
        }

        public List<Attendance> GetAttendanceByStudent(int studentId)
        {
            var attendances = new List<Attendance>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Attendance WHERE StudentId = @studentId";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            attendances.Add(new Attendance
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                StudentId = Convert.ToInt32(reader["StudentId"]),
                                SubjectId = Convert.ToInt32(reader["SubjectId"]),
                                Date = Convert.ToDateTime(reader["Date"]),
                                IsPresent = Convert.ToBoolean(reader["IsPresent"]),
                                AbsenceReason = reader["AbsenceReason"]?.ToString()
                            });
                        }
                    }
                }
            }
            return attendances;
        }

        public void AddAttendance(Attendance attendance)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Attendance (StudentId, SubjectId, Date, IsPresent, AbsenceReason) 
                                VALUES (@studentId, @subjectId, @date, @isPresent, @reason)";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@studentId", attendance.StudentId);
                    cmd.Parameters.AddWithValue("@subjectId", attendance.SubjectId);
                    cmd.Parameters.AddWithValue("@date", attendance.Date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@isPresent", attendance.IsPresent ? 1 : 0);
                    cmd.Parameters.AddWithValue("@reason", attendance.AbsenceReason ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateAttendance(Attendance attendance)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE Attendance SET 
                    StudentId = @studentId, SubjectId = @subjectId, 
                    Date = @date, IsPresent = @isPresent, AbsenceReason = @reason
                    WHERE Id = @id";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", attendance.Id);
                    cmd.Parameters.AddWithValue("@studentId", attendance.StudentId);
                    cmd.Parameters.AddWithValue("@subjectId", attendance.SubjectId);
                    cmd.Parameters.AddWithValue("@date", attendance.Date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@isPresent", attendance.IsPresent ? 1 : 0);
                    cmd.Parameters.AddWithValue("@reason", attendance.AbsenceReason ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAttendance(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Attendance WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

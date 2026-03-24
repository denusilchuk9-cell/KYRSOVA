using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicJournal.Models;
using ElectronicJournal.Business;
using ElectronicJournal.Data;

namespace ElectronicJournal.Tests
{
    [TestClass]
    public class AllTests
    {
        private void ClearStudentList()
        {
            var field = typeof(StudentRepository).GetField("_students", BindingFlags.Static | BindingFlags.NonPublic);
            if (field != null)
            {
                var list = field.GetValue(null) as IList;
                if (list != null) list.Clear();
            }
            var idField = typeof(StudentRepository).GetField("_nextId", BindingFlags.Static | BindingFlags.NonPublic);
            if (idField != null) idField.SetValue(null, 1);
        }

        private void ClearGradeList()
        {
            var field = typeof(GradeRepository).GetField("_grades", BindingFlags.Static | BindingFlags.NonPublic);
            if (field != null)
            {
                var list = field.GetValue(null) as IList;
                if (list != null) list.Clear();
            }
            var idField = typeof(GradeRepository).GetField("_nextId", BindingFlags.Static | BindingFlags.NonPublic);
            if (idField != null) idField.SetValue(null, 1);
        }

        private void ClearSubjectList()
        {
            var field = typeof(SubjectRepository).GetField("_subjects", BindingFlags.Static | BindingFlags.NonPublic);
            if (field != null)
            {
                var list = field.GetValue(null) as IList;
                if (list != null) list.Clear();
            }
            var idField = typeof(SubjectRepository).GetField("_nextId", BindingFlags.Static | BindingFlags.NonPublic);
            if (idField != null) idField.SetValue(null, 1);
        }

        private void ClearAttendanceList()
        {
            var field = typeof(AttendanceRepository).GetField("_attendances", BindingFlags.Static | BindingFlags.NonPublic);
            if (field != null)
            {
                var list = field.GetValue(null) as IList;
                if (list != null) list.Clear();
            }
            var idField = typeof(AttendanceRepository).GetField("_nextId", BindingFlags.Static | BindingFlags.NonPublic);
            if (idField != null) idField.SetValue(null, 1);
        }

        [TestMethod]
        public void Test01_AlwaysPasses()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Test02_StudentCreation()
        {
            var student = new Student("Іван", "Петренко");
            Assert.AreEqual("Іван", student.FirstName);
            Assert.AreEqual("Петренко", student.LastName);
        }

        [TestMethod]
        public void Test03_GradeCreation()
        {
            var grade = new Grade(1, 2, 85, DateTime.Today);
            Assert.AreEqual(85, grade.Value);
        }

        [TestMethod]
        public void Test04_AttendanceCreation()
        {
            ClearStudentList();
            ClearSubjectList();

            var studentRepo = new StudentRepository();
            var subjectRepo = new SubjectRepository();
            var studentService = new StudentService(studentRepo);
            var subjectService = new SubjectService(subjectRepo);

            var student = new Student("Тест", "Студент");
            studentService.AddStudent(student);
            var subject = new Subject("Тест");
            subjectService.AddSubject(subject);

            var attendance = new Attendance(student.Id, subject.Id, DateTime.Today);
            Assert.IsTrue(attendance.IsPresent);
        }

        [TestMethod]
        public void Test05_StudentFullName()
        {
            var student = new Student("Іван", "Петренко") { MiddleName = "Іванович" };
            Assert.AreEqual("Петренко Іван Іванович", student.GetFullName());
        }

        [TestMethod]
        public void Test06_GradeIsPassingTrue()
        {
            var grade = new Grade(1, 2, 75, DateTime.Today);
            Assert.IsTrue(grade.IsPassing());
        }

        [TestMethod]
        public void Test07_GradeIsPassingFalse()
        {
            var grade = new Grade(1, 2, 50, DateTime.Today);
            Assert.IsFalse(grade.IsPassing());
        }

        [TestMethod]
        public void Test08_SubjectGetInfo()
        {
            var subject = new Subject("Математика")
            {
                TeacherName = "Іванов",
                Hours = 120,
                ControlForm = "Іспит"
            };
            var info = subject.GetInfo();
            Assert.AreEqual("Математика - Іванов - 120 год. - Іспит", info);
        }

        [TestMethod]
        public void Test09_AttendanceMarkAbsent()
        {
            var attendance = new Attendance(1, 2, DateTime.Today);
            attendance.MarkAbsent("Хвороба");
            Assert.IsFalse(attendance.IsPresent);
            Assert.AreEqual("Хвороба", attendance.AbsenceReason);
        }

        [TestMethod]
        public void Test10_AddStudent()
        {
            ClearStudentList();
            var repo = new StudentRepository();
            var service = new StudentService(repo);
            var student = new Student("Іван", "Петренко");
            service.AddStudent(student);
            var result = service.GetAllStudents();
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void Test11_AddGrade()
        {
            ClearStudentList();
            ClearSubjectList();
            ClearGradeList();
            var studentRepo = new StudentRepository();
            var subjectRepo = new SubjectRepository();
            var gradeRepo = new GradeRepository();
            var studentService = new StudentService(studentRepo);
            var subjectService = new SubjectService(subjectRepo);
            var gradeService = new GradeService(gradeRepo, studentRepo, subjectRepo);
            var student = new Student("Іван", "Петренко");
            studentService.AddStudent(student);
            var subject = new Subject("Математика");
            subjectService.AddSubject(subject);
            var grade = new Grade(student.Id, subject.Id, 85, DateTime.Today);
            gradeService.AddGrade(grade);
            var result = gradeService.GetGradesByStudent(student.Id);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(85, result[0].Value);
        }

        [TestMethod]
        public void Test12_AddAttendance()
        {
            ClearStudentList();
            ClearSubjectList();
            ClearAttendanceList();
            var studentRepo = new StudentRepository();
            var subjectRepo = new SubjectRepository();
            var attendanceRepo = new AttendanceRepository();
            var studentService = new StudentService(studentRepo);
            var subjectService = new SubjectService(subjectRepo);
            var attendanceService = new AttendanceService(attendanceRepo, studentRepo, subjectRepo);
            var student = new Student("Іван", "Петренко");
            studentService.AddStudent(student);
            var subject = new Subject("Математика");
            subjectService.AddSubject(subject);
            var attendance = new Attendance(student.Id, subject.Id, DateTime.Today);
            attendanceService.AddAttendance(attendance);
            var result = attendanceService.GetAttendanceByStudent(student.Id);
            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result[0].IsPresent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test13_StudentEmptyFirstNameThrows()
        {
            var student = new Student("", "Петренко");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test14_StudentEmptyLastNameThrows()
        {
            var student = new Student("Іван", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test15_GradeValueBelowZeroThrows()
        {
            var grade = new Grade(1, 2, -10, DateTime.Today);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test16_GradeValueAbove100Throws()
        {
            var grade = new Grade(1, 2, 101, DateTime.Today);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test17_AttendanceInvalidStudentIdThrows()
        {
            var attendance = new Attendance(0, 2, DateTime.Today);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test18_AttendanceInvalidSubjectIdThrows()
        {
            var attendance = new Attendance(1, 0, DateTime.Today);
        }

        [TestMethod]
        public void Test19_MarkAbsent()
        {
            ClearStudentList();
            ClearSubjectList();
            ClearAttendanceList();
            var studentRepo = new StudentRepository();
            var subjectRepo = new SubjectRepository();
            var attendanceRepo = new AttendanceRepository();
            var studentService = new StudentService(studentRepo);
            var subjectService = new SubjectService(subjectRepo);
            var attendanceService = new AttendanceService(attendanceRepo, studentRepo, subjectRepo);
            var student = new Student("Марія", "Шевченко");
            studentService.AddStudent(student);
            var subject = new Subject("Фізика");
            subjectService.AddSubject(subject);
            attendanceService.MarkAbsent(student.Id, subject.Id, DateTime.Today, "Хвороба");
            var result = attendanceService.GetAttendanceByStudent(student.Id);
            Assert.AreEqual(1, result.Count);
            Assert.IsFalse(result[0].IsPresent);
            Assert.AreEqual("Хвороба", result[0].AbsenceReason);
        }

        [TestMethod]
        public void Test20_GetAttendancePercentage()
        {
            ClearStudentList();
            ClearSubjectList();
            ClearAttendanceList();
            var studentRepo = new StudentRepository();
            var subjectRepo = new SubjectRepository();
            var attendanceRepo = new AttendanceRepository();
            var studentService = new StudentService(studentRepo);
            var subjectService = new SubjectService(subjectRepo);
            var attendanceService = new AttendanceService(attendanceRepo, studentRepo, subjectRepo);
            var student = new Student("Дмитро", "Бондаренко");
            studentService.AddStudent(student);
            var subject = new Subject("Історія");
            subjectService.AddSubject(subject);
            attendanceService.AddAttendance(new Attendance(student.Id, subject.Id, DateTime.Today));
            attendanceService.AddAttendance(new Attendance(student.Id, subject.Id, DateTime.Today.AddDays(1)));
            var result = attendanceService.GetAttendancePercentage(student.Id);
            Assert.AreEqual(100, result);
        }

        [TestMethod]
        public void Test21_GetStudentAverage()
        {
            ClearStudentList();
            ClearSubjectList();
            ClearGradeList();
            var studentRepo = new StudentRepository();
            var subjectRepo = new SubjectRepository();
            var gradeRepo = new GradeRepository();
            var studentService = new StudentService(studentRepo);
            var subjectService = new SubjectService(subjectRepo);
            var gradeService = new GradeService(gradeRepo, studentRepo, subjectRepo);
            var student = new Student("Олег", "Сидоренко");
            studentService.AddStudent(student);
            var subject = new Subject("Біологія");
            subjectService.AddSubject(subject);
            gradeService.AddGrade(new Grade(student.Id, subject.Id, 80, DateTime.Today));
            gradeService.AddGrade(new Grade(student.Id, subject.Id, 100, DateTime.Today));
            var result = gradeService.GetStudentAverage(student.Id, subject.Id);
            Assert.AreEqual(90, result);
        }

        [TestMethod]
        public void Test22_SetSimpleStrategy()
        {
            var studentRepo = new StudentRepository();
            var subjectRepo = new SubjectRepository();
            var gradeRepo = new GradeRepository();
            var gradeService = new GradeService(gradeRepo, studentRepo, subjectRepo);
            gradeService.SetStrategy(new SimpleAverageStrategy());
            Assert.AreEqual("Проста (Simple)", gradeService.GetStrategyName());
        }

        [TestMethod]
        public void Test23_SetWeightedStrategy()
        {
            var studentRepo = new StudentRepository();
            var subjectRepo = new SubjectRepository();
            var gradeRepo = new GradeRepository();
            var gradeService = new GradeService(gradeRepo, studentRepo, subjectRepo);
            gradeService.SetStrategy(new WeightedAverageStrategy());
            Assert.AreEqual("Зважена (Weighted)", gradeService.GetStrategyName());
        }

        [TestMethod]
        public void Test24_DeleteStudent()
        {
            ClearStudentList();
            var repo = new StudentRepository();
            var service = new StudentService(repo);
            var student = new Student("Марія", "Шевченко");
            service.AddStudent(student);
            var students = service.GetAllStudents();
            int id = students[0].Id;
            service.DeleteStudent(id);
            var afterDelete = service.GetAllStudents();
            Assert.AreEqual(0, afterDelete.Count);
        }

        [TestMethod]
        public void Test25_GetAllStudents()
        {
            ClearStudentList();
            var repo = new StudentRepository();
            var service = new StudentService(repo);
            service.AddStudent(new Student("Іван", "Петренко"));
            service.AddStudent(new Student("Марія", "Шевченко"));
            service.AddStudent(new Student("Петро", "Іваненко"));
            var result = service.GetAllStudents();
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void Test26_UpdateStudent()
        {
            ClearStudentList();
            var repo = new StudentRepository();
            var service = new StudentService(repo);
            var student = new Student("Іван", "Петренко");
            service.AddStudent(student);
            var added = service.GetAllStudents()[0];
            added.FirstName = "Петро";
            added.LastName = "Іваненко";
            service.UpdateStudent(added);
            var updated = service.GetStudentById(added.Id);
            Assert.AreEqual("Петро", updated.FirstName);
            Assert.AreEqual("Іваненко", updated.LastName);
        }

        [TestMethod]
        public void Test27_GetStudentById()
        {
            ClearStudentList();
            var repo = new StudentRepository();
            var service = new StudentService(repo);
            var student = new Student("Олег", "Сидоренко");
            service.AddStudent(student);
            var added = service.GetAllStudents()[0];
            var result = service.GetStudentById(added.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual("Олег", result.FirstName);
        }

        [TestMethod]
        public void Test28_GetStudentByIdNotFound()
        {
            ClearStudentList();
            var repo = new StudentRepository();
            var service = new StudentService(repo);
            var result = service.GetStudentById(999);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Test29_ValidateStudentValid()
        {
            var student = new Student("Іван", "Петренко");
            Assert.IsTrue(student.Validate());
        }

        [TestMethod]
        public void Test30_ValidateStudentInvalid()
        {
            try
            {
                var student = new Student("", "");
                Assert.IsFalse(student.Validate());
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Test31_DeleteGrade()
        {
            ClearStudentList();
            ClearSubjectList();
            ClearGradeList();
            var studentRepo = new StudentRepository();
            var subjectRepo = new SubjectRepository();
            var gradeRepo = new GradeRepository();
            var studentService = new StudentService(studentRepo);
            var subjectService = new SubjectService(subjectRepo);
            var gradeService = new GradeService(gradeRepo, studentRepo, subjectRepo);
            var student = new Student("Марія", "Шевченко");
            studentService.AddStudent(student);
            var subject = new Subject("Фізика");
            subjectService.AddSubject(subject);
            var grade = new Grade(student.Id, subject.Id, 90, DateTime.Today);
            gradeService.AddGrade(grade);
            var grades = gradeService.GetGradesByStudent(student.Id);
            gradeService.DeleteGrade(grades[0].Id);
            var afterDelete = gradeService.GetGradesByStudent(student.Id);
            Assert.AreEqual(0, afterDelete.Count);
        }

        [TestMethod]
        public void Test32_GetAttendanceByStudent()
        {
            ClearStudentList();
            ClearSubjectList();
            ClearAttendanceList();
            var studentRepo = new StudentRepository();
            var subjectRepo = new SubjectRepository();
            var attendanceRepo = new AttendanceRepository();
            var studentService = new StudentService(studentRepo);
            var subjectService = new SubjectService(subjectRepo);
            var attendanceService = new AttendanceService(attendanceRepo, studentRepo, subjectRepo);
            var student1 = new Student("Студент1", "Тест");
            var student2 = new Student("Студент2", "Тест");
            studentService.AddStudent(student1);
            studentService.AddStudent(student2);
            var subject = new Subject("Предмет");
            subjectService.AddSubject(subject);
            attendanceService.AddAttendance(new Attendance(student1.Id, subject.Id, DateTime.Today));
            attendanceService.AddAttendance(new Attendance(student2.Id, subject.Id, DateTime.Today));
            var result = attendanceService.GetAttendanceByStudent(student1.Id);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(student1.Id, result[0].StudentId);
        }

        [TestMethod]
        public void Test33_GetGradesByStudent()
        {
            ClearStudentList();
            ClearSubjectList();
            ClearGradeList();
            var studentRepo = new StudentRepository();
            var subjectRepo = new SubjectRepository();
            var gradeRepo = new GradeRepository();
            var studentService = new StudentService(studentRepo);
            var subjectService = new SubjectService(subjectRepo);
            var gradeService = new GradeService(gradeRepo, studentRepo, subjectRepo);
            var student1 = new Student("Студент1", "Тест");
            var student2 = new Student("Студент2", "Тест");
            studentService.AddStudent(student1);
            studentService.AddStudent(student2);
            var subject = new Subject("Предмет");
            subjectService.AddSubject(subject);
            gradeService.AddGrade(new Grade(student1.Id, subject.Id, 80, DateTime.Today));
            gradeService.AddGrade(new Grade(student2.Id, subject.Id, 90, DateTime.Today));
            var result = gradeService.GetGradesByStudent(student1.Id);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(student1.Id, result[0].StudentId);
        }

        [TestMethod]
        public void Test34_GetAttendancePercentageHalf()
        {
            ClearStudentList();
            ClearSubjectList();
            ClearAttendanceList();
            var studentRepo = new StudentRepository();
            var subjectRepo = new SubjectRepository();
            var attendanceRepo = new AttendanceRepository();
            var studentService = new StudentService(studentRepo);
            var subjectService = new SubjectService(subjectRepo);
            var attendanceService = new AttendanceService(attendanceRepo, studentRepo, subjectRepo);
            var student = new Student("Тест", "Тестовий");
            studentService.AddStudent(student);
            var subject = new Subject("Тест");
            subjectService.AddSubject(subject);
            attendanceService.AddAttendance(new Attendance(student.Id, subject.Id, DateTime.Today));
            attendanceService.MarkAbsent(student.Id, subject.Id, DateTime.Today.AddDays(1), "Хвороба");
            var result = attendanceService.GetAttendancePercentage(student.Id);
            Assert.AreEqual(50, result);
        }
    }
}
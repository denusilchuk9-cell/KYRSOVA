using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicJournal.Business;
using ElectronicJournal.Data;
using ElectronicJournal.Models;
using System;

namespace ElectronicJournal.Tests
{
    [TestClass]
    public class AttendanceTests
    {
        [TestMethod]
        public void AddAttendance_InvalidStudentId_ShouldThrowException()
        {
            try
            {
                var a = new Attendance(0, 1, DateTime.Now);
                Assert.Fail();
            }
            catch (ArgumentException)
            {
            }
        }

        [TestMethod]
        public void AddAttendance_InvalidSubjectId_ShouldThrowException()
        {
            try
            {
                var a = new Attendance(1, 0, DateTime.Now);
                Assert.Fail();
            }
            catch (ArgumentException)
            {
            }
        }

        [TestMethod]
        public void AddAttendance_ValidAttendance_ShouldAddSuccessfully()
        {
            var service = new AttendanceService(new AttendanceRepository(), new StudentRepository(), new SubjectRepository());
            service.AddAttendance(new Attendance(1, 1, DateTime.Now));
            var result = service.GetAttendanceByStudent(1);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void MarkAbsent_ShouldSetIsPresentToFalse()
        {
            var service = new AttendanceService(new AttendanceRepository(), new StudentRepository(), new SubjectRepository());
            service.MarkAbsent(1, 1, DateTime.Now, "Хвороба");
            var result = service.GetAttendanceByStudent(1);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
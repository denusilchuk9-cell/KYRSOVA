using System;
using ElectronicJournal.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElectronicJournalTests
{
    [TestClass]
    public class AttendanceTests
    {
        [TestMethod]
        public void AttendanceConstructor_WithValidData_CreatesAttendance()
        {
            var date = DateTime.Now;
            var attendance = new Attendance(1, 2, date);

            Assert.AreEqual(1, attendance.StudentId);
            Assert.AreEqual(2, attendance.SubjectId);
            Assert.AreEqual(date, attendance.Date);
            Assert.IsTrue(attendance.IsPresent);
        }

        [TestMethod]
        public void MarkAbsent_SetsIsPresentToFalseAndAddsReason()
        {
            var attendance = new Attendance(1, 1, DateTime.Now);

            attendance.MarkAbsent("Хвороба");

            Assert.IsFalse(attendance.IsPresent);
            Assert.AreEqual("Хвороба", attendance.AbsenceReason);
        }
    }
}
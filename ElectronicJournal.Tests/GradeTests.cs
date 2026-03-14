using System;
using ElectronicJournal.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElectronicJournalTests
{
    [TestClass]
    public class GradeTests
    {
        [TestMethod]
        public void GradeConstructor_WithValidData_CreatesGrade()
        {
            var date = DateTime.Now;
            var grade = new Grade(1, 2, 85, date);

            Assert.AreEqual(1, grade.StudentId);
            Assert.AreEqual(2, grade.SubjectId);
            Assert.AreEqual(85, grade.Value);
            Assert.AreEqual(date, grade.Date);
        }

        [TestMethod]
        public void IsPassing_WithValueAbove60_ReturnsTrue()
        {
            var grade = new Grade(1, 1, 85, DateTime.Now);

            bool result = grade.IsPassing();

            Assert.IsTrue(result);
        }
    }
}
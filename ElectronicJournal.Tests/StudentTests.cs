using System;
using ElectronicJournal.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElectronicJournalTests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void StudentConstructor_WithValidNames_CreatesStudent()
        {
            var student = new Student("Іван", "Петренко");

            Assert.AreEqual("Іван", student.FirstName);
            Assert.AreEqual("Петренко", student.LastName);
        }

        [TestMethod]
        public void GetFullName_WithMiddleName_ReturnsFormattedName()
        {
            var student = new Student("Іван", "Петренко")
            {
                MiddleName = "Петрович"
            };

            string result = student.GetFullName();

            Assert.AreEqual("Петренко Іван Петрович", result);
        }
    }
}
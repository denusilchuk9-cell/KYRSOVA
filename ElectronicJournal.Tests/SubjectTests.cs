using System;
using ElectronicJournal.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElectronicJournalTests
{
    [TestClass]
    public class SubjectTests
    {
        [TestMethod]
        public void SubjectConstructor_WithValidName_CreatesSubject()
        {
            var subject = new Subject("Математика");

            Assert.AreEqual("Математика", subject.Name);
        }

        [TestMethod]
        public void GetInfo_WithAllFields_ReturnsFormattedString()
        {
            var subject = new Subject("Математика")
            {
                TeacherName = "Іванов І.І.",
                Hours = 120,
                ControlForm = "Іспит"
            };

            string result = subject.GetInfo();

            Assert.AreEqual("Математика - Іванов І.І. - 120 год. - Іспит", result);
        }
    }
}
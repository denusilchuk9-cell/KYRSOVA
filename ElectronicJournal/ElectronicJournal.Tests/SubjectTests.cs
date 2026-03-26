using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicJournal.Business;
using ElectronicJournal.Data;
using ElectronicJournal.Models;

namespace ElectronicJournal.Tests
{
    [TestClass]
    public class SubjectTests
    {
        [TestMethod]
        public void AddSubject_EmptyName_ShouldThrowException()
        {
            try
            {
                var s = new Subject("");
                Assert.Fail();
            }
            catch (ArgumentException)
            {
            }
        }

        [TestMethod]
        public void AddSubject_ValidSubject_ShouldAddSuccessfully()
        {
            var service = new SubjectService(new SubjectRepository());
            service.AddSubject(new Subject("Математика"));
            var result = service.GetAllSubjects();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Subject_GetInfo_ShouldReturnCorrectFormat()
        {
            var subject = new Subject("Математика")
            {
                TeacherName = "Іванов",
                Hours = 120,
                ControlForm = "Іспит"
            };
            Assert.AreEqual("Математика - Іванов - 120 год. - Іспит", subject.GetInfo());
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicJournal.Business;
using ElectronicJournal.Data;
using ElectronicJournal.Models;

namespace ElectronicJournal.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AddStudent_ValidStudent_ShouldAddSuccessfully()
        {
            var service = new StudentService(new StudentRepository());
            service.AddStudent(new Student("Іван", "Петров"));
            var result = service.GetAllStudents();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void AddStudent_EmptyFirstName_ShouldThrowException()
        {
            try
            {
                var s = new Student("", "Петров");
                Assert.Fail();
            }
            catch (ArgumentException)
            {
            }
        }

        [TestMethod]
        public void AddStudent_EmptyLastName_ShouldThrowException()
        {
            try
            {
                var s = new Student("Іван", "");
                Assert.Fail();
            }
            catch (ArgumentException)
            {
            }
        }

        [TestMethod]
        public void Student_GetFullName_ShouldReturnCorrectFormat()
        {
            var student = new Student("Іван", "Петров") { MiddleName = "Іванович" };
            Assert.AreEqual("Петров Іван Іванович", student.GetFullName());
        }
    }
}
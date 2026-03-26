using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicJournal.Business;
using ElectronicJournal.Data;
using ElectronicJournal.Models;
using System;

namespace ElectronicJournal.Tests
{
    [TestClass]
    public class GradeTests
    {
        [TestMethod]
        public void AddGrade_InvalidStudentId_ShouldThrowException()
        {
            try
            {
                var g = new Grade(0, 1, 85, DateTime.Now);
                Assert.Fail();
            }
            catch (ArgumentException)
            {
            }
        }

        [TestMethod]
        public void AddGrade_InvalidSubjectId_ShouldThrowException()
        {
            try
            {
                var g = new Grade(1, 0, 85, DateTime.Now);
                Assert.Fail();
            }
            catch (ArgumentException)
            {
            }
        }

        [TestMethod]
        public void AddGrade_ValidGrade_ShouldAddSuccessfully()
        {
            var service = new GradeService(new GradeRepository(), new StudentRepository(), new SubjectRepository());
            service.AddGrade(new Grade(1, 1, 85, DateTime.Now));
            var result = service.GetGradesByStudent(1);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void AddGrade_ValueBelowZero_ShouldThrowException()
        {
            try
            {
                var g = new Grade(1, 1, -5, DateTime.Now);
                Assert.Fail();
            }
            catch (ArgumentException)
            {
            }
        }

        [TestMethod]
        public void AddGrade_ValueAbove100_ShouldThrowException()
        {
            try
            {
                var g = new Grade(1, 1, 150, DateTime.Now);
                Assert.Fail();
            }
            catch (ArgumentException)
            {
            }
        }

        [TestMethod]
        public void Grade_IsPassing_Value60_ShouldReturnTrue()
        {
            var grade = new Grade(1, 1, 60, DateTime.Now);
            Assert.IsTrue(grade.IsPassing());
        }

        [TestMethod]
        public void Grade_IsPassing_Value59_ShouldReturnFalse()
        {
            var grade = new Grade(1, 1, 59, DateTime.Now);
            Assert.IsFalse(grade.IsPassing());
        }
    }
}
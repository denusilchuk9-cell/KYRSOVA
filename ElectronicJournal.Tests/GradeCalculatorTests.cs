using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicJournal.Business;
using ElectronicJournal.Models;
using System;
using System.Collections.Generic;

namespace ElectronicJournal.Tests
{
    [TestClass]
    public class GradeCalculatorTests
    {
        [TestMethod]
        public void CalculateAverage_WithGrades_ReturnsCorrectAverage()
        {
            var calculator = new GradeCalculator();
            var grades = new List<Grade>
            {
                new Grade(1, 1, 85, DateTime.Now),
                new Grade(1, 1, 90, DateTime.Now),
                new Grade(1, 1, 95, DateTime.Now)
            };

            double result = calculator.CalculateAverage(grades);

            Assert.AreEqual(90, result);
        }
    }
}
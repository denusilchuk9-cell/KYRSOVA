using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicJournal.Business;
using ElectronicJournal.Models;
using System;
using System.Collections.Generic;

namespace ElectronicJournal.Tests
{
    [TestClass]
    public class StrategyTests
    {
        [TestMethod]
        public void SimpleAverageStrategy_EmptyList_ShouldReturn0()
        {
            var strategy = new SimpleAverageStrategy();
            var result = strategy.Calculate(new List<Grade>());
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SimpleAverageStrategy_SingleGrade_ShouldReturnGrade()
        {
            var strategy = new SimpleAverageStrategy();
            var grades = new List<Grade> { new Grade(1, 1, 85, DateTime.Now) };
            var result = strategy.Calculate(grades);
            Assert.AreEqual(85, result);
        }

        [TestMethod]
        public void SimpleAverageStrategy_MultipleGrades_ShouldReturnAverage()
        {
            var strategy = new SimpleAverageStrategy();
            var grades = new List<Grade>
            {
                new Grade(1, 1, 80, DateTime.Now),
                new Grade(1, 1, 100, DateTime.Now)
            };
            var result = strategy.Calculate(grades);
            Assert.AreEqual(90, result);
        }

        [TestMethod]
        public void WeightedAverageStrategy_EmptyList_ShouldReturn0()
        {
            var strategy = new WeightedAverageStrategy();
            var result = strategy.Calculate(new List<Grade>());
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void WeightedAverageStrategy_SingleGrade_ShouldReturnGrade()
        {
            var strategy = new WeightedAverageStrategy();
            var grades = new List<Grade> { new Grade(1, 1, 85, DateTime.Now) };
            var result = strategy.Calculate(grades);
            Assert.AreEqual(85, result);
        }

        [TestMethod]
        public void WeightedAverageStrategy_MultipleGrades_ShouldReturnWeightedAverage()
        {
            var strategy = new WeightedAverageStrategy();
            var grades = new List<Grade>
            {
                new Grade(1, 1, 80, DateTime.Now),
                new Grade(1, 1, 100, DateTime.Now)
            };
            double expected = (80 * 1 + 100 * 2) / 3.0;
            var result = strategy.Calculate(grades);
            Assert.AreEqual(expected, result, 0.001);
        }

        [TestMethod]
        public void GradeCalculator_GetStrategyName_ShouldReturnCorrect()
        {
            var calculator = new GradeCalculator();
            calculator.SetStrategy(new SimpleAverageStrategy());
            Assert.AreEqual("Проста (Simple)", calculator.GetStrategyName());
            calculator.SetStrategy(new WeightedAverageStrategy());
            Assert.AreEqual("Зважена (Weighted)", calculator.GetStrategyName());
        }

        [TestMethod]
        public void GradeCalculator_CalculateAverageByStudent_ShouldFilterCorrectly()
        {
            var calculator = new GradeCalculator();
            var grades = new List<Grade>
            {
                new Grade(1, 1, 80, DateTime.Now),
                new Grade(1, 1, 90, DateTime.Now),
                new Grade(2, 1, 100, DateTime.Now)
            };
            var result = calculator.CalculateAverageByStudent(grades, 1);
            Assert.AreEqual(85, result);
        }

        [TestMethod]
        public void GradeCalculator_CalculateAverageBySubject_ShouldFilterCorrectly()
        {
            var calculator = new GradeCalculator();
            var grades = new List<Grade>
            {
                new Grade(1, 1, 80, DateTime.Now),
                new Grade(1, 1, 90, DateTime.Now),
                new Grade(1, 2, 100, DateTime.Now)
            };
            var result = calculator.CalculateAverageBySubject(grades, 1);
            Assert.AreEqual(85, result);
        }

        [TestMethod]
        public void GradeCalculator_CalculateAttendancePercentage_ShouldReturnCorrect()
        {
            var calculator = new GradeCalculator();
            var attendances = new List<Attendance>
            {
                new Attendance(1, 1, DateTime.Now),
                new Attendance(1, 1, DateTime.Now),
                new Attendance(1, 1, DateTime.Now)
            };
            attendances[1].MarkAbsent("Хвороба");
            var result = calculator.CalculateAttendancePercentage(attendances);
            Assert.AreEqual(66.66666666666666, result, 0.001);
        }

        [TestMethod]
        public void GradeCalculator_CalculateAttendancePercentage_EmptyList_ShouldReturn0()
        {
            var calculator = new GradeCalculator();
            var result = calculator.CalculateAttendancePercentage(null);
            Assert.AreEqual(0, result);
        }
    }
}
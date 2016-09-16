using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Grades;

namespace Grades.Tests
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void CalculateHighestGrade()
        {
            GradeBook book=new GradeBook();

            book.AddGrade(90f);
            book.AddGrade(50f);

            GradeStatistics stats = book.ComputeStatistics();

            // the last param is delta, represent the acceptable difference between the first two params (mostly for float)
            Assert.AreEqual(90f,stats.HighestGrade,0.01);  
        }

        [TestMethod]
        public void PassByValue()
        {
            GradeBook book=new GradeBook();
            book.Name = "Not set";
            SetName(ref book);

            Assert.AreEqual("Name set", book.Name);
        }

        void SetName(ref GradeBook book)
        {
            book=new GradeBook();
            book.Name = "Name set";
        }

    }
}

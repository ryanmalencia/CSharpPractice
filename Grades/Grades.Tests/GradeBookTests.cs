using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grades.Tests
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void AddNewGrade()
        {
            //GIVEN
            GradeBook book = new GradeBook();

            //WHEN
            book.AddGrade(95);

            //THEN
            Assert.AreEqual(book.GetCount(),1);
        }

        [TestMethod]
        public void AddBadGrade()
        {
            //GIVEN
            GradeBook book = new GradeBook();

            //WHEN
            book.AddGrade(-10);

            //THEN
            Assert.AreEqual(book.GetCount(), 0);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests
    {
        [TestMethod]
        public void UppercaseString()
        {
            string name = "scott";
            PassStringByValue(name);
            Assert.AreEqual("scott", name);
            name = name.ToUpper();

            Assert.AreEqual("SCOTT", name);
        }

        private void PassStringByValue(string name)
        {
            name = "sssst";
        }

        [TestMethod]
        public void ValueTypesPassByRef()
        {
            int x = 46;
            IncrementNumberRef(ref x);
            Assert.AreEqual(47, x);
        }

        private void IncrementNumberRef(ref int number)
        {
            number += 1;
        }

        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 46;
            IncrementNumber(x);
            Assert.AreEqual(46,x);
        }

        private void IncrementNumber(int number)
        {
            number += 1;
            number = 0;
        }

        [TestMethod]
        public void ReferenceTypePassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(book2);
            Assert.AreEqual("A GradeBook", book1.Name);
            Assert.AreEqual("A GradeBook", book2.Name);
        }

        private void GiveBookAName(GradeBook book)
        {
            book.Name = "A GradeBook";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Scoot";
            string name2 = "scoot";

            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result );
        }

        [TestMethod]
        public void IntVariableHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;
            Assert.AreNotEqual(x1,x2);
        }

        [TestMethod]
        public void GradeBookVariableHoldAReference()
        {
            GradeBook g1=new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Scotte's grade book";
            Assert.AreEqual(g1.Name,g2.Name);
        }
    }
}

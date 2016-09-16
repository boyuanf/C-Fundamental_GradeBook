using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class ThrowAwayGradeBook : GradeBook
    {
        public ThrowAwayGradeBook(string name):base(name)
        {
            Console.WriteLine("throw away ctor");
        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("Throw away compute");
            float minGrade = float.MaxValue;
            foreach (float grade in _grades)
            {
                minGrade = Math.Min(minGrade, grade);
            }
            _grades.Remove(minGrade);
            return base.ComputeStatistics();
        }
    }
}

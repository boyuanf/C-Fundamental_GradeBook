using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeTracker
    {

        public GradeBook(string name="There is no name")
        {
            Console.WriteLine("GradeBook ctor");
            Name = name;
            _grades = new List<float>();
        }

        public override IEnumerator GetEnumerator()
        {
            return _grades.GetEnumerator();
        }

        public void TestInherient()
        {
            Console.WriteLine("Gradebook TestInherient");
        }

        public override void AddGrade(float grade)
        {
            if ((grade >= 0) && (grade <= 100))
            {
                _grades.Add(grade);
            }
        }

        public override void TestVirtual()
        {
            Console.WriteLine("Gradebook test for virtual");
        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("Grade book compute");
            GradeStatistics stats=new GradeStatistics();

            float sum = 0f;

            foreach (float grade in _grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum/_grades.Count;

            return stats;
        }


        

        protected List<float > _grades;


        public override void WriteGrades(TextWriter textWriter)
        {
            textWriter.WriteLine("Grades:");
            foreach (float grade in _grades)
            {
                textWriter.WriteLine(grade);
            }
            for(int i=0;i<_grades.Count;i++)
            {
                textWriter.WriteLine(_grades[i]);
            }
            textWriter.WriteLine("***************");
        }

        public string testArray;

        public string Name;

    }
}

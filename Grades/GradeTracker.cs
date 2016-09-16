using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public interface IGradeTracker: IEnumerable
    {
        void AddGrade(float grade);
        GradeStatistics ComputeStatistics();
        void WriteGrades(TextWriter textWriter);
        string Name { get; set; }
        event NameChangedEvent NameChangedEvent;
    }


    public abstract class GradeTracker : IGradeTracker
    {
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter textWriter);
        public abstract IEnumerator GetEnumerator();

        public virtual void TestVirtual()
        {
            Console.WriteLine("GradeTacker test for virtual");
        }

        public void TestInherient()
        {
            Console.WriteLine("GradeTacker TestInherient");
        }

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                if (_name != value)
                {
                    var oldValue = _name;
                    _name = value;
                    if (/*NameChanged*/ NameChangedEvent != null)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.OldValue = oldValue;
                        args.NewValue = value;
                        NameChangedEvent(this, args);
                        //NameChanged(oldValue, value);
                    }
                }

            }
        }

        public NameChangedDelegate NameChanged;

        public event NameChangedEvent NameChangedEvent;
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void GiveBookAName(GradeBook book)
        {
            book.Name = "The Gradebook";
        }

        static void DoSomething(string strLocal)
        {
            strLocal = "local";
        }

        static void Main(string[] args)
        {
            SpeechSynthesizer synth= new SpeechSynthesizer();
            synth.Speak("Hello! This is the grade book program!");

            //string strMain = "main";
            //DoSomething(strMain);
            //Console.Write(strMain); // What gets printed?



            //for (int i = 0; i < 3; i++)
            //{
            //    Console.Write(i);
            //}
            //i = 5;

            //Immutable();

            PassByValueAndRef();

            //IGradeTracker book = CreateGradeBook();

            GradeTracker book = new GradeBook("test"){testArray = "test attribute of array"};

            GradeTracker [] books={
                new GradeBook("test books"){testArray = "test attribute of array"},
                new GradeBook("test books"){testArray = "test attribute of array"}
            };


            book.TestVirtual();
            book.TestInherient();

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75f);
            book.WriteGrades(Console.Out);

            //try
            //{
            //    Console.WriteLine("Please enter a name for the book");
            //    book.Name = Console.ReadLine();
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine("Invalid name");
            //}

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }

             WriteNames(book.Name);

            GradeStatistics staus = book.ComputeStatistics();

            /********************* DELEGATE ******************************/
            //book.NameChanged = new NameChangedDelegate(OnNameChanged);
            
            //book.NameChanged += OnNameChanged;
            //book.NameChanged += OnNameChanged;
            //book.NameChanged += OnNameChanged2;
            //book.NameChanged -= OnNameChanged;

            /*********************EVENT ****************************************/
            //book.NameChangedEvent += OnNameChangedEvent;
            //book.NameChangedEvent += OnNameChangedEvent2;


            book.Name = "Allen's Book";

            book.Name = "Also Allen's Book";

            WriteNames("Allen", "Scot", "Alex", "Joy");

            int number = 20;
            WriteBytes(number);

            WriteBytes(staus.AverageGrade);

            Console.WriteLine(staus.HighestGrade);
            Console.WriteLine(staus.LowestGrade);
            Console.WriteLine(staus.AverageGrade);
        }

        private static IGradeTracker CreateGradeBook()
        {
            IGradeTracker book = new ThrowAwayGradeBook("Scott's Book");
            return book;
        }

        private static void OnNameChangedEvent2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("*******");
        }

        private static void OnNameChangedEvent(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("Name changed from {0} to {1}", args.OldValue, args.NewValue);
        }

        private static void OnNameChanged(string oldValue, string newValue)
        {
            Console.WriteLine("Name changed from {0} to {1}",oldValue,newValue);
        }

        private static void OnNameChanged2(string oldValue, string newValue)
        {
            Console.WriteLine("*******");
        }

        private static void WriteBytes(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WriteByteArray(bytes);
        }

        private static void WriteByteArray(byte[] bytes)
        {
            foreach (byte b in bytes)
            {
                Console.Write("0x{0:X} ", b);
            }
            Console.WriteLine();
        }

        private static void WriteBytes(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WriteByteArray(bytes);
        }

        private static void WriteNames(params string[] names)
        {
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }

        private static void Immutable()
        {
            string name = " Scott ";
            name=name.Trim();

            DateTime date= new DateTime(2014,1,1);
            date=date.AddHours(25);

            Console.WriteLine(name);
            Console.WriteLine(date);
        }

        private static void PassByValueAndRef()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "1";
            g1 = new GradeBook();


            GiveBookAName(g2);

            Console.WriteLine(g1.Name);
        }
    }
}

using System;
using System.IO;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set default file name, set name if arg is present
            string readFile = "data.txt";
            if (args.Length > 0)
            {
                readFile = args[0];
            }

            //Create new gradebook object, set delegate and event
            GradeBook book = new GradeBook("Math")
            {
                NameChanged = new NameChangedDelegate(OnNameChanged),
            };
            book.NewNameChanged += new NameChangedEventDelegate(OnNewNameChanged);

            //Read the specified file, place grades in gradebook
            try
            {
                using (FileStream stream = File.Open(@"" + readFile, FileMode.Open))
                using (StreamReader reader = new StreamReader(stream))
                {

                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        book.AddGrade(float.Parse(line));
                        line = reader.ReadLine();
                    }
                    reader.Close();
                    stream.Close();
                }
            }
            //Quit if file is not found
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.FileName);
                return;
            }

            //book.Print();

            book.SetName("Science");

            book.WriteGrades(Console.Out);

            book.ComputeStatistics().Print();
            book.ComputeStatistics().Print();
        }

        /// <summary>
        /// Delegate testing
        /// </summary>
        /// <param name="old"></param>
        /// <param name="n"></param>
        private static void OnNameChanged(string old, string n)
        {
            Console.WriteLine("Delegate name changed from {0} to {1}", old, n);
        }

        /// <summary>
        /// Event testing
        /// </summary>
        /// <param name="old"></param>
        /// <param name="n"></param>
        private static void OnNewNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("Event name changed from {0} to {1}", args.Oldvalue, args.NewValue);
        }
    }
}

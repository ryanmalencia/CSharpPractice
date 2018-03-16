using System;
using System.IO;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            string readFile = args[0];
            string[] input = File.ReadAllLines(@"" + readFile);
            GradeBook book = new GradeBook();

            foreach(string line in input)
            {
                book.AddGrade(float.Parse(line));
            }

            book.Print();
            book.ComputeStatistics().Print();
        }
    }
}

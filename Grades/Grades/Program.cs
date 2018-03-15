using System;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook Science = new GradeBook("Science");
            GradeBook Math = new GradeBook("Math");

            Console.WriteLine(Math.GetName());


            /*GradeBook gradeBook = new GradeBook();
            gradeBook.AddGrade(91);
            gradeBook.AddGrade(89.1f);
            gradeBook.AddGrade(75);

            GradeStatistics stats = gradeBook.ComputeStatistics();

            stats.Print();*/
            int i = 0;
        }
    }
}

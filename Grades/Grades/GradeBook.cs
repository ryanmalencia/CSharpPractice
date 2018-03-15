using System;
using System.Collections.Generic;

namespace Grades
{
    public class GradeBook
    {
        private List<float> grades;
        private string name;

        /// <summary>
        /// Default constructor
        /// </summary>
        public GradeBook()
        {
            grades = new List<float>();
            name = "New Gradebook";
        }

        /// <summary>
        /// Constructor with precreated list
        /// </summary>
        /// <param name="grades">List of grades</param>
        public GradeBook(List<float> grades)
        {
            this.grades = grades;
            name = "New Gradebook";
        }

        /// <summary>
        /// Constructor that sets name
        /// </summary>
        /// <param name="name">Name of gradebook</param>
        public GradeBook(string name)
        {
            grades = new List<float>();
            this.name = name;
        }

        /// <summary>
        /// Constructor that sets name and list
        /// </summary>
        /// <param name="grades">List of grades</param>
        /// <param name="name">Name of gradebook</param>
        public GradeBook(List<float> grades, string name)
        {
            this.grades = grades;
            this.name = name;
        }

        /// <summary>
        /// Add grade to list
        /// </summary>
        /// <param name="grade">Grade to add</param>
        /// <returns>Success/Failure</returns>
        public bool AddGrade(float grade)
        {
            if (grade >= 0)
            {
                grades.Add(grade);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Compute statistics of grades in gradebook
        /// </summary>
        /// <returns>GradeStatistics containing stats</returns>
        public GradeStatistics ComputeStatistics()
        {
            float sum = 0;
            float average = 0;
            float highest = 0;
            float lowest = 200;
            int count = grades.Count;
            GradeStatistics stats = new GradeStatistics();

            if (count > 0)
            {
                foreach (float grade in grades)
                {
                    sum += grade;
                    highest = Math.Max(highest, grade);
                    lowest = Math.Min(lowest, grade);
                }

                average = sum / grades.Count;

                stats.SetStatistics(average, highest, lowest);
            }

            return stats;
        }

        /// <summary>
        /// Set name of gradebook
        /// </summary>
        /// <param name="name">Name of gradebook</param>
        /// <returns>New name of gradebook</returns>
        public string SetName(string name)
        {
            this.name = name;
            return this.name;
        }

        /// <summary>
        /// Get name of gradebook
        /// </summary>
        /// <returns>Name of gradebook</returns>
        public string GetName()
        {
            return this.name;
        }

        /// <summary>
        /// Print out all grades to console
        /// </summary>
        /// <returns>String that was output</returns>
        public string Print()
        {
            string statement = "";
            foreach(float grade in grades)
            {
                Console.WriteLine(grade);
                statement = statement + grade + "\n";
            }
            return statement;
        }

        public int GetCount()
        {
            return grades.Count;
        }
    }
}

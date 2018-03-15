using System;

namespace Grades
{
    public class GradeStatistics
    {
        private float AverageGrade;
        private float HighestGrade;
        private float LowestGrade;

        /// <summary>
        /// Default constructor
        /// </summary>
        public GradeStatistics()
        {
            AverageGrade = 0;
            HighestGrade = 0;
            LowestGrade = 0;
        }

        /// <summary>
        /// Set the grade statistics
        /// </summary>
        /// <param name="average">Average grade</param>
        /// <param name="highest">Highest grade</param>
        /// <param name="lowest">Lowest grade</param>
        /// <returns></returns>
        public bool SetStatistics(float average, float highest, float lowest)
        {
            AverageGrade = average;
            HighestGrade = highest;
            LowestGrade = lowest;
            return true;
        }

        /// <summary>
        /// Get average grade
        /// </summary>
        /// <returns>Average grade</returns>
        public float GetAverageGrade()
        {
            return AverageGrade;
        }

        /// <summary>
        /// Get highest grade
        /// </summary>
        /// <returns>Highest grade</returns>
        public float GetHighestGrade()
        {
            return HighestGrade;
        }

        /// <summary>
        /// Get lowest grade
        /// </summary>
        /// <returns>Lowest grade</returns>
        public float GetLowestGrade()
        {
            return LowestGrade;
        }

        /// <summary>
        /// Print statistics
        /// </summary>
        /// <returns>Formatted string</returns>
        public string Print()
        {
            Console.WriteLine("Average: " + AverageGrade);
            Console.WriteLine("Highest: " + HighestGrade);
            Console.WriteLine("Lowest: " + LowestGrade);
            return "Average: " + AverageGrade + "\nHighest: " + HighestGrade + "\nLowest: " + LowestGrade;
        }
    }
}

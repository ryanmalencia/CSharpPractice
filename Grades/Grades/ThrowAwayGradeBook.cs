using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class ThrowAwayGradeBook : GradeBook
    {
        public ThrowAwayGradeBook():base()
        {

        }

        public ThrowAwayGradeBook(string name):base(name)
        {

        }

        public ThrowAwayGradeBook(List<float> grades, string name):base(grades,name)
        {

        }

        public ThrowAwayGradeBook(List<float> grades):base(grades)
        {

        }

        public override GradeStatistics ComputeStatistics()
        {
            float sum = 0;
            float average = 0;
            float highest = 0;
            float save = 0;
            int count = 0;
            float lowest = float.MaxValue;
            GradeStatistics stats = new GradeStatistics();

            foreach (float grade in _grades)
            {
                lowest = Math.Min(lowest, grade);
            }
            save = lowest;
            _grades.Remove(lowest);
            lowest = float.MaxValue;
            count = _grades.Count;

            if (count > 0)
            {
                foreach (float grade in _grades)
                {
                    sum += grade;
                    highest = Math.Max(highest, grade);
                    lowest = Math.Min(lowest, grade);
                }

                average = sum / _grades.Count;

                stats.SetStatistics(average, highest, lowest);
            }
            _grades.Add(save);
            return stats;
        }
    }
}

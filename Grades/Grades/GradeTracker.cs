using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker
    {
        public abstract bool AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract IEnumerator GetEnumerator();
    }
}

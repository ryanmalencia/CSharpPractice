using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public interface IGradeTracker : IEnumerable
    {
        bool AddGrade(float grade);
        GradeStatistics ComputeStatistics();
    }
}

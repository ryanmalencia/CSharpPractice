using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        protected List<float> _grades;
        private string name;
        public NameChangedDelegate NameChanged;
        public event NameChangedEventDelegate NewNameChanged;

        /// <summary>
        /// Default constructor
        /// </summary>
        public GradeBook()
        {
            _grades = new List<float>();
            name = "New Gradebook";
        }

        /// <summary>
        /// Constructor with precreated list
        /// </summary>
        /// <param name="grades">List of grades</param>
        public GradeBook(List<float> grades)
        {
            this._grades = grades;
            name = "New Gradebook";
        }

        /// <summary>
        /// Constructor that sets name
        /// </summary>
        /// <param name="name">Name of gradebook</param>
        public GradeBook(string name)
        {
            _grades = new List<float>();
            this.name = name;
        }

        /// <summary>
        /// Constructor that sets name and list
        /// </summary>
        /// <param name="grades">List of grades</param>
        /// <param name="name">Name of gradebook</param>
        public GradeBook(List<float> grades, string name)
        {
            this._grades = grades;
            this.name = name;
        }

        /// <summary>
        /// Add grade to list
        /// </summary>
        /// <param name="grade">Grade to add</param>
        /// <returns>Success/Failure</returns>
        public override bool AddGrade(float grade)
        {
            if (grade >= 0)
            {
                _grades.Add(grade);
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
        public override GradeStatistics ComputeStatistics()
        {
            float sum = 0;
            float average = 0;
            float highest = 0;
            float lowest = float.MaxValue;
            int count = _grades.Count;
            GradeStatistics stats = new GradeStatistics();

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

            return stats;
        }

        /// <summary>
        /// Set name of gradebook
        /// </summary>
        /// <param name="name">Name of gradebook</param>
        /// <returns>New name of gradebook</returns>
        public string SetName(string name)
        {
            if (name != null)
            {
                //delegate
                NameChanged(this.name, name);

                //event
                NameChangedEventArgs args = new NameChangedEventArgs
                {
                    Oldvalue = this.name,
                    NewValue = name
                };
                NewNameChanged(this, args);

                this.name = name;
            }
            else
            {
                throw new ArgumentNullException("Name cannot be null");
            }
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
            foreach(float grade in _grades)
            {
                Console.WriteLine(grade);
                statement = statement + grade + "\n";
            }
            return statement;
        }

        /// <summary>
        /// Write all grades to desired destination
        /// </summary>
        /// <param name="writer">TextWriter destination</param>
        /// <returns>Success/Failure</returns>
        public bool WriteGrades(TextWriter writer)
        {
            writer.WriteLine(name + " Grades");
            foreach (float grade in _grades)
            {
                writer.WriteLine(grade);
            }
            return true;
        }

        /// <summary>
        /// Get amount of grades
        /// </summary>
        /// <returns>Count of grades</returns>
        public int GetCount()
        {
            return _grades.Count;
        }

        /// <summary>
        /// Get grade enumerator
        /// </summary>
        /// <returns>Enumerator for grades list</returns>
        public override IEnumerator GetEnumerator()
        {
            return _grades.GetEnumerator();
        }
    }
}

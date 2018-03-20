using System;

namespace Grades
{
    public class NameChangedEventArgs : EventArgs
    {
        public string Oldvalue { get; set; }
        public string NewValue { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr1
{
    public class Subject
    {
        public string Name { get; set; }
        public Teacher Lecturer { get; set; } // Об'єкт іншого класу як поле

        public Subject(string name, Teacher lecturer)
        {
            Name = name;
            Lecturer = lecturer;
        }
    }
}

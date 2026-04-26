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
        public Teacher Lecturer { get; set; }

        // Конструктор має приймати саме ці 2 аргументи
        public Subject(string name, Teacher lecturer)
        {
            Name = name;
            Lecturer = lecturer;
        }
    }
}

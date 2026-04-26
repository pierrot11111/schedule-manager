using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr1
{
    public class Lesson
    {
        public DateTime Time { get; set; }
        public Subject CurrentSubject { get; set; }
        public LessonType Type { get; set; }
        public string ZoomLink { get; set; }

        public Lesson(DateTime time, Subject subject, LessonType type, string link)
        {
            Time = time;
            CurrentSubject = subject;
            Type = type;
            ZoomLink = link;
        }
    }
}

using System;

namespace pr1
{
    public class Lesson
    {
        public DateTime Time { get; set; }
        public Subject CurrentSubject { get; set; }
        public LessonType Type { get; set; }
        public string ZoomLink { get; set; }
        public int WeekNumber { get; set; }

        public Lesson(DateTime time, Subject subject, LessonType type, string link, int week = 0)
        {
            Time = time;
            CurrentSubject = subject;
            Type = type;
            ZoomLink = link;
            WeekNumber = week;
        }
    }
}
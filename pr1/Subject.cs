namespace pr1
{
    public class Subject
    {
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public Subject(string name, Teacher teacher) { Name = name; Teacher = teacher; }
    }
}
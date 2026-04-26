using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr1
{
    public class LessonRepository : IRepository<Lesson>
    {
        // Колекція для зберігання даних у пам'яті
        private readonly List<Lesson> _lessons = new List<Lesson>();

        public void Add(Lesson item) => _lessons.Add(item);

        public IEnumerable<Lesson> GetAll() => _lessons;

        public bool Delete(Lesson item) => _lessons.Remove(item);

        public Lesson Find(Predicate<Lesson> match) => _lessons.Find(match);
    }
}

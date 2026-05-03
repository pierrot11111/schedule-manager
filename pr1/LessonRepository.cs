using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace pr1
{
    public class LessonRepository : IRepository<Lesson>
    {
        private List<Lesson> _lessons = new List<Lesson>();
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "schedule.json");

        public LessonRepository() => LoadData();

        public void Add(Lesson item)
        {
            _lessons.Add(item);
            SaveData();
        }

        public bool Delete(Lesson item)
        {
            var found = _lessons.FirstOrDefault(l => l.Time == item.Time && l.ZoomLink == item.ZoomLink);
            if (found != null)
            {
                _lessons.Remove(found);
                SaveData();
                return true;
            }
            return false;
        }

        public IEnumerable<Lesson> GetAll() => _lessons.OrderBy(l => l.Time).ToList();

        public Lesson? Find(Predicate<Lesson> predicate) => _lessons.Find(predicate);

        private void SaveData()
        {
            try
            {
                var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, Formatting = Formatting.Indented };
                string json = JsonConvert.SerializeObject(_lessons, settings);
                File.WriteAllText(_filePath, json);
            }
            catch (IOException ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }
        }

        private void LoadData()
        {
            if (!File.Exists(_filePath)) return;
            try
            {
                string json = File.ReadAllText(_filePath);
                var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                _lessons = JsonConvert.DeserializeObject<List<Lesson>>(json, settings) ?? new List<Lesson>();
            }
            catch { _lessons = new List<Lesson>(); }
        }
    }
}
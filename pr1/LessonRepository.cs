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
        // Використовуємо AppDomain, щоб файл завжди був в папці з .exe
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "schedule.json");

        public LessonRepository()
        {
            LoadData();
        }

        public void Add(Lesson item)
        {
            _lessons.Add(item);
            SaveData();
        }

        public bool Delete(Lesson item)
        {
            var lessonToRemove = _lessons.FirstOrDefault(l => l.Time == item.Time && l.ZoomLink == item.ZoomLink);
            if (lessonToRemove != null)
            {
                _lessons.Remove(lessonToRemove);
                SaveData();
                return true;
            }
            return false;
        }

        public Lesson Find(Predicate<Lesson> predicate) => _lessons.Find(predicate);

        public IEnumerable<Lesson> GetAll() => _lessons;

        private void SaveData()
        {
            try
            {
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All, // Зберігає інформацію про класи
                    Formatting = Formatting.Indented
                };
                string json = JsonConvert.SerializeObject(_lessons, settings);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Помилка збереження: " + ex.Message);
            }
        }

        private void LoadData()
        {
            if (File.Exists(_filePath))
            {
                try
                {
                    string json = File.ReadAllText(_filePath);
                    var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                    var data = JsonConvert.DeserializeObject<List<Lesson>>(json, settings);
                    if (data != null) _lessons = data;
                }
                catch (Exception ex)
                {
                    _lessons = new List<Lesson>();
                    System.Windows.Forms.MessageBox.Show("Помилка завантаження: " + ex.Message);
                }
            }
        }
    }
}
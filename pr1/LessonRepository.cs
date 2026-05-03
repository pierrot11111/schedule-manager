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
            // Пошук за часом та посиланням для точного видалення
            var found = _lessons.FirstOrDefault(l => l.Time == item.Time && l.ZoomLink == item.ZoomLink);
            if (found != null)
            {
                _lessons.Remove(found);
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
                var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, Formatting = Formatting.Indented };
                string json = JsonConvert.SerializeObject(_lessons, settings);
                File.WriteAllText(_filePath, json);
            }
            catch (IOException ex)
            {
                System.Windows.Forms.MessageBox.Show($"Помилка доступу до файлу: {ex.Message}", "Помилка запису", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Непередбачувана помилка при збереженні: {ex.Message}");
            }
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
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Не вдалося завантажити розклад: {ex.Message}", "Помилка файлу", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                _lessons = new List<Lesson>();
            }
        }
    }
}
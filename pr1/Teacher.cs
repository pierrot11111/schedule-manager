using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr1
{
    public class Teacher
    {
        // Приватне поле (інкапсуляція)
        private string _fullName;

        // Публічна властивість
        public string FullName
        {
            get => _fullName;
            set => _fullName = value;
        }

        public string Email { get; set; }

        // Конструктор для ініціалізації
        public Teacher(string fullName, string email)
        {
            _fullName = fullName;
            Email = email;
        }
    }
}

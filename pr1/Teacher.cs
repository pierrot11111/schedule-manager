using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr1
{
    public class Teacher
    {
        private string _fullName;

        public string FullName
        {
            get => _fullName;
            set => _fullName = value;
        }

        public string Email { get; set; }

        // Цей конструктор МАЄ БУТИ ТУТ
        public Teacher(string fullName, string email)
        {
            _fullName = fullName;
            Email = email;
        }
    }
}

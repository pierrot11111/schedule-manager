using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr1
{
    // Узагальнений інтерфейс для роботи з даними
    public interface IRepository<T>
    {
        void Add(T item);               // Додати елемент
        IEnumerable<T> GetAll();        // Отримати всі елементи
        bool Delete(T item);            // Видалити елемент
        T Find(Predicate<T> match);     // Пошук за умовою
    }
}

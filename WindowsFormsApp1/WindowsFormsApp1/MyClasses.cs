using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{

    public class Cabinets
    {
        public int Value { get; set; }
        public string Resolution { get; set; }
        public string Side { get; set; }

    }

    public class Screen : IEnumerable<Cabinets>
    {
        public List<Cabinets> Cabinets { get; set; }
        public Screen()
        {
            Cabinets = new List<Cabinets>();
        }

        public IEnumerator<Cabinets> GetEnumerator()
        {
            return Cabinets.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class EnumerableExtensions
    {
        public static T Find<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            // Проверяем входные параметры
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            // Перебираем элементы и возвращаем первый элемент, который удовлетворяет предикату
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            // Возвращаем значение по умолчанию (null для ссылочных типов, например, классов)
            return default;
        }
    }
}

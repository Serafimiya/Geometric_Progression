using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Progression
{


    /// <summary>
    /// Реализация интерфейса ISeries
    /// </summary>
    internal class TwoSeries : ISeries
    {
        private int start;        // Первый элемент (b)
        private int current;      // Текущее значение
        private int multiplier;   // Множитель (q)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="q"></param>
        /// <exception cref="ArgumentException"></exception>
        public TwoSeries(int b, int q)
        {
            if (b <= 0)
                throw new ArgumentException("Первый элемент (b) должен быть больше 0.");
            if (q <= 0)
                throw new ArgumentException("Множитель должен быть больше 0.");

            start = b;
            current = b;
            multiplier = q;
        }
        /// <summary>
        /// Возвратить следующее по порядку число
        /// </summary>

        public int Next
        {
            get { return GetNext(); }
        }

        /// <summary>
        /// Возратить следующее по порядку число
        /// </summary>
        /// <returns></returns>
        public int GetNext()
        {
            int temp = current;
            current *= multiplier; // Умножаем текущее значение на множитель
            return temp;
        }

        /// <summary>
        /// Перезапустить
        /// </summary>
        public void Reset()
        {
            current = start;
        }

        /// <summary>
        /// Задать начальное значение
        /// </summary>
        /// <param name="x"></param>
        public void SetStart(int x)
        {
            start = x;
            current = start;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class Series : IComparable, ICloneable
    {
        int q; // Шаг прогрессии
        int b; // Первый эелемент

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="q"></param>
        public Series(int b, int q)
        {
            this.b = b;
            this.q = q;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj) // Реализация интерфейса
        {
            Series other = (Series)obj;
            if (this.q > other.q) return 1; // Текущий объект "больше"
            if (this.q < other.q) return -1; // Текущий объект "меньше"
            return 0; // Равны
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Series(this.b, this.q);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Series: b = {b}, q = {q}";
        }
    }

}

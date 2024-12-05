using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometric_Progression
{
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

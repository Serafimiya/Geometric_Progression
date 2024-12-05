using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometric_Progression
{
    internal interface ISeries
    {
        int Next { get; } // Возратить следующее по порядку число
        void Reset(); // Перезапустить
        void SetStart(int x); //Задать начальное значение

    }
}

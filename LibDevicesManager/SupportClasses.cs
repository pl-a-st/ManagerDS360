using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDevicesManager
{
    /// <summary>
    /// Для вызова досрочного выхода из родительского метода 
    /// </summary>
    public class EarlyExitException : Exception
    {
        public EarlyExitException(string message)
            : base(message) { }
    }
    /// <summary>
    /// Сортированный словарь реализуеющий АЧХ 
    /// где ключ - частота,
    /// занчение - коэффициент, на который нужно домножить
    /// </summary>
    [Serializable]
    public class FrequencyResponse : SortedDictionary<double, double>
    {
        public string Name = string.Empty;
        /// <summary>
        /// Добавляет или затирает коэффициент для указанной частоты в словаре
        /// </summary>
        /// <value><br><see langword="double"/></br> frequency: частота 
        /// <br><see langword="double"/></br> <see cref="coefficient"/>: коэффициент  </value>
        /// <param name="frequency"></param>
        /// <param name="coefficient"></param>
        public new void Add(double frequency, double coefficient)
        {
            if (this.ContainsKey(frequency))
            {
                this[frequency] = coefficient;
            }
            else
            {
                base.Add(frequency, coefficient);
            }
        }
        /// <summary>
        /// Вычисляет аппроксимированный коэффициент для указанной частоты 
        /// </summary>
        /// <value><br><strong><see langword="double"/></strong></br> frequency: частота </value>
        /// <returns><br><strong><see langword="double"/></strong></br> коэффициент</returns>
        public double GetCoefficient(double frequency)
        {
            double coefficient = 1;
            if (this.TryGetValue(frequency, out coefficient))
            {
                return coefficient;
            }
            if (this.Count < 1)
            {
                return 1;
            }
            if (this.Count < 2)
            {
                return this.ElementAt(0).Value;
            }
            double x = frequency;
            double x1 = 0;
            double x2 = 0;
            double y1 = 0;
            double y2 = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (frequency > this.ElementAt(i).Key)
                {
                    continue;
                }
                if (i == 0)
                {
                    x1 = this.ElementAt(i).Key;
                    x2 = this.ElementAt(i + 1).Key;
                    y1 = this.ElementAt(i).Value;
                    y2 = this.ElementAt(i + 1).Value;
                    return y1 + (x - x1) * (y2 - y1) / (x2 - x1);
                }
                x1 = this.ElementAt(i).Key;
                x2 = this.ElementAt(i - 1).Key;
                y1 = this.ElementAt(i).Value;
                y2 = this.ElementAt(i - 1).Value;
                return y1 + (x - x1) * (y2 - y1) / (x2 - x1);
            }
            x1 = this.ElementAt(this.Count - 1).Key;
            x2 = this.ElementAt(this.Count - 1 - 1).Key;
            y1 = this.ElementAt(this.Count - 1).Value;
            y2 = this.ElementAt(this.Count - 1 - 1).Value;
            return y1 + (x - x1) * (y2 - y1) / (x2 - x1);
        }
    }
    
}

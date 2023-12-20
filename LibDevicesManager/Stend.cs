using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDevicesManager
{
    [Serializable]
    public class Stend
    {
        private double accuracy = 0.01;
        /// <summary>
        /// Точность, значение от 0 до 1
        /// </summary>
        public double Accuracy
        {
            get => accuracy;
            set => accuracy = value >= 0 && value <= 1 ? value : throw new ArgumentOutOfRangeException("Значение Accuracy больше единицы или меньше нуля");
        }
    }
}

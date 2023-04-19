using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSystem
{
    internal class Food : Product
    {
        private const double MaxPercentageMarkup = 100;

        public Food(string name, int quantity, double deliverPrice, double percentageMarkup)
            : base(name, quantity, deliverPrice, percentageMarkup)
        {
            if (this.PercentageMarkup > MaxPercentageMarkup)
            {
                throw new ArgumentException("Food percentage markup cannot be above 100%!");
            }
        }

        public override string ToString()
        {
            return $"Food\n{base.ToString()}";
        }
    }
}

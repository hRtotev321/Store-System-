using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSystem
{
    internal class Drink : Product
    {
        private const double MaxPercentageMarkup = 200;

        public Drink(string name, int quantity, double deliverPrice, double percentageMarkup)
            : base(name, quantity, deliverPrice, percentageMarkup)
        {
            if (this.PercentageMarkup > MaxPercentageMarkup)
            {
                throw new ArgumentException("Drink percentage markup cannot be above 200%!");
            }
        }

        public override string ToString()
        {
            return $"Drink\n{base.ToString()}";
        }
    }
}

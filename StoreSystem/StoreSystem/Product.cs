using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSystem
{
    public abstract class Product
    {
        private string name;
        private int quantity;
        private double deliverPrice;
        private double percentageMarkup;

        public Product(string name, int quantity, double deliverPrice, double percentageMarkup)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.DeliverPrice = deliverPrice;
            this.PercentageMarkup = percentageMarkup;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Product name must not be null or empty!");
                }

                this.name = value;
            }
        }

        public int Quantity
        {
            get => this.quantity;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Quantity cannot be less or equal to 0!");
                }

                this.quantity = value;
            }
        }

        public double DeliverPrice
        {
            get => this.deliverPrice;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Deliver price cannot be less or equal to 0!");
                }

                this.deliverPrice = value;
            }
        }

        public double PercentageMarkup
        {
            get => this.percentageMarkup;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Percentage markup cannot be less or equal to 0!");
                }

                this.percentageMarkup = value;
            }
        }

        public double FinalPrice => this.DeliverPrice + (this.DeliverPrice * this.PercentageMarkup / 100);

        public override string ToString()
        {
            return ($"Product: {this.Name} <{this.Quantity}>\n") +
                   ($"Deliver Price: {this.DeliverPrice}\n") +
                   ($"Percentage Markup: {this.PercentageMarkup}\n") +
                   ($"Final Price: {this.FinalPrice}");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSystem
{
    internal class Store:Product
    {
        private string name;
        private string type;
        private double revenue;
        private readonly Dictionary<string, List<Product>> products;

        public Store(string name, string type)
        {
            this.Name = name;
            this.Type = type;
            this.revenue = 0;
            this.products = new Dictionary<string, List<Product>>();
        }

        public new string Name;

        public string Type { get; private set; }

        internal object Products;

        internal object AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        internal object SellProduct(object product, int quantity)
        {
            throw new NotImplementedException();
        }

        internal object GetRevenue()
        {
            throw new NotImplementedException();
        }
    }
}

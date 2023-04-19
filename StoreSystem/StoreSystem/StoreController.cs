using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreSystem
{
    internal class StoreController
    {
        private readonly List<Store> stores = new List<Store>();

        public string CreateStore(List<string> args)
        {
            if (args.Count != 2)
            {
                return "Error: Invalid number of arguments for create store command.";
            }

            string name = args[0];
            string type = args[1];

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(type))
            {
                return "Error: Store name and type cannot be empty.";
            }

            var store = new Store(name, type);
            stores.Add(store);

            return $"Success: Store {name} of type {type} created.";
        }

        public string ReceiveProduct(List<string> args)
        {
            if (args.Count != 6)
            {
                return "Error: Invalid number of arguments for receive product command.";
            }

            string type = args[0];
            string name = args[1];
            string storeName = args[5];

            if (string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(storeName)
                || !int.TryParse(args[2], out int quantity) || !decimal.TryParse(args[3], out decimal price)
                || !decimal.TryParse(args[4], out decimal markup))
            {
                return "Error: Invalid arguments for receive product command.";
            }

            var store = stores.FirstOrDefault(s => s.Name == storeName);
            if (store == null)
            {
                return $"Error: Store {storeName} not found.";
            }

            Product product1 = new Product(type, name, quantity, price, markup);
            Product product = product1;
            var result = store.AddProduct(product);

            return (string)result;
        }

        public string SellProduct(List<string> args)
        {
            if (args.Count != 3)
            {
                return "Error: Invalid number of arguments for sell product command.";
            }

            string name = args[0];
            string storeName = args[2];

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(storeName)
                || !int.TryParse(args[1], out int quantity))
            {
                return "Error: Invalid arguments for sell product command.";
            }

            var store = stores.FirstOrDefault(s => s.Name == storeName);
            if (store == null)
            {
                return $"Error: Store {storeName} not found.";
            }

            var product = store.Products.FirstOrDefault(p => p.Name == name);
            if (product == null)
            {
                return $"Error: Product {name} not found in store {storeName}.";
            }

            var result = store.SellProduct(product, quantity);

            object result1 = result;
            return (string)result1;
        }

        public string StoreInfo(List<string> args)
        {
            if (args.Count != 1)
            {
                return "Error: Invalid number of arguments for store info command.";
            }

            string storeName = args[0];

            if (string.IsNullOrWhiteSpace(storeName))
            {
                return "Error: Store name cannot be empty.";
            }

            var store = stores.FirstOrDefault(s => s.Name == storeName);
            if (store == null)
            {
                return $"Error: Store {storeName} not found.";
            }

            return store.ToString();
        }

        public string Shutdown()
        {
            var sortedStores = stores.OrderByDescending(s => s.GetRevenue()).ThenBy(s => s.Name).ToList();
            return string.Join(Environment.NewLine, sortedStores);
        }
    }
}


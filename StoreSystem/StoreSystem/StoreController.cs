﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

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
            int quantity = 0;
            decimal price = 0;
            decimal markup = 0;
            string storeName = args[5];

            if (string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(storeName)
                || !int.TryParse(args[2], out quantity) || !decimal.TryParse(args[3], out price)
                || !decimal.TryParse(args[4], out markup))
            {
                return "Error: Invalid arguments for receive product command.";
            }

            var store = stores.FirstOrDefault(s => s.Name == storeName);
            if (store == null)
            {
                return $"Error: Store {storeName} not found.";
            }

            var product = new Product(type, name, quantity, price, markup);
            var result = store.AddProduct(product);

            return result;
        }

        public string SellProduct(List<string> args)
        {
            if (args.Count != 3)
            {
                return "Error: Invalid number of arguments for sell product command.";
            }

            string name = args[0];
            int quantity = 0;
            string storeName = args[2];

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(storeName)
                || !int.TryParse(args[1], out quantity))
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

            return result;
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


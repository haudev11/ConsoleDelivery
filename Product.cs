using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    internal class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int OnMap { get; set; }
        public int Node { get; set; }
        public Product()
        {
                
        }
        public Product(int id, string name, double price, int onMap, int node)
        {
            ID = id;
            Name = name;
            Price = price;
            OnMap = onMap;
            Node = node;
        }

        public void ShowInfo()
        {
            Console.WriteLine("ID        : {0}", ID);
            Console.WriteLine("Name      : {0}", Name);
            Console.WriteLine("Price     : {0}", Price);
            Console.WriteLine("Map       : {0}", OnMap);
            Console.WriteLine("Location  : {0}", Node);
            Console.WriteLine();
        }
    }
}

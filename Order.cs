using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    internal class Order
    {
        public int ID { get; set; }
        public int IdProduct { get; set; }
        public int IdUser { get; set; }

        public double Price { get; set; }

        public Order(int id, int idProduct, int idUser, double price)
        {
            ID = id;
            IdProduct = idProduct;
            IdUser = idUser;
            Price = price;
        }
    }
}

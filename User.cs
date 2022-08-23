using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    internal class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
        public double Money { get; set; }
        public int OnMap { get; set; }
        public int Node { get; set; }

        public User()
        {
        }
        public User(int id, string firstName, string lastName, string userName, string password, double money, int onMap, int node)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Money = money;
            OnMap = onMap;
            Node = node;
        }
        public void ShowInfomation()
        {
            Console.WriteLine("Your information");
            Console.WriteLine("Name         : {0} {1}", FirstName, LastName);
            Console.WriteLine("ID           : {0}", ID);
            Console.WriteLine("User Name    : {0}", UserName);
            Console.WriteLine("Money        : {0}", Money);
            Console.WriteLine("Map          : {0}", OnMap);
            Console.WriteLine("Location     : {0}", Node);
            Console.WriteLine();
        }
        public void ChangeName()
        {
            string firstName;
            string lastName;
            Console.WriteLine("Please enter a new name:");
            Console.Write("First name: ");
            firstName = Console.ReadLine();
            Console.Write("Last name: ");
            lastName = Console.ReadLine();
            LastName = lastName;

            if (firstName == FirstName && lastName == LastName)
            {
                Console.WriteLine("New name and old name are the same, update failed");
            } else
            {
                FirstName = firstName;
                lastName = lastName;
                Console.WriteLine("Update successful");
            }
        }

        public void ChangePassword()
        {
            while (true)
            {
                Console.WriteLine("Please enter old password");
                Console.Write("Password: ");
                string password = Console.ReadLine();
                if (password != Password)
                {
                    Console.WriteLine("Wrong password. Please enter again.");
                } else
                {
                    string newPassword;
                    string reNewPassword;
                    while (true)
                    {
                        Console.Write("New password: ");
                        newPassword = Console.ReadLine();
                        Console.Write("Re-enter New password: ");
                        reNewPassword = Console.ReadLine();
                        if (newPassword != reNewPassword)
                        {
                            Console.WriteLine("New Passwords do not match");
                            Console.WriteLine("Re-enter");
                        }
                        else
                        {
                            break;
                        }
                    }
                    Password = newPassword;
                    break;
                }
            }
        }
        public void Recharge()
        {
            //This method is only completed as a test and cannot be put into practice
            Console.WriteLine("Enter the amount you want to deposit");
            double money = int.Parse(Console.ReadLine());
            Money = money;
            Console.WriteLine("Recharge completed");
        }
        public Order OrderProduct(int idOrder, List<Product> products)
        {
            Console.WriteLine("Menu products:");
            products.ForEach(p => p.ShowInfo());

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("|If you want to buy a product, enter the number 1     |");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("|If you want to exit purchase mode, enter key 2       |");
            Console.WriteLine("-------------------------------------------------------");
            string option;
            while (true)
            {
               option = Console.ReadLine();
                if (option != "2" && option != "1")
                {
                    Console.WriteLine("Your selection does not match, please enter only 1 or 2");
                    Console.Write("Retype: ");
                }
                else break;
            }
            if (option == "2") return null;

            int idProduct;
            double price = 0;
            while (true)
            {
                Console.WriteLine("Please enter the product ID you want to order");
                Console.Write("ID Product: ");
                idProduct = int.Parse(Console.ReadLine());
                bool checkID = false;

                products.ForEach(p =>
                {
                    if (p.ID == idProduct)
                    {
                        checkID = true;
                        price = p.Price;
                    }
                });

                if (!checkID)
                {
                    Console.WriteLine("ID {0} does not exist, please re-enter", idProduct);
                }
                else break;
            }
            Order order = new Order(idOrder, idProduct, ID, price);
            return order;
        }
    }
}

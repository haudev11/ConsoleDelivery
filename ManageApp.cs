using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    internal class ManageApp
    {
        public List<User> Users { get; set; }
        public List<Product> Products { get; set; }
        public List<SingleMap> Maps { get; set; }
        public List<Order> Orders { get; set; }
        public ManageApp()
        {
            Users = new List<User>();
            Products = new List<Product>();
            Maps = new List<SingleMap>();
            Orders = new List<Order>();
        }

        private void ReadListMaps()
        {
            string path = @"F:\Greenwich\1618_ProgrammingC#\asm1\data\maps.txt";
            string[] mapsLine = File.ReadAllLines(path);

            int numberMaps = int.Parse(mapsLine[0]);
            int currentLine = 1;
            for (int i = 1; i <= numberMaps; i++)
            {
                string[] line = mapsLine[currentLine].Split(' ').ToArray();
                int numberNode, numberRoad;
                numberNode = int.Parse(line[0]);
                numberRoad = int.Parse(line[1]);
                currentLine++;
                SingleMap singleMap = new SingleMap(numberNode, numberRoad);
                for (int j = currentLine; j < currentLine + numberRoad; j++)
                {
                    line = mapsLine[j].Split(' ').ToArray();
                    singleMap.AddRoad(int.Parse(line[0]), int.Parse(line[1]), int.Parse(line[2]), double.Parse(line[3]));
                }
                currentLine += numberRoad;
                Maps.Add(singleMap);
            }
        }
        private void ReadListProducts()
        {
            string path = @"F:\Greenwich\1618_ProgrammingC#\asm1\data\products.txt";
            string[] procductsLine = File.ReadAllLines(path);

            for (int i = 0; i < procductsLine.Length; i++)
            {
                string[] line = procductsLine[i].Split(' ').ToArray();

                int id = int.Parse(line[0]);
                string name = "";
                for (int j = 2; j <= int.Parse(line[1]) + 1; j++)
                {
                    if (j != int.Parse(line[1])) name += line[j] + " ";
                    else name += line[j];
                }
                double price = double.Parse(line[2 + int.Parse(line[1])]);
                int onMap = int.Parse(line[3 + int.Parse(line[1])]);
                int node = int.Parse(line[4 + int.Parse(line[1])]);
                Product product = new Product(id, name, price, onMap, node);
                Products.Add(product);
            }   
        }
        private void ReadListUsers()
        {
            string path = @"F:\Greenwich\1618_ProgrammingC#\asm1\data\users.txt";
            string[] usersLine = File.ReadAllLines(path);

            for (int i = 0; i < usersLine.Length; i++)
            {
                string[] line = usersLine[i].Split(' ').ToArray();
                int id = int.Parse(line[0]);
                int firstNameBegin = 2;
                int firstNameEnd = 2 + int.Parse(line[1]) - 1;
                int lastNameIndex = firstNameEnd + 1;
                string firstName = "";
                for (int j = firstNameBegin; j <= firstNameEnd; j++)
                {
                    firstName += line[j];
                    if (j != firstNameEnd) firstName += " ";
                }
                string lastName = line[lastNameIndex];
                string userName = line[lastNameIndex + 1];
                string password = line[lastNameIndex + 2];
                double money = double.Parse(line[lastNameIndex + 3]);
                int map = int.Parse(line[lastNameIndex + 4]);
                int node = int.Parse(line[lastNameIndex + 5]);
                User user = new User(id, firstName, lastName, userName, password, money, map, node);
                Users.Add(user);
            } 

        }
        private void WriteListUsers()
        {
            string path = @"F:\Greenwich\1618_ProgrammingC#\asm1\data\users.txt";
            string content = "";
            for (int i = 0; i < Users.Count; i++)
            {
                int firstNameLength = Users[i].FirstName.Split(' ').ToArray().Length;
                content += Users[i].ID.ToString() + " "
                         + firstNameLength.ToString() + " "
                         + Users[i].FirstName + " "
                         + Users[i].LastName + " "
                         + Users[i].UserName + " "
                         + Users[i].Password + " "
                         + Users[i].Money.ToString() + " "
                         + Users[i].OnMap.ToString() + " "
                         + Users[i].Node.ToString()+ " "
                         + System.Environment.NewLine;
            }
            File.WriteAllText(path, content);
        }
        private void ReadListOrders()
        {
            string path = @"F:\Greenwich\1618_ProgrammingC#\asm1\data\orders.txt";
            string[] ordersLine = File.ReadAllLines(path);

            for (int i = 0; i < ordersLine.Length; i++)
            {
                string[] line = ordersLine[i].Split(' ').ToArray();
                Order order = new Order(int.Parse(line[0]), int.Parse(line[1]), int.Parse(line[2]), double.Parse(line[3]));
                Orders.Add(order);
            }
        }
        private void WriteListOrders()
        {
            string path = @"F:\Greenwich\1618_ProgrammingC#\asm1\data\orders.txt";
            string content = "";
            for (int i = 0; i < Orders.Count; i++)
            {
                content += Orders[i].ID.ToString() + " "
                         + Orders[i].IdProduct.ToString() + " "
                         + Orders[i].IdUser.ToString() + " "
                         + Orders[i].Price.ToString() + " "
                         + System.Environment.NewLine;
            }
            File.WriteAllText(path, content);
        }
        public void ReadData()
        {
            ReadListMaps();
            ReadListProducts();
            ReadListUsers();
            ReadListOrders();
        }
        public void WriteData()
        {
            WriteListUsers();
            WriteListOrders();
        }
        private bool CheckUserName(string userName)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].UserName == userName) return false;
            }
            return true;
        }
        public void CreateAccount()
        {
            string firstName;
            string lastName;
            string userName;
            string password;
            string repeatPassword;
            int onMap;
            int node;
            int id = Users.Count + 1;
            Console.WriteLine("Please enter the following information to create your account");
            Console.Write("First Name: ");
            firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            lastName = Console.ReadLine();
            while (true)
            {
                Console.Write("User name: ");
                userName = Console.ReadLine();
                if (!CheckUserName(userName))
                {
                    Console.WriteLine("User name {0} already exists", userName);
                    Console.WriteLine("Please enter User Name");
                }
                else break;
            }
            while (true)
            {
                Console.Write("Password: ");
                password = Console.ReadLine();
                Console.Write("Re-enter password: ");
                repeatPassword = Console.ReadLine();
                if (password != repeatPassword)
                {
                    Console.WriteLine("Passwords do not match");
                    Console.WriteLine("Re-enter");
                }else
                {
                    break;
                }
            }
            Console.WriteLine("Please enter your address");
            Console.Write("Map: ");
            onMap = int.Parse(Console.ReadLine());
            Console.Write("Node: ");
            node = int.Parse(Console.ReadLine());   
            
            User newUser = new User(id: id, firstName: firstName, lastName: lastName,
                                    userName: userName, password: password, money: 0, onMap: onMap, node: node);
            Users.Add(newUser);
            Console.WriteLine("You have successfully created an account, please login again");
        }
        private int CheckUserNameAndPassword(string userName, string password)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].UserName == userName)
                {
                    if (Users[i].Password == password) return i;
                    return -2;
                }
            }
            return -1;
        }
        public int LogIn()
        {
            string userName;
            string password;
            Console.WriteLine("Please login your account");
            Console.Write("User name: ");
            userName = Console.ReadLine();
            Console.Write("Your password: ");
            password = Console.ReadLine();

            int check = CheckUserNameAndPassword(userName, password);
            if (check == -2)
            {
                Console.WriteLine("Wrong password");
                return -1;
            } else if (check == -1)
            {
                Console.WriteLine("Account does not exist");
                return -1;
            }
            return check;
        }

        public void ReceivedOneOrder(Order order)
        {
            Console.WriteLine("Each order will have a shipping fee," +
                " we will calculate the shipping cost based on the distance" +
                " from you to the product (the shortest path)");

            Console.WriteLine("Shipping price");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("|1: Road less than 2km: 5000vnd    ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("|2: Road less than 5km: 10000vnd   ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("|3: Road less than 10km: 15000vnd  ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("|4: Road equal or more than 10km: 20000vnd  ");
            Console.WriteLine("-------------------------------------------");

            User user = new User();
            int userIndex = 0;
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].ID == order.IdUser)
                {
                    user = Users[i];
                    userIndex = i;
                    break;
                }
            }
            Product product = new Product();

            for(int i = 0;i < Products.Count; i++)
            {
                if (Products[i].ID == order.IdProduct)
                {
                    product = Products[i];
                }
            }
            double shippingCost;
            double pathCost = Maps[user.OnMap - 1].FindShortestPath(user.Node, product.Node);
            if (pathCost < 2)
            {
                shippingCost = 5000;
            } else if (pathCost < 5)
            {
                shippingCost = 10000;
            } else if (pathCost < 10)
            {
                shippingCost  = 15000;
            } else
            {
                shippingCost = 20000;
            }
            double total = order.Price + shippingCost;
            Console.WriteLine("----------------------------------");
            Console.WriteLine("|The distance is {0}km          ", pathCost);
            Console.WriteLine("----------------------------------");
            Console.WriteLine("The total value of your order is: ");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Price product: {0:F2}   ", order.Price);
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Shipping cost: {0:F2}", shippingCost);
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Total        : {0:F2}       ", total);
            Console.WriteLine("----------------------------------");
            Console.WriteLine();
            Console.WriteLine("Do you want to pay Bills");
            Console.WriteLine("1: Yes");
            Console.WriteLine("2: No");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                if (user.Money < total)
                {
                    Console.WriteLine("Your wallet does not have enough money to pay, the order will be canceled");
                    return;
                }
                Users[userIndex].Money -= total;
                order.Price = total;
                Orders.Add(order);
                Console.WriteLine("Your order has been successful, please wait for delivery");
                WriteData();
            } 
        }
    }
}

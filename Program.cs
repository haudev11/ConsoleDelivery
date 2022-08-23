using System;

namespace App
{
    class Program
    {

        
        public static void Main()
        {
            ManageApp manageApp = new ManageApp();
            manageApp.ReadData();
            int userIndex = 1;
            while (true)
            {
                Console.WriteLine("Welcome to Pi App is an application." +
                    " That allows you to order products" +
                    " and have fast delivery in 1h");

                Console.WriteLine("1: Press 1 to login");
                Console.WriteLine("2: Press 2 to create an account");
                Console.WriteLine("3: Press 3 to exit");
                Console.Write("Your option: ");
                int option = int.Parse(Console.ReadLine());
                if (option == 3) return;
                if (option == 1)
                {
                    userIndex = manageApp.LogIn();
                    if (userIndex >= 0) break;
                } else
                {
                    manageApp.CreateAccount();
                }
                manageApp.WriteData();
            }
            
            Console.Clear();
            Console.WriteLine("Welcome {0} to PiApp", manageApp.Users[userIndex].LastName);
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Here are your options");
                Console.WriteLine("1: Show my information");
                Console.WriteLine("2: Change my name");
                Console.WriteLine("3: Change password");
                Console.WriteLine("4: Deposit money into my account");
                Console.WriteLine("5: Order the products");
                Console.WriteLine("6: Exit the program");
                Console.Write("Your option: ");
                int option = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (option == 1) manageApp.Users[userIndex].ShowInfomation();
                else if (option == 2) manageApp.Users[userIndex].ChangeName();
                else if (option == 3) manageApp.Users[userIndex].ChangePassword();
                else if (option == 4) manageApp.Users[userIndex].Recharge();
                else if (option == 5)
                {
                    Order order = manageApp.Users[userIndex].OrderProduct(manageApp.Orders.Count +1, 
                        manageApp.Products.FindAll( p => p.OnMap == manageApp.Users[userIndex].OnMap));
                    if (order != null)
                    {
                        manageApp.ReceivedOneOrder(order);
                    }
                }
                else break;
            }
            Console.WriteLine();
        }
    }
}
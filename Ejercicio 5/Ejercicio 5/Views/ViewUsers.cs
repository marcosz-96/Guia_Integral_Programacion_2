using System;
using System.Collections.Generic;

using Models;

namespace Views
{
    public class ViewUsers
    {
        public User RegisteredUser()
        {
            Console.WriteLine("---- REGISTER USER ----");
            Console.Write("\nUser Name: ");
            string nameUser = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            return new User(nameUser, email);
        }

        public void ShowUsers(List<User> users)
        {
            Console.WriteLine("\nLIST OF THE USERS");

            for (int u = 0; u < users.Count; u++)
            {
                Console.WriteLine("\n::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                Console.WriteLine($"ID: {u + 1} | User Name: {users[u].NameUser} | Email: {users[u].Email}");
                Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            }
        }

        public void MostrarMenuUsuarios()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("         ----> USER MENU <----       ");
            Console.WriteLine("-------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n-------------------------------------");
            Console.WriteLine("1. Register user");
            Console.WriteLine("2. List users");
            Console.WriteLine("3. Return to the main menu");
            Console.WriteLine("-------------------------------------");
            Console.Write("Enter an option: ");
            Console.ResetColor();
        }
    }
}

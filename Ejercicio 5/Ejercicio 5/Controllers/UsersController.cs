using System;
using System.Collections.Generic;

using Models;
using Views;
using Repository;

namespace Controllers
{
    public class UsersController
    {
        private List<User> _users;
        private ViewUsers _view;
        private const string UserFile = "usersList"; // Nombre del archivo JSON

        public UsersController(List<User> users)
        {
            _view = new ViewUsers();
            _users = Repository<User>.ObtenerTodos(UserFile);
        }

        private void RegisterUser()
        {
            // Registramos a los usuarios
            User newUser = _view.RegisteredUser();
            _users.Add(newUser);

            // También se guarda la lista de usuarios en un archivo JSON
            Repository<User>.GuardarLista(UserFile, _users);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n¡User successfully registered!");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }

        private void UserList()
        {
            _view.ShowUsers(_users);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPress 'enter' per return to menu.");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }

        // Submenu de opciones para registrar usuarios
        public void ShowMenuUser()
        {
            bool inMainUser = true;

            while (inMainUser)
            {
                Console.Clear();
                _view.MostrarMenuUsuarios();
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        RegisterUser();
                        break;
                    case "2":
                        Console.Clear();
                        UserList();
                        break;
                    case "3":
                        Console.Clear();
                        inMainUser = false;
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[ERROR] Option invalid.");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}

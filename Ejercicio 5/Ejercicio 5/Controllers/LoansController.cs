using System;
using System.Collections.Generic;

using Models;
using Views;
using Repository;

namespace Controllers
{
    public class LoansController
    {
        // Se instancian las dependencias
        private List<Loans> _loans;
        private List<Book> _books;
        private List<User> _users;
        private ViewLoans _views;

        // Se crean los nombres de los archivos JSON
        private const string LoansFile = "loans";
        private const string BooksFile = "books";
        private const string UsersFile = "users";

        // Se inicializan las dependencias con el constructor y se cargan desde los archivos JSON
        public LoansController()
        {
            _loans = Repository<Loans>.ObtenerTodos(LoansFile);
            _books = Repository<Book>.ObtenerTodos(BooksFile);
            _users = Repository<User>.ObtenerTodos(UsersFile);
            _views = new ViewLoans();
        }

        // Funcion que registra prestamos de libros
        private void RegisterLoan()
        {
            if (_books.Count == 0 || _users.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[ALERT] There are no books or registered users.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            // Se crea una varialbe que toma como parametro los indices de los datos registrados
            var (bookIdx, userIdx) = _views.RequestLoanData(_books, _users);

            // Se crea el prestamo añadiendo los indices y la fecha actual
            var loans  = new Loans(
                _books[bookIdx],
                _users[userIdx],
                DateTime.Now
            );

            // Se marca prestado como 'true'
            _books[bookIdx].IsLoans = true;
            _loans.Add(loans);

            // Se guardan las listas de los préstamos de los libros en los archivos JSON
            Repository<Loans>.GuardarLista(LoansFile, _loans);
            Repository<Book>.GuardarLista(BooksFile, _books);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n¡Loans register successfully!");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }

        private void RegisteredReturn() // Se registra devolución de libros
        {
            if (_loans.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[ALERT] There are no loans registered.");
                Console.ResetColor();
                Console.ReadKey(); 
                return;
            }

            // Se crea un indice para buscar en la lista de préstamos
            int loansIdx = _views.RequestBookReturn(_loans);
            // Vualve el estado de prestado a 'false'
            _loans[loansIdx].Book.IsLoans = false;
            // Borra el libro de la lista de prestados
            _loans.RemoveAt(loansIdx);

            // Se guarda la lista actualizada en los archivos JSON
            Repository<Loans>.GuardarLista(LoansFile, _loans);
            Repository<Book>.GuardarLista(BooksFile, _books);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n¡Return successfully registered!");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }

        private void ListLoans()
        {
            _views.ShowLoans(_loans);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPress 'enter' per return to menu.");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }

        // Submenu de opciones
        public void ShowMenuLoans()
        {
            bool inMainLoans = true;

            while (inMainLoans)
            {
                Console.Clear();
                _views.MostrarMenuPrestamos();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        RegisterLoan();
                        break;
                    case "2":
                        Console.Clear();
                        RegisteredReturn();
                        break;
                    case "3":
                        Console.Clear();
                        ListLoans();
                        break;
                    case "4":
                        Console.Clear();
                        inMainLoans = false;
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

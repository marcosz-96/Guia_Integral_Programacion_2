using System;
using System.Collections.Generic;

using Repository;
using Models;
using Views;

namespace Controllers
{
    public class BooksController
    {
        private List<Book> _books;
        private ViewBooks _view;
        private const string BookFile = "booksList";

        public BooksController(List<Book> books)
        {
            _view = new ViewBooks();
            _books = Repository<Book>.ObtenerTodos(BookFile);
        }

        private void RegisterBook()
        {
            // Se cargan datos de los libros a la lista
            Book newBook = _view.LoadDataBooks();
            _books.Add(newBook);

            // Tambien se guarda la lista de libros en el archivo JSON
            Repository<Book>.GuardarLista(BookFile, _books);

            Console.ForegroundColor = ConsoleColor.Green;
            _view.ShowMsg("\n¡Book successfully registered!");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }

        private void BookList()
        {
            _view.ViewBookList(_books);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press 'enter' per retunr to menu.");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }

        public void ShowMenuBook()
        {
            bool inMainBook = true;

            while (inMainBook)
            {
                Console.Clear();
                _view.MostrarMenuLibros();
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        RegisterBook();
                        break;
                    case "2":
                        Console.Clear();
                        BookList();
                        break;
                    case "3":
                        Console.Clear();
                        inMainBook = false;
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        _view.ShowMsg("[ERROR] Option invalid");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}

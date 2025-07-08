using System;
using System.Collections.Generic;

using Models;

namespace Views
{
    public class ViewBooks
    {
        // Ingresar datos de un libro
        public Book LoadDataBooks()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------");
            Console.WriteLine("  ---- REGISTER BOOKS ----   ");
            Console.WriteLine("-----------------------------");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n-----------------------------");
            Console.Write("Title of the Book: ");
            string titleBook = Console.ReadLine();
            Console.Write("Author: ");
            string authorBook = Console.ReadLine();
            Console.Write("ISBN: ");
            int isbn = int.Parse(Console.ReadLine());
            Console.WriteLine("-----------------------------");
            Console.ResetColor();

            return new Book(titleBook, authorBook, isbn);
        }

        // Mostrar datos de un libro
        public void ViewBookList(List<Book> books)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- LIST OF BOOKS ---");
            for (int i = 0; i < books.Count; i++)
            {
                // Se verifica a través del índice, si el libro fue prestado o está disponible
                string status = books[i].IsLoans ? "WAS BORROWED" : "BOOK AVAILABLE";

                Console.WriteLine("\n====================================================================================================================");
                Console.WriteLine($"ID: {i+1} | Title: {books[i].BookTitle} | Author: {books[i].AuthorBook} | ISBN: {books[i].ISBN} | Status: {status}");
                Console.WriteLine("====================================================================================================================");
                Console.ResetColor();
            }
            Console.ReadKey();
            return;
        }

        public void MostrarMenuLibros()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***********************************");
            Console.WriteLine("   ******** BOOKS MENU ********");
            Console.WriteLine("***********************************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n***********************************");
            Console.WriteLine("1. Register book");
            Console.WriteLine("2. List all books");
            Console.WriteLine("3. Return to the main menu");
            Console.WriteLine("***********************************");
            Console.Write("Enter an option: ");
            Console.ResetColor();
        }

        public void ShowMsg(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}

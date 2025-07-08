using System;
using System.Collections.Generic;

using Models;

namespace Views
{
    public class ViewLoans
    {
        // Función que solicita los datos para otorgar préstamos de libros disponibles
        public (int, int) RequestLoanData(List<Book> books, List<User> users)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("        -_-_- REGISTER LOANS -_-_-");
            Console.WriteLine("-------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine(" Books Available"); // Libros disponibles
            Console.WriteLine("-------------------------------------------");
            Console.ResetColor();

            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine("\n---------------------------------------------");
                if (!books[i].IsLoans)
                    Console.WriteLine($"ID: {i+1} | Book: {books[i].BookTitle}");
                Console.WriteLine("---------------------------------------------");
            }

            Console.WriteLine("\n Registered Users");
            for (int u = 0; u < users.Count; u++)
            {
                Console.WriteLine("\n---------------------------------------------");
                Console.WriteLine($"ID: {u+1} | User: {users[u].NameUser}");
                Console.WriteLine("---------------------------------------------");
            }

            Console.Write("\nSelect the book number: ");
            int bookID = int.Parse(Console.ReadLine());
            Console.Write("\nSelect the user number: ");
            int userID = int.Parse(Console.ReadLine());

            return (bookID, userID);
        }

        // Función que solicita la devolución de los libros
        public int RequestBookReturn(List<Loans> loans)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("=== REGISTER RETURN BOOK ==="); // Registrar devolución de libros
            Console.WriteLine("--------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n--------------------------------------------");
            Console.WriteLine("Loans Assets"); // Préstamos activos
            Console.WriteLine("--------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Gray;

            // Muestra la lista de libros prestados y a quién se lo prestó
            for (int p = 0; p < loans.Count; p++)
            {
                Console.WriteLine("\n---------------------------------------------------------------------------------");
                Console.WriteLine($"ID: {p+1} | Title: {loans[p].Book.BookTitle} -> User: {loans[p].User.NameUser}");
                Console.WriteLine("---------------------------------------------------------------------------------");
            }

            // De dicha lista se selecciona el número del préstamo para que vuelva a la biblioteca
            Console.Write("\nSelect the loan number to be repaid: ");
            Console.ResetColor();
            return int.Parse(Console.ReadLine());
            
        }

        // Función que muestra la lista de préstamos activos, sin devolver
        public void ShowLoans(List<Loans> loans)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("            ---- LOANS ASSETS ----         "); // Préstamos activos
            Console.WriteLine("-------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n-------------------------------------------");
            
            for (int l = 0; l < loans.Count; l++)
            {
                Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"ID: {l+1} | Title: {loans[l].Book.BookTitle} | User: {loans[l].User.NameUser} | Date: {loans[l].Date.ToShortTimeString()}");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
            }
            Console.ResetColor();
            Console.ReadKey();
            return;
        }

        public void MostrarMenuPrestamos()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<><><><><><><><><><><><><><><><><>");
            Console.WriteLine("      >>>> LOANS MENU <<<<");
            Console.WriteLine("<><><><><><><><><><><><><><><><><>");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n<><><><><><><><><><><><><><><><><>");
            Console.WriteLine("1. Register loan");
            Console.WriteLine("2. Register book return");
            Console.WriteLine("3. List active loans");
            Console.WriteLine("4. Return to the main menu");
            Console.WriteLine("<><><><><><><><><><><><><><><><><>");
            Console.Write("Enter an option: ");
            Console.ResetColor();
        }
    }
}

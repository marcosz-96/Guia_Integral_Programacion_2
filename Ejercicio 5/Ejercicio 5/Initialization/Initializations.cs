using Controllers;
using Models;
using Views;
using Repository;

namespace Initialization
{
    public static class Initializations
    {
        // Propiedades estáticas para acceder a los controladores
        public static BooksController BooksController { get; private set; }
        public static UsersController UsersController { get; private set; }
        public static LoansController LoansController { get; private set; }

        // Método para inicializar todo el sistema
        public static void InitApplication()
        {
            // Cargar datos desde los repositorios
            var books = Repository<Book>.ObtenerTodos("books");
            var users = Repository<User>.ObtenerTodos("users");
            var loans = Repository<Loans>.ObtenerTodos("loans");

            // Crear controladores con las dependencias
            BooksController = new BooksController(books);
            UsersController = new UsersController(users); // Asume que ya carga usuarios internamente
            LoansController = new LoansController(); // Asume que ya carga loans y books internamente
        }
    }
}

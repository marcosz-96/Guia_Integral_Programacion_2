namespace Models
{
    public class Book // Libro
    {
        public string BookTitle {  get; set; }
        public string AuthorBook {  get; set; }

        // Numero Estandar de Identificacion de un Libro (Identification, Standar, Book, Number)
        public int ISBN { get; set; } 
        public bool IsLoans { get; set; }

        public Book(string bookTitle, string authorBook, int isbn)
        {
            this.BookTitle = bookTitle;
            this.AuthorBook = authorBook;
            this.ISBN = isbn;
            this.IsLoans = false;
        }

        public Book() { }
    }
}

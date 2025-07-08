using System;

namespace Models
{
    public class Loans // Prestamos
    {
        public Book Book { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }

        public Loans(Book book, User user, DateTime date)
        {
            this.Book = book;
            this.User = user;
            this.Date = date;
        }

        public Loans() { }
    }
}

namespace Models
{
    public class User // Usuario
    {
        public string NameUser { get; set; }
        public string Email {  get; set; }

        public User(string nameUser, string email)
        {
            this.NameUser = nameUser;
            this.Email = email;
        }

        public User() { }
    }
}

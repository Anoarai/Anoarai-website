using System.Security.Cryptography;

namespace Website.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        private string _password;
        public string Password
        {
            get => _password;
            set { _password = HashPassword(value); }
        }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }

        internal User()
        { }

        public User(string username, string password, string email)
        {
            Username = username;
            PasswordSalt = RandomNumberGenerator.GetBytes(16);
            Password = password;
            Email = email;
        }

        private string HashPassword(string passwordInput)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(passwordInput, PasswordSalt, 87640);
            byte[] hash = pbkdf2.GetBytes(20);

            var result = Convert.ToBase64String(hash);
            return result;
        }

        public bool PasswordCheck(string passwordInput)
        {
            return HashPassword(passwordInput) == Password;
        }
    }
}
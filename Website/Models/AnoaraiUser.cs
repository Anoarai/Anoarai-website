using System.Security.Cryptography;

namespace Website.Models
{
    public class AnoaraiUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        private string _password;
        public string Password
        {
            get => _password;
            set { _password = HashPassword(value); }
        }
        public string PublicEmail { get; set; }
        public string PrivateEmail { get; set; }
        public byte[] PasswordSalt { get; set; }

        internal AnoaraiUser()
        { }

        public AnoaraiUser(string username, string password, string publicEmail, string privateEmail)
        {
            Username = username;
            PasswordSalt = RandomNumberGenerator.GetBytes(16);
            Password = password;
            PublicEmail = publicEmail;
            PrivateEmail = privateEmail;
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
using Website.DatabaseContext;
using Website.Models;

namespace Website.Services
{
    public class LoginService : ILoginService
    {
        private IDatabaseContext database;
        public LoginService(IDatabaseContext database)
        {
            this.database = database;
        }

        public bool CheckPassword(string username, string password)
        {
            return database.Users.First(u=>u.Username == username).PasswordCheck(password);
        }
    }

    public interface ILoginService
    {

    }
}

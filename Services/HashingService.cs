

namespace RegistrationSite.Services
{
    public interface IHashingService
    {
        public string PasswordHashing(string password);
        public bool PasswordCheck(string passwordDataBase, string passwordGiven);
    }

    public class HashingService : IHashingService
    {
        public string PasswordHashing(string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            return passwordHash;
        }

        public bool PasswordCheck(string passwordDataBase, string passwordGiven)
        {
            if(BCrypt.Net.BCrypt.Verify(passwordGiven, passwordDataBase))
                return true;
            return false;
        }
    }
}

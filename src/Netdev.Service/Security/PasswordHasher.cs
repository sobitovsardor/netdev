namespace Netdev.Service.Security
{
    public class PasswordHasher
    {
        public static (string Salt, string Hash) Hash(string password)
        {
            string salt = Guid.NewGuid().ToString();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password + salt);
            return (Salt: salt, Hash: passwordHash);
        }

        public static bool Verify(string password, string hash, string salt)
        {
            return BCrypt.Net.BCrypt.Verify(password + salt, hash);
        }
    }
}
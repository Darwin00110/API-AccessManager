using Microsoft.AspNetCore.Identity;
namespace API_AccessManeger.src.Infrastructure.Services.Hashes
{
    public class HashesService : IHashesService
    {
        private readonly PasswordHasher<User> _passwordHasher = new();
        public string HashPassword(User user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }
        public bool VerifyPassword(User user, string password, string hashedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}

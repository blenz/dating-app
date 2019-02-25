using System;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Data.Interfaces;
using DatingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users
                        .FirstOrDefaultAsync(u => u.Username == username);

            // user was not found
            if (user == null)
                return null;

            // incorrect password
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }


        public async Task<bool> UserExists(string username)
        {
            return await _context.Users
            .AnyAsync(u => u.Username == username);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;

                byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
                passwordHash         = hmac.ComputeHash(passwordBytes);
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] computedHash  = hmac.ComputeHash(passwordBytes);

                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
using System;
using System.Threading.Tasks;
using ETH.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ETH.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<User> LogIn(string username, string password)
        {
            var user = await _context.UserName.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
                return null;

            if(!verifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        private bool verifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
             using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
               var computedHash =  hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

               for(int i = 0; i< computedHash.Length; i++)
               {
                    if(computedHash[i] != passwordHash[i])
                    return false;                        
               }
               return true;
            }
        }

        public async Task<bool> MobileExists(string MobileNumber)
        {
             if (await _context.UserName.AnyAsync(x => x.MobileNumber == MobileNumber))
                return true;
            
            return false;
        }

        public async Task<User> Register(User user, string MobileNumber, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.UserName.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.UserName.AnyAsync(x => x.Username == username))
                return true;
            
            return false;
        }
    }
}
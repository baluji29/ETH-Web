using System.Threading.Tasks;
using ETH.API.Models;

namespace ETH.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string MobileNumber, string password);
         Task<User> LogIn(string username, string password);
         Task<bool> UserExists(string username);
         Task<bool> MobileExists(string MobileNumber);

    }
}
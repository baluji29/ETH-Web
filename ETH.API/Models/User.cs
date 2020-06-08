using System.ComponentModel.DataAnnotations;

namespace ETH.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string MobileNumber { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }


    }
}
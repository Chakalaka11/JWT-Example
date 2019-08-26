using BackEnd.Models;

namespace BackEnd.Services
{
    public class UserService
    {
        public User GetTestUser()
        {
            return new User
            {
                FirstName = "Alex",
                LastName = "Securson",
                Phone = "+13551451324",
                Email = "alex@secur.com",
                Username = "AlexSec"
            };
        }
    }
}
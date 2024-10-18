using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCPA.Models
{
    public class UserRepository
    {
        private static List<User> _users = new List<User>();

        public User GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }
        public void AddUser(User user)
        {
            _users.Add(user);
        }
    }
}
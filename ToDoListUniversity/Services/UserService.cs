using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListUniversity.Models;

namespace ToDoListUniversity.Services
{
    public class UserService
    {

        public void AddNewUser(User user) 
        {
            user.AddNewUser(user);
        }

        public bool CheckUser(User user) 
        {
            return user.CheckUsers(user);
        }

        public User GetUser(User user) 
        {
            return user.GetUser(user);
        }
    }
}

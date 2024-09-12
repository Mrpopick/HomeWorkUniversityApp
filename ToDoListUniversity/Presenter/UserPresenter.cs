
using ToDoListUniversity.Models;
using ToDoListUniversity.Services;

namespace ToDoListUniversity.Presenter
{
    public class UserPresenter
    {
        private readonly UserService _userService;


        public UserPresenter(UserService userService)
        {
            _userService = userService;
        }


        public void AddUser(User user) 
        {
            _userService.AddNewUser(user);
        }

        public bool CheckUser(User user) 
        {
            return _userService.CheckUser(user);
        }

        public User GetUser(User user) 
        {
            return _userService.GetUser(user);
        }
    }
}

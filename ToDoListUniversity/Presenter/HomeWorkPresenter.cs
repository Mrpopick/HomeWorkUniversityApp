using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListUniversity.Forms;
using ToDoListUniversity.Models;
using ToDoListUniversity.Services;

namespace ToDoListUniversity.Presenter
{
    public class HomeWorkPresenter
    {
        private readonly HomeWorkService _homeWorkService;
        private readonly User _user;
        private readonly AddHomeworkForm _addHomeworkForm;


        public HomeWorkPresenter(HomeWorkService homeWorkService, User user, AddHomeworkForm addHomeworkForm)
        {
            _homeWorkService = homeWorkService;
            _user = user;
            _addHomeworkForm = addHomeworkForm;
        }

        public HomeWorkPresenter(HomeWorkService homeWorkService) 
        {
            _homeWorkService = homeWorkService;
        }


        public void UpdateHomeWork(HomeWorkInfo homeWork) 
        {
            _homeWorkService.UpdateHomeWork(homeWork);
        }

        public void AddHomeWork(HomeWorkInfo homeWork) 
        {
            _homeWorkService.AddHomeWork(homeWork);
        }

        public void DeletehomeWork(HomeWorkInfo homeWork) 
        {
            _homeWorkService.DelteHomeWork(homeWork);
        }

        public List<HomeWorkInfo> GetAllHomeWork(HomeWorkInfo homeWork) 
        {
            return _homeWorkService.GetAllHomeWork(homeWork);
        }
    }
}

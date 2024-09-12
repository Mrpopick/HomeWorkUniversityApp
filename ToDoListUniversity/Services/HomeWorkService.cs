using System.Collections.Generic;
using ToDoListUniversity.Models;

namespace ToDoListUniversity.Services
{
    public class HomeWorkService
    {
        public void AddHomeWork(HomeWorkInfo homeWork) 
        {
            homeWork.AddNewHomeWork(homeWork);
        }

        public void UpdateHomeWork(HomeWorkInfo homeWork) 
        { 
            homeWork.UpdateHomeWork(homeWork);
        }

        public void DelteHomeWork(HomeWorkInfo homeWork) 
        {
            homeWork.DeleteHomeWork(homeWork);
        }

        public List<HomeWorkInfo> GetAllHomeWork(HomeWorkInfo homeWork) 
        {
            return homeWork.GetAllHomewWork();
        }
    }
}

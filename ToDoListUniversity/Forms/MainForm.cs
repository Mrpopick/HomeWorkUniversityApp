using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ToDoListUniversity.Models;
using ToDoListUniversity.Presenter;
using ToDoListUniversity.Services;

namespace ToDoListUniversity.Forms
{
    public partial class MainForm : Form
    {
        User mainUser;
        List<HomeWorkInfo> homeWorksInfo;
        HomeWorkInfo curentHomework;

        private readonly HomeWorkPresenter _homeWorkPresenter;
        public MainForm()
        {
            InitializeComponent();
            homeWorksInfo = new List<HomeWorkInfo>();
            _homeWorkPresenter = new HomeWorkPresenter(new HomeWorkService());


        }

        public void SetMainForm(User user, List<HomeWorkInfo> homeWorkInfos)
        {
            this.mainUser = user;
            label1.Text = user.fullname;
            homeWorksInfo = homeWorkInfos;
            dataGridView1.DataSource = homeWorksInfo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newForm = new AddHomeworkForm(mainUser);
            newForm.AddDataTable(this.dataGridView1);
            newForm.Show();
        }

        public static void UpdateTable(DataGridView dt, List<HomeWorkInfo> homeWorkInfos)
        {
            dt.DataSource = null;
            dt.DataSource = homeWorkInfos;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            List<HomeWorkInfo> hmL = _homeWorkPresenter.GetAllHomeWork(new HomeWorkInfo());
            var a = hmL.Where(x => x.start.Day == dateTimePicker1.Value.Day && x.start.Month == dateTimePicker1.Value.Month && x.start.Year == dateTimePicker1.Value.Year).ToList();
            UpdateTable(dataGridView1, a);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (curentHomework.fullname == mainUser.fullname)
            {
                var a = new AddHomeworkForm(mainUser, curentHomework);
                a.AddDataTable(this.dataGridView1);
                a.Show();
            }
            else
            {
                ViewService.GetErrorMessage("Менять задание может лишь его владелец!");
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                DataGridViewCell selectedRow = dataGridView1.SelectedCells[0];
                object homeworkData = dataGridView1.Rows[selectedRow.RowIndex].DataBoundItem;
                // Now you can cast the object to its actual type, e.g.:
                HomeWorkInfo homeworkCurent = (HomeWorkInfo)homeworkData;
                curentHomework = homeworkCurent;
                // Do something with the userData object
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (curentHomework != null)
            {
                if (curentHomework.fullname == mainUser.fullname)
                {
                    _homeWorkPresenter.DeletehomeWork(curentHomework);
                    ViewService.GetSuccessMessage("Задание удалено!");
                    UpdateTable(this.dataGridView1, _homeWorkPresenter.GetAllHomeWork(curentHomework));
                }
                else
                {
                    ViewService.GetErrorMessage("Нельзя удалять чужие задания!");
                }
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            UpdateTable(this.dataGridView1, _homeWorkPresenter.GetAllHomeWork(curentHomework));
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                DataGridViewCell selectedRow = dataGridView1.SelectedCells[0];
                object homeworkData = dataGridView1.Rows[selectedRow.RowIndex].DataBoundItem;
                // Now you can cast the object to its actual type, e.g.:
                HomeWorkInfo homeworkCurent = (HomeWorkInfo)homeworkData;
                curentHomework = homeworkCurent;
                // Do something with the userData object
                var a = new ViewHomeworkForm(curentHomework);
                a.Show();
            }
        }
    }
}

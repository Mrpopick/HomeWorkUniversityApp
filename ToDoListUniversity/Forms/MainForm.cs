using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoListUniversity.Models;

namespace ToDoListUniversity.Forms
{
    public partial class MainForm : Form
    {
        User mainUser;
        public MainForm()
        {
            InitializeComponent();
        }

        public void SetUser(User user) 
        {
            this.mainUser = user;
            label1.Text = user.fullname;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void sfCalendar1_SelectionChanged(Syncfusion.WinForms.Input.SfCalendar sender, Syncfusion.WinForms.Input.Events.SelectionChangedEventArgs e)
        {
            var newDate = e.NewValue;
            if (newDate != null)
            {
                string day = newDate.Value.Day.ToString();
                string month = newDate.Value.Month.ToString();
                if (newDate.Value.Day < 10) 
                {
                    day = "0" + day;
                }
                if (newDate.Value.Month < 10)
                    month = "0" + month;
                lbDate.Text = day + "." + month + "." + newDate.Value.Year;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }


    }
}

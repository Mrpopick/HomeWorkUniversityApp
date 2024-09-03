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
    
    public partial class TaskBeginEndDate : Form
    {
        public static TextBox t3;
        public static TextBox t4;
        public TaskBeginEndDate(TextBox t1, TextBox t2)
        {
            InitializeComponent();
            t3 = t1;
            t4 = t2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t3.Text = monthCalendar1.SelectionRange.Start.ToString("dd MMM yyyy");
            t4.Text = monthCalendar1.SelectionRange.End.ToString("dd MMM yyyy");
            this.Close();
        }
    }
}

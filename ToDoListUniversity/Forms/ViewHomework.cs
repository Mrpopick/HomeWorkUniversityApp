using Org.BouncyCastle.X509.Extension;
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
    public partial class ViewHomeworkForm : Form
    {
        
        public ViewHomeworkForm(HomeWorkInfo curHmWork)
        {
            InitializeComponent();
            lbSubject.Text = curHmWork.subject;
            lbStart.Text = curHmWork.start.ToShortDateString();
            lbEnd.Text = curHmWork.end.ToShortDateString();
            lbDifficulty.Text = curHmWork.difficulty;
            richTbDescription.Text = curHmWork.description;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTbDescription.ReadOnly = false;
            richTbDescription.BackColor = Color.White;
        }

    }
}

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

    public partial class AddHomeworkForm : Form
    {
        public static List<string> dangerousLevel = new List<string>() { "Простой", "Средний", "Тяжелый", "НЕВЪЕБАТЬСЯ" };   
        public static List<string> subjects = new List<string>() { "Теория автоматического управления", "Электротехника и цифровая схемотехника", "Специальные главы электротехники", "Основы интеллектуального анализа данных", "Языки программирования искусственного интеллекта", "Проектная деятельность", "Вычислительные машины, системы и сети", "Прикладная физическая культура", "Системы искусственного интеллекта", "Информационные сети и телекоммуникации" };
        public AddHomeworkForm(User mainUser)
        {
            InitializeComponent();
            comboBox1.DataSource = subjects;
            comboBox2.DataSource = dangerousLevel;
            
        }

        public class HomeworkInfo
        {
            public string subject, difficulty, description;
            public DateTime start, end;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newForm = new TaskBeginEndDate(textBox1, textBox2);
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                HomeworkInfo hwinfo = new HomeworkInfo();
                hwinfo.subject = comboBox1.SelectedItem.ToString();
                hwinfo.difficulty = comboBox2.SelectedItem.ToString();
                hwinfo.description = richTextBox2.Text;
                if (DateTime.TryParse(textBox1.Text, out hwinfo.start))
                {
                   hwinfo.start = DateTime.Parse(textBox1.Text);
                }
                if (DateTime.TryParse(textBox2.Text, out hwinfo.end))
                {
                hwinfo.end = DateTime.Parse(textBox2.Text);
                }
                richTextBox1.Text = hwinfo.subject + "\n" + hwinfo.difficulty + "\n" + hwinfo.start + "\n" + hwinfo.end + "\n" + hwinfo.description;
            }
                
        }
    }
}

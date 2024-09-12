using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using ToDoListUniversity.Models;
using ToDoListUniversity.Presenter;
using ToDoListUniversity.Services;

namespace ToDoListUniversity.Forms

{

    public partial class AddHomeworkForm : Form
    {
        public static List<string> dangerousLevel = new List<string>() { "Простой", "Средний", "Тяжелый", "НЕВЪЕБАТЬСЯ" };
        public static List<string> subjects = new List<string>() { "Теория автоматического управления", "Электротехника и цифровая схемотехника", "Специальные главы электротехники", "Основы интеллектуального анализа данных", "Языки программирования искусственного интеллекта", "Проектная деятельность", "Вычислительные машины, системы и сети", "Прикладная физическая культура", "Системы искусственного интеллекта", "Информационные сети и телекоммуникации" };
        public User user;
        private HomeWorkInfo homeWorkInfo;
        DataGridView dt;
        private readonly HomeWorkPresenter _presenter;
        public AddHomeworkForm(User mainUser, HomeWorkInfo hm = null)
        {
            InitializeComponent();
            comboBox1.DataSource = subjects;
            comboBox2.DataSource = dangerousLevel;
            user = mainUser;
            this.homeWorkInfo = hm;
            if (hm != null)
            {
                this.comboBox1.SelectedItem = hm.subject;
                this.comboBox2.SelectedItem = hm.difficulty;
                this.textBox1.Text = hm.start.ToString();
                this.textBox2.Text = hm.end.ToString();
                this.richTextBox2.Text = hm.description;
            }
            _presenter = new HomeWorkPresenter(new HomeWorkService(), user, this);

        }

        public void AddDataTable(DataGridView dt)
        {
            this.dt = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var newForm = new TaskBeginEndDate(textBox1, textBox2);
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (homeWorkInfo != null)
            {
                homeWorkInfo.fullname = user.fullname;
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    homeWorkInfo.subject = comboBox1.SelectedItem.ToString();
                    homeWorkInfo.difficulty = comboBox2.SelectedItem.ToString();
                    homeWorkInfo.description = richTextBox2.Text;
                    if (DateTime.TryParse(textBox1.Text, out _))
                    {
                        homeWorkInfo.start = DateTime.Parse(textBox1.Text);
                    }
                    if (DateTime.TryParse(textBox2.Text, out _))
                    {
                        homeWorkInfo.end = DateTime.Parse(textBox2.Text);
                    }

                }
                _presenter.UpdateHomeWork(homeWorkInfo);
                ViewService.GetSuccessMessage("Дз обновлено");
                this.Close();
            }
            else
            {
                HomeWorkInfo hwinfo = new HomeWorkInfo();
                hwinfo.fullname = user.fullname;
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    hwinfo.subject = comboBox1.SelectedItem.ToString();
                    hwinfo.difficulty = comboBox2.SelectedItem.ToString();
                    hwinfo.description = richTextBox2.Text;
                    if (DateTime.TryParse(textBox1.Text, out _))
                    {
                        hwinfo.start = DateTime.Parse(textBox1.Text);
                    }
                    if (DateTime.TryParse(textBox2.Text, out _))
                    {
                        hwinfo.end = DateTime.Parse(textBox2.Text);
                    }

                }

                _presenter.AddHomeWork(hwinfo);
                ViewService.GetSuccessMessage("Дз добавленно!");
                this.Close();
            }
        }

        private void AddHomeworkForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.UpdateTable(dt, _presenter.GetAllHomeWork(homeWorkInfo));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] data;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;
            else
            {
                string filename = ofd.FileName;
                Image image = Image.FromFile(filename);
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, image.RawFormat);
                    data = ms.ToArray();
                }

            }

            using (MemoryStream mr = new MemoryStream(data))
            {
                //Image image = Image.FromStream(mr);

                //// Define the maximum dimensions for the resized image
                //// Get the dimensions of the original image
                //int width = image.Width;
                //int height = image.Height;

                //// Define the maximum dimensions for the resized image
                //int maxWidth = pictureBox1.Width; // adjust this value to your needs
                //int maxHeight = pictureBox1.Height; // adjust this value to your needs

                //// Calculate the scaling factor
                //float scale = Math.Min((float)maxWidth / width, (float)maxHeight / height);

                //// Create a new Bitmap with the resized dimensions
                //Bitmap resizedImage = new Bitmap((int)(width * scale), (int)(height * scale));

                //// Use a high-quality interpolation mode to resize the image
                //using (Graphics graphics = Graphics.FromImage(resizedImage))
                //{
                //    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //    graphics.DrawImage(image, 0, 0, resizedImage.Width, resizedImage.Height);
                //}

                //// Now you can use the resizedImage object, e.g. display it in a PictureBox
                //pictureBox1.Image = resizedImage;
            }
        }
    }
}

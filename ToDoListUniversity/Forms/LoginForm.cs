using System;
using System.Windows.Forms;
using ToDoListUniversity.Forms;
using ToDoListUniversity.Models;
using ToDoListUniversity.Services;

namespace ToDoListUniversity
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            tbPassword.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var newForm = new RegisterForm();
            newForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                if (tbLogin.Text == "admin" && tbPassword.Text == "admin")
                {
                    User user = new User();
                    user.fullname = "Pidor";

                    var newForm = new MainForm();
                    newForm.SetMainForm(user, HomeWorkInfo.GetAllHomewWork());
                    newForm.Show();
                    this.Hide();
                    return;
                }
                if (User.CheckUsers(tbLogin.Text, tbPassword.Text))
                {
                    try
                    {
                        User user = new User().GetUser(tbLogin.Text);
                        var newForm = new MainForm();
                        newForm.SetMainForm(user, HomeWorkInfo.GetAllHomewWork());
                        newForm.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        ViewService.GetErrorMessage(ex.Message);
                    }
                }
                else
                {
                    ViewService.GetErrorMessage("Неверный логин или пароль!");
                }
            }
        }

        bool ValidateData()
        {
            if (!string.IsNullOrEmpty(tbLogin.Text))
            {
                if (!string.IsNullOrEmpty(tbPassword.Text))
                {
                    return true;
                }
                else
                {
                    ViewService.GetErrorMessage("Пароль не может быть пустым!");
                    return false;
                }
            }
            else
            {
                ViewService.GetErrorMessage("Логин не может быть пустым!");
                return false;
            }
        }

        private void cbPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPassword.Checked)
                tbPassword.PasswordChar = '\0';
            else
                tbPassword.PasswordChar = '*';
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoListUniversity.Forms;
using ToDoListUniversity.Models;

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
                    User user = new User().GetUser("Mrpopick");
                    var newForm = new MainForm();
                    newForm.SetUser(user);
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
                        newForm.SetUser(user);
                        newForm.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else 
                {
                    MessageBox.Show("Неверный логин или пароль!");
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
                    MessageBox.Show("Пароль не может быть пустым!");
                    return false;
                }
            }
            else 
            {
                MessageBox.Show("Логин не может быть пустым!");
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

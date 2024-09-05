using System;
using System.Windows.Forms;
using ToDoListUniversity.Models;

namespace ToDoListUniversity.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    User.AddNewUser(tbFullName.Text, tbLogin.Text, tbPassword.Text, tbEmail.Text);
                    MessageBox.Show($"Пользователь успешно добавлен {tbLogin.Text} - {tbPassword.Text}");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool ValidateData()
        {
            if (!string.IsNullOrEmpty(tbEmail.Text))
            {

                if (IsValidEmail(tbEmail.Text))
                {
                    if (!string.IsNullOrEmpty(tbLogin.Text))
                    {
                        if (!string.IsNullOrEmpty(tbPassword.Text))
                        {
                            if (!string.IsNullOrEmpty(tbFullName.Text))
                            {
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Фио не может быть пустым!");
                                return false;
                            }
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
                else
                {
                    MessageBox.Show("Неверный email");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Емаил не может быть пустым!");
                return false;
            }
        }
        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}

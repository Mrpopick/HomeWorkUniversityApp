using System;
using System.Windows.Forms;
using ToDoListUniversity.Models;
using ToDoListUniversity.Presenter;
using ToDoListUniversity.Services;

namespace ToDoListUniversity.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly UserPresenter _userPresenter;
        public RegisterForm()
        {
            InitializeComponent();
            _userPresenter = new UserPresenter(new UserService());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    User user = new User(tbFullName.Text, tbEmail.Text, tbLogin.Text, tbPassword.Text);
                    _userPresenter.AddUser(user);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ViewService.GetErrorMessage(ex.Message);
            }
        }

        bool ValidateData()
        {
            if (!string.IsNullOrEmpty(tbEmail.Text))
            {

                if (ViewService.IsValidEmail(tbEmail.Text))
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
                                ViewService.GetErrorMessage("Фио не может быть пустым!");
                                return false;
                            }
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
                else
                {
                    ViewService.GetErrorMessage("Неверный email");
                    return false;
                }
            }
            else
            {
                ViewService.GetErrorMessage("Емаил не может быть пустым!");
                return false;
            }
        }

    }
}

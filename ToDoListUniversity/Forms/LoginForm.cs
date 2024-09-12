using System;
using System.ComponentModel;
using System.Windows.Forms;
using ToDoListUniversity.Forms;
using ToDoListUniversity.Models;
using ToDoListUniversity.Presenter;
using ToDoListUniversity.Services;

namespace ToDoListUniversity
{
    public partial class LoginForm : Form
    {
        private readonly UserPresenter _userPresenter;
        private readonly HomeWorkPresenter _homeWorkPresenter;

        private BackgroundWorker _loginWorker;
        public LoginForm()
        {
            InitializeComponent();
            _userPresenter = new UserPresenter(new UserService());
            _homeWorkPresenter = new HomeWorkPresenter(new HomeWorkService());
            tbPassword.PasswordChar = '*';
            _loginWorker = new BackgroundWorker();
            _loginWorker.DoWork += _loginWorker_DoWork;
            _loginWorker.RunWorkerCompleted += _loginWorker_RunWorkerCompleted;
            pictureBox1.Visible = false;
        }

        private void _loginWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            if (e.Result != null)
            {
                User user = (User)e.Result;
                var newForm = new MainForm();
                newForm.SetMainForm(user, _homeWorkPresenter.GetAllHomeWork(new HomeWorkInfo()));
                newForm.Show();
                this.Hide();
            }
            else
            {
                // Handle error
                if (e.Error != null)
                {
                    ViewService.GetErrorMessage(e.Error.Message);
                }
                else
                {
                    ViewService.GetErrorMessage("Неверный логин или пароль!");
                }
            }
        }

        private void _loginWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            User user;
            if (tbLogin.Text == "admin" && tbPassword.Text == "admin")
            {
                user = new User();
                user.fullname = "Pidor";
            }
            user = new User(tbLogin.Text, tbPassword.Text);
            if (_userPresenter.CheckUser(user))
            {
                try
                {
                    user = _userPresenter.GetUser(user);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new Exception("Неверный логин или пароль!");
            }
            e.Result = user;
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
                pictureBox1.Visible = true;
                _loginWorker.RunWorkerAsync();
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

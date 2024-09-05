using System;
using System.Windows.Forms;

namespace ToDoListUniversity.Services
{
    public class ViewService
    {

        public static void GetErrorMessage(string message)
        {
            const string title = "ERROR MESSAGE";
            const MessageBoxButtons buttons = MessageBoxButtons.OK;
            const MessageBoxIcon icon = MessageBoxIcon.Error;
            const MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
            const MessageBoxOptions options = MessageBoxOptions.ServiceNotification;

            MessageBox.Show(message, title, buttons, icon, defaultButton, options);
        }


        public static void GetSuccessMessage(string message)
        {
            const string title = "SUCCESS";
            const MessageBoxButtons buttons = MessageBoxButtons.OK;
            const MessageBoxIcon icon = MessageBoxIcon.Information;
            const MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
            const MessageBoxOptions options = MessageBoxOptions.ServiceNotification;

            MessageBox.Show(message, title, buttons, icon, defaultButton, options);
        }

        public static string CreateNewGuid()
        {
            return Guid.NewGuid().ToString("N");
        }

        public static bool IsValidEmail(string email)
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

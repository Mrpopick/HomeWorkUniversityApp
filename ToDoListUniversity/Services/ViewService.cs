using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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




    }
}

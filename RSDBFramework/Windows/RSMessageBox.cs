using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSDBFramework.Windows
{
    public class RSMessageBox
    {
        public static void ShowErrorMessage(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ShowErrorMessage(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowSuccessMessage(string msg)
        {
            MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ShowSuccessMessage(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

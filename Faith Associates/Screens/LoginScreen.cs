using Faith_Associates.Models.Users;
using Faith_Associates.Utilities;
using RSDBFramework;
using RSDBFramework.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faith_Associates.Screens
{
    public partial class LoginScreen : TemplateForm
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
                bool isLoginDetailsCorrect = Convert.ToBoolean(db.GetScalarValue("usp_UsersCheckLoginDetails", GetParameters()));

                if (isLoginDetailsCorrect)
                {
                    this.Hide();
                    LoggedInUser.Username = txtUsername.Text.Trim();
                    DashboardForm dashboard = new DashboardForm();
                    
                    dashboard.Show();
                }
                else
                {
                    RSMessageBox.ShowErrorMessage("Invalid Username or Password");
                }
            }
        }

        private DBParameter[] GetParameters()
        {
            List<DBParameter> parameters = new List<DBParameter>();
            DBParameter para1 = new DBParameter();
            para1.Parameter = "@Username";
            para1.Value = txtUsername.Text.Trim();
            parameters.Add(para1);

            DBParameter para2 = new DBParameter();
            para2.Parameter = "@Password";
            para2.Value = txtPassword.Text.Trim();
            parameters.Add(para2);

            return parameters.ToArray();
        }

        private bool IsFormValid()
        {
            if (txtUsername.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Username is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Clear();
                txtUsername.Focus();
                return false;
            }
            if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Password is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return false;
            }
            return true;
        }
    }
}

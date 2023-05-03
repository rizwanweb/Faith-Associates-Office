using RSDBFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faith_Associates.Utilities.Lists
{
    public class ListData
    {
        public static void LoadDataIntoDataGridView(DataGridView dgv, string storedProcedure)
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            dgv.DataSource = db.GetDataList(storedProcedure);

            //Data GridView Settings
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Columns[0].Visible = false;
            dgv.RowHeadersVisible = false;
        }

        // Parameter
        public static void LoadDataIntoDataGridView(DataGridView dgv, string storedProcedure, DBParameter parameter)
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            dgv.DataSource = db.GetDataList(storedProcedure, parameter);

            //Data GridView Settings
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Columns[0].Visible = false;
            dgv.RowHeadersVisible = false;
        }

        public static void LoadDataIntoComboBox(ComboBox cb, string storedProcedure)
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());

            cb.DataSource = db.GetDataList(storedProcedure);
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.SelectedIndex = -1;
        }


        // Clear Form
        public static void ClearFormControls(Control control)
        {
            if (control is TextBox)
            {
                ((TextBox)control).Clear();
                if (((TextBox)control).Name == "txtSalesTaxRate")
                {
                    ((TextBox)control).Text = "13.00";
                }
            }
            if (control is DateTimePicker)
            {
                ((DateTimePicker)control).Value = DateTime.Now.Date;
            }
            if (control is ComboBox)
            {
                ((ComboBox)control).SelectedIndex = -1;
            }
            for (int i = 0; i < control.Controls.Count; i++)
            {
                ClearFormControls(control.Controls[i]);
            }

        }
    }
}

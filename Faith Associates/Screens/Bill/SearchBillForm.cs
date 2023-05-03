using Faith_Associates.Utilities.Lists;
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

namespace Faith_Associates.Screens.Jobs
{
    public partial class SearchBillForm : TemplateForm
    {
        public int JobID { get; set; }
        public int BillID { get; set; }
        public int BillNo { get; set; }
        public int BillDetailsID { get; set; }

        public SearchBillForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchBox.Text.Trim() == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Enter something for search.");
                txtSearchBox.Clear();
                txtSearchBox.Focus();
            }
            else
            {
                SearchJobs();
            }
        }

        private void SearchJobs()
        {
            int billNo = Convert.ToInt32(txtSearchBox.Text);
            DBParameter para = new DBParameter();
            para.Parameter = "@BillNo";
            para.Value = billNo;
            ListData.LoadDataIntoDataGridView(dgvJobList, "usp_BillsGetBillByBillNo", para);

            dgvJobList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvJobList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvJobList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvJobList.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvJobList.Columns["JobID"].Visible = false;
        }

        private void dgvJobList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            int rowIndex = dgvJobList.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            JobID = (int)dgvJobList.Rows[rowIndex].Cells["JobID"].Value;
            BillID = (int)dgvJobList.Rows[rowIndex].Cells["BillID"].Value;
            BillNo = (int)dgvJobList.Rows[rowIndex].Cells["BillNo"].Value;
            this.Close();            
        }


    }
}


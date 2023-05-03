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
    public partial class SearchJobsForm : TemplateForm
    {
        public int JobID { get; set; }
        
        public SearchJobsForm()
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
            if (cmbBy.SelectedIndex == 0)
            {
                int jobNo = Convert.ToInt32(txtSearchBox.Text);
                DBParameter para = new DBParameter();
                para.Parameter = "@JobNo";
                para.Value = jobNo;
                ListData.LoadDataIntoDataGridView(dgvJobList, "usp_JobsGetJobsByJobNo", para);

                dgvJobList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvJobList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvJobList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvJobList.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            if (cmbBy.SelectedIndex == 1)
            {
                string lc = txtSearchBox.Text.Trim().ToUpper();
                DBParameter para = new DBParameter();
                para.Parameter = "@LC";
                para.Value = lc;
                ListData.LoadDataIntoDataGridView(dgvJobList, "usp_JobsGetJobsByLC", para);

                dgvJobList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvJobList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvJobList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvJobList.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void dgvJobList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            int rowIndex = dgvJobList.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            JobID = (int)dgvJobList.Rows[rowIndex].Cells["ID"].Value;
            isUpdate = true;
            this.Close();
            
        }

        private void SearchJobsForm_Load(object sender, EventArgs e)
        {
            cmbBy.SelectedIndex = 0;
        }
    }
}


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
    public partial class SearchPidsForm : TemplateForm
    {
        public int PidID { get; set; }
        
        public SearchPidsForm()
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
                SearchPids();
            }
        }

        private void SearchPids()
        {
            if (cmbBy.SelectedIndex == 0)
            {
                int PidNo = Convert.ToInt32(txtSearchBox.Text);
                DBParameter para = new DBParameter();
                para.Parameter = "@PidNo";
                para.Value = PidNo;
                ListData.LoadDataIntoDataGridView(dgvJobList, "usp_PidsGetPidsByPidNo", para);

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
                ListData.LoadDataIntoDataGridView(dgvJobList, "usp_PidsGetPidsByLC", para);

                dgvJobList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvJobList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvJobList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvJobList.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void dgvJobList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            int rowIndex = dgvJobList.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            PidID = (int)dgvJobList.Rows[rowIndex].Cells["ID"].Value;
            isUpdate = true;
            this.Close();
            
        }

        private void SearchJobsForm_Load(object sender, EventArgs e)
        {
            cmbBy.SelectedIndex = 0;
        }
    }
}


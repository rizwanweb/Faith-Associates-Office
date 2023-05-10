using Faith_Associates.Models.Clients;
using Faith_Associates.Screens.Jobs;
using Faith_Associates.Utilities;
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

namespace Faith_Associates.Screens.Clients
{
    public partial class ClientPortal : TemplateForm
    {
        int ClientID { get; set; }
        public int JobID { get; set; }
        public int PidID { get; set; }

        public ClientPortal()
        {
            InitializeComponent();
        }

        private void ClientPortal_Load(object sender, EventArgs e)
        {
            LoadTreeView();
        }

        private void LoadTreeView()
        {
            TreeNode node = new TreeNode("Clients");
            treeView1.Nodes.Add(node);

            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DataTable dt = db.GetDataList("usp_ClientsGetClientsForComboBox");

            foreach (DataRow row in dt.Rows)
            {
                TreeNode client = new TreeNode(row["ClientName"].ToString());
                client.Tag = row["ClientID"];
                node.Nodes.Add(client);
            }
            node.Expand();
            
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                treeView1.SelectedNode = e.Node;
                int id = Convert.ToInt32(treeView1.SelectedNode.Tag.ToString());
                this.ClientID = id;
                LoadClientDatatoLabels(id);
                LoadClientJobstoDGV(id);
                LoadClientPidstoDGV(id);
            }
            catch (Exception)
            {
                
            }

        }

        private void LoadClientJobstoDGV(int id)
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter ClientID = new DBParameter();
            ClientID.Parameter = "@ClientID";
            ClientID.Value = id;
            ListData.LoadDataIntoDataGridView(dgvJobs, "usp_JobsGetClientsJob", ClientID);
            dgvJobs.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvJobs.Columns[1].Width = 90;
            dgvJobs.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvJobs.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvJobs.Columns[2].Width = 120;
        }
        private void LoadClientPidstoDGV(int id)
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter ClientID = new DBParameter();
            ClientID.Parameter = "@ClientID";
            ClientID.Value = id;
            ListData.LoadDataIntoDataGridView(dgvPid, "usp_PidsGetClientsPids", ClientID);
            dgvJobs.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvJobs.Columns[1].Width = 90;
            dgvJobs.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvJobs.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvJobs.Columns[2].Width = 120;
        }

        private void LoadClientDatatoLabels(int id)
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter ClientID = new DBParameter();
            ClientID.Parameter = "@ClientID";
            ClientID.Value = id;
            DataTable dt = db.GetDataList("usp_ClientGetClientDetailByID", ClientID);

            lblClientName.Text = dt.Rows[0]["ClientName"].ToString();
            lblPerson.Text = dt.Rows[0]["ContactPerson"].ToString();
            lblAddress.Text = dt.Rows[0]["Address"].ToString();
            lblPhone.Text = dt.Rows[0]["Phone"].ToString();
            lblMobile.Text = dt.Rows[0]["Mobile"].ToString();
            lblNTN.Text = dt.Rows[0]["NTN"].ToString();
            lblGST.Text = dt.Rows[0]["GST"].ToString();
            lblCity.Text = dt.Rows[0]["CityName"].ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
            LoadTreeView();
        }


        private void DeleteRecord()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter para = new DBParameter();
            para.Parameter = "@ClientID";
            para.Value = this.ClientID;

            DialogResult result = MessageBox.Show("Do you want to Delete this Client ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                db.DeleteRecord("usp_ClientsDeleteClient", para);
                RSMessageBox.ShowSuccessMessage("Record Deleted...");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ClientDetailsForm client = new ClientDetailsForm();
            client.ClientID = this.ClientID;
            client.isUpdate = true;
            client.ShowDialog();
            treeView1.Nodes.Clear();
            LoadTreeView();
        }

        private void dgvJobs_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ShowJobDetails(int jobID)
        {
            JobEntryForm job = new JobEntryForm();
            job.JobID = jobID;
            job.isUpdate = true;
            job.ShowDialog();
        }

        private void dgvPid_DoubleClick(object sender, EventArgs e)
        {
            int rowIndex = dgvPid.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            this.PidID = Convert.ToInt32(dgvPid.Rows[rowIndex].Cells["PidID"].Value);
            ShowPidDetails(this.PidID);
        }

        private void ShowPidDetails(int pidID)
        {
            NewPidEntryForm pid = new NewPidEntryForm();
            pid.PidID = pidID;
            pid.isUpdate = true;
            pid.ShowDialog();
        }

        private void dgvJobs_DoubleClick(object sender, EventArgs e)
        {
            int rowIndex = dgvJobs.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            this.JobID = Convert.ToInt32(dgvJobs.Rows[rowIndex].Cells["JobID"].Value);

            ShowJobDetails(this.JobID);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClientDetailsForm client = new ClientDetailsForm();
            client.ShowDialog();
            treeView1.Nodes.Clear();
            LoadTreeView();
        }
    }
}

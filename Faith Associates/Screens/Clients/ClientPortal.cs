using Faith_Associates.Models.Clients;
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
            LoadTreeView();
        }

        //TODO : Get total Consignments
        //TODO : Get Total Containers
    }
}

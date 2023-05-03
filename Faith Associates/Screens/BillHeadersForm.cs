using Faith_Associates.Models.Bills;
using Faith_Associates.Utilities;
using Faith_Associates.Utilities.Lists;
using RSDBFramework;
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
    public partial class BillHeadersForm : TemplateForm
    {
        public int HeadID { get; set; }
        public BillHeadersForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BillHeadersForm_Load(object sender, EventArgs e)
        {
            LoadHeadersToDataGridView();
        }

        private void LoadHeadersToDataGridView()
        {
            ListData.LoadDataIntoDataGridView(dgvHeaders, "usp_HeadsGetAllHeads");
            dgvHeaders.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHeaders.Columns[1].HeaderCell.Value = "Bill Headers";
        }

        private void dgvHeaders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            isUpdate = true;
            int rowIndex = dgvHeaders.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            this.HeadID = Convert.ToInt32(dgvHeaders.Rows[rowIndex].Cells[0].Value);
            txtHeader.Text = dgvHeaders.Rows[rowIndex].Cells[1].Value.ToString();


            
            
            

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtHeader.Clear();
            txtHeader.Focus();
            isUpdate = false;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            if (isUpdate)
            {
                UpdateHeader();
                LoadHeadersToDataGridView();
            }
            else
            {
                InsertHeader();
                LoadHeadersToDataGridView();
            }
        }

        private void InsertHeader()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            db.InsertOrUpdateRecord("usp_HeadersInsertNewHeader", GetObjects());
            txtHeader.Clear();
            btnAdd.Focus();
        }

        private void UpdateHeader()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            db.InsertOrUpdateRecord("usp_HeadersUpdateByID", GetObjects());
            txtHeader.Clear();
        }

        private object GetObjects()
        {
            BillHeader bh = new BillHeader();
            bh.HeadID = this.isUpdate ? this.HeadID : 0;
            bh.BillHead = txtHeader.Text.Trim();
            return bh;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter para = new DBParameter();
            para.Parameter = "@HeadID";
            para.Value = this.HeadID;
            db.DeleteRecord("usp_HeadersDeleteByID", para);
            txtHeader.Clear();
            LoadHeadersToDataGridView();
        }
    }
}

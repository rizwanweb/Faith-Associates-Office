using Faith_Associates.Models.Items;
using Faith_Associates.Utilities;
using Faith_Associates.Utilities.Lists;
using RSDBFramework;
using RSDBFramework.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faith_Associates.Screens.Items
{
    public partial class ItemDetailsScreen : TemplateForm
    {
        public int ItemID { get; set; }
        public ItemDetailsScreen()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ItemDetailsScreen_Load(object sender, EventArgs e)
        {
            LoadAndBindDataToControlsIfUpdate();
            if (isUpdate)
            {                
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                cmbITType.SelectedIndex = 0;
                cmbSTType.SelectedIndex = 0;
                cmbRDType.SelectedIndex = 1;
                cmbCessType.SelectedIndex = 0;
                cmbACDType.SelectedIndex = 1;
            }
        }

        private void LoadAndBindDataToControlsIfUpdate()
        {
            if (isUpdate) {
                DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
                DBParameter parameter = new DBParameter();
                parameter.Parameter = "@ItemID";
                parameter.Value = ItemID;
                DataTable dt = db.GetDataList("usp_ItemsGetItemByID", parameter);

                DataRow row = dt.Rows[0];
                txtItemName.Text = row["ItemName"].ToString();
                txtHSCode.Text = row["HSCode"].ToString();
                txtCD.Text = row["CustomDuty"].ToString();
                txtACD.Text = row["AddCustomDuty"].ToString();
                txtST.Text = row["SalesTax"].ToString();
                txtIT.Text = row["IncomeTax"].ToString();
                txtCess.Text = row["Cess"].ToString();
                txtRD.Text = row["RD"].ToString();

                cmbCDType.SelectedIndex = Convert.ToInt16(row["CustomDutyType"]);
                cmbACDType.SelectedIndex = Convert.ToInt16(row["AddCustomDutyType"]);
                cmbSTType.SelectedIndex = 0;
                cmbITType.SelectedIndex = 0;
                cmbCessType.SelectedIndex = Convert.ToInt16(row["CessType"]);
                cmbRDType.SelectedIndex = Convert.ToInt16(row["RDType"]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveorUpdateItem();
            this.Close();
        }

        private void SaveorUpdateItem()
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            if (IsFormValidated())
            {
                if (isUpdate)
                {
                    db.InsertOrUpdateRecord("usp_ItemsUpdateItem", GetObjects());
                    RSMessageBox.ShowSuccessMessage("Item Updated Successfully");
                    this.Close();
                }
                else
                {
                    db.InsertOrUpdateRecord("usp_ItemsAddNewItem", GetObjects());
                    RSMessageBox.ShowSuccessMessage("Item Added Successfully");
                    this.Close();
                }
            }

        }

        private bool IsFormValidated()
        {
            if (txtItemName.Text.Trim() == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("Enter Item Name..");
                txtItemName.Clear();
                txtItemName.Focus();
                return false;
            }
            if (txtHSCode.Text.Trim() == String.Empty)
            {
                RSMessageBox.ShowErrorMessage("H.S.Code Required..");
                txtHSCode.Clear();
                txtHSCode.Focus();
                return false;
            }
            return true;
        }

        private object GetObjects()
        {
            Item i = new Item();
            i.ItemID = (this.isUpdate) ? this.ItemID : 0;
            i.ItemName = txtItemName.Text.Trim().ToUpper();
            i.HSCode = txtHSCode.Text.Trim();
            i.CustomDuty = CheckNull(txtCD);
            i.AddCustomDuty = CheckNull(txtACD);
            i.SalesTax = CheckNull(txtST);
            i.IncomeTax = CheckNull(txtIT);
            i.Cess = CheckNull(txtCess);
            i.RD = CheckNull(txtRD);

            i.CustomDutyType = cmbCDType.SelectedIndex;
            i.AddCustomDutyType = cmbACDType.SelectedIndex;
            i.CessType = cmbCessType.SelectedIndex;
            i.RDType = cmbRDType.SelectedIndex;
            
            return i;
        }
        private static double CheckNull(TextBox tb)
        {
            if (tb?.Text != null && double.TryParse(tb.Text, out double value))
            {
                return value;
            }
            return 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DBSQLServer db = new DBSQLServer(AppSetting.ConnectionString());
            DBParameter para = new DBParameter();
            para.Parameter = "@ItemID";
            para.Value = ItemID;

            DialogResult result = MessageBox.Show("Do you want to Delete this Item ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                db.DeleteRecord("usp_ItemsDeleteItem", para);
                RSMessageBox.ShowSuccessMessage("Record Deleted...");
            }
            this.Close();
        }
    }
}

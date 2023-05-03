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

namespace Faith_Associates.Screens.Items
{
    public partial class ItemListScreen : TemplateForm
    {
        public ItemListScreen()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDescription.Clear();
            txtHSCode.Clear();
            txtDescription.Focus();
        }

        private void ItemListScreen_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGrid();
        }

        private void LoadDataIntoDataGrid()
        {
            ListData.LoadDataIntoDataGridView(dgvItems, "usp_ItemsGetAllItems");
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            
        }
        private void LoadDataIntoDataGridByName()
        {
            DBParameter para = new DBParameter();
            para.Parameter = "@ItemName";
            para.Value = txtDescription.Text.Trim();
            ListData.LoadDataIntoDataGridView(dgvItems, "usp_ItemsGetItemByName", para);
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            FindItemWithValidation();

        }

        private void FindItemWithValidation()
        {
            if (txtDescription.Text == String.Empty && txtHSCode.Text == String.Empty)
            {
                LoadDataIntoDataGrid();
            }
            if (txtHSCode.Text == String.Empty && txtDescription.Text != String.Empty)
            {
                LoadDataIntoDataGridByName();
            }
            if (txtHSCode.Text != String.Empty && txtDescription.Text == String.Empty)
            {
                LoadDataIntoDataGrid();
            }
            //LoadDataIntoDataGridByName();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvItems.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            int ItemID = Convert.ToInt32(dgvItems.Rows[rowIndex].Cells["ItemID"].Value);

            ShowItemDetailForm(ItemID, true);
        }

        private void ShowItemDetailForm(int itemID, bool v)
        {
            ItemDetailsScreen item = new ItemDetailsScreen();
            item.isUpdate = v;
            item.ItemID = itemID;
            item.ShowDialog();
            LoadDataIntoDataGrid();
        }
    }
}

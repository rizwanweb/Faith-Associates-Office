using Faith_Associates.Utilities.Lists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faith_Associates.Screens.ShippingLines
{
    public partial class ShippingLineList : TemplateForm
    {
        public ShippingLineList()
        {
            InitializeComponent();
        }

        private void ShippingLineList_Load(object sender, EventArgs e)
        {
            LoadDataIntoGridView();           
        }

        private void LoadDataIntoGridView()
        {
            ListData.LoadDataIntoDataGridView(dgvShippingLineList, "usp_ShippingLinesGetAllShippingLines");
        }

        private void addNewClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShippingLineDetailsForm terminal = new ShippingLineDetailsForm();
            terminal.ShowDialog();
            LoadDataIntoGridView();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvShippingLineList_DoubleClick(object sender, EventArgs e)
        {
            int rowIndex = dgvShippingLineList.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            int slID = Convert.ToInt32(dgvShippingLineList.Rows[rowIndex].Cells["ShippingLineID"].Value);

            ShowShippingLineDetailsForm(slID, true);
        }

        private void ShowShippingLineDetailsForm(int slID, bool isUpdated)
        {
            ShippingLineDetailsForm sl = new ShippingLineDetailsForm();
            sl.ShippingLineID = slID;
            sl.isUpdate = isUpdated;
            sl.ShowDialog();
            LoadDataIntoGridView();            
        }
    }
}

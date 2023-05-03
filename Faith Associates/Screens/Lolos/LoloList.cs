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

namespace Faith_Associates.Screens.Lolos
{
    public partial class LoloList : TemplateForm
    {
        public LoloList()
        {
            InitializeComponent();
        }

        private void LoloList_Load(object sender, EventArgs e)
        {
            LoadDataIntoGridView();           
        }

        private void LoadDataIntoGridView()
        {
            ListData.LoadDataIntoDataGridView(dgvLoloList, "usp_LolosGetAllLolos");
        }

        private void addNewClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoloDetailsForm lolo = new LoloDetailsForm();
            lolo.ShowDialog();
            LoadDataIntoGridView();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLoloList_DoubleClick(object sender, EventArgs e)
        {
            int rowIndex = dgvLoloList.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            int loloID = Convert.ToInt32(dgvLoloList.Rows[rowIndex].Cells["LoloID"].Value);

            ShowLoloDetailsForm(loloID, true);
        }

        private void ShowLoloDetailsForm(int loloID, bool isUpdated)
        {
            LoloDetailsForm lolo = new LoloDetailsForm();
            lolo.LoloID = loloID;
            lolo.isUpdate = isUpdated;
            lolo.ShowDialog();
            LoadDataIntoGridView();            
        }
    }
}

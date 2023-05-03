namespace Faith_Associates.Screens.Jobs
{
    partial class SearchJobsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchJobsForm));
            this.dgvJobList = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvJobList
            // 
            this.dgvJobList.AllowUserToAddRows = false;
            this.dgvJobList.AllowUserToDeleteRows = false;
            this.dgvJobList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJobList.Location = new System.Drawing.Point(13, 169);
            this.dgvJobList.Name = "dgvJobList";
            this.dgvJobList.ReadOnly = true;
            this.dgvJobList.Size = new System.Drawing.Size(826, 374);
            this.dgvJobList.TabIndex = 2;
            this.dgvJobList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvJobList_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cmbBy);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSearchBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(826, 71);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(548, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(44, 31);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbBy
            // 
            this.cmbBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBy.FormattingEnabled = true;
            this.cmbBy.Items.AddRange(new object[] {
            "Job No",
            "LC"});
            this.cmbBy.Location = new System.Drawing.Point(379, 25);
            this.cmbBy.Name = "cmbBy";
            this.cmbBy.Size = new System.Drawing.Size(162, 29);
            this.cmbBy.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(339, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "BY";
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBox.Location = new System.Drawing.Point(6, 25);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(327, 30);
            this.txtSearchBox.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(851, 84);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(851, 84);
            this.label1.TabIndex = 0;
            this.label1.Text = "JOB SEARCH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SearchJobsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 555);
            this.Controls.Add(this.dgvJobList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "SearchJobsForm";
            this.Text = "Search Jobs";
            this.Load += new System.EventHandler(this.SearchJobsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.DataGridView dgvJobList;
    }
}
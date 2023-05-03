namespace Faith_Associates.Screens.Items
{
    partial class ItemDetailsScreen
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtHSCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtRD = new System.Windows.Forms.TextBox();
            this.cmbRDType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCess = new System.Windows.Forms.TextBox();
            this.cmbCessType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIT = new System.Windows.Forms.TextBox();
            this.cmbITType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtST = new System.Windows.Forms.TextBox();
            this.cmbSTType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtACD = new System.Windows.Forms.TextBox();
            this.cmbACDType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCD = new System.Windows.Forms.TextBox();
            this.cmbCDType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 81);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Cascadia Code SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(621, 81);
            this.label1.TabIndex = 0;
            this.label1.Text = "ITEM DETAILS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtHSCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtItemName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 164);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Information";
            // 
            // txtHSCode
            // 
            this.txtHSCode.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHSCode.Location = new System.Drawing.Point(6, 116);
            this.txtHSCode.Name = "txtHSCode";
            this.txtHSCode.Size = new System.Drawing.Size(133, 30);
            this.txtHSCode.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "H.S.Code";
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(6, 55);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(436, 30);
            this.txtItemName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Item Description";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Location = new System.Drawing.Point(472, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(137, 418);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 23);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 43);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(6, 72);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(125, 43);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(6, 121);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(125, 43);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtRD);
            this.groupBox3.Controls.Add(this.cmbRDType);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtCess);
            this.groupBox3.Controls.Add(this.cmbCessType);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtIT);
            this.groupBox3.Controls.Add(this.cmbITType);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtST);
            this.groupBox3.Controls.Add(this.cmbSTType);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtACD);
            this.groupBox3.Controls.Add(this.cmbACDType);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtCD);
            this.groupBox3.Controls.Add(this.cmbCDType);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 257);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(454, 248);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Duty Structure";
            // 
            // txtRD
            // 
            this.txtRD.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRD.Location = new System.Drawing.Point(259, 203);
            this.txtRD.Name = "txtRD";
            this.txtRD.Size = new System.Drawing.Size(183, 30);
            this.txtRD.TabIndex = 11;
            this.txtRD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbRDType
            // 
            this.cmbRDType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRDType.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRDType.FormattingEnabled = true;
            this.cmbRDType.Items.AddRange(new object[] {
            "",
            "F",
            "%"});
            this.cmbRDType.Location = new System.Drawing.Point(201, 204);
            this.cmbRDType.Name = "cmbRDType";
            this.cmbRDType.Size = new System.Drawing.Size(52, 29);
            this.cmbRDType.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(150, 206);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 25);
            this.label9.TabIndex = 15;
            this.label9.Text = "RD:";
            // 
            // txtCess
            // 
            this.txtCess.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCess.Location = new System.Drawing.Point(259, 167);
            this.txtCess.Name = "txtCess";
            this.txtCess.Size = new System.Drawing.Size(183, 30);
            this.txtCess.TabIndex = 9;
            this.txtCess.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbCessType
            // 
            this.cmbCessType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCessType.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCessType.FormattingEnabled = true;
            this.cmbCessType.Items.AddRange(new object[] {
            "",
            "F",
            "%"});
            this.cmbCessType.Location = new System.Drawing.Point(201, 168);
            this.cmbCessType.Name = "cmbCessType";
            this.cmbCessType.Size = new System.Drawing.Size(52, 29);
            this.cmbCessType.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(128, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 25);
            this.label8.TabIndex = 12;
            this.label8.Text = "CESS:";
            // 
            // txtIT
            // 
            this.txtIT.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIT.Location = new System.Drawing.Point(259, 131);
            this.txtIT.Name = "txtIT";
            this.txtIT.Size = new System.Drawing.Size(183, 30);
            this.txtIT.TabIndex = 7;
            this.txtIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbITType
            // 
            this.cmbITType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbITType.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbITType.FormattingEnabled = true;
            this.cmbITType.Items.AddRange(new object[] {
            "%"});
            this.cmbITType.Location = new System.Drawing.Point(201, 132);
            this.cmbITType.Name = "cmbITType";
            this.cmbITType.Size = new System.Drawing.Size(52, 29);
            this.cmbITType.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(62, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 25);
            this.label7.TabIndex = 9;
            this.label7.Text = "Income Tax:";
            // 
            // txtST
            // 
            this.txtST.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtST.Location = new System.Drawing.Point(259, 95);
            this.txtST.Name = "txtST";
            this.txtST.Size = new System.Drawing.Size(183, 30);
            this.txtST.TabIndex = 5;
            this.txtST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbSTType
            // 
            this.cmbSTType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSTType.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSTType.FormattingEnabled = true;
            this.cmbSTType.Items.AddRange(new object[] {
            "%"});
            this.cmbSTType.Location = new System.Drawing.Point(201, 96);
            this.cmbSTType.Name = "cmbSTType";
            this.cmbSTType.Size = new System.Drawing.Size(52, 29);
            this.cmbSTType.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(73, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "Sales Tax:";
            // 
            // txtACD
            // 
            this.txtACD.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtACD.Location = new System.Drawing.Point(259, 59);
            this.txtACD.Name = "txtACD";
            this.txtACD.Size = new System.Drawing.Size(183, 30);
            this.txtACD.TabIndex = 3;
            this.txtACD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbACDType
            // 
            this.cmbACDType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbACDType.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbACDType.FormattingEnabled = true;
            this.cmbACDType.Items.AddRange(new object[] {
            "",
            "F",
            "%"});
            this.cmbACDType.Location = new System.Drawing.Point(201, 60);
            this.cmbACDType.Name = "cmbACDType";
            this.cmbACDType.Size = new System.Drawing.Size(52, 29);
            this.cmbACDType.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Add Custom Duty:";
            // 
            // txtCD
            // 
            this.txtCD.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCD.Location = new System.Drawing.Point(259, 23);
            this.txtCD.Name = "txtCD";
            this.txtCD.Size = new System.Drawing.Size(183, 30);
            this.txtCD.TabIndex = 1;
            this.txtCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbCDType
            // 
            this.cmbCDType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCDType.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCDType.FormattingEnabled = true;
            this.cmbCDType.Items.AddRange(new object[] {
            "",
            "F",
            "%"});
            this.cmbCDType.Location = new System.Drawing.Point(201, 23);
            this.cmbCDType.Name = "cmbCDType";
            this.cmbCDType.Size = new System.Drawing.Size(52, 29);
            this.cmbCDType.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(51, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Custom Duty:";
            // 
            // ItemDetailsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 517);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "ItemDetailsScreen";
            this.Text = "Item Details";
            this.Load += new System.EventHandler(this.ItemDetailsScreen_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtHSCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtCD;
        private System.Windows.Forms.ComboBox cmbCDType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtRD;
        private System.Windows.Forms.ComboBox cmbRDType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCess;
        private System.Windows.Forms.ComboBox cmbCessType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIT;
        private System.Windows.Forms.ComboBox cmbITType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtST;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtACD;
        private System.Windows.Forms.ComboBox cmbACDType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSTType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
    }
}
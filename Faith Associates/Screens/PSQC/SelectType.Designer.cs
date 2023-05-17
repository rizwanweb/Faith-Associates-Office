namespace Faith_Associates.Screens.PSQC
{
    partial class SelectType
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbJob = new System.Windows.Forms.RadioButton();
            this.rbPid = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbJob);
            this.groupBox1.Controls.Add(this.rbPid);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rbJob
            // 
            this.rbJob.AutoSize = true;
            this.rbJob.Location = new System.Drawing.Point(41, 56);
            this.rbJob.Name = "rbJob";
            this.rbJob.Size = new System.Drawing.Size(55, 25);
            this.rbJob.TabIndex = 1;
            this.rbJob.TabStop = true;
            this.rbJob.Text = "JOB";
            this.rbJob.UseVisualStyleBackColor = true;
            // 
            // rbPid
            // 
            this.rbPid.AutoSize = true;
            this.rbPid.Location = new System.Drawing.Point(41, 25);
            this.rbPid.Name = "rbPid";
            this.rbPid.Size = new System.Drawing.Size(55, 25);
            this.rbPid.TabIndex = 0;
            this.rbPid.TabStop = true;
            this.rbPid.Text = "PID";
            this.rbPid.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(171, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 33);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SelectType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 159);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "SelectType";
            this.Text = "Select Job Type";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbJob;
        private System.Windows.Forms.RadioButton rbPid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
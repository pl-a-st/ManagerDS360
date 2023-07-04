namespace ManagerDS360
{
    partial class frmManagerRoutse
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
            this.lblLisеComPorts = new System.Windows.Forms.Label();
            this.butSave = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.butFindGenerator = new System.Windows.Forms.Button();
            this.cboListComPorts = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLisеComPorts
            // 
            this.lblLisеComPorts.AutoSize = true;
            this.lblLisеComPorts.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLisеComPorts.Location = new System.Drawing.Point(6, 21);
            this.lblLisеComPorts.Name = "lblLisеComPorts";
            this.lblLisеComPorts.Size = new System.Drawing.Size(141, 14);
            this.lblLisеComPorts.TabIndex = 1;
            this.lblLisеComPorts.Text = "Список генераторов";
            this.lblLisеComPorts.Click += new System.EventHandler(this.lblLisеComPorts_Click);
            // 
            // butSave
            // 
            this.butSave.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butSave.Location = new System.Drawing.Point(45, 197);
            this.butSave.MaximumSize = new System.Drawing.Size(110, 27);
            this.butSave.MinimumSize = new System.Drawing.Size(110, 27);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(110, 27);
            this.butSave.TabIndex = 3;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butCancel
            // 
            this.butCancel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCancel.Location = new System.Drawing.Point(238, 197);
            this.butCancel.MaximumSize = new System.Drawing.Size(110, 27);
            this.butCancel.MinimumSize = new System.Drawing.Size(110, 27);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(110, 27);
            this.butCancel.TabIndex = 4;
            this.butCancel.Text = "Отмена";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butFindGenerator
            // 
            this.butFindGenerator.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butFindGenerator.Location = new System.Drawing.Point(269, 30);
            this.butFindGenerator.MinimumSize = new System.Drawing.Size(110, 27);
            this.butFindGenerator.Name = "butFindGenerator";
            this.butFindGenerator.Size = new System.Drawing.Size(110, 41);
            this.butFindGenerator.TabIndex = 2;
            this.butFindGenerator.Text = "Обновить список";
            this.butFindGenerator.UseVisualStyleBackColor = true;
            this.butFindGenerator.Click += new System.EventHandler(this.butFindGenerator_Click);
            // 
            // cboListComPorts
            // 
            this.cboListComPorts.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboListComPorts.FormattingEnabled = true;
            this.cboListComPorts.Location = new System.Drawing.Point(9, 40);
            this.cboListComPorts.Name = "cboListComPorts";
            this.cboListComPorts.Size = new System.Drawing.Size(240, 22);
            this.cboListComPorts.TabIndex = 1;
            this.cboListComPorts.SelectedIndexChanged += new System.EventHandler(this.cboListComPorts_SelectedIndexChanged);
            this.cboListComPorts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butFindGenerator);
            this.groupBox1.Controls.Add(this.butCancel);
            this.groupBox1.Controls.Add(this.cboListComPorts);
            this.groupBox1.Controls.Add(this.butSave);
            this.groupBox1.Controls.Add(this.lblLisеComPorts);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 232);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // frmManagerRoutse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 238);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(435, 277);
            this.MinimumSize = new System.Drawing.Size(435, 277);
            this.Name = "frmManagerRoutse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Назначение генератора по умолчанию";
            this.Load += new System.EventHandler(this.frmDefaultGenerator_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblLisеComPorts;
        internal System.Windows.Forms.Button butSave;
        internal System.Windows.Forms.Button butCancel;
        internal System.Windows.Forms.Button butFindGenerator;
        internal System.Windows.Forms.ComboBox cboListComPorts;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
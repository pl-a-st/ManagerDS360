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
            this.SuspendLayout();
            // 
            // lblLisеComPorts
            // 
            this.lblLisеComPorts.AutoSize = true;
            this.lblLisеComPorts.Location = new System.Drawing.Point(9, 9);
            this.lblLisеComPorts.Name = "lblLisеComPorts";
            this.lblLisеComPorts.Size = new System.Drawing.Size(105, 13);
            this.lblLisеComPorts.TabIndex = 1;
            this.lblLisеComPorts.Text = "Список com портов";
            this.lblLisеComPorts.Click += new System.EventHandler(this.lblLisеComPorts_Click);
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(200, 128);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(113, 23);
            this.butSave.TabIndex = 3;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(12, 203);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(113, 23);
            this.butCancel.TabIndex = 4;
            this.butCancel.Text = "Отмена";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butFindGenerator
            // 
            this.butFindGenerator.Location = new System.Drawing.Point(200, 27);
            this.butFindGenerator.Name = "butFindGenerator";
            this.butFindGenerator.Size = new System.Drawing.Size(113, 23);
            this.butFindGenerator.TabIndex = 5;
            this.butFindGenerator.Text = "Найти генератор";
            this.butFindGenerator.UseVisualStyleBackColor = true;
            this.butFindGenerator.Click += new System.EventHandler(this.butFindGenerator_Click);
            // 
            // cboListComPorts
            // 
            this.cboListComPorts.FormattingEnabled = true;
            this.cboListComPorts.Location = new System.Drawing.Point(12, 27);
            this.cboListComPorts.Name = "cboListComPorts";
            this.cboListComPorts.Size = new System.Drawing.Size(154, 21);
            this.cboListComPorts.TabIndex = 6;
            this.cboListComPorts.SelectedIndexChanged += new System.EventHandler(this.cboListComPorts_SelectedIndexChanged);
            // 
            // frmManagerRoutse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 238);
            this.Controls.Add(this.cboListComPorts);
            this.Controls.Add(this.butFindGenerator);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.lblLisеComPorts);
            this.MaximumSize = new System.Drawing.Size(394, 277);
            this.MinimumSize = new System.Drawing.Size(394, 277);
            this.Name = "frmManagerRoutse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Окно назначения генератора по умолчанию";
            this.Load += new System.EventHandler(this.frmDefaultGenerator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblLisеComPorts;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butFindGenerator;
        private System.Windows.Forms.ComboBox cboListComPorts;
    }
}
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
            this.lblLisеComPorts.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLisеComPorts.Location = new System.Drawing.Point(19, 30);
            this.lblLisеComPorts.Name = "lblLisеComPorts";
            this.lblLisеComPorts.Size = new System.Drawing.Size(132, 14);
            this.lblLisеComPorts.TabIndex = 1;
            this.lblLisеComPorts.Text = "Список com портов";
            this.lblLisеComPorts.Click += new System.EventHandler(this.lblLisеComPorts_Click);
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(22, 199);
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
            this.butCancel.Location = new System.Drawing.Point(277, 199);
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
            this.butFindGenerator.Location = new System.Drawing.Point(277, 47);
            this.butFindGenerator.MaximumSize = new System.Drawing.Size(110, 27);
            this.butFindGenerator.MinimumSize = new System.Drawing.Size(110, 27);
            this.butFindGenerator.Name = "butFindGenerator";
            this.butFindGenerator.Size = new System.Drawing.Size(110, 27);
            this.butFindGenerator.TabIndex = 5;
            this.butFindGenerator.Text = "Найти генераторы";
            this.butFindGenerator.UseVisualStyleBackColor = true;
            this.butFindGenerator.Click += new System.EventHandler(this.butFindGenerator_Click);
            // 
            // cboListComPorts
            // 
            this.cboListComPorts.FormattingEnabled = true;
            this.cboListComPorts.Location = new System.Drawing.Point(22, 49);
            this.cboListComPorts.Name = "cboListComPorts";
            this.cboListComPorts.Size = new System.Drawing.Size(160, 21);
            this.cboListComPorts.TabIndex = 6;
            this.cboListComPorts.SelectedIndexChanged += new System.EventHandler(this.cboListComPorts_SelectedIndexChanged);
            // 
            // frmManagerRoutse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 238);
            this.Controls.Add(this.cboListComPorts);
            this.Controls.Add(this.butFindGenerator);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.lblLisеComPorts);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(435, 277);
            this.MinimumSize = new System.Drawing.Size(435, 277);
            this.Name = "frmManagerRoutse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Окно назначения генератора по умолчанию";
            this.Load += new System.EventHandler(this.frmDefaultGenerator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblLisеComPorts;
        internal System.Windows.Forms.Button butSave;
        internal System.Windows.Forms.Button butCancel;
        internal System.Windows.Forms.Button butFindGenerator;
        internal System.Windows.Forms.ComboBox cboListComPorts;
    }
}
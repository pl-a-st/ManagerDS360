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
            this.lstComPort = new System.Windows.Forms.ListBox();
            this.lblLisеComPorts = new System.Windows.Forms.Label();
            this.butSave = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.butRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstComPort
            // 
            this.lstComPort.FormattingEnabled = true;
            this.lstComPort.Location = new System.Drawing.Point(11, 25);
            this.lstComPort.Name = "lstComPort";
            this.lstComPort.Size = new System.Drawing.Size(355, 160);
            this.lstComPort.TabIndex = 0;
            // 
            // lblLisеComPorts
            // 
            this.lblLisеComPorts.AutoSize = true;
            this.lblLisеComPorts.Location = new System.Drawing.Point(9, 9);
            this.lblLisеComPorts.Name = "lblLisеComPorts";
            this.lblLisеComPorts.Size = new System.Drawing.Size(105, 13);
            this.lblLisеComPorts.TabIndex = 1;
            this.lblLisеComPorts.Text = "Список com портов";
            this.lblLisеComPorts.Click += new System.EventHandler(this.label1_Click);
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(153, 203);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 23);
            this.butSave.TabIndex = 3;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(291, 203);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 4;
            this.butCancel.Text = "Отмена";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // butRefresh
            // 
            this.butRefresh.Location = new System.Drawing.Point(11, 203);
            this.butRefresh.Name = "butRefresh";
            this.butRefresh.Size = new System.Drawing.Size(75, 23);
            this.butRefresh.TabIndex = 5;
            this.butRefresh.Text = "Обновить";
            this.butRefresh.UseVisualStyleBackColor = true;
            // 
            // frmManagerRoutse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 238);
            this.Controls.Add(this.butRefresh);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.lblLisеComPorts);
            this.Controls.Add(this.lstComPort);
            this.Name = "frmManagerRoutse";
            this.Text = "Окно назначения генератора по умолчанию";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstComPort;
        private System.Windows.Forms.Label lblLisеComPorts;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butRefresh;
    }
}
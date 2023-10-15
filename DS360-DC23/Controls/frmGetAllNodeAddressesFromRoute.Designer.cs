
namespace ManagerDS360.Controls
{
    partial class frmGetAllNodeAddressesFromRoute
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
            this.lstAddresses = new System.Windows.Forms.ListBox();
            this.butSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboTestedDevice = new System.Windows.Forms.ComboBox();
            this.lblTestedDevice = new System.Windows.Forms.Label();
            this.ButCancel = new System.Windows.Forms.Button();
            this.butGetAddresses = new System.Windows.Forms.Button();
            this.ButDelete = new System.Windows.Forms.Button();
            this.txtRouteName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstAddresses
            // 
            this.lstAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAddresses.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstAddresses.FormattingEnabled = true;
            this.lstAddresses.ItemHeight = 16;
            this.lstAddresses.Location = new System.Drawing.Point(19, 15);
            this.lstAddresses.Name = "lstAddresses";
            this.lstAddresses.ScrollAlwaysVisible = true;
            this.lstAddresses.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstAddresses.Size = new System.Drawing.Size(882, 388);
            this.lstAddresses.TabIndex = 0;
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSave.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butSave.Location = new System.Drawing.Point(744, 421);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(157, 40);
            this.butSave.TabIndex = 5;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cboTestedDevice);
            this.groupBox2.Controls.Add(this.lblTestedDevice);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(907, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 76);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // cboTestedDevice
            // 
            this.cboTestedDevice.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboTestedDevice.FormattingEnabled = true;
            this.cboTestedDevice.Location = new System.Drawing.Point(7, 39);
            this.cboTestedDevice.Name = "cboTestedDevice";
            this.cboTestedDevice.Size = new System.Drawing.Size(215, 24);
            this.cboTestedDevice.TabIndex = 1;
            this.cboTestedDevice.SelectedIndexChanged += new System.EventHandler(this.cboTestedDevice_SelectedIndexChanged_1);
            // 
            // lblTestedDevice
            // 
            this.lblTestedDevice.AutoSize = true;
            this.lblTestedDevice.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTestedDevice.Location = new System.Drawing.Point(6, 19);
            this.lblTestedDevice.Name = "lblTestedDevice";
            this.lblTestedDevice.Size = new System.Drawing.Size(148, 16);
            this.lblTestedDevice.TabIndex = 0;
            this.lblTestedDevice.Text = "Подключить  прибор";
            // 
            // ButCancel
            // 
            this.ButCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButCancel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButCancel.Location = new System.Drawing.Point(19, 421);
            this.ButCancel.Name = "ButCancel";
            this.ButCancel.Size = new System.Drawing.Size(157, 40);
            this.ButCancel.TabIndex = 5;
            this.ButCancel.Text = "Отменить";
            this.ButCancel.UseVisualStyleBackColor = true;
            this.ButCancel.Click += new System.EventHandler(this.ButCancel_Click);
            // 
            // butGetAddresses
            // 
            this.butGetAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butGetAddresses.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butGetAddresses.Location = new System.Drawing.Point(907, 141);
            this.butGetAddresses.Name = "butGetAddresses";
            this.butGetAddresses.Size = new System.Drawing.Size(230, 40);
            this.butGetAddresses.TabIndex = 5;
            this.butGetAddresses.Text = "Получить узлы";
            this.butGetAddresses.UseVisualStyleBackColor = true;
            this.butGetAddresses.Click += new System.EventHandler(this.button2_Click);
            // 
            // ButDelete
            // 
            this.ButDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButDelete.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButDelete.Location = new System.Drawing.Point(907, 187);
            this.ButDelete.Name = "ButDelete";
            this.ButDelete.Size = new System.Drawing.Size(230, 40);
            this.ButDelete.TabIndex = 5;
            this.ButDelete.Text = "Удалить узел";
            this.ButDelete.UseVisualStyleBackColor = true;
            this.ButDelete.Click += new System.EventHandler(this.ButDelete_Click);
            // 
            // txtRouteName
            // 
            this.txtRouteName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRouteName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRouteName.Location = new System.Drawing.Point(907, 109);
            this.txtRouteName.Name = "txtRouteName";
            this.txtRouteName.Size = new System.Drawing.Size(230, 23);
            this.txtRouteName.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(907, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Имя маршрута";
            // 
            // frmGetAllNodeAddressesFromRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 473);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRouteName);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ButCancel);
            this.Controls.Add(this.ButDelete);
            this.Controls.Add(this.butGetAddresses);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.lstAddresses);
            this.Name = "frmGetAllNodeAddressesFromRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Получение адресов узлов из маршрута";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGetAllNodeAddressesFromRoute_FormClosing);
            this.Load += new System.EventHandler(this.frmGetAllNodeAddressesFromRoute_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox lstAddresses;
        public System.Windows.Forms.Button butSave;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ComboBox cboTestedDevice;
        public System.Windows.Forms.Label lblTestedDevice;
        public System.Windows.Forms.Button ButCancel;
        public System.Windows.Forms.Button butGetAddresses;
        public System.Windows.Forms.Button ButDelete;
        public System.Windows.Forms.TextBox txtRouteName;
        public System.Windows.Forms.Label label1;
    }
}
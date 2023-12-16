﻿namespace ManagerDS360
{
    partial class frmCreationVibroCalibSetting
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
            this.cboSetValue = new System.Windows.Forms.ComboBox();
            this.lblSetValue = new System.Windows.Forms.Label();
            this.lblConversionFactor = new System.Windows.Forms.Label();
            this.butSave = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.butSend = new System.Windows.Forms.Button();
            this.lblValue = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblDetector = new System.Windows.Forms.Label();
            this.cboDetector = new System.Windows.Forms.ComboBox();
            this.txtConversionFactor = new LibControls.ModifiedTextBox();
            this.txtFrequency = new LibControls.ModifiedTextBox();
            this.txtValue = new LibControls.ModifiedTextBox();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboSetValue
            // 
            this.cboSetValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSetValue.FormattingEnabled = true;
            this.cboSetValue.Location = new System.Drawing.Point(23, 73);
            this.cboSetValue.Name = "cboSetValue";
            this.cboSetValue.Size = new System.Drawing.Size(143, 21);
            this.cboSetValue.TabIndex = 5;
            // 
            // lblSetValue
            // 
            this.lblSetValue.AutoSize = true;
            this.lblSetValue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSetValue.Location = new System.Drawing.Point(20, 57);
            this.lblSetValue.Name = "lblSetValue";
            this.lblSetValue.Size = new System.Drawing.Size(137, 13);
            this.lblSetValue.TabIndex = 6;
            this.lblSetValue.Text = "Физическая величина";
            // 
            // lblConversionFactor
            // 
            this.lblConversionFactor.AutoSize = true;
            this.lblConversionFactor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblConversionFactor.Location = new System.Drawing.Point(20, 16);
            this.lblConversionFactor.Name = "lblConversionFactor";
            this.lblConversionFactor.Size = new System.Drawing.Size(132, 13);
            this.lblConversionFactor.TabIndex = 8;
            this.lblConversionFactor.Text = "Коэфф. преобр. мВ/g";
            // 
            // butSave
            // 
            this.butSave.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butSave.Location = new System.Drawing.Point(135, 164);
            this.butSave.MaximumSize = new System.Drawing.Size(110, 27);
            this.butSave.MinimumSize = new System.Drawing.Size(110, 27);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(110, 27);
            this.butSave.TabIndex = 19;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click_1);
            // 
            // butCancel
            // 
            this.butCancel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCancel.Location = new System.Drawing.Point(332, 164);
            this.butCancel.MaximumSize = new System.Drawing.Size(110, 27);
            this.butCancel.MinimumSize = new System.Drawing.Size(110, 27);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(110, 27);
            this.butCancel.TabIndex = 20;
            this.butCancel.Text = "Отмена";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFrequency.Location = new System.Drawing.Point(364, 57);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(74, 13);
            this.lblFrequency.TabIndex = 12;
            this.lblFrequency.Text = "Частота, Гц";
            // 
            // butSend
            // 
            this.butSend.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butSend.Location = new System.Drawing.Point(135, 197);
            this.butSend.MaximumSize = new System.Drawing.Size(110, 27);
            this.butSend.MinimumSize = new System.Drawing.Size(110, 27);
            this.butSend.Name = "butSend";
            this.butSend.Size = new System.Drawing.Size(110, 27);
            this.butSend.TabIndex = 18;
            this.butSend.Text = "Отправить";
            this.butSend.UseVisualStyleBackColor = true;
            this.butSend.Click += new System.EventHandler(this.butSend_Click);
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblValue.Location = new System.Drawing.Point(185, 57);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(155, 13);
            this.lblValue.TabIndex = 33;
            this.lblValue.Text = "Значение физ. величины";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblDetector);
            this.groupBox4.Controls.Add(this.cboDetector);
            this.groupBox4.Controls.Add(this.lblFrequency);
            this.groupBox4.Controls.Add(this.txtConversionFactor);
            this.groupBox4.Controls.Add(this.lblSetValue);
            this.groupBox4.Controls.Add(this.lblValue);
            this.groupBox4.Controls.Add(this.txtFrequency);
            this.groupBox4.Controls.Add(this.cboSetValue);
            this.groupBox4.Controls.Add(this.txtValue);
            this.groupBox4.Controls.Add(this.lblConversionFactor);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(513, 135);
            this.groupBox4.TabIndex = 38;
            this.groupBox4.TabStop = false;
            // 
            // lblDetector
            // 
            this.lblDetector.AutoSize = true;
            this.lblDetector.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDetector.Location = new System.Drawing.Point(185, 16);
            this.lblDetector.Name = "lblDetector";
            this.lblDetector.Size = new System.Drawing.Size(60, 13);
            this.lblDetector.TabIndex = 40;
            this.lblDetector.Text = "Детектор";
            // 
            // cboDetector
            // 
            this.cboDetector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDetector.FormattingEnabled = true;
            this.cboDetector.Location = new System.Drawing.Point(188, 31);
            this.cboDetector.Name = "cboDetector";
            this.cboDetector.Size = new System.Drawing.Size(152, 21);
            this.cboDetector.TabIndex = 39;
            // 
            // txtConversionFactor
            // 
            this.txtConversionFactor.Location = new System.Drawing.Point(23, 32);
            this.txtConversionFactor.MaxLength = 9;
            this.txtConversionFactor.Name = "txtConversionFactor";
            this.txtConversionFactor.Size = new System.Drawing.Size(143, 20);
            this.txtConversionFactor.TabIndex = 7;
            this.txtConversionFactor.Text = "100";
            // 
            // txtFrequency
            // 
            this.txtFrequency.Location = new System.Drawing.Point(357, 73);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Size = new System.Drawing.Size(143, 20);
            this.txtFrequency.TabIndex = 10;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(188, 73);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(152, 20);
            this.txtValue.TabIndex = 8;
            // 
            // frmCreationVibroCalibSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 241);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.butSend);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSave);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmCreationVibroCalibSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = ",";
            this.Load += new System.EventHandler(this.frmCreationVibroCalibSetting_LoadAsync);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.ComboBox cboSetValue;
        internal System.Windows.Forms.Label lblSetValue;
        internal System.Windows.Forms.Label lblConversionFactor;
        internal System.Windows.Forms.Button butSave;
        internal System.Windows.Forms.Button butCancel;
        internal System.Windows.Forms.Label lblFrequency;
        internal System.Windows.Forms.Button butSend;
        internal LibControls.ModifiedTextBox txtConversionFactor;
        internal LibControls.ModifiedTextBox txtFrequency;
        internal System.Windows.Forms.Label lblValue;
        internal LibControls.ModifiedTextBox txtValue;
        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.ComboBox cboDetector;
        internal System.Windows.Forms.Label lblDetector;
    }
}
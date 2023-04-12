namespace ManagerDS360
{
    partial class frmCreationEditingSettings
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
            this.chcDefaultGenerator = new System.Windows.Forms.CheckBox();
            this.cboComPort = new System.Windows.Forms.ComboBox();
            this.lblComPort = new System.Windows.Forms.Label();
            this.cboTypeSignal = new System.Windows.Forms.ComboBox();
            this.lblTypeSignal = new System.Windows.Forms.Label();
            this.cboSetValue = new System.Windows.Forms.ComboBox();
            this.lblSetValue = new System.Windows.Forms.Label();
            this.txtConversionFactor = new System.Windows.Forms.TextBox();
            this.lblConversionFactor = new System.Windows.Forms.Label();
            this.butSave = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.txtFrequency = new System.Windows.Forms.TextBox();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.txtDetector = new System.Windows.Forms.TextBox();
            this.lblDetector = new System.Windows.Forms.Label();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.lblOffset = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chcDefaultGenerator
            // 
            this.chcDefaultGenerator.AutoSize = true;
            this.chcDefaultGenerator.Location = new System.Drawing.Point(24, 38);
            this.chcDefaultGenerator.Name = "chcDefaultGenerator";
            this.chcDefaultGenerator.Size = new System.Drawing.Size(153, 17);
            this.chcDefaultGenerator.TabIndex = 0;
            this.chcDefaultGenerator.Text = "Генератор по умолчанию";
            this.chcDefaultGenerator.UseVisualStyleBackColor = true;
            // 
            // cboComPort
            // 
            this.cboComPort.FormattingEnabled = true;
            this.cboComPort.Location = new System.Drawing.Point(24, 89);
            this.cboComPort.Name = "cboComPort";
            this.cboComPort.Size = new System.Drawing.Size(143, 21);
            this.cboComPort.TabIndex = 1;
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Location = new System.Drawing.Point(21, 73);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(54, 13);
            this.lblComPort.TabIndex = 2;
            this.lblComPort.Text = "Com порт";
            // 
            // cboTypeSignal
            // 
            this.cboTypeSignal.FormattingEnabled = true;
            this.cboTypeSignal.Location = new System.Drawing.Point(200, 89);
            this.cboTypeSignal.Name = "cboTypeSignal";
            this.cboTypeSignal.Size = new System.Drawing.Size(143, 21);
            this.cboTypeSignal.TabIndex = 3;
            // 
            // lblTypeSignal
            // 
            this.lblTypeSignal.AutoSize = true;
            this.lblTypeSignal.Location = new System.Drawing.Point(197, 70);
            this.lblTypeSignal.Name = "lblTypeSignal";
            this.lblTypeSignal.Size = new System.Drawing.Size(70, 13);
            this.lblTypeSignal.TabIndex = 4;
            this.lblTypeSignal.Text = "Вид сигнала";
            // 
            // cboSetValue
            // 
            this.cboSetValue.FormattingEnabled = true;
            this.cboSetValue.Location = new System.Drawing.Point(388, 89);
            this.cboSetValue.Name = "cboSetValue";
            this.cboSetValue.Size = new System.Drawing.Size(143, 21);
            this.cboSetValue.TabIndex = 5;
            // 
            // lblSetValue
            // 
            this.lblSetValue.AutoSize = true;
            this.lblSetValue.Location = new System.Drawing.Point(385, 73);
            this.lblSetValue.Name = "lblSetValue";
            this.lblSetValue.Size = new System.Drawing.Size(120, 13);
            this.lblSetValue.TabIndex = 6;
            this.lblSetValue.Text = "Задаваемая величина";
            // 
            // txtConversionFactor
            // 
            this.txtConversionFactor.Location = new System.Drawing.Point(24, 164);
            this.txtConversionFactor.Name = "txtConversionFactor";
            this.txtConversionFactor.Size = new System.Drawing.Size(143, 20);
            this.txtConversionFactor.TabIndex = 7;
            // 
            // lblConversionFactor
            // 
            this.lblConversionFactor.AutoSize = true;
            this.lblConversionFactor.Location = new System.Drawing.Point(24, 133);
            this.lblConversionFactor.Name = "lblConversionFactor";
            this.lblConversionFactor.Size = new System.Drawing.Size(143, 26);
            this.lblConversionFactor.TabIndex = 8;
            this.lblConversionFactor.Text = "Коэффициент \r\nпреобразования мВ/м×с-2";
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(12, 300);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(109, 27);
            this.butSave.TabIndex = 9;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(422, 300);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(109, 27);
            this.butCancel.TabIndex = 10;
            this.butCancel.Text = "Отмена";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // txtFrequency
            // 
            this.txtFrequency.Location = new System.Drawing.Point(200, 164);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Size = new System.Drawing.Size(143, 20);
            this.txtFrequency.TabIndex = 11;
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Location = new System.Drawing.Point(197, 148);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(64, 13);
            this.lblFrequency.TabIndex = 12;
            this.lblFrequency.Text = "Частота Гц";
            // 
            // txtDetector
            // 
            this.txtDetector.Location = new System.Drawing.Point(24, 228);
            this.txtDetector.Name = "txtDetector";
            this.txtDetector.Size = new System.Drawing.Size(143, 20);
            this.txtDetector.TabIndex = 13;
            // 
            // lblDetector
            // 
            this.lblDetector.AutoSize = true;
            this.lblDetector.Location = new System.Drawing.Point(21, 212);
            this.lblDetector.Name = "lblDetector";
            this.lblDetector.Size = new System.Drawing.Size(56, 13);
            this.lblDetector.TabIndex = 14;
            this.lblDetector.Text = "Детектор";
            // 
            // txtOffset
            // 
            this.txtOffset.Location = new System.Drawing.Point(388, 164);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(143, 20);
            this.txtOffset.TabIndex = 15;
            // 
            // lblOffset
            // 
            this.lblOffset.AutoSize = true;
            this.lblOffset.Location = new System.Drawing.Point(386, 150);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(61, 13);
            this.lblOffset.TabIndex = 16;
            this.lblOffset.Text = "Смещение";
            // 
            // frmCreationEditingSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 339);
            this.Controls.Add(this.lblOffset);
            this.Controls.Add(this.txtOffset);
            this.Controls.Add(this.lblDetector);
            this.Controls.Add(this.txtDetector);
            this.Controls.Add(this.lblFrequency);
            this.Controls.Add(this.txtFrequency);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.lblConversionFactor);
            this.Controls.Add(this.txtConversionFactor);
            this.Controls.Add(this.lblSetValue);
            this.Controls.Add(this.cboSetValue);
            this.Controls.Add(this.lblTypeSignal);
            this.Controls.Add(this.cboTypeSignal);
            this.Controls.Add(this.lblComPort);
            this.Controls.Add(this.cboComPort);
            this.Controls.Add(this.chcDefaultGenerator);
            this.Name = "frmCreationEditingSettings";
            this.Text = "frmCreationEditingSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chcDefaultGenerator;
        private System.Windows.Forms.ComboBox cboComPort;
        private System.Windows.Forms.Label lblComPort;
        private System.Windows.Forms.ComboBox cboTypeSignal;
        private System.Windows.Forms.Label lblTypeSignal;
        private System.Windows.Forms.ComboBox cboSetValue;
        private System.Windows.Forms.Label lblSetValue;
        private System.Windows.Forms.TextBox txtConversionFactor;
        private System.Windows.Forms.Label lblConversionFactor;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.TextBox txtFrequency;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.TextBox txtDetector;
        private System.Windows.Forms.Label lblDetector;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.Label lblOffset;
    }
}
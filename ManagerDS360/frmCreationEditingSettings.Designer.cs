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
            this.lblConversionFactor = new System.Windows.Forms.Label();
            this.butSave = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.lblDetector = new System.Windows.Forms.Label();
            this.lblOffset = new System.Windows.Forms.Label();
            this.cboDetector = new System.Windows.Forms.ComboBox();
            this.butSend = new System.Windows.Forms.Button();
            this.lblFrequency2 = new System.Windows.Forms.Label();
            this.cboDetector2 = new System.Windows.Forms.ComboBox();
            this.lblDetector2 = new System.Windows.Forms.Label();
            this.txtConversionFactor = new LibControls.ModifiedTextBox();
            this.txtOffset = new LibControls.ModifiedTextBox();
            this.txtFrequency2 = new LibControls.ModifiedTextBox();
            this.txtFrequency = new LibControls.ModifiedTextBox();
            this.txtValue = new LibControls.ModifiedTextBox();
            this.txtValue2 = new LibControls.ModifiedTextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblValue2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chcDefaultGenerator
            // 
            this.chcDefaultGenerator.AutoSize = true;
            this.chcDefaultGenerator.Location = new System.Drawing.Point(50, 16);
            this.chcDefaultGenerator.Name = "chcDefaultGenerator";
            this.chcDefaultGenerator.Size = new System.Drawing.Size(153, 17);
            this.chcDefaultGenerator.TabIndex = 0;
            this.chcDefaultGenerator.Text = "Генератор по умолчанию";
            this.chcDefaultGenerator.UseVisualStyleBackColor = true;
            this.chcDefaultGenerator.CheckedChanged += new System.EventHandler(this.chcDefaultGenerator_CheckedChanged);
            // 
            // cboComPort
            // 
            this.cboComPort.FormattingEnabled = true;
            this.cboComPort.Location = new System.Drawing.Point(49, 64);
            this.cboComPort.Name = "cboComPort";
            this.cboComPort.Size = new System.Drawing.Size(143, 21);
            this.cboComPort.TabIndex = 1;
            this.cboComPort.SelectedIndexChanged += new System.EventHandler(this.cboComPort_SelectedIndexChanged);
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Location = new System.Drawing.Point(49, 48);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(54, 13);
            this.lblComPort.TabIndex = 2;
            this.lblComPort.Text = "Com порт";
            this.lblComPort.Click += new System.EventHandler(this.lblComPort_Click);
            // 
            // cboTypeSignal
            // 
            this.cboTypeSignal.FormattingEnabled = true;
            this.cboTypeSignal.Location = new System.Drawing.Point(239, 114);
            this.cboTypeSignal.Name = "cboTypeSignal";
            this.cboTypeSignal.Size = new System.Drawing.Size(143, 21);
            this.cboTypeSignal.TabIndex = 3;
            this.cboTypeSignal.SelectedIndexChanged += new System.EventHandler(this.cboTypeSignal_SelectedIndexChanged);
            // 
            // lblTypeSignal
            // 
            this.lblTypeSignal.AutoSize = true;
            this.lblTypeSignal.Location = new System.Drawing.Point(236, 98);
            this.lblTypeSignal.Name = "lblTypeSignal";
            this.lblTypeSignal.Size = new System.Drawing.Size(88, 13);
            this.lblTypeSignal.TabIndex = 4;
            this.lblTypeSignal.Text = "Форма сигнала";
            this.lblTypeSignal.Click += new System.EventHandler(this.lblTypeSignal_Click);
            // 
            // cboSetValue
            // 
            this.cboSetValue.FormattingEnabled = true;
            this.cboSetValue.Location = new System.Drawing.Point(49, 114);
            this.cboSetValue.Name = "cboSetValue";
            this.cboSetValue.Size = new System.Drawing.Size(143, 21);
            this.cboSetValue.TabIndex = 5;
            this.cboSetValue.SelectedIndexChanged += new System.EventHandler(this.cboSetValue_SelectedIndexChanged);
            // 
            // lblSetValue
            // 
            this.lblSetValue.AutoSize = true;
            this.lblSetValue.Location = new System.Drawing.Point(46, 98);
            this.lblSetValue.Name = "lblSetValue";
            this.lblSetValue.Size = new System.Drawing.Size(121, 13);
            this.lblSetValue.TabIndex = 6;
            this.lblSetValue.Text = "Физическая величина";
            this.lblSetValue.Click += new System.EventHandler(this.lblSetValue_Click);
            // 
            // lblConversionFactor
            // 
            this.lblConversionFactor.AutoSize = true;
            this.lblConversionFactor.Location = new System.Drawing.Point(46, 141);
            this.lblConversionFactor.Name = "lblConversionFactor";
            this.lblConversionFactor.Size = new System.Drawing.Size(143, 26);
            this.lblConversionFactor.TabIndex = 8;
            this.lblConversionFactor.Text = "Коэффициент \r\nпреобразования мВ/м×с-2";
            this.lblConversionFactor.Click += new System.EventHandler(this.lblConversionFactor_Click);
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(53, 387);
            this.butSave.MaximumSize = new System.Drawing.Size(110, 27);
            this.butSave.MinimumSize = new System.Drawing.Size(110, 27);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(110, 27);
            this.butSave.TabIndex = 9;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(268, 404);
            this.butCancel.MaximumSize = new System.Drawing.Size(110, 27);
            this.butCancel.MinimumSize = new System.Drawing.Size(110, 27);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(110, 27);
            this.butCancel.TabIndex = 10;
            this.butCancel.Text = "Отмена";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Location = new System.Drawing.Point(46, 237);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(64, 13);
            this.lblFrequency.TabIndex = 12;
            this.lblFrequency.Text = "Частота Гц";
            this.lblFrequency.Click += new System.EventHandler(this.lblFrequency_Click);
            // 
            // lblDetector
            // 
            this.lblDetector.AutoSize = true;
            this.lblDetector.Location = new System.Drawing.Point(46, 279);
            this.lblDetector.Name = "lblDetector";
            this.lblDetector.Size = new System.Drawing.Size(95, 13);
            this.lblDetector.TabIndex = 14;
            this.lblDetector.Text = "Выбор детектора";
            this.lblDetector.Click += new System.EventHandler(this.lblDetector_Click);
            // 
            // lblOffset
            // 
            this.lblOffset.AutoSize = true;
            this.lblOffset.Location = new System.Drawing.Point(47, 324);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(61, 13);
            this.lblOffset.TabIndex = 16;
            this.lblOffset.Text = "Смещение";
            this.lblOffset.Click += new System.EventHandler(this.lblOffset_Click);
            // 
            // cboDetector
            // 
            this.cboDetector.FormattingEnabled = true;
            this.cboDetector.Location = new System.Drawing.Point(49, 295);
            this.cboDetector.Name = "cboDetector";
            this.cboDetector.Size = new System.Drawing.Size(143, 21);
            this.cboDetector.TabIndex = 17;
            this.cboDetector.SelectedIndexChanged += new System.EventHandler(this.cboDetector_SelectedIndexChanged);
            // 
            // butSend
            // 
            this.butSend.Location = new System.Drawing.Point(53, 420);
            this.butSend.MaximumSize = new System.Drawing.Size(110, 27);
            this.butSend.MinimumSize = new System.Drawing.Size(110, 27);
            this.butSend.Name = "butSend";
            this.butSend.Size = new System.Drawing.Size(110, 27);
            this.butSend.TabIndex = 18;
            this.butSend.Text = "Отправить";
            this.butSend.UseVisualStyleBackColor = true;
            this.butSend.Click += new System.EventHandler(this.butSendSetting_Click);
            // 
            // lblFrequency2
            // 
            this.lblFrequency2.AutoSize = true;
            this.lblFrequency2.Location = new System.Drawing.Point(236, 237);
            this.lblFrequency2.Name = "lblFrequency2";
            this.lblFrequency2.Size = new System.Drawing.Size(84, 13);
            this.lblFrequency2.TabIndex = 22;
            this.lblFrequency2.Text = "Частота Гц (2т)";
            // 
            // cboDetector2
            // 
            this.cboDetector2.FormattingEnabled = true;
            this.cboDetector2.Location = new System.Drawing.Point(239, 295);
            this.cboDetector2.Name = "cboDetector2";
            this.cboDetector2.Size = new System.Drawing.Size(143, 21);
            this.cboDetector2.TabIndex = 23;
            this.cboDetector2.SelectedIndexChanged += new System.EventHandler(this.cboDetector2_SelectedIndexChanged);
            // 
            // lblDetector2
            // 
            this.lblDetector2.AutoSize = true;
            this.lblDetector2.Location = new System.Drawing.Point(236, 279);
            this.lblDetector2.Name = "lblDetector2";
            this.lblDetector2.Size = new System.Drawing.Size(115, 13);
            this.lblDetector2.TabIndex = 24;
            this.lblDetector2.Text = "Выбор детектора (2т)";
            // 
            // txtConversionFactor
            // 
            this.txtConversionFactor.Location = new System.Drawing.Point(49, 170);
            this.txtConversionFactor.MaxLength = 9;
            this.txtConversionFactor.Name = "txtConversionFactor";
            this.txtConversionFactor.Size = new System.Drawing.Size(143, 20);
            this.txtConversionFactor.TabIndex = 30;
            this.txtConversionFactor.TextChanged += new System.EventHandler(this.txtConversionFactor_TextChanged);
            // 
            // txtOffset
            // 
            this.txtOffset.Location = new System.Drawing.Point(49, 340);
            this.txtOffset.MaxLength = 9;
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(143, 20);
            this.txtOffset.TabIndex = 29;
            this.txtOffset.TextChanged += new System.EventHandler(this.txtOffset_TextChanged);
            // 
            // txtFrequency2
            // 
            this.txtFrequency2.Location = new System.Drawing.Point(239, 253);
            this.txtFrequency2.MaxLength = 9;
            this.txtFrequency2.Name = "txtFrequency2";
            this.txtFrequency2.Size = new System.Drawing.Size(143, 20);
            this.txtFrequency2.TabIndex = 28;
            this.txtFrequency2.TextChanged += new System.EventHandler(this.txtFrequency2_TextChanged);
            // 
            // txtFrequency
            // 
            this.txtFrequency.Location = new System.Drawing.Point(49, 253);
            this.txtFrequency.MaxLength = 9;
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Size = new System.Drawing.Size(143, 20);
            this.txtFrequency.TabIndex = 27;
            this.txtFrequency.TextChanged += new System.EventHandler(this.txtFrequency_TextChanged);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(49, 209);
            this.txtValue.MaxLength = 9;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(143, 20);
            this.txtValue.TabIndex = 31;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // txtValue2
            // 
            this.txtValue2.Location = new System.Drawing.Point(239, 209);
            this.txtValue2.MaxLength = 9;
            this.txtValue2.Name = "txtValue2";
            this.txtValue2.Size = new System.Drawing.Size(143, 20);
            this.txtValue2.TabIndex = 32;
            this.txtValue2.TextChanged += new System.EventHandler(this.txtValue2_TextChanged);
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(49, 193);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(55, 13);
            this.lblValue.TabIndex = 33;
            this.lblValue.Text = "Значение";
            // 
            // lblValue2
            // 
            this.lblValue2.AutoSize = true;
            this.lblValue2.Location = new System.Drawing.Point(236, 193);
            this.lblValue2.Name = "lblValue2";
            this.lblValue2.Size = new System.Drawing.Size(75, 13);
            this.lblValue2.TabIndex = 34;
            this.lblValue2.Text = "Значение (2т)";
            // 
            // frmCreationEditingSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 461);
            this.Controls.Add(this.lblValue2);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.txtValue2);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.txtConversionFactor);
            this.Controls.Add(this.txtOffset);
            this.Controls.Add(this.txtFrequency2);
            this.Controls.Add(this.txtFrequency);
            this.Controls.Add(this.butSend);
            this.Controls.Add(this.cboDetector);
            this.Controls.Add(this.lblOffset);
            this.Controls.Add(this.lblDetector);
            this.Controls.Add(this.lblFrequency);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.lblConversionFactor);
            this.Controls.Add(this.lblSetValue);
            this.Controls.Add(this.cboSetValue);
            this.Controls.Add(this.lblTypeSignal);
            this.Controls.Add(this.cboTypeSignal);
            this.Controls.Add(this.lblComPort);
            this.Controls.Add(this.cboComPort);
            this.Controls.Add(this.chcDefaultGenerator);
            this.Controls.Add(this.lblFrequency2);
            this.Controls.Add(this.cboDetector2);
            this.Controls.Add(this.lblDetector2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 500);
            this.MinimumSize = new System.Drawing.Size(450, 500);
            this.Name = "frmCreationEditingSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Окно создания и редактирования настройки";
            this.Load += new System.EventHandler(this.frmCreationEditingSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox chcDefaultGenerator;
        internal System.Windows.Forms.ComboBox cboComPort;
        internal System.Windows.Forms.Label lblComPort;
        internal System.Windows.Forms.Label lblTypeSignal;
        internal System.Windows.Forms.ComboBox cboSetValue;
        internal System.Windows.Forms.Label lblSetValue;
        internal System.Windows.Forms.Label lblConversionFactor;
        internal System.Windows.Forms.Button butSave;
        internal System.Windows.Forms.Button butCancel;
        internal System.Windows.Forms.Label lblFrequency;
        internal System.Windows.Forms.Label lblDetector;
        internal System.Windows.Forms.Label lblOffset;
        internal System.Windows.Forms.ComboBox cboDetector;
        internal System.Windows.Forms.Button butSend;
        internal System.Windows.Forms.Label lblFrequency2;
        internal System.Windows.Forms.ComboBox cboDetector2;
        internal System.Windows.Forms.Label lblDetector2;
        internal System.Windows.Forms.ComboBox cboTypeSignal;
        internal LibControls.ModifiedTextBox txtOffset;
        internal LibControls.ModifiedTextBox txtConversionFactor;
        internal LibControls.ModifiedTextBox txtFrequency;
        internal LibControls.ModifiedTextBox txtFrequency2;
        internal LibControls.ModifiedTextBox txtValue2;
        internal System.Windows.Forms.Label lblValue;
        internal System.Windows.Forms.Label lblValue2;
        internal LibControls.ModifiedTextBox txtValue;
    }
}
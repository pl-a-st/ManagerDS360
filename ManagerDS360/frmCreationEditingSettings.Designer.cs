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
            this.cboDetector2 = new System.Windows.Forms.ComboBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numComName = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFrequency = new LibControls.ModifiedTextBox();
            this.txtValue = new LibControls.ModifiedTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValue2 = new LibControls.ModifiedTextBox();
            this.txtFrequency2 = new LibControls.ModifiedTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtConversionFactor = new LibControls.ModifiedTextBox();
            this.txtOffset = new LibControls.ModifiedTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numComName)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // chcDefaultGenerator
            // 
            this.chcDefaultGenerator.AutoSize = true;
            this.chcDefaultGenerator.Checked = true;
            this.chcDefaultGenerator.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chcDefaultGenerator.Location = new System.Drawing.Point(20, 27);
            this.chcDefaultGenerator.Name = "chcDefaultGenerator";
            this.chcDefaultGenerator.Size = new System.Drawing.Size(153, 17);
            this.chcDefaultGenerator.TabIndex = 0;
            this.chcDefaultGenerator.Text = "Генератор по умолчанию";
            this.chcDefaultGenerator.UseVisualStyleBackColor = true;
            this.chcDefaultGenerator.CheckedChanged += new System.EventHandler(this.chcDefaultGenerator_CheckedChanged);
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Location = new System.Drawing.Point(179, 28);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(28, 13);
            this.lblComPort.TabIndex = 2;
            this.lblComPort.Text = "Com";
            this.lblComPort.Click += new System.EventHandler(this.lblComPort_Click);
            // 
            // cboTypeSignal
            // 
            this.cboTypeSignal.FormattingEnabled = true;
            this.cboTypeSignal.Location = new System.Drawing.Point(30, 120);
            this.cboTypeSignal.Name = "cboTypeSignal";
            this.cboTypeSignal.Size = new System.Drawing.Size(143, 21);
            this.cboTypeSignal.TabIndex = 3;
            this.cboTypeSignal.SelectedIndexChanged += new System.EventHandler(this.cboTypeSignal_SelectedIndexChanged);
            // 
            // lblTypeSignal
            // 
            this.lblTypeSignal.AutoSize = true;
            this.lblTypeSignal.Location = new System.Drawing.Point(27, 104);
            this.lblTypeSignal.Name = "lblTypeSignal";
            this.lblTypeSignal.Size = new System.Drawing.Size(88, 13);
            this.lblTypeSignal.TabIndex = 4;
            this.lblTypeSignal.Text = "Форма сигнала";
            this.lblTypeSignal.Click += new System.EventHandler(this.lblTypeSignal_Click);
            // 
            // cboSetValue
            // 
            this.cboSetValue.FormattingEnabled = true;
            this.cboSetValue.Location = new System.Drawing.Point(30, 74);
            this.cboSetValue.Name = "cboSetValue";
            this.cboSetValue.Size = new System.Drawing.Size(143, 21);
            this.cboSetValue.TabIndex = 5;
            this.cboSetValue.SelectedIndexChanged += new System.EventHandler(this.cboSetValue_SelectedIndexChanged);
            // 
            // lblSetValue
            // 
            this.lblSetValue.AutoSize = true;
            this.lblSetValue.Location = new System.Drawing.Point(27, 58);
            this.lblSetValue.Name = "lblSetValue";
            this.lblSetValue.Size = new System.Drawing.Size(121, 13);
            this.lblSetValue.TabIndex = 6;
            this.lblSetValue.Text = "Физическая величина";
            this.lblSetValue.Click += new System.EventHandler(this.lblSetValue_Click);
            // 
            // lblConversionFactor
            // 
            this.lblConversionFactor.AutoSize = true;
            this.lblConversionFactor.Location = new System.Drawing.Point(27, 150);
            this.lblConversionFactor.Name = "lblConversionFactor";
            this.lblConversionFactor.Size = new System.Drawing.Size(116, 13);
            this.lblConversionFactor.TabIndex = 8;
            this.lblConversionFactor.Text = "Коэфф. преобр. мВ/g";
            this.lblConversionFactor.Click += new System.EventHandler(this.lblConversionFactor_Click);
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(143, 343);
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
            this.butCancel.Location = new System.Drawing.Point(340, 343);
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
            this.lblFrequency.Location = new System.Drawing.Point(16, 123);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(67, 13);
            this.lblFrequency.TabIndex = 12;
            this.lblFrequency.Text = "Частота, Гц";
            this.lblFrequency.Click += new System.EventHandler(this.lblFrequency_Click);
            // 
            // lblDetector
            // 
            this.lblDetector.AutoSize = true;
            this.lblDetector.Location = new System.Drawing.Point(16, 77);
            this.lblDetector.Name = "lblDetector";
            this.lblDetector.Size = new System.Drawing.Size(56, 13);
            this.lblDetector.TabIndex = 14;
            this.lblDetector.Text = "Детектор";
            this.lblDetector.Click += new System.EventHandler(this.lblDetector_Click);
            // 
            // lblOffset
            // 
            this.lblOffset.AutoSize = true;
            this.lblOffset.Location = new System.Drawing.Point(309, 210);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(61, 13);
            this.lblOffset.TabIndex = 16;
            this.lblOffset.Text = "Смещение";
            this.lblOffset.Click += new System.EventHandler(this.lblOffset_Click);
            // 
            // cboDetector
            // 
            this.cboDetector.FormattingEnabled = true;
            this.cboDetector.Location = new System.Drawing.Point(19, 93);
            this.cboDetector.Name = "cboDetector";
            this.cboDetector.Size = new System.Drawing.Size(143, 21);
            this.cboDetector.TabIndex = 17;
            this.cboDetector.SelectedIndexChanged += new System.EventHandler(this.cboDetector_SelectedIndexChanged);
            // 
            // butSend
            // 
            this.butSend.Location = new System.Drawing.Point(12, 343);
            this.butSend.MaximumSize = new System.Drawing.Size(110, 27);
            this.butSend.MinimumSize = new System.Drawing.Size(110, 27);
            this.butSend.Name = "butSend";
            this.butSend.Size = new System.Drawing.Size(110, 27);
            this.butSend.TabIndex = 18;
            this.butSend.Text = "Отправить";
            this.butSend.UseVisualStyleBackColor = true;
            this.butSend.Click += new System.EventHandler(this.butSendSetting_Click);
            // 
            // cboDetector2
            // 
            this.cboDetector2.FormattingEnabled = true;
            this.cboDetector2.Location = new System.Drawing.Point(17, 93);
            this.cboDetector2.Name = "cboDetector2";
            this.cboDetector2.Size = new System.Drawing.Size(143, 21);
            this.cboDetector2.TabIndex = 23;
            this.cboDetector2.SelectedIndexChanged += new System.EventHandler(this.cboDetector2_SelectedIndexChanged);
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(16, 32);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(133, 13);
            this.lblValue.TabIndex = 33;
            this.lblValue.Text = "Значение физ. величины";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numComName);
            this.groupBox1.Controls.Add(this.chcDefaultGenerator);
            this.groupBox1.Controls.Add(this.lblComPort);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 68);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Подключение";
            // 
            // numComName
            // 
            this.numComName.Location = new System.Drawing.Point(209, 24);
            this.numComName.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numComName.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numComName.Name = "numComName";
            this.numComName.Size = new System.Drawing.Size(53, 20);
            this.numComName.TabIndex = 3;
            this.numComName.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numComName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numComName_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboDetector);
            this.groupBox2.Controls.Add(this.lblFrequency);
            this.groupBox2.Controls.Add(this.lblDetector);
            this.groupBox2.Controls.Add(this.lblValue);
            this.groupBox2.Controls.Add(this.txtFrequency);
            this.groupBox2.Controls.Add(this.txtValue);
            this.groupBox2.Location = new System.Drawing.Point(190, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(189, 183);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Основной сигнал";
            // 
            // txtFrequency
            // 
            this.txtFrequency.Location = new System.Drawing.Point(19, 139);
            this.txtFrequency.MaxLength = 9;
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Size = new System.Drawing.Size(143, 20);
            this.txtFrequency.TabIndex = 27;
            this.txtFrequency.TextChanged += new System.EventHandler(this.txtFrequency_TextChanged);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(19, 48);
            this.txtValue.MaxLength = 9;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(143, 20);
            this.txtValue.TabIndex = 31;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtValue2);
            this.groupBox3.Controls.Add(this.cboDetector2);
            this.groupBox3.Controls.Add(this.txtFrequency2);
            this.groupBox3.Location = new System.Drawing.Point(385, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(183, 183);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Второй сигнал";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Детектор";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Значение физ. величины";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Частота, Гц";
            this.label3.Click += new System.EventHandler(this.lblFrequency_Click);
            // 
            // txtValue2
            // 
            this.txtValue2.Location = new System.Drawing.Point(17, 48);
            this.txtValue2.MaxLength = 9;
            this.txtValue2.Name = "txtValue2";
            this.txtValue2.Size = new System.Drawing.Size(143, 20);
            this.txtValue2.TabIndex = 32;
            this.txtValue2.TextChanged += new System.EventHandler(this.txtValue2_TextChanged);
            // 
            // txtFrequency2
            // 
            this.txtFrequency2.Location = new System.Drawing.Point(17, 139);
            this.txtFrequency2.MaxLength = 9;
            this.txtFrequency2.Name = "txtFrequency2";
            this.txtFrequency2.Size = new System.Drawing.Size(143, 20);
            this.txtFrequency2.TabIndex = 28;
            this.txtFrequency2.TextChanged += new System.EventHandler(this.txtFrequency2_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.txtConversionFactor);
            this.groupBox4.Controls.Add(this.txtOffset);
            this.groupBox4.Controls.Add(this.lblOffset);
            this.groupBox4.Controls.Add(this.lblSetValue);
            this.groupBox4.Controls.Add(this.cboSetValue);
            this.groupBox4.Controls.Add(this.lblConversionFactor);
            this.groupBox4.Controls.Add(this.lblTypeSignal);
            this.groupBox4.Controls.Add(this.cboTypeSignal);
            this.groupBox4.Location = new System.Drawing.Point(12, 86);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(587, 251);
            this.groupBox4.TabIndex = 38;
            this.groupBox4.TabStop = false;
            // 
            // txtConversionFactor
            // 
            this.txtConversionFactor.Location = new System.Drawing.Point(30, 166);
            this.txtConversionFactor.MaxLength = 9;
            this.txtConversionFactor.Name = "txtConversionFactor";
            this.txtConversionFactor.Size = new System.Drawing.Size(143, 20);
            this.txtConversionFactor.TabIndex = 30;
            this.txtConversionFactor.Text = "100";
            this.txtConversionFactor.TextChanged += new System.EventHandler(this.txtConversionFactor_TextChanged);
            // 
            // txtOffset
            // 
            this.txtOffset.Location = new System.Drawing.Point(312, 223);
            this.txtOffset.MaxLength = 9;
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(143, 20);
            this.txtOffset.TabIndex = 29;
            this.txtOffset.Text = "0";
            this.txtOffset.TextChanged += new System.EventHandler(this.txtOffset_TextChanged);
            // 
            // frmCreationEditingSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 411);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butSend);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSave);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 450);
            this.Name = "frmCreationEditingSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ",";
            this.Load += new System.EventHandler(this.frmCreationEditingSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numComName)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.CheckBox chcDefaultGenerator;
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
        internal System.Windows.Forms.ComboBox cboDetector2;
        internal System.Windows.Forms.ComboBox cboTypeSignal;
        internal LibControls.ModifiedTextBox txtOffset;
        internal LibControls.ModifiedTextBox txtConversionFactor;
        internal LibControls.ModifiedTextBox txtFrequency;
        internal LibControls.ModifiedTextBox txtFrequency2;
        internal LibControls.ModifiedTextBox txtValue2;
        internal System.Windows.Forms.Label lblValue;
        internal LibControls.ModifiedTextBox txtValue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.NumericUpDown numComName;
    }
}
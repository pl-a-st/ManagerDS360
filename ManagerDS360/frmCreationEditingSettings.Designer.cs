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
            this.lblDetector = new System.Windows.Forms.Label();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.lblOffset = new System.Windows.Forms.Label();
            this.cboDetector = new System.Windows.Forms.ComboBox();
            this.butSend = new System.Windows.Forms.Button();
            this.txtFrequency2 = new System.Windows.Forms.TextBox();
            this.lblTypeSignal2 = new System.Windows.Forms.Label();
            this.lblFrequency2 = new System.Windows.Forms.Label();
            this.cboDetector2 = new System.Windows.Forms.ComboBox();
            this.lblDetector2 = new System.Windows.Forms.Label();
            this.cboTypeSignal2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // chcDefaultGenerator
            // 
            this.chcDefaultGenerator.AutoSize = true;
            this.chcDefaultGenerator.Location = new System.Drawing.Point(14, 25);
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
            this.cboComPort.Location = new System.Drawing.Point(200, 25);
            this.cboComPort.Name = "cboComPort";
            this.cboComPort.Size = new System.Drawing.Size(143, 21);
            this.cboComPort.TabIndex = 1;
            this.cboComPort.SelectedIndexChanged += new System.EventHandler(this.cboComPort_SelectedIndexChanged);
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Location = new System.Drawing.Point(197, 9);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(54, 13);
            this.lblComPort.TabIndex = 2;
            this.lblComPort.Text = "Com порт";
            this.lblComPort.Click += new System.EventHandler(this.lblComPort_Click);
            // 
            // cboTypeSignal
            // 
            this.cboTypeSignal.FormattingEnabled = true;
            this.cboTypeSignal.Location = new System.Drawing.Point(18, 88);
            this.cboTypeSignal.Name = "cboTypeSignal";
            this.cboTypeSignal.Size = new System.Drawing.Size(143, 21);
            this.cboTypeSignal.TabIndex = 3;
            this.cboTypeSignal.SelectedIndexChanged += new System.EventHandler(this.cboTypeSignal_SelectedIndexChanged);
            // 
            // lblTypeSignal
            // 
            this.lblTypeSignal.AutoSize = true;
            this.lblTypeSignal.Location = new System.Drawing.Point(18, 70);
            this.lblTypeSignal.Name = "lblTypeSignal";
            this.lblTypeSignal.Size = new System.Drawing.Size(70, 13);
            this.lblTypeSignal.TabIndex = 4;
            this.lblTypeSignal.Text = "Вид сигнала";
            this.lblTypeSignal.Click += new System.EventHandler(this.lblTypeSignal_Click);
            // 
            // cboSetValue
            // 
            this.cboSetValue.FormattingEnabled = true;
            this.cboSetValue.Location = new System.Drawing.Point(381, 25);
            this.cboSetValue.Name = "cboSetValue";
            this.cboSetValue.Size = new System.Drawing.Size(143, 21);
            this.cboSetValue.TabIndex = 5;
            this.cboSetValue.SelectedIndexChanged += new System.EventHandler(this.cboSetValue_SelectedIndexChanged);
            // 
            // lblSetValue
            // 
            this.lblSetValue.AutoSize = true;
            this.lblSetValue.Location = new System.Drawing.Point(378, 9);
            this.lblSetValue.Name = "lblSetValue";
            this.lblSetValue.Size = new System.Drawing.Size(120, 13);
            this.lblSetValue.TabIndex = 6;
            this.lblSetValue.Text = "Задаваемая величина";
            this.lblSetValue.Click += new System.EventHandler(this.lblSetValue_Click);
            // 
            // txtConversionFactor
            // 
            this.txtConversionFactor.Location = new System.Drawing.Point(200, 90);
            this.txtConversionFactor.Name = "txtConversionFactor";
            this.txtConversionFactor.Size = new System.Drawing.Size(143, 20);
            this.txtConversionFactor.TabIndex = 7;
            this.txtConversionFactor.TextChanged += new System.EventHandler(this.txtConversionFactor_TextChanged);
            // 
            // lblConversionFactor
            // 
            this.lblConversionFactor.AutoSize = true;
            this.lblConversionFactor.Location = new System.Drawing.Point(200, 59);
            this.lblConversionFactor.Name = "lblConversionFactor";
            this.lblConversionFactor.Size = new System.Drawing.Size(143, 26);
            this.lblConversionFactor.TabIndex = 8;
            this.lblConversionFactor.Text = "Коэффициент \r\nпреобразования мВ/м×с-2";
            this.lblConversionFactor.Click += new System.EventHandler(this.lblConversionFactor_Click);
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(21, 300);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(109, 27);
            this.butSave.TabIndex = 9;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Visible = false;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(623, 300);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(109, 27);
            this.butCancel.TabIndex = 10;
            this.butCancel.Text = "Отмена";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // txtFrequency
            // 
            this.txtFrequency.Location = new System.Drawing.Point(394, 89);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Size = new System.Drawing.Size(143, 20);
            this.txtFrequency.TabIndex = 11;
            this.txtFrequency.TextChanged += new System.EventHandler(this.txtFrequency_TextChanged);
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Location = new System.Drawing.Point(391, 73);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(64, 13);
            this.lblFrequency.TabIndex = 12;
            this.lblFrequency.Text = "Частота Гц";
            this.lblFrequency.Click += new System.EventHandler(this.lblFrequency_Click);
            // 
            // lblDetector
            // 
            this.lblDetector.AutoSize = true;
            this.lblDetector.Location = new System.Drawing.Point(570, 74);
            this.lblDetector.Name = "lblDetector";
            this.lblDetector.Size = new System.Drawing.Size(95, 13);
            this.lblDetector.TabIndex = 14;
            this.lblDetector.Text = "Выбор детектора";
            this.lblDetector.Click += new System.EventHandler(this.lblDetector_Click);
            // 
            // txtOffset
            // 
            this.txtOffset.Location = new System.Drawing.Point(573, 26);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(143, 20);
            this.txtOffset.TabIndex = 15;
            this.txtOffset.TextChanged += new System.EventHandler(this.txtOffset_TextChanged);
            // 
            // lblOffset
            // 
            this.lblOffset.AutoSize = true;
            this.lblOffset.Location = new System.Drawing.Point(571, 12);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(61, 13);
            this.lblOffset.TabIndex = 16;
            this.lblOffset.Text = "Смещение";
            this.lblOffset.Click += new System.EventHandler(this.lblOffset_Click);
            // 
            // cboDetector
            // 
            this.cboDetector.FormattingEnabled = true;
            this.cboDetector.Location = new System.Drawing.Point(570, 90);
            this.cboDetector.Name = "cboDetector";
            this.cboDetector.Size = new System.Drawing.Size(146, 21);
            this.cboDetector.TabIndex = 17;
            // 
            // butSend
            // 
            this.butSend.Location = new System.Drawing.Point(319, 301);
            this.butSend.Name = "butSend";
            this.butSend.Size = new System.Drawing.Size(102, 26);
            this.butSend.TabIndex = 18;
            this.butSend.Text = "Отправить";
            this.butSend.UseVisualStyleBackColor = true;
            this.butSend.Click += new System.EventHandler(this.butSend_Click);
            // 
            // txtFrequency2
            // 
            this.txtFrequency2.Location = new System.Drawing.Point(394, 150);
            this.txtFrequency2.Name = "txtFrequency2";
            this.txtFrequency2.Size = new System.Drawing.Size(147, 20);
            this.txtFrequency2.TabIndex = 19;
            // 
            // lblTypeSignal2
            // 
            this.lblTypeSignal2.AutoSize = true;
            this.lblTypeSignal2.Location = new System.Drawing.Point(15, 125);
            this.lblTypeSignal2.Name = "lblTypeSignal2";
            this.lblTypeSignal2.Size = new System.Drawing.Size(90, 13);
            this.lblTypeSignal2.TabIndex = 21;
            this.lblTypeSignal2.Text = "Вид сигнала (2т)";
            this.lblTypeSignal2.Click += new System.EventHandler(this.lblTypeSignal2_Click);
            // 
            // lblFrequency2
            // 
            this.lblFrequency2.AutoSize = true;
            this.lblFrequency2.Location = new System.Drawing.Point(399, 132);
            this.lblFrequency2.Name = "lblFrequency2";
            this.lblFrequency2.Size = new System.Drawing.Size(84, 13);
            this.lblFrequency2.TabIndex = 22;
            this.lblFrequency2.Text = "Частота Гц (2т)";
            // 
            // cboDetector2
            // 
            this.cboDetector2.FormattingEnabled = true;
            this.cboDetector2.Location = new System.Drawing.Point(571, 143);
            this.cboDetector2.Name = "cboDetector2";
            this.cboDetector2.Size = new System.Drawing.Size(141, 21);
            this.cboDetector2.TabIndex = 23;
            // 
            // lblDetector2
            // 
            this.lblDetector2.AutoSize = true;
            this.lblDetector2.Location = new System.Drawing.Point(571, 125);
            this.lblDetector2.Name = "lblDetector2";
            this.lblDetector2.Size = new System.Drawing.Size(115, 13);
            this.lblDetector2.TabIndex = 24;
            this.lblDetector2.Text = "Выбор детектора (2т)";
            // 
            // cboTypeSignal2
            // 
            this.cboTypeSignal2.FormattingEnabled = true;
            this.cboTypeSignal2.Location = new System.Drawing.Point(18, 141);
            this.cboTypeSignal2.Name = "cboTypeSignal2";
            this.cboTypeSignal2.Size = new System.Drawing.Size(145, 21);
            this.cboTypeSignal2.TabIndex = 25;
            // 
            // frmCreationEditingSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 339);
            this.Controls.Add(this.cboTypeSignal2);
            this.Controls.Add(this.lblDetector2);
            this.Controls.Add(this.cboDetector2);
            this.Controls.Add(this.lblFrequency2);
            this.Controls.Add(this.lblTypeSignal2);
            this.Controls.Add(this.txtFrequency2);
            this.Controls.Add(this.butSend);
            this.Controls.Add(this.cboDetector);
            this.Controls.Add(this.lblOffset);
            this.Controls.Add(this.txtOffset);
            this.Controls.Add(this.lblDetector);
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
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(566, 378);
            this.MinimumSize = new System.Drawing.Size(566, 378);
            this.Name = "frmCreationEditingSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Окно создания и редактирования настройки";
            this.Load += new System.EventHandler(this.frmCreationEditingSettings_Load);
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
        private System.Windows.Forms.Label lblDetector;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.Label lblOffset;
        private System.Windows.Forms.ComboBox cboDetector;
        private System.Windows.Forms.Button butSend;
        private System.Windows.Forms.TextBox txtFrequency2;
        private System.Windows.Forms.Label lblTypeSignal2;
        private System.Windows.Forms.Label lblFrequency2;
        private System.Windows.Forms.ComboBox cboDetector2;
        private System.Windows.Forms.Label lblDetector2;
        private System.Windows.Forms.ComboBox cboTypeSignal2;
    }
}
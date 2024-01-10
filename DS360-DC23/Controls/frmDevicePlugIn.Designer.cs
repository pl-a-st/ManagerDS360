
namespace ManagerDS360
{
    partial class frmDevicePlugIn
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
            this.components = new System.ComponentModel.Container();
            this.cboListComPorts = new System.Windows.Forms.ComboBox();
            this.lblLisеComPorts = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboMultToMultType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboMultToMultAddress = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboGenToMultType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboGenToMultAddress = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboMultToVibType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboMultToVibAddress = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboGenToVibType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboGenToVibAddress = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.butRefreshMultToVibAddresses = new LibControls.ButtonForRotation();
            this.butRefreshGenToVibAddresses = new LibControls.ButtonForRotation();
            this.buttonForPicture5 = new LibControls.ButtonForRotation();
            this.butRefreshGenToMultAddresses = new LibControls.ButtonForRotation();
            this.buttonForPicture3 = new LibControls.ButtonForRotation();
            this.buttonForPicture2 = new LibControls.ButtonForRotation();
            this.butRefreshDS360List = new LibControls.ButtonForRotation();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboListComPorts
            // 
            this.cboListComPorts.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboListComPorts.FormattingEnabled = true;
            this.cboListComPorts.Location = new System.Drawing.Point(19, 47);
            this.cboListComPorts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboListComPorts.Name = "cboListComPorts";
            this.cboListComPorts.Size = new System.Drawing.Size(361, 22);
            this.cboListComPorts.TabIndex = 3;
            this.cboListComPorts.SelectedIndexChanged += new System.EventHandler(this.cboListComPorts_SelectedIndexChanged);
            // 
            // lblLisеComPorts
            // 
            this.lblLisеComPorts.AutoSize = true;
            this.lblLisеComPorts.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLisеComPorts.Location = new System.Drawing.Point(15, 27);
            this.lblLisеComPorts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLisеComPorts.Name = "lblLisеComPorts";
            this.lblLisеComPorts.Size = new System.Drawing.Size(141, 14);
            this.lblLisеComPorts.TabIndex = 4;
            this.lblLisеComPorts.Text = "Список генераторов";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butRefreshDS360List);
            this.groupBox1.Controls.Add(this.cboListComPorts);
            this.groupBox1.Controls.Add(this.lblLisеComPorts);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(16, 37);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(438, 95);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Генератор DS-360 по умолчанию";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonForPicture2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(16, 138);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(440, 95);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Генератор Agilent основной по умолчанию";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Список генераторов";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(19, 47);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(361, 22);
            this.comboBox1.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonForPicture3);
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(16, 246);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(440, 95);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Генератор Agilent для фазы по умолчанию";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(19, 50);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(361, 22);
            this.comboBox2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(15, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Список генераторов";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboMultToMultType);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.buttonForPicture5);
            this.groupBox4.Controls.Add(this.cboMultToMultAddress);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.cboGenToMultType);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.butRefreshGenToMultAddresses);
            this.groupBox4.Controls.Add(this.cboGenToMultAddress);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(469, 37);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Size = new System.Drawing.Size(848, 145);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Генератор по вольтметру";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // cboMultToMultType
            // 
            this.cboMultToMultType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboMultToMultType.FormattingEnabled = true;
            this.cboMultToMultType.Location = new System.Drawing.Point(432, 47);
            this.cboMultToMultType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboMultToMultType.Name = "cboMultToMultType";
            this.cboMultToMultType.Size = new System.Drawing.Size(368, 22);
            this.cboMultToMultType.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(428, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "Тип вольтметра";
            // 
            // cboMultToMultAddress
            // 
            this.cboMultToMultAddress.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboMultToMultAddress.FormattingEnabled = true;
            this.cboMultToMultAddress.Location = new System.Drawing.Point(432, 97);
            this.cboMultToMultAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboMultToMultAddress.Name = "cboMultToMultAddress";
            this.cboMultToMultAddress.Size = new System.Drawing.Size(368, 22);
            this.cboMultToMultAddress.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(428, 76);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Список вольтметров";
            // 
            // cboGenToMultType
            // 
            this.cboGenToMultType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboGenToMultType.FormattingEnabled = true;
            this.cboGenToMultType.Location = new System.Drawing.Point(12, 47);
            this.cboGenToMultType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboGenToMultType.Name = "cboGenToMultType";
            this.cboGenToMultType.Size = new System.Drawing.Size(368, 22);
            this.cboGenToMultType.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(8, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Тип генератора";
            // 
            // cboGenToMultAddress
            // 
            this.cboGenToMultAddress.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboGenToMultAddress.FormattingEnabled = true;
            this.cboGenToMultAddress.Location = new System.Drawing.Point(12, 97);
            this.cboGenToMultAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboGenToMultAddress.Name = "cboGenToMultAddress";
            this.cboGenToMultAddress.Size = new System.Drawing.Size(368, 22);
            this.cboGenToMultAddress.TabIndex = 3;
            this.cboGenToMultAddress.SelectedIndexChanged += new System.EventHandler(this.cboGenToMultAddress_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(8, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Список генераторов";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cboMultToVibType);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.butRefreshMultToVibAddresses);
            this.groupBox5.Controls.Add(this.cboMultToVibAddress);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.cboGenToVibType);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.butRefreshGenToVibAddresses);
            this.groupBox5.Controls.Add(this.cboGenToVibAddress);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(469, 196);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Size = new System.Drawing.Size(848, 145);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Вибрационная установка";
            // 
            // cboMultToVibType
            // 
            this.cboMultToVibType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboMultToVibType.FormattingEnabled = true;
            this.cboMultToVibType.Location = new System.Drawing.Point(431, 47);
            this.cboMultToVibType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboMultToVibType.Name = "cboMultToVibType";
            this.cboMultToVibType.Size = new System.Drawing.Size(368, 22);
            this.cboMultToVibType.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(427, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 14);
            this.label7.TabIndex = 13;
            this.label7.Text = "Тип вольтметра";
            // 
            // cboMultToVibAddress
            // 
            this.cboMultToVibAddress.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboMultToVibAddress.FormattingEnabled = true;
            this.cboMultToVibAddress.Location = new System.Drawing.Point(431, 97);
            this.cboMultToVibAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboMultToVibAddress.Name = "cboMultToVibAddress";
            this.cboMultToVibAddress.Size = new System.Drawing.Size(368, 22);
            this.cboMultToVibAddress.TabIndex = 9;
            this.cboMultToVibAddress.SelectedIndexChanged += new System.EventHandler(this.cboMultToVibAddress_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(427, 76);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 14);
            this.label8.TabIndex = 10;
            this.label8.Text = "Список вольтметров";
            // 
            // cboGenToVibType
            // 
            this.cboGenToVibType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboGenToVibType.FormattingEnabled = true;
            this.cboGenToVibType.Location = new System.Drawing.Point(12, 47);
            this.cboGenToVibType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboGenToVibType.Name = "cboGenToVibType";
            this.cboGenToVibType.Size = new System.Drawing.Size(368, 22);
            this.cboGenToVibType.TabIndex = 7;
            this.cboGenToVibType.SelectedIndexChanged += new System.EventHandler(this.cboGenToVibType_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(8, 27);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 14);
            this.label9.TabIndex = 8;
            this.label9.Text = "Тип генератора";
            // 
            // cboGenToVibAddress
            // 
            this.cboGenToVibAddress.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboGenToVibAddress.FormattingEnabled = true;
            this.cboGenToVibAddress.Location = new System.Drawing.Point(12, 97);
            this.cboGenToVibAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboGenToVibAddress.Name = "cboGenToVibAddress";
            this.cboGenToVibAddress.Size = new System.Drawing.Size(368, 22);
            this.cboGenToVibAddress.TabIndex = 3;
            this.cboGenToVibAddress.SelectedIndexChanged += new System.EventHandler(this.cboGenToVibAddress_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(8, 76);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 14);
            this.label10.TabIndex = 4;
            this.label10.Text = "Список генераторов";
            // 
            // butRefreshMultToVibAddresses
            // 
            this.butRefreshMultToVibAddresses.BackColor = System.Drawing.Color.Transparent;
            this.butRefreshMultToVibAddresses.BackgroundImage = global::ManagerDS360.Properties.Resources.Обновить9;
            this.butRefreshMultToVibAddresses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butRefreshMultToVibAddresses.FlatAppearance.BorderSize = 0;
            this.butRefreshMultToVibAddresses.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butRefreshMultToVibAddresses.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butRefreshMultToVibAddresses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butRefreshMultToVibAddresses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butRefreshMultToVibAddresses.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butRefreshMultToVibAddresses.Location = new System.Drawing.Point(802, 86);
            this.butRefreshMultToVibAddresses.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butRefreshMultToVibAddresses.Name = "butRefreshMultToVibAddresses";
            this.butRefreshMultToVibAddresses.Size = new System.Drawing.Size(40, 40);
            this.butRefreshMultToVibAddresses.TabIndex = 11;
            this.butRefreshMultToVibAddresses.UseVisualStyleBackColor = false;
            this.butRefreshMultToVibAddresses.Click += new System.EventHandler(this.buttonForPicture6_Click);
            // 
            // butRefreshGenToVibAddresses
            // 
            this.butRefreshGenToVibAddresses.BackColor = System.Drawing.Color.Transparent;
            this.butRefreshGenToVibAddresses.BackgroundImage = global::ManagerDS360.Properties.Resources.Обновить9;
            this.butRefreshGenToVibAddresses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butRefreshGenToVibAddresses.FlatAppearance.BorderSize = 0;
            this.butRefreshGenToVibAddresses.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butRefreshGenToVibAddresses.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butRefreshGenToVibAddresses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butRefreshGenToVibAddresses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butRefreshGenToVibAddresses.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butRefreshGenToVibAddresses.Location = new System.Drawing.Point(383, 87);
            this.butRefreshGenToVibAddresses.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butRefreshGenToVibAddresses.Name = "butRefreshGenToVibAddresses";
            this.butRefreshGenToVibAddresses.Size = new System.Drawing.Size(40, 40);
            this.butRefreshGenToVibAddresses.TabIndex = 6;
            this.butRefreshGenToVibAddresses.UseVisualStyleBackColor = false;
            this.butRefreshGenToVibAddresses.Click += new System.EventHandler(this.butRefreshGenToVibAddresses_Click);
            // 
            // buttonForPicture5
            // 
            this.buttonForPicture5.BackColor = System.Drawing.Color.Transparent;
            this.buttonForPicture5.BackgroundImage = global::ManagerDS360.Properties.Resources.Обновить9;
            this.buttonForPicture5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonForPicture5.FlatAppearance.BorderSize = 0;
            this.buttonForPicture5.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonForPicture5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonForPicture5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonForPicture5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonForPicture5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForPicture5.Location = new System.Drawing.Point(803, 86);
            this.buttonForPicture5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonForPicture5.Name = "buttonForPicture5";
            this.buttonForPicture5.Size = new System.Drawing.Size(40, 40);
            this.buttonForPicture5.TabIndex = 11;
            this.buttonForPicture5.UseVisualStyleBackColor = false;
            // 
            // butRefreshGenToMultAddresses
            // 
            this.butRefreshGenToMultAddresses.BackColor = System.Drawing.Color.Transparent;
            this.butRefreshGenToMultAddresses.BackgroundImage = global::ManagerDS360.Properties.Resources.Обновить9;
            this.butRefreshGenToMultAddresses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butRefreshGenToMultAddresses.FlatAppearance.BorderSize = 0;
            this.butRefreshGenToMultAddresses.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butRefreshGenToMultAddresses.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butRefreshGenToMultAddresses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butRefreshGenToMultAddresses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butRefreshGenToMultAddresses.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butRefreshGenToMultAddresses.Location = new System.Drawing.Point(382, 83);
            this.butRefreshGenToMultAddresses.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butRefreshGenToMultAddresses.Name = "butRefreshGenToMultAddresses";
            this.butRefreshGenToMultAddresses.Size = new System.Drawing.Size(40, 40);
            this.butRefreshGenToMultAddresses.TabIndex = 6;
            this.butRefreshGenToMultAddresses.UseVisualStyleBackColor = false;
            this.butRefreshGenToMultAddresses.Click += new System.EventHandler(this.butRefreshGenToMultAddresses_Click);
            // 
            // buttonForPicture3
            // 
            this.buttonForPicture3.BackColor = System.Drawing.Color.Transparent;
            this.buttonForPicture3.BackgroundImage = global::ManagerDS360.Properties.Resources.Обновить9;
            this.buttonForPicture3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonForPicture3.FlatAppearance.BorderSize = 0;
            this.buttonForPicture3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonForPicture3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonForPicture3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonForPicture3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonForPicture3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForPicture3.Location = new System.Drawing.Point(383, 41);
            this.buttonForPicture3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonForPicture3.Name = "buttonForPicture3";
            this.buttonForPicture3.Size = new System.Drawing.Size(40, 40);
            this.buttonForPicture3.TabIndex = 7;
            this.buttonForPicture3.UseVisualStyleBackColor = false;
            this.buttonForPicture3.Click += new System.EventHandler(this.buttonForPicture3_Click_1);
            // 
            // buttonForPicture2
            // 
            this.buttonForPicture2.BackColor = System.Drawing.Color.Transparent;
            this.buttonForPicture2.BackgroundImage = global::ManagerDS360.Properties.Resources.Обновить9;
            this.buttonForPicture2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonForPicture2.FlatAppearance.BorderSize = 0;
            this.buttonForPicture2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonForPicture2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonForPicture2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonForPicture2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonForPicture2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForPicture2.Location = new System.Drawing.Point(386, 36);
            this.buttonForPicture2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonForPicture2.Name = "buttonForPicture2";
            this.buttonForPicture2.Size = new System.Drawing.Size(40, 40);
            this.buttonForPicture2.TabIndex = 7;
            this.buttonForPicture2.UseVisualStyleBackColor = false;
            this.buttonForPicture2.Click += new System.EventHandler(this.buttonForPicture2_Click);
            // 
            // butRefreshDS360List
            // 
            this.butRefreshDS360List.BackColor = System.Drawing.Color.Transparent;
            this.butRefreshDS360List.BackgroundImage = global::ManagerDS360.Properties.Resources.Обновить9;
            this.butRefreshDS360List.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butRefreshDS360List.FlatAppearance.BorderSize = 0;
            this.butRefreshDS360List.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butRefreshDS360List.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butRefreshDS360List.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butRefreshDS360List.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butRefreshDS360List.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butRefreshDS360List.Location = new System.Drawing.Point(388, 37);
            this.butRefreshDS360List.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butRefreshDS360List.Name = "butRefreshDS360List";
            this.butRefreshDS360List.Size = new System.Drawing.Size(40, 40);
            this.butRefreshDS360List.TabIndex = 5;
            this.butRefreshDS360List.UseVisualStyleBackColor = false;
            this.butRefreshDS360List.Click += new System.EventHandler(this.buttonForPicture1_Click);
            // 
            // frmDevicePlugIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 351);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmDevicePlugIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Подключение приборов";
            this.Load += new System.EventHandler(this.frmDevicePlugIn_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox cboListComPorts;
        private System.Windows.Forms.Label lblLisеComPorts;
        private System.Windows.Forms.GroupBox groupBox1;
        private LibControls.ButtonForRotation butRefreshDS360List;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private LibControls.ButtonForRotation butRefreshGenToMultAddresses;
        internal System.Windows.Forms.ComboBox cboGenToMultAddress;
        private System.Windows.Forms.Label label3;
        private LibControls.ButtonForRotation buttonForPicture2;
        internal System.Windows.Forms.ComboBox comboBox1;
        private LibControls.ButtonForRotation buttonForPicture3;
        internal System.Windows.Forms.ComboBox comboBox2;
        internal System.Windows.Forms.ComboBox cboMultToMultType;
        private System.Windows.Forms.Label label5;
        private LibControls.ButtonForRotation buttonForPicture5;
        internal System.Windows.Forms.ComboBox cboMultToMultAddress;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cboGenToMultType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox5;
        internal System.Windows.Forms.ComboBox cboMultToVibType;
        private System.Windows.Forms.Label label7;
        private LibControls.ButtonForRotation butRefreshMultToVibAddresses;
        internal System.Windows.Forms.ComboBox cboMultToVibAddress;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ComboBox cboGenToVibType;
        private System.Windows.Forms.Label label9;
        private LibControls.ButtonForRotation butRefreshGenToVibAddresses;
        internal System.Windows.Forms.ComboBox cboGenToVibAddress;
        private System.Windows.Forms.Label label10;
    }
}
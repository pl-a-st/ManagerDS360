namespace ManagerDS360
{
    partial class frmTestExchangeDC23
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
            this.lblConectStatus = new System.Windows.Forms.Label();
            this.butDisconect = new System.Windows.Forms.Button();
            this.txtRouteName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNodeAddressChannelA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butOpenRoute = new System.Windows.Forms.Button();
            this.butSetChannelA = new System.Windows.Forms.Button();
            this.txtNodeAddressChannelB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.butSetChannelB = new System.Windows.Forms.Button();
            this.butMeas = new System.Windows.Forms.Button();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblConectStatus
            // 
            this.lblConectStatus.AutoSize = true;
            this.lblConectStatus.Location = new System.Drawing.Point(21, 21);
            this.lblConectStatus.Name = "lblConectStatus";
            this.lblConectStatus.Size = new System.Drawing.Size(35, 13);
            this.lblConectStatus.TabIndex = 0;
            this.lblConectStatus.Text = "label1";
            // 
            // butDisconect
            // 
            this.butDisconect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butDisconect.Location = new System.Drawing.Point(438, 406);
            this.butDisconect.Name = "butDisconect";
            this.butDisconect.Size = new System.Drawing.Size(144, 23);
            this.butDisconect.TabIndex = 2;
            this.butDisconect.Text = "Разорвать соединение";
            this.butDisconect.UseVisualStyleBackColor = true;
            this.butDisconect.Click += new System.EventHandler(this.butDisconect_Click);
            // 
            // txtRouteName
            // 
            this.txtRouteName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRouteName.Enabled = false;
            this.txtRouteName.Location = new System.Drawing.Point(588, 64);
            this.txtRouteName.Name = "txtRouteName";
            this.txtRouteName.Size = new System.Drawing.Size(493, 20);
            this.txtRouteName.TabIndex = 3;
            this.txtRouteName.Text = "[Поверка]";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(585, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Имя маршрута";
            // 
            // txtNodeAddressChannelA
            // 
            this.txtNodeAddressChannelA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNodeAddressChannelA.Enabled = false;
            this.txtNodeAddressChannelA.Location = new System.Drawing.Point(588, 121);
            this.txtNodeAddressChannelA.Name = "txtNodeAddressChannelA";
            this.txtNodeAddressChannelA.Size = new System.Drawing.Size(493, 20);
            this.txtNodeAddressChannelA.TabIndex = 3;
            this.txtNodeAddressChannelA.Text = "[Поверка]/СД-23/ПОВЕРКА/ПЕРВИЧНАЯ_ПОВЕРКА/ПОВЕРКА_С_ВИБРОПРЕОБРАЗОВАТЕЛЯМИ/КОЭФФИ" +
    "ЦИЕНТ_ПРЕОБРАЗОВАНИЯ_/КОЭФФИЦИЕНТ_ПРЕОБРАЗОВАНИЯ/Канал_А";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(585, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Адрес узла (разделитель /)";
            // 
            // butOpenRoute
            // 
            this.butOpenRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butOpenRoute.Enabled = false;
            this.butOpenRoute.Location = new System.Drawing.Point(438, 39);
            this.butOpenRoute.Name = "butOpenRoute";
            this.butOpenRoute.Size = new System.Drawing.Size(141, 23);
            this.butOpenRoute.TabIndex = 5;
            this.butOpenRoute.Text = "Открыть маршрут";
            this.butOpenRoute.UseVisualStyleBackColor = true;
            this.butOpenRoute.Click += new System.EventHandler(this.butOpenRoute_Click);
            // 
            // butSetChannelA
            // 
            this.butSetChannelA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSetChannelA.Enabled = false;
            this.butSetChannelA.Location = new System.Drawing.Point(438, 105);
            this.butSetChannelA.Name = "butSetChannelA";
            this.butSetChannelA.Size = new System.Drawing.Size(141, 23);
            this.butSetChannelA.TabIndex = 5;
            this.butSetChannelA.Text = "Назначить каналом А";
            this.butSetChannelA.UseVisualStyleBackColor = true;
            this.butSetChannelA.Click += new System.EventHandler(this.butSetChannelA_Click);
            // 
            // txtNodeAddressChannelB
            // 
            this.txtNodeAddressChannelB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNodeAddressChannelB.Enabled = false;
            this.txtNodeAddressChannelB.Location = new System.Drawing.Point(591, 177);
            this.txtNodeAddressChannelB.Name = "txtNodeAddressChannelB";
            this.txtNodeAddressChannelB.Size = new System.Drawing.Size(493, 20);
            this.txtNodeAddressChannelB.TabIndex = 3;
            this.txtNodeAddressChannelB.Text = "[Поверка]/СД-23/ПОВЕРКА/ПЕРВИЧНАЯ_ПОВЕРКА/ПОВЕРКА_С_ВИБРОПРЕОБРАЗОВАТЕЛЯМИ/КОЭФФИ" +
    "ЦИЕНТ_ПРЕОБРАЗОВАНИЯ_/КОЭФФИЦИЕНТ_ПРЕОБРАЗОВАНИЯ/Канал_В";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(588, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Адрес узла (разделитель /)";
            // 
            // butSetChannelB
            // 
            this.butSetChannelB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSetChannelB.Enabled = false;
            this.butSetChannelB.Location = new System.Drawing.Point(438, 163);
            this.butSetChannelB.Name = "butSetChannelB";
            this.butSetChannelB.Size = new System.Drawing.Size(141, 23);
            this.butSetChannelB.TabIndex = 5;
            this.butSetChannelB.Text = "Назначить каналом B";
            this.butSetChannelB.UseVisualStyleBackColor = true;
            this.butSetChannelB.Click += new System.EventHandler(this.butSetChannelB_Click);
            // 
            // butMeas
            // 
            this.butMeas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butMeas.Enabled = false;
            this.butMeas.Location = new System.Drawing.Point(439, 244);
            this.butMeas.Name = "butMeas";
            this.butMeas.Size = new System.Drawing.Size(141, 23);
            this.butMeas.TabIndex = 5;
            this.butMeas.Text = "Измерить";
            this.butMeas.UseVisualStyleBackColor = true;
            this.butMeas.Click += new System.EventHandler(this.butMeas_Click);
            // 
            // txtMessages
            // 
            this.txtMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessages.Location = new System.Drawing.Point(24, 41);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ReadOnly = true;
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessages.Size = new System.Drawing.Size(408, 388);
            this.txtMessages.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(438, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Открыть маршрут";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(439, 134);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Назначить каналом А";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(438, 192);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(141, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Назначить каналом B";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(439, 273);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(141, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Измерить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(441, 326);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(141, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Получить Адерса";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // frmTestExchangeDC23
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 450);
            this.Controls.Add(this.txtMessages);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.butMeas);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.butSetChannelB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.butSetChannelA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.butOpenRoute);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNodeAddressChannelB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNodeAddressChannelA);
            this.Controls.Add(this.txtRouteName);
            this.Controls.Add(this.butDisconect);
            this.Controls.Add(this.lblConectStatus);
            this.Name = "frmTestExchangeDC23";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmTestExchangeDC23";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTestExchangeDC23_FormClosing);
            this.Load += new System.EventHandler(this.frmTestExchangeDC23_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConectStatus;
        private System.Windows.Forms.Button butDisconect;
        private System.Windows.Forms.TextBox txtRouteName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNodeAddressChannelA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butOpenRoute;
        private System.Windows.Forms.Button butSetChannelA;
        private System.Windows.Forms.TextBox txtNodeAddressChannelB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butSetChannelB;
        private System.Windows.Forms.Button butMeas;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}
﻿namespace ManagerDS360
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
            this.txtRouteName.Location = new System.Drawing.Point(588, 64);
            this.txtRouteName.Name = "txtRouteName";
            this.txtRouteName.Size = new System.Drawing.Size(493, 20);
            this.txtRouteName.TabIndex = 3;
            this.txtRouteName.Text = "Поверка";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(585, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Имя маршрута";
            // 
            // txtNodeAddressChannelA
            // 
            this.txtNodeAddressChannelA.Location = new System.Drawing.Point(588, 121);
            this.txtNodeAddressChannelA.Name = "txtNodeAddressChannelA";
            this.txtNodeAddressChannelA.Size = new System.Drawing.Size(493, 20);
            this.txtNodeAddressChannelA.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(585, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Адрес узла (разделитель /)";
            // 
            // butOpenRoute
            // 
            this.butOpenRoute.Location = new System.Drawing.Point(438, 61);
            this.butOpenRoute.Name = "butOpenRoute";
            this.butOpenRoute.Size = new System.Drawing.Size(141, 23);
            this.butOpenRoute.TabIndex = 5;
            this.butOpenRoute.Text = "Открыть маршрут";
            this.butOpenRoute.UseVisualStyleBackColor = true;
            this.butOpenRoute.Click += new System.EventHandler(this.butOpenRoute_Click);
            // 
            // butSetChannelA
            // 
            this.butSetChannelA.Location = new System.Drawing.Point(438, 118);
            this.butSetChannelA.Name = "butSetChannelA";
            this.butSetChannelA.Size = new System.Drawing.Size(141, 23);
            this.butSetChannelA.TabIndex = 5;
            this.butSetChannelA.Text = "Назначить каналом А";
            this.butSetChannelA.UseVisualStyleBackColor = true;
            this.butSetChannelA.Click += new System.EventHandler(this.butSetChannelA_Click);
            // 
            // txtNodeAddressChannelB
            // 
            this.txtNodeAddressChannelB.Enabled = false;
            this.txtNodeAddressChannelB.Location = new System.Drawing.Point(591, 177);
            this.txtNodeAddressChannelB.Name = "txtNodeAddressChannelB";
            this.txtNodeAddressChannelB.Size = new System.Drawing.Size(493, 20);
            this.txtNodeAddressChannelB.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(588, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Адрес узла (разделитель /)";
            // 
            // butSetChannelB
            // 
            this.butSetChannelB.Enabled = false;
            this.butSetChannelB.Location = new System.Drawing.Point(438, 175);
            this.butSetChannelB.Name = "butSetChannelB";
            this.butSetChannelB.Size = new System.Drawing.Size(141, 23);
            this.butSetChannelB.TabIndex = 5;
            this.butSetChannelB.Text = "Назначить каналом B";
            this.butSetChannelB.UseVisualStyleBackColor = true;
            this.butSetChannelB.Click += new System.EventHandler(this.butSetChannelB_Click);
            // 
            // butMeas
            // 
            this.butMeas.Location = new System.Drawing.Point(438, 226);
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
            // frmTestExchangeDC23
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 450);
            this.Controls.Add(this.txtMessages);
            this.Controls.Add(this.butMeas);
            this.Controls.Add(this.butSetChannelB);
            this.Controls.Add(this.butSetChannelA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butOpenRoute);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNodeAddressChannelB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNodeAddressChannelA);
            this.Controls.Add(this.txtRouteName);
            this.Controls.Add(this.butDisconect);
            this.Controls.Add(this.lblConectStatus);
            this.Name = "frmTestExchangeDC23";
            this.Text = "frmTestExchangeDC23";
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
    }
}
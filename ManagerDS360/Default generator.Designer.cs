namespace ManagerDS360
{
    partial class Default_Generator_window
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
            this.list_com_port = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.but_save = new System.Windows.Forms.Button();
            this.but_cancel = new System.Windows.Forms.Button();
            this.but_refresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // list_com_port
            // 
            this.list_com_port.FormattingEnabled = true;
            this.list_com_port.Location = new System.Drawing.Point(11, 25);
            this.list_com_port.Name = "list_com_port";
            this.list_com_port.Size = new System.Drawing.Size(355, 160);
            this.list_com_port.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Список com портов";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // but_save
            // 
            this.but_save.Location = new System.Drawing.Point(126, 203);
            this.but_save.Name = "but_save";
            this.but_save.Size = new System.Drawing.Size(75, 23);
            this.but_save.TabIndex = 3;
            this.but_save.Text = "Сохранить";
            this.but_save.UseVisualStyleBackColor = true;
            // 
            // but_cancel
            // 
            this.but_cancel.Location = new System.Drawing.Point(277, 203);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(75, 23);
            this.but_cancel.TabIndex = 4;
            this.but_cancel.Text = "Отмена";
            this.but_cancel.UseVisualStyleBackColor = true;
            // 
            // but_refresh
            // 
            this.but_refresh.Location = new System.Drawing.Point(11, 203);
            this.but_refresh.Name = "but_refresh";
            this.but_refresh.Size = new System.Drawing.Size(75, 23);
            this.but_refresh.TabIndex = 5;
            this.but_refresh.Text = "Обновить";
            this.but_refresh.UseVisualStyleBackColor = true;
            // 
            // Default_Generator_window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 238);
            this.Controls.Add(this.but_refresh);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.but_save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.list_com_port);
            this.Name = "Default_Generator_window";
            this.Text = "Окно назначения генератора по умолчанию";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox list_com_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button but_save;
        private System.Windows.Forms.Button but_cancel;
        private System.Windows.Forms.Button but_refresh;
    }
}
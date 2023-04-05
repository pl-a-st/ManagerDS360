namespace ManagerDS360
{
    partial class frmManagerRoutse
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
            this.listcomport = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butsave = new System.Windows.Forms.Button();
            this.butcancel = new System.Windows.Forms.Button();
            this.butrefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listcomport
            // 
            this.listcomport.FormattingEnabled = true;
            this.listcomport.Location = new System.Drawing.Point(11, 25);
            this.listcomport.Name = "listcomport";
            this.listcomport.Size = new System.Drawing.Size(355, 160);
            this.listcomport.TabIndex = 0;
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
            // butsave
            // 
            this.butsave.Location = new System.Drawing.Point(126, 203);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(75, 23);
            this.butsave.TabIndex = 3;
            this.butsave.Text = "Сохранить";
            this.butsave.UseVisualStyleBackColor = true;
            // 
            // butcancel
            // 
            this.butcancel.Location = new System.Drawing.Point(277, 203);
            this.butcancel.Name = "butcancel";
            this.butcancel.Size = new System.Drawing.Size(75, 23);
            this.butcancel.TabIndex = 4;
            this.butcancel.Text = "Отмена";
            this.butcancel.UseVisualStyleBackColor = true;
            // 
            // butrefresh
            // 
            this.butrefresh.Location = new System.Drawing.Point(11, 203);
            this.butrefresh.Name = "butrefresh";
            this.butrefresh.Size = new System.Drawing.Size(75, 23);
            this.butrefresh.TabIndex = 5;
            this.butrefresh.Text = "Обновить";
            this.butrefresh.UseVisualStyleBackColor = true;
            // 
            // frmManagerRoutse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 238);
            this.Controls.Add(this.butrefresh);
            this.Controls.Add(this.butcancel);
            this.Controls.Add(this.butsave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listcomport);
            this.Name = "frmManagerRoutse";
            this.Text = "Окно назначения генератора по умолчанию";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listcomport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butsave;
        private System.Windows.Forms.Button butcancel;
        private System.Windows.Forms.Button butrefresh;
    }
}
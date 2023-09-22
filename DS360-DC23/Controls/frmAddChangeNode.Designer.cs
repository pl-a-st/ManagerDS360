
namespace ManagerDS360.Controls
{
    partial class frmAddChangeNode
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
            this.butCancel = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.lblChannel = new System.Windows.Forms.Label();
            this.cboChannel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNameNode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // butCancel
            // 
            this.butCancel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCancel.Location = new System.Drawing.Point(432, 126);
            this.butCancel.MinimumSize = new System.Drawing.Size(110, 27);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(110, 40);
            this.butCancel.TabIndex = 16;
            this.butCancel.Text = "Отмена";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSave
            // 
            this.butSave.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butSave.Location = new System.Drawing.Point(13, 126);
            this.butSave.MinimumSize = new System.Drawing.Size(110, 27);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(110, 40);
            this.butSave.TabIndex = 15;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // lblChannel
            // 
            this.lblChannel.AutoSize = true;
            this.lblChannel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblChannel.Location = new System.Drawing.Point(186, 20);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(190, 16);
            this.lblChannel.TabIndex = 17;
            this.lblChannel.Text = "Добавить узел для канала";
            // 
            // cboChannel
            // 
            this.cboChannel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboChannel.FormattingEnabled = true;
            this.cboChannel.Location = new System.Drawing.Point(189, 36);
            this.cboChannel.Name = "cboChannel";
            this.cboChannel.Size = new System.Drawing.Size(187, 22);
            this.cboChannel.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(15, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Название узла";
            // 
            // txtNameNode
            // 
            this.txtNameNode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtNameNode.Location = new System.Drawing.Point(13, 88);
            this.txtNameNode.Name = "txtNameNode";
            this.txtNameNode.Size = new System.Drawing.Size(529, 23);
            this.txtNameNode.TabIndex = 20;
            // 
            // frmAddChangeNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 186);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNameNode);
            this.Controls.Add(this.cboChannel);
            this.Controls.Add(this.lblChannel);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSave);
            this.Name = "frmAddChangeNode";
            this.Text = "Добавить узел";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddChangeNode_FormClosed);
            this.Load += new System.EventHandler(this.frmAddChangeNode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button butCancel;
        internal System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.ComboBox cboChannel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNameNode;
    }
}
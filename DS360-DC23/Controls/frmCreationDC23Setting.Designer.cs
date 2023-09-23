
namespace ManagerDS360.Controls
{
    partial class frmCreationDC23Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreationDC23Setting));
            this.txtRouteName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.butAdd = new System.Windows.Forms.Button();
            this.butChange = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.butCopy = new System.Windows.Forms.Button();
            this.butPaste = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstChannelFirst = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butChannelFirstUp = new LibControls.ButtonForPicture();
            this.butChannelFirstDown = new LibControls.ButtonForPicture();
            this.lstChannelSecond = new System.Windows.Forms.ListBox();
            this.butChannelSecondUp = new LibControls.ButtonForPicture();
            this.label3 = new System.Windows.Forms.Label();
            this.butChannelSecondDown = new LibControls.ButtonForPicture();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRouteName
            // 
            this.txtRouteName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRouteName.Location = new System.Drawing.Point(17, 32);
            this.txtRouteName.Name = "txtRouteName";
            this.txtRouteName.Size = new System.Drawing.Size(529, 20);
            this.txtRouteName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(19, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название маршрута";
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCancel.Location = new System.Drawing.Point(440, 431);
            this.butCancel.MinimumSize = new System.Drawing.Size(110, 27);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(110, 40);
            this.butCancel.TabIndex = 14;
            this.butCancel.Text = "Отмена";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSave.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butSave.Location = new System.Drawing.Point(17, 431);
            this.butSave.MinimumSize = new System.Drawing.Size(110, 27);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(110, 40);
            this.butSave.TabIndex = 13;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butAdd
            // 
            this.butAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butAdd.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAdd.Location = new System.Drawing.Point(605, 84);
            this.butAdd.MinimumSize = new System.Drawing.Size(110, 27);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(148, 40);
            this.butAdd.TabIndex = 13;
            this.butAdd.Text = "Добавить узел";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butChange
            // 
            this.butChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butChange.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butChange.Location = new System.Drawing.Point(605, 130);
            this.butChange.MinimumSize = new System.Drawing.Size(110, 27);
            this.butChange.Name = "butChange";
            this.butChange.Size = new System.Drawing.Size(148, 40);
            this.butChange.TabIndex = 13;
            this.butChange.Text = "Редактировать узел";
            this.butChange.UseVisualStyleBackColor = true;
            this.butChange.Click += new System.EventHandler(this.butChange_Click);
            // 
            // butDelete
            // 
            this.butDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butDelete.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butDelete.Location = new System.Drawing.Point(605, 383);
            this.butDelete.MinimumSize = new System.Drawing.Size(110, 27);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(148, 40);
            this.butDelete.TabIndex = 13;
            this.butDelete.Text = "Удалить узел";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butCopy
            // 
            this.butCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butCopy.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCopy.Location = new System.Drawing.Point(605, 176);
            this.butCopy.MinimumSize = new System.Drawing.Size(110, 27);
            this.butCopy.Name = "butCopy";
            this.butCopy.Size = new System.Drawing.Size(148, 40);
            this.butCopy.TabIndex = 19;
            this.butCopy.Text = "Копировать узел";
            this.butCopy.UseVisualStyleBackColor = true;
            this.butCopy.Click += new System.EventHandler(this.butCopy_Click);
            // 
            // butPaste
            // 
            this.butPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPaste.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butPaste.Location = new System.Drawing.Point(605, 222);
            this.butPaste.MinimumSize = new System.Drawing.Size(110, 27);
            this.butPaste.Name = "butPaste";
            this.butPaste.Size = new System.Drawing.Size(148, 40);
            this.butPaste.TabIndex = 19;
            this.butPaste.Text = "Вставить узел";
            this.butPaste.UseVisualStyleBackColor = true;
            this.butPaste.Click += new System.EventHandler(this.butPaste_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(17, 58);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstChannelFirst);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.butChannelFirstUp);
            this.splitContainer1.Panel1.Controls.Add(this.butChannelFirstDown);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstChannelSecond);
            this.splitContainer1.Panel2.Controls.Add(this.butChannelSecondUp);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.butChannelSecondDown);
            this.splitContainer1.Size = new System.Drawing.Size(582, 371);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.TabIndex = 20;
            // 
            // lstChannelFirst
            // 
            this.lstChannelFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstChannelFirst.FormattingEnabled = true;
            this.lstChannelFirst.Location = new System.Drawing.Point(3, 23);
            this.lstChannelFirst.Name = "lstChannelFirst";
            this.lstChannelFirst.Size = new System.Drawing.Size(229, 329);
            this.lstChannelFirst.TabIndex = 0;
            this.lstChannelFirst.SelectedIndexChanged += new System.EventHandler(this.lstChannelFirst_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(5, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Канал А";
            // 
            // butChannelFirstUp
            // 
            this.butChannelFirstUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butChannelFirstUp.BackColor = System.Drawing.Color.Transparent;
            this.butChannelFirstUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("butChannelFirstUp.BackgroundImage")));
            this.butChannelFirstUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butChannelFirstUp.FlatAppearance.BorderSize = 0;
            this.butChannelFirstUp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butChannelFirstUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butChannelFirstUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butChannelFirstUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butChannelFirstUp.Location = new System.Drawing.Point(238, 102);
            this.butChannelFirstUp.Name = "butChannelFirstUp";
            this.butChannelFirstUp.Size = new System.Drawing.Size(33, 39);
            this.butChannelFirstUp.TabIndex = 15;
            this.butChannelFirstUp.UseVisualStyleBackColor = false;
            this.butChannelFirstUp.Click += new System.EventHandler(this.butChannelFirstUp_Click);
            // 
            // butChannelFirstDown
            // 
            this.butChannelFirstDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butChannelFirstDown.BackColor = System.Drawing.Color.Transparent;
            this.butChannelFirstDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("butChannelFirstDown.BackgroundImage")));
            this.butChannelFirstDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butChannelFirstDown.FlatAppearance.BorderSize = 0;
            this.butChannelFirstDown.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butChannelFirstDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butChannelFirstDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butChannelFirstDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butChannelFirstDown.Location = new System.Drawing.Point(238, 193);
            this.butChannelFirstDown.Name = "butChannelFirstDown";
            this.butChannelFirstDown.Size = new System.Drawing.Size(33, 39);
            this.butChannelFirstDown.TabIndex = 16;
            this.butChannelFirstDown.UseVisualStyleBackColor = false;
            this.butChannelFirstDown.Click += new System.EventHandler(this.butChannelFirstDown_Click);
            // 
            // lstChannelSecond
            // 
            this.lstChannelSecond.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstChannelSecond.FormattingEnabled = true;
            this.lstChannelSecond.Location = new System.Drawing.Point(3, 23);
            this.lstChannelSecond.Name = "lstChannelSecond";
            this.lstChannelSecond.Size = new System.Drawing.Size(231, 329);
            this.lstChannelSecond.TabIndex = 17;
            this.lstChannelSecond.SelectedIndexChanged += new System.EventHandler(this.lstChannelSecond_SelectedIndexChanged);
            // 
            // butChannelSecondUp
            // 
            this.butChannelSecondUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butChannelSecondUp.BackColor = System.Drawing.Color.Transparent;
            this.butChannelSecondUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("butChannelSecondUp.BackgroundImage")));
            this.butChannelSecondUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butChannelSecondUp.FlatAppearance.BorderSize = 0;
            this.butChannelSecondUp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butChannelSecondUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butChannelSecondUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butChannelSecondUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butChannelSecondUp.Location = new System.Drawing.Point(240, 102);
            this.butChannelSecondUp.Name = "butChannelSecondUp";
            this.butChannelSecondUp.Size = new System.Drawing.Size(33, 39);
            this.butChannelSecondUp.TabIndex = 18;
            this.butChannelSecondUp.UseVisualStyleBackColor = false;
            this.butChannelSecondUp.Click += new System.EventHandler(this.butChannelSecondUp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Канал B";
            // 
            // butChannelSecondDown
            // 
            this.butChannelSecondDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butChannelSecondDown.BackColor = System.Drawing.Color.Transparent;
            this.butChannelSecondDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("butChannelSecondDown.BackgroundImage")));
            this.butChannelSecondDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butChannelSecondDown.FlatAppearance.BorderSize = 0;
            this.butChannelSecondDown.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butChannelSecondDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butChannelSecondDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butChannelSecondDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butChannelSecondDown.Location = new System.Drawing.Point(240, 193);
            this.butChannelSecondDown.Name = "butChannelSecondDown";
            this.butChannelSecondDown.Size = new System.Drawing.Size(33, 39);
            this.butChannelSecondDown.TabIndex = 19;
            this.butChannelSecondDown.UseVisualStyleBackColor = false;
            this.butChannelSecondDown.Click += new System.EventHandler(this.butChannelSecondDown_Click);
            // 
            // frmCreationDC23Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 483);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.butPaste);
            this.Controls.Add(this.butCopy);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butChange);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRouteName);
            this.Name = "frmCreationDC23Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Измерение СД-23";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCreationDC23Setting_FormClosed);
            this.Load += new System.EventHandler(this.frmCreationDC23Setting_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtRouteName;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button butCancel;
        internal System.Windows.Forms.Button butSave;
        internal System.Windows.Forms.Button butAdd;
        internal System.Windows.Forms.Button butChange;
        internal System.Windows.Forms.Button butDelete;
        internal System.Windows.Forms.Button butCopy;
        internal System.Windows.Forms.Button butPaste;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstChannelFirst;
        private System.Windows.Forms.Label label2;
        private LibControls.ButtonForPicture butChannelFirstUp;
        private LibControls.ButtonForPicture butChannelFirstDown;
        private System.Windows.Forms.ListBox lstChannelSecond;
        private LibControls.ButtonForPicture butChannelSecondUp;
        private System.Windows.Forms.Label label3;
        private LibControls.ButtonForPicture butChannelSecondDown;
    }
}
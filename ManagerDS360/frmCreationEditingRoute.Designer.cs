namespace ManagerDS360
{
    partial class frmCreationEditingRoute
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
            this.txtNameRoute = new System.Windows.Forms.TextBox();
            this.lblRouteName = new System.Windows.Forms.Label();
            this.lblRouteTree = new System.Windows.Forms.Label();
            this.butAddFolder = new System.Windows.Forms.Button();
            this.butAddSetting = new System.Windows.Forms.Button();
            this.butEditSetting = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.butAllDelete = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.treRouteTree = new LibControls.TreeViewWithSetting();
            this.chkUseLastSetting = new System.Windows.Forms.CheckBox();
            this.picButUp = new System.Windows.Forms.PictureBox();
            this.picButDown = new System.Windows.Forms.PictureBox();
            this.butCpopy = new System.Windows.Forms.Button();
            this.butPaste = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picButUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picButDown)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNameRoute
            // 
            this.txtNameRoute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameRoute.Location = new System.Drawing.Point(18, 26);
            this.txtNameRoute.Name = "txtNameRoute";
            this.txtNameRoute.Size = new System.Drawing.Size(763, 20);
            this.txtNameRoute.TabIndex = 0;
            this.txtNameRoute.TextChanged += new System.EventHandler(this.txtNameRoute_TextChanged);
            // 
            // lblRouteName
            // 
            this.lblRouteName.AutoSize = true;
            this.lblRouteName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRouteName.Location = new System.Drawing.Point(17, 9);
            this.lblRouteName.Name = "lblRouteName";
            this.lblRouteName.Size = new System.Drawing.Size(138, 14);
            this.lblRouteName.TabIndex = 0;
            this.lblRouteName.Text = "Название маршрута";
            this.lblRouteName.Click += new System.EventHandler(this.lblRouteName_Click);
            // 
            // lblRouteTree
            // 
            this.lblRouteTree.AutoSize = true;
            this.lblRouteTree.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRouteTree.Location = new System.Drawing.Point(243, 60);
            this.lblRouteTree.Name = "lblRouteTree";
            this.lblRouteTree.Size = new System.Drawing.Size(124, 14);
            this.lblRouteTree.TabIndex = 9;
            this.lblRouteTree.Text = "Дерево маршрута";
            this.lblRouteTree.Click += new System.EventHandler(this.lblRouteTree_Click);
            // 
            // butAddFolder
            // 
            this.butAddFolder.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAddFolder.Location = new System.Drawing.Point(18, 123);
            this.butAddFolder.Name = "butAddFolder";
            this.butAddFolder.Size = new System.Drawing.Size(157, 40);
            this.butAddFolder.TabIndex = 3;
            this.butAddFolder.Text = "Добавить папку";
            this.butAddFolder.UseVisualStyleBackColor = true;
            this.butAddFolder.Click += new System.EventHandler(this.butAddFolder_Click);
            // 
            // butAddSetting
            // 
            this.butAddSetting.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAddSetting.Location = new System.Drawing.Point(18, 77);
            this.butAddSetting.Name = "butAddSetting";
            this.butAddSetting.Size = new System.Drawing.Size(157, 40);
            this.butAddSetting.TabIndex = 2;
            this.butAddSetting.Text = "Добавить настройку";
            this.butAddSetting.UseVisualStyleBackColor = true;
            this.butAddSetting.Click += new System.EventHandler(this.butAddSetting_Click);
            // 
            // butEditSetting
            // 
            this.butEditSetting.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butEditSetting.Location = new System.Drawing.Point(18, 169);
            this.butEditSetting.Name = "butEditSetting";
            this.butEditSetting.Size = new System.Drawing.Size(157, 40);
            this.butEditSetting.TabIndex = 4;
            this.butEditSetting.Text = "Редактировать узел";
            this.butEditSetting.UseVisualStyleBackColor = true;
            this.butEditSetting.Click += new System.EventHandler(this.butEditSetting_Click);
            // 
            // butDelete
            // 
            this.butDelete.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butDelete.Location = new System.Drawing.Point(18, 322);
            this.butDelete.MinimumSize = new System.Drawing.Size(110, 27);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(157, 40);
            this.butDelete.TabIndex = 5;
            this.butDelete.Text = "Удалить узел";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSave.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butSave.Location = new System.Drawing.Point(246, 427);
            this.butSave.MinimumSize = new System.Drawing.Size(110, 27);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(110, 40);
            this.butSave.TabIndex = 11;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butAllDelete
            // 
            this.butAllDelete.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAllDelete.Location = new System.Drawing.Point(18, 368);
            this.butAllDelete.Name = "butAllDelete";
            this.butAllDelete.Size = new System.Drawing.Size(157, 40);
            this.butAllDelete.TabIndex = 6;
            this.butAllDelete.Text = "Очистить дерево";
            this.butAllDelete.UseVisualStyleBackColor = true;
            this.butAllDelete.Click += new System.EventHandler(this.butAllDelete_Click);
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCancel.Location = new System.Drawing.Point(671, 427);
            this.butCancel.MinimumSize = new System.Drawing.Size(110, 27);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(110, 40);
            this.butCancel.TabIndex = 12;
            this.butCancel.Text = "Отмена";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // treRouteTree
            // 
            this.treRouteTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treRouteTree.ImageIndex = 0;
            this.treRouteTree.Location = new System.Drawing.Point(246, 77);
            this.treRouteTree.Name = "treRouteTree";
            this.treRouteTree.SelectedImageIndex = 0;
            this.treRouteTree.Size = new System.Drawing.Size(535, 330);
            this.treRouteTree.TabIndex = 10;
            // 
            // chkUseLastSetting
            // 
            this.chkUseLastSetting.AutoSize = true;
            this.chkUseLastSetting.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkUseLastSetting.Location = new System.Drawing.Point(18, 62);
            this.chkUseLastSetting.Name = "chkUseLastSetting";
            this.chkUseLastSetting.Size = new System.Drawing.Size(157, 17);
            this.chkUseLastSetting.TabIndex = 14;
            this.chkUseLastSetting.Text = "запоминать настройку";
            this.chkUseLastSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkUseLastSetting.UseVisualStyleBackColor = true;
            // 
            // picButUp
            // 
            this.picButUp.BackColor = System.Drawing.Color.Transparent;
            this.picButUp.Image = global::ManagerDS360.Properties.Resources.Стрелка_вверх1;
            this.picButUp.Location = new System.Drawing.Point(204, 184);
            this.picButUp.Name = "picButUp";
            this.picButUp.Size = new System.Drawing.Size(35, 35);
            this.picButUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picButUp.TabIndex = 15;
            this.picButUp.TabStop = false;
            this.picButUp.Click += new System.EventHandler(this.picButUp_Click);
            this.picButUp.MouseEnter += new System.EventHandler(this.picButUp_MouseEnter);
            this.picButUp.MouseLeave += new System.EventHandler(this.picButUp_MouseLeave);
            // 
            // picButDown
            // 
            this.picButDown.BackColor = System.Drawing.Color.Transparent;
            this.picButDown.Image = global::ManagerDS360.Properties.Resources.Стрелка_вниз1;
            this.picButDown.Location = new System.Drawing.Point(204, 248);
            this.picButDown.Name = "picButDown";
            this.picButDown.Size = new System.Drawing.Size(35, 35);
            this.picButDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picButDown.TabIndex = 15;
            this.picButDown.TabStop = false;
            this.picButDown.Click += new System.EventHandler(this.picButDown_Click);
            this.picButDown.MouseEnter += new System.EventHandler(this.picButDown_MouseEnter);
            this.picButDown.MouseLeave += new System.EventHandler(this.picButDown_MouseLeave);
            // 
            // butCpopy
            // 
            this.butCpopy.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCpopy.Location = new System.Drawing.Point(18, 215);
            this.butCpopy.Name = "butCpopy";
            this.butCpopy.Size = new System.Drawing.Size(157, 40);
            this.butCpopy.TabIndex = 4;
            this.butCpopy.Text = "Копировать узел";
            this.butCpopy.UseVisualStyleBackColor = true;
            this.butCpopy.Click += new System.EventHandler(this.butCpopy_Click);
            // 
            // butPaste
            // 
            this.butPaste.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butPaste.Location = new System.Drawing.Point(18, 261);
            this.butPaste.Name = "butPaste";
            this.butPaste.Size = new System.Drawing.Size(157, 40);
            this.butPaste.TabIndex = 4;
            this.butPaste.Text = "Вставить узел";
            this.butPaste.UseVisualStyleBackColor = true;
            this.butPaste.Click += new System.EventHandler(this.butPaste_Click);
            // 
            // frmCreationEditingRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 485);
            this.Controls.Add(this.picButDown);
            this.Controls.Add(this.picButUp);
            this.Controls.Add(this.treRouteTree);
            this.Controls.Add(this.butAllDelete);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butPaste);
            this.Controls.Add(this.butCpopy);
            this.Controls.Add(this.butEditSetting);
            this.Controls.Add(this.butAddSetting);
            this.Controls.Add(this.butAddFolder);
            this.Controls.Add(this.lblRouteTree);
            this.Controls.Add(this.lblRouteName);
            this.Controls.Add(this.txtNameRoute);
            this.Controls.Add(this.chkUseLastSetting);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 519);
            this.Name = "frmCreationEditingRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание и редактирование маршрута";
            this.Load += new System.EventHandler(this.frmCreationEditingRoute_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picButUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picButDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtNameRoute;
        internal System.Windows.Forms.Label lblRouteName;
        internal System.Windows.Forms.Label lblRouteTree;
        internal System.Windows.Forms.Button butAddFolder;
        internal System.Windows.Forms.Button butAddSetting;
        internal System.Windows.Forms.Button butEditSetting;
        internal System.Windows.Forms.Button butDelete;
        internal System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butAllDelete;
        internal System.Windows.Forms.Button butCancel;
        public LibControls.TreeViewWithSetting treRouteTree;
        private System.Windows.Forms.CheckBox chkUseLastSetting;
        private System.Windows.Forms.PictureBox picButUp;
        private System.Windows.Forms.PictureBox picButDown;
        internal System.Windows.Forms.Button butCpopy;
        internal System.Windows.Forms.Button butPaste;
    }
}
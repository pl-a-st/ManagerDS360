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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreationEditingRoute));
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
            this.chkUseLastSetting = new System.Windows.Forms.CheckBox();
            this.butCopy = new System.Windows.Forms.Button();
            this.butPaste = new System.Windows.Forms.Button();
            this.treRouteTree = new LibControls.TreeViewWithSetting();
            this.butDown = new LibControls.ButtonForPicture();
            this.butUp = new LibControls.ButtonForPicture();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txtNameRoute
            // 
            this.txtNameRoute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameRoute.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtNameRoute.Location = new System.Drawing.Point(18, 26);
            this.txtNameRoute.Name = "txtNameRoute";
            this.txtNameRoute.Size = new System.Drawing.Size(536, 22);
            this.txtNameRoute.TabIndex = 1;
            this.txtNameRoute.TextChanged += new System.EventHandler(this.txtNameRoute_TextChanged);
            this.txtNameRoute.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
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
            this.lblRouteTree.Location = new System.Drawing.Point(15, 59);
            this.lblRouteTree.Name = "lblRouteTree";
            this.lblRouteTree.Size = new System.Drawing.Size(124, 14);
            this.lblRouteTree.TabIndex = 9;
            this.lblRouteTree.Text = "Дерево маршрута";
            this.lblRouteTree.Click += new System.EventHandler(this.lblRouteTree_Click);
            // 
            // butAddFolder
            // 
            this.butAddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddFolder.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAddFolder.Location = new System.Drawing.Point(619, 136);
            this.butAddFolder.Name = "butAddFolder";
            this.butAddFolder.Size = new System.Drawing.Size(157, 40);
            this.butAddFolder.TabIndex = 5;
            this.butAddFolder.Text = "Добавить папку";
            this.butAddFolder.UseVisualStyleBackColor = true;
            this.butAddFolder.Click += new System.EventHandler(this.butAddFolder_Click);
            // 
            // butAddSetting
            // 
            this.butAddSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddSetting.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAddSetting.Location = new System.Drawing.Point(619, 90);
            this.butAddSetting.Name = "butAddSetting";
            this.butAddSetting.Size = new System.Drawing.Size(157, 40);
            this.butAddSetting.TabIndex = 4;
            this.butAddSetting.Text = "Добавить настройку";
            this.butAddSetting.UseVisualStyleBackColor = true;
            this.butAddSetting.Click += new System.EventHandler(this.butAddSetting_Click);
            this.butAddSetting.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // butEditSetting
            // 
            this.butEditSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butEditSetting.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butEditSetting.Location = new System.Drawing.Point(619, 209);
            this.butEditSetting.Name = "butEditSetting";
            this.butEditSetting.Size = new System.Drawing.Size(157, 40);
            this.butEditSetting.TabIndex = 6;
            this.butEditSetting.Text = "Редактировать узел";
            this.butEditSetting.UseVisualStyleBackColor = true;
            this.butEditSetting.Click += new System.EventHandler(this.butEditSetting_Click);
            // 
            // butDelete
            // 
            this.butDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butDelete.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butDelete.Location = new System.Drawing.Point(619, 377);
            this.butDelete.MinimumSize = new System.Drawing.Size(110, 27);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(157, 40);
            this.butDelete.TabIndex = 9;
            this.butDelete.Text = "Удалить узел";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSave.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butSave.Location = new System.Drawing.Point(18, 477);
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
            this.butAllDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butAllDelete.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAllDelete.Location = new System.Drawing.Point(619, 423);
            this.butAllDelete.Name = "butAllDelete";
            this.butAllDelete.Size = new System.Drawing.Size(157, 40);
            this.butAllDelete.TabIndex = 10;
            this.butAllDelete.Text = "Очистить дерево";
            this.butAllDelete.UseVisualStyleBackColor = true;
            this.butAllDelete.Click += new System.EventHandler(this.butAllDelete_Click);
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCancel.Location = new System.Drawing.Point(444, 477);
            this.butCancel.MinimumSize = new System.Drawing.Size(110, 27);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(110, 40);
            this.butCancel.TabIndex = 12;
            this.butCancel.Text = "Отмена";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // chkUseLastSetting
            // 
            this.chkUseLastSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUseLastSetting.AutoSize = true;
            this.chkUseLastSetting.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkUseLastSetting.Location = new System.Drawing.Point(619, 75);
            this.chkUseLastSetting.Name = "chkUseLastSetting";
            this.chkUseLastSetting.Size = new System.Drawing.Size(157, 17);
            this.chkUseLastSetting.TabIndex = 3;
            this.chkUseLastSetting.Text = "запоминать настройку";
            this.chkUseLastSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkUseLastSetting.UseVisualStyleBackColor = true;
            // 
            // butCopy
            // 
            this.butCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butCopy.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCopy.Location = new System.Drawing.Point(619, 255);
            this.butCopy.Name = "butCopy";
            this.butCopy.Size = new System.Drawing.Size(157, 40);
            this.butCopy.TabIndex = 7;
            this.butCopy.Text = "Копировать узел";
            this.butCopy.UseVisualStyleBackColor = true;
            this.butCopy.Click += new System.EventHandler(this.butCopy_Click);
            // 
            // butPaste
            // 
            this.butPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPaste.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butPaste.Location = new System.Drawing.Point(619, 301);
            this.butPaste.Name = "butPaste";
            this.butPaste.Size = new System.Drawing.Size(157, 40);
            this.butPaste.TabIndex = 8;
            this.butPaste.Text = "Вставить узел";
            this.butPaste.UseVisualStyleBackColor = true;
            this.butPaste.Click += new System.EventHandler(this.butPaste_Click);
            // 
            // treRouteTree
            // 
            this.treRouteTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treRouteTree.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treRouteTree.ImageIndex = 0;
            this.treRouteTree.Location = new System.Drawing.Point(18, 76);
            this.treRouteTree.Name = "treRouteTree";
            this.treRouteTree.SelectedImageIndex = 0;
            this.treRouteTree.Size = new System.Drawing.Size(536, 387);
            this.treRouteTree.TabIndex = 2;
            // 
            // butDown
            // 
            this.butDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butDown.BackColor = System.Drawing.Color.Transparent;
            this.butDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("butDown.BackgroundImage")));
            this.butDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butDown.FlatAppearance.BorderSize = 0;
            this.butDown.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDown.Location = new System.Drawing.Point(560, 301);
            this.butDown.Name = "butDown";
            this.butDown.Size = new System.Drawing.Size(33, 39);
            this.butDown.TabIndex = 14;
            this.butDown.UseVisualStyleBackColor = false;
            this.butDown.Click += new System.EventHandler(this.butDown_Click_1);
            this.butDown.MouseEnter += new System.EventHandler(this.butDown_MouseEnter);
            this.butDown.MouseLeave += new System.EventHandler(this.butDown_MouseLeave);
            // 
            // butUp
            // 
            this.butUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butUp.BackColor = System.Drawing.Color.Transparent;
            this.butUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("butUp.BackgroundImage")));
            this.butUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butUp.FlatAppearance.BorderSize = 0;
            this.butUp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butUp.Location = new System.Drawing.Point(560, 210);
            this.butUp.Name = "butUp";
            this.butUp.Size = new System.Drawing.Size(33, 39);
            this.butUp.TabIndex = 13;
            this.butUp.UseVisualStyleBackColor = false;
            this.butUp.Click += new System.EventHandler(this.butUp_Click_1);
            this.butUp.MouseEnter += new System.EventHandler(this.butUp_MouseEnter);
            this.butUp.MouseLeave += new System.EventHandler(this.butUp_MouseLeave);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "тест";
            // 
            // frmCreationEditingRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.butDown);
            this.Controls.Add(this.butUp);
            this.Controls.Add(this.treRouteTree);
            this.Controls.Add(this.butAllDelete);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butPaste);
            this.Controls.Add(this.butCopy);
            this.Controls.Add(this.butEditSetting);
            this.Controls.Add(this.butAddSetting);
            this.Controls.Add(this.butAddFolder);
            this.Controls.Add(this.lblRouteTree);
            this.Controls.Add(this.lblRouteName);
            this.Controls.Add(this.txtNameRoute);
            this.Controls.Add(this.chkUseLastSetting);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(816, 519);
            this.Name = "frmCreationEditingRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание и редактирование маршрута";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCreationEditingRoute_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCreationEditingRoute_FormClosed);
            this.Load += new System.EventHandler(this.frmCreationEditingRoute_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
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
        internal System.Windows.Forms.Button butCopy;
        internal System.Windows.Forms.Button butPaste;
        private LibControls.ButtonForPicture butDown;
        private LibControls.ButtonForPicture butUp;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
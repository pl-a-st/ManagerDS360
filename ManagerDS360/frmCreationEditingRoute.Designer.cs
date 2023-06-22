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
            this.butUp = new System.Windows.Forms.Button();
            this.butDown = new System.Windows.Forms.Button();
            this.butAllDelete = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.treRouteTree = new LibControls.TreeViewWithSetting();
            this.chkUseLastSetting = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtNameRoute
            // 
            this.txtNameRoute.Location = new System.Drawing.Point(19, 40);
            this.txtNameRoute.Name = "txtNameRoute";
            this.txtNameRoute.Size = new System.Drawing.Size(268, 20);
            this.txtNameRoute.TabIndex = 0;
            this.txtNameRoute.TextChanged += new System.EventHandler(this.txtNameRoute_TextChanged);
            // 
            // lblRouteName
            // 
            this.lblRouteName.AutoSize = true;
            this.lblRouteName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRouteName.Location = new System.Drawing.Point(16, 23);
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
            this.lblRouteTree.Location = new System.Drawing.Point(296, 23);
            this.lblRouteTree.Name = "lblRouteTree";
            this.lblRouteTree.Size = new System.Drawing.Size(124, 14);
            this.lblRouteTree.TabIndex = 9;
            this.lblRouteTree.Text = "Дерево маршрута";
            this.lblRouteTree.Click += new System.EventHandler(this.lblRouteTree_Click);
            // 
            // butAddFolder
            // 
            this.butAddFolder.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAddFolder.Location = new System.Drawing.Point(41, 172);
            this.butAddFolder.Name = "butAddFolder";
            this.butAddFolder.Size = new System.Drawing.Size(144, 40);
            this.butAddFolder.TabIndex = 3;
            this.butAddFolder.Text = "Добавить папку";
            this.butAddFolder.UseVisualStyleBackColor = true;
            this.butAddFolder.Click += new System.EventHandler(this.butAddFolder_Click);
            // 
            // butAddSetting
            // 
            this.butAddSetting.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAddSetting.Location = new System.Drawing.Point(41, 101);
            this.butAddSetting.Name = "butAddSetting";
            this.butAddSetting.Size = new System.Drawing.Size(144, 42);
            this.butAddSetting.TabIndex = 2;
            this.butAddSetting.Text = "Добавить настройку";
            this.butAddSetting.UseVisualStyleBackColor = true;
            this.butAddSetting.Click += new System.EventHandler(this.butAddSetting_Click);
            // 
            // butEditSetting
            // 
            this.butEditSetting.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butEditSetting.Location = new System.Drawing.Point(41, 234);
            this.butEditSetting.Name = "butEditSetting";
            this.butEditSetting.Size = new System.Drawing.Size(144, 40);
            this.butEditSetting.TabIndex = 4;
            this.butEditSetting.Text = "Редактировать узел";
            this.butEditSetting.UseVisualStyleBackColor = true;
            this.butEditSetting.Click += new System.EventHandler(this.butEditSetting_Click);
            // 
            // butDelete
            // 
            this.butDelete.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butDelete.Location = new System.Drawing.Point(41, 331);
            this.butDelete.MinimumSize = new System.Drawing.Size(110, 27);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(144, 40);
            this.butDelete.TabIndex = 5;
            this.butDelete.Text = "Удалить узел";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSave.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butSave.Location = new System.Drawing.Point(299, 414);
            this.butSave.MaximumSize = new System.Drawing.Size(110, 27);
            this.butSave.MinimumSize = new System.Drawing.Size(110, 27);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(110, 27);
            this.butSave.TabIndex = 11;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butUp
            // 
            this.butUp.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butUp.Location = new System.Drawing.Point(226, 171);
            this.butUp.Name = "butUp";
            this.butUp.Size = new System.Drawing.Size(63, 33);
            this.butUp.TabIndex = 7;
            this.butUp.Text = "Вверх";
            this.butUp.UseVisualStyleBackColor = true;
            this.butUp.Click += new System.EventHandler(this.butUp_Click);
            // 
            // butDown
            // 
            this.butDown.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butDown.Location = new System.Drawing.Point(226, 226);
            this.butDown.Name = "butDown";
            this.butDown.Size = new System.Drawing.Size(63, 33);
            this.butDown.TabIndex = 8;
            this.butDown.Text = "Вниз";
            this.butDown.UseVisualStyleBackColor = true;
            this.butDown.Click += new System.EventHandler(this.butDown_Click);
            // 
            // butAllDelete
            // 
            this.butAllDelete.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAllDelete.Location = new System.Drawing.Point(41, 377);
            this.butAllDelete.Name = "butAllDelete";
            this.butAllDelete.Size = new System.Drawing.Size(144, 40);
            this.butAllDelete.TabIndex = 6;
            this.butAllDelete.Text = "Очистить дерево";
            this.butAllDelete.UseVisualStyleBackColor = true;
            this.butAllDelete.Click += new System.EventHandler(this.butAllDelete_Click);
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCancel.Location = new System.Drawing.Point(718, 414);
            this.butCancel.MaximumSize = new System.Drawing.Size(110, 27);
            this.butCancel.MinimumSize = new System.Drawing.Size(110, 27);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(110, 27);
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
            this.treRouteTree.Location = new System.Drawing.Point(299, 42);
            this.treRouteTree.Name = "treRouteTree";
            this.treRouteTree.SelectedImageIndex = 0;
            this.treRouteTree.Size = new System.Drawing.Size(529, 366);
            this.treRouteTree.TabIndex = 10;
            // 
            // chkUseLastSetting
            // 
            this.chkUseLastSetting.AutoSize = true;
            this.chkUseLastSetting.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkUseLastSetting.Location = new System.Drawing.Point(19, 66);
            this.chkUseLastSetting.Name = "chkUseLastSetting";
            this.chkUseLastSetting.Size = new System.Drawing.Size(182, 32);
            this.chkUseLastSetting.TabIndex = 14;
            this.chkUseLastSetting.Text = "Брать значения\r\nпредыдущей настройки";
            this.chkUseLastSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkUseLastSetting.UseVisualStyleBackColor = true;
            // 
            // frmCreationEditingRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 480);
            this.Controls.Add(this.treRouteTree);
            this.Controls.Add(this.butAllDelete);
            this.Controls.Add(this.butDown);
            this.Controls.Add(this.butUp);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.butDelete);
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
        internal System.Windows.Forms.Button butUp;
        internal System.Windows.Forms.Button butDown;
        private System.Windows.Forms.Button butAllDelete;
        internal System.Windows.Forms.Button butCancel;
        public LibControls.TreeViewWithSetting treRouteTree;
        private System.Windows.Forms.CheckBox chkUseLastSetting;
    }
}
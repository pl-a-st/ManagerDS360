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
            this.lblSave = new System.Windows.Forms.Label();
            this.lblSaveRoute = new System.Windows.Forms.Label();
            this.butAllDelete = new System.Windows.Forms.Button();
            this.treRouteTree = new LibControls.TreeViewWithSetting();
            this.butCancel = new System.Windows.Forms.Button();
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
            this.lblRouteName.Location = new System.Drawing.Point(19, 26);
            this.lblRouteName.Name = "lblRouteName";
            this.lblRouteName.Size = new System.Drawing.Size(110, 13);
            this.lblRouteName.TabIndex = 1;
            this.lblRouteName.Text = "Название маршрута";
            this.lblRouteName.Click += new System.EventHandler(this.lblRouteName_Click);
            // 
            // lblRouteTree
            // 
            this.lblRouteTree.AutoSize = true;
            this.lblRouteTree.Location = new System.Drawing.Point(296, 26);
            this.lblRouteTree.Name = "lblRouteTree";
            this.lblRouteTree.Size = new System.Drawing.Size(99, 13);
            this.lblRouteTree.TabIndex = 3;
            this.lblRouteTree.Text = "Дерево маршрута";
            this.lblRouteTree.Click += new System.EventHandler(this.lblRouteTree_Click);
            // 
            // butAddFolder
            // 
            this.butAddFolder.Location = new System.Drawing.Point(19, 164);
            this.butAddFolder.Name = "butAddFolder";
            this.butAddFolder.Size = new System.Drawing.Size(144, 40);
            this.butAddFolder.TabIndex = 4;
            this.butAddFolder.Text = "Добавить папку";
            this.butAddFolder.UseVisualStyleBackColor = true;
            this.butAddFolder.Click += new System.EventHandler(this.butAddFolder_Click);
            // 
            // butAddSetting
            // 
            this.butAddSetting.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAddSetting.Location = new System.Drawing.Point(19, 94);
            this.butAddSetting.Name = "butAddSetting";
            this.butAddSetting.Size = new System.Drawing.Size(144, 42);
            this.butAddSetting.TabIndex = 5;
            this.butAddSetting.Text = "Добавить настройку";
            this.butAddSetting.UseVisualStyleBackColor = true;
            this.butAddSetting.Click += new System.EventHandler(this.butAddSetting_Click);
            // 
            // butEditSetting
            // 
            this.butEditSetting.Location = new System.Drawing.Point(19, 226);
            this.butEditSetting.Name = "butEditSetting";
            this.butEditSetting.Size = new System.Drawing.Size(144, 40);
            this.butEditSetting.TabIndex = 6;
            this.butEditSetting.Text = "Редактировать узел";
            this.butEditSetting.UseVisualStyleBackColor = true;
            this.butEditSetting.Click += new System.EventHandler(this.butEditSetting_Click);
            // 
            // butDelete
            // 
            this.butDelete.Location = new System.Drawing.Point(19, 323);
            this.butDelete.MinimumSize = new System.Drawing.Size(110, 27);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(144, 40);
            this.butDelete.TabIndex = 7;
            this.butDelete.Text = "Удалить узел";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSave.Location = new System.Drawing.Point(299, 414);
            this.butSave.MaximumSize = new System.Drawing.Size(110, 27);
            this.butSave.MinimumSize = new System.Drawing.Size(110, 27);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(110, 27);
            this.butSave.TabIndex = 8;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butUp
            // 
            this.butUp.Location = new System.Drawing.Point(202, 151);
            this.butUp.Name = "butUp";
            this.butUp.Size = new System.Drawing.Size(85, 33);
            this.butUp.TabIndex = 9;
            this.butUp.Text = "Вверх";
            this.butUp.UseVisualStyleBackColor = true;
            this.butUp.Click += new System.EventHandler(this.butUp_Click);
            // 
            // butDown
            // 
            this.butDown.Location = new System.Drawing.Point(202, 226);
            this.butDown.Name = "butDown";
            this.butDown.Size = new System.Drawing.Size(85, 33);
            this.butDown.TabIndex = 10;
            this.butDown.Text = "Вниз";
            this.butDown.UseVisualStyleBackColor = true;
            this.butDown.Click += new System.EventHandler(this.butDown_Click);
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.BackColor = System.Drawing.SystemColors.Menu;
            this.lblSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSave.ForeColor = System.Drawing.Color.Green;
            this.lblSave.Location = new System.Drawing.Point(50, 139);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(70, 13);
            this.lblSave.TabIndex = 12;
            this.lblSave.Text = "Сохранено";
            this.lblSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSave.Visible = false;
            this.lblSave.Click += new System.EventHandler(this.lblSave_Click);
            // 
            // lblSaveRoute
            // 
            this.lblSaveRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSaveRoute.AutoSize = true;
            this.lblSaveRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSaveRoute.ForeColor = System.Drawing.Color.Green;
            this.lblSaveRoute.Location = new System.Drawing.Point(315, 444);
            this.lblSaveRoute.Name = "lblSaveRoute";
            this.lblSaveRoute.Size = new System.Drawing.Size(70, 13);
            this.lblSaveRoute.TabIndex = 13;
            this.lblSaveRoute.Text = "Сохранено";
            this.lblSaveRoute.Visible = false;
            // 
            // butAllDelete
            // 
            this.butAllDelete.Location = new System.Drawing.Point(19, 369);
            this.butAllDelete.Name = "butAllDelete";
            this.butAllDelete.Size = new System.Drawing.Size(144, 40);
            this.butAllDelete.TabIndex = 14;
            this.butAllDelete.Text = "Очистить дерево";
            this.butAllDelete.UseVisualStyleBackColor = true;
            this.butAllDelete.Click += new System.EventHandler(this.butAllDelete_Click);
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
            this.treRouteTree.TabIndex = 15;
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.Location = new System.Drawing.Point(718, 414);
            this.butCancel.MaximumSize = new System.Drawing.Size(110, 27);
            this.butCancel.MinimumSize = new System.Drawing.Size(110, 27);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(110, 27);
            this.butCancel.TabIndex = 8;
            this.butCancel.Text = "Отмена";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // frmCreationEditingRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 480);
            this.Controls.Add(this.treRouteTree);
            this.Controls.Add(this.butAllDelete);
            this.Controls.Add(this.lblSaveRoute);
            this.Controls.Add(this.lblSave);
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
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 519);
            this.Name = "frmCreationEditingRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Окно создания и редактирования маршрута";
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
        internal System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.Label lblSaveRoute;
        private System.Windows.Forms.Button butAllDelete;
        private LibControls.TreeViewWithSetting treRouteTree;
        internal System.Windows.Forms.Button butCancel;
    }
}
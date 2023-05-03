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
            this.treRouteTree = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // txtNameRoute
            // 
            this.txtNameRoute.Location = new System.Drawing.Point(12, 40);
            this.txtNameRoute.Name = "txtNameRoute";
            this.txtNameRoute.Size = new System.Drawing.Size(222, 20);
            this.txtNameRoute.TabIndex = 0;
            this.txtNameRoute.TextChanged += new System.EventHandler(this.txtNameRoute_TextChanged);
            // 
            // lblRouteName
            // 
            this.lblRouteName.AutoSize = true;
            this.lblRouteName.Location = new System.Drawing.Point(12, 26);
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
            this.butAddFolder.Location = new System.Drawing.Point(12, 97);
            this.butAddFolder.Name = "butAddFolder";
            this.butAddFolder.Size = new System.Drawing.Size(144, 42);
            this.butAddFolder.TabIndex = 4;
            this.butAddFolder.Text = "Добавить папку";
            this.butAddFolder.UseVisualStyleBackColor = true;
            this.butAddFolder.Click += new System.EventHandler(this.butAddFolder_Click);
            // 
            // butAddSetting
            // 
            this.butAddSetting.Location = new System.Drawing.Point(12, 145);
            this.butAddSetting.Name = "butAddSetting";
            this.butAddSetting.Size = new System.Drawing.Size(144, 42);
            this.butAddSetting.TabIndex = 5;
            this.butAddSetting.Text = "Добавить настройку";
            this.butAddSetting.UseVisualStyleBackColor = true;
            this.butAddSetting.Click += new System.EventHandler(this.butAddSetting_Click);
            // 
            // butEditSetting
            // 
            this.butEditSetting.Location = new System.Drawing.Point(12, 234);
            this.butEditSetting.Name = "butEditSetting";
            this.butEditSetting.Size = new System.Drawing.Size(144, 42);
            this.butEditSetting.TabIndex = 6;
            this.butEditSetting.Text = "Редактировать настройку";
            this.butEditSetting.UseVisualStyleBackColor = true;
            this.butEditSetting.Click += new System.EventHandler(this.butEditSetting_Click);
            // 
            // butDelete
            // 
            this.butDelete.Location = new System.Drawing.Point(635, 333);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(96, 25);
            this.butDelete.TabIndex = 7;
            this.butDelete.Text = "Удалить";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(295, 333);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(96, 25);
            this.butSave.TabIndex = 8;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butUp
            // 
            this.butUp.Location = new System.Drawing.Point(204, 115);
            this.butUp.Name = "butUp";
            this.butUp.Size = new System.Drawing.Size(85, 33);
            this.butUp.TabIndex = 9;
            this.butUp.Text = "Вверх";
            this.butUp.UseVisualStyleBackColor = true;
            this.butUp.Click += new System.EventHandler(this.butUp_Click);
            // 
            // butDown
            // 
            this.butDown.Location = new System.Drawing.Point(204, 190);
            this.butDown.Name = "butDown";
            this.butDown.Size = new System.Drawing.Size(85, 33);
            this.butDown.TabIndex = 10;
            this.butDown.Text = "Вниз";
            this.butDown.UseVisualStyleBackColor = true;
            this.butDown.Click += new System.EventHandler(this.butDown_Click);
            // 
            // treRouteTree
            // 
            this.treRouteTree.CheckBoxes = true;
            this.treRouteTree.Location = new System.Drawing.Point(295, 42);
            this.treRouteTree.Name = "treRouteTree";
            this.treRouteTree.Size = new System.Drawing.Size(436, 274);
            this.treRouteTree.TabIndex = 11;
            this.treRouteTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treRouteTree_AfterSelect);
            // 
            // frmCreationEditingRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treRouteTree);
            this.Controls.Add(this.butDown);
            this.Controls.Add(this.butUp);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butEditSetting);
            this.Controls.Add(this.butAddSetting);
            this.Controls.Add(this.butAddFolder);
            this.Controls.Add(this.lblRouteTree);
            this.Controls.Add(this.lblRouteName);
            this.Controls.Add(this.txtNameRoute);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "frmCreationEditingRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Окно создания и редактирования маршрута";
            this.Load += new System.EventHandler(this.frmCreationEditingRoute_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNameRoute;
        private System.Windows.Forms.Label lblRouteName;
        private System.Windows.Forms.Label lblRouteTree;
        private System.Windows.Forms.Button butAddFolder;
        private System.Windows.Forms.Button butAddSetting;
        private System.Windows.Forms.Button butEditSetting;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butUp;
        private System.Windows.Forms.Button butDown;
        private System.Windows.Forms.TreeView treRouteTree;
    }
}
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
            this.lstRouteTree = new System.Windows.Forms.ListBox();
            this.lblRouteTree = new System.Windows.Forms.Label();
            this.butAddFolder = new System.Windows.Forms.Button();
            this.butAddSetting = new System.Windows.Forms.Button();
            this.butEditSetting = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.butUp = new System.Windows.Forms.Button();
            this.butDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNameRoute
            // 
            this.txtNameRoute.Location = new System.Drawing.Point(12, 40);
            this.txtNameRoute.Name = "txtNameRoute";
            this.txtNameRoute.Size = new System.Drawing.Size(222, 20);
            this.txtNameRoute.TabIndex = 0;
            // 
            // lblRouteName
            // 
            this.lblRouteName.AutoSize = true;
            this.lblRouteName.Location = new System.Drawing.Point(25, 24);
            this.lblRouteName.Name = "lblRouteName";
            this.lblRouteName.Size = new System.Drawing.Size(110, 13);
            this.lblRouteName.TabIndex = 1;
            this.lblRouteName.Text = "Название маршрута";
            // 
            // lstRouteTree
            // 
            this.lstRouteTree.FormattingEnabled = true;
            this.lstRouteTree.Location = new System.Drawing.Point(295, 42);
            this.lstRouteTree.Name = "lstRouteTree";
            this.lstRouteTree.Size = new System.Drawing.Size(376, 264);
            this.lstRouteTree.TabIndex = 2;
            // 
            // lblRouteTree
            // 
            this.lblRouteTree.AutoSize = true;
            this.lblRouteTree.Location = new System.Drawing.Point(296, 26);
            this.lblRouteTree.Name = "lblRouteTree";
            this.lblRouteTree.Size = new System.Drawing.Size(99, 13);
            this.lblRouteTree.TabIndex = 3;
            this.lblRouteTree.Text = "Дерево маршрута";
            // 
            // butAddFolder
            // 
            this.butAddFolder.Location = new System.Drawing.Point(12, 97);
            this.butAddFolder.Name = "butAddFolder";
            this.butAddFolder.Size = new System.Drawing.Size(144, 42);
            this.butAddFolder.TabIndex = 4;
            this.butAddFolder.Text = "Добавить папку";
            this.butAddFolder.UseVisualStyleBackColor = true;
            // 
            // butAddSetting
            // 
            this.butAddSetting.Location = new System.Drawing.Point(12, 190);
            this.butAddSetting.Name = "butAddSetting";
            this.butAddSetting.Size = new System.Drawing.Size(144, 42);
            this.butAddSetting.TabIndex = 5;
            this.butAddSetting.Text = "Добавить настройку";
            this.butAddSetting.UseVisualStyleBackColor = true;
            // 
            // butEditSetting
            // 
            this.butEditSetting.Location = new System.Drawing.Point(12, 305);
            this.butEditSetting.Name = "butEditSetting";
            this.butEditSetting.Size = new System.Drawing.Size(144, 42);
            this.butEditSetting.TabIndex = 6;
            this.butEditSetting.Text = "Редактировать настройку";
            this.butEditSetting.UseVisualStyleBackColor = true;
            // 
            // butDelete
            // 
            this.butDelete.Location = new System.Drawing.Point(575, 322);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(96, 25);
            this.butDelete.TabIndex = 7;
            this.butDelete.Text = "Удалить";
            this.butDelete.UseVisualStyleBackColor = true;
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(295, 322);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(96, 25);
            this.butSave.TabIndex = 8;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            // 
            // butUp
            // 
            this.butUp.Location = new System.Drawing.Point(204, 115);
            this.butUp.Name = "butUp";
            this.butUp.Size = new System.Drawing.Size(85, 33);
            this.butUp.TabIndex = 9;
            this.butUp.Text = "Вверх";
            this.butUp.UseVisualStyleBackColor = true;
            // 
            // butDown
            // 
            this.butDown.Location = new System.Drawing.Point(204, 190);
            this.butDown.Name = "butDown";
            this.butDown.Size = new System.Drawing.Size(85, 33);
            this.butDown.TabIndex = 10;
            this.butDown.Text = "Вниз";
            this.butDown.UseVisualStyleBackColor = true;
            // 
            // frmCreationEditingRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 362);
            this.Controls.Add(this.butDown);
            this.Controls.Add(this.butUp);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butEditSetting);
            this.Controls.Add(this.butAddSetting);
            this.Controls.Add(this.butAddFolder);
            this.Controls.Add(this.lblRouteTree);
            this.Controls.Add(this.lstRouteTree);
            this.Controls.Add(this.lblRouteName);
            this.Controls.Add(this.txtNameRoute);
            this.Name = "frmCreationEditingRoute";
            this.Text = "frmCreationEditingRoute";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNameRoute;
        private System.Windows.Forms.Label lblRouteName;
        private System.Windows.Forms.ListBox lstRouteTree;
        private System.Windows.Forms.Label lblRouteTree;
        private System.Windows.Forms.Button butAddFolder;
        private System.Windows.Forms.Button butAddSetting;
        private System.Windows.Forms.Button butEditSetting;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butUp;
        private System.Windows.Forms.Button butDown;
    }
}
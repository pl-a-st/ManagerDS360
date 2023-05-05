namespace ManagerDS360
{
    partial class frmEditingRoutes
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
            this.lblSavedRoutes = new System.Windows.Forms.Label();
            this.butCreateRoutes = new System.Windows.Forms.Button();
            this.butEditingRoute = new System.Windows.Forms.Button();
            this.butUpRoute = new System.Windows.Forms.Button();
            this.butDownRoute = new System.Windows.Forms.Button();
            this.butSaveRoutes = new System.Windows.Forms.Button();
            this.butDeleteRoute = new System.Windows.Forms.Button();
            this.treSaveRoutes = new System.Windows.Forms.TreeView();
            this.lblSaveRoutes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSavedRoutes
            // 
            this.lblSavedRoutes.AutoSize = true;
            this.lblSavedRoutes.Location = new System.Drawing.Point(18, 13);
            this.lblSavedRoutes.Name = "lblSavedRoutes";
            this.lblSavedRoutes.Size = new System.Drawing.Size(130, 13);
            this.lblSavedRoutes.TabIndex = 1;
            this.lblSavedRoutes.Text = "Сохраненные маршруты";
            this.lblSavedRoutes.Click += new System.EventHandler(this.lblSavedRoutes_Click);
            // 
            // butCreateRoutes
            // 
            this.butCreateRoutes.Location = new System.Drawing.Point(391, 29);
            this.butCreateRoutes.Name = "butCreateRoutes";
            this.butCreateRoutes.Size = new System.Drawing.Size(132, 34);
            this.butCreateRoutes.TabIndex = 2;
            this.butCreateRoutes.Text = "Создать маршрут";
            this.butCreateRoutes.UseVisualStyleBackColor = true;
            this.butCreateRoutes.Click += new System.EventHandler(this.butCreateRoutes_Click);
            // 
            // butEditingRoute
            // 
            this.butEditingRoute.Location = new System.Drawing.Point(391, 74);
            this.butEditingRoute.Name = "butEditingRoute";
            this.butEditingRoute.Size = new System.Drawing.Size(132, 34);
            this.butEditingRoute.TabIndex = 3;
            this.butEditingRoute.Text = "Редактировать маршрут";
            this.butEditingRoute.UseVisualStyleBackColor = true;
            this.butEditingRoute.Click += new System.EventHandler(this.butEditingRoute_Click);
            // 
            // butUpRoute
            // 
            this.butUpRoute.Location = new System.Drawing.Point(391, 139);
            this.butUpRoute.Name = "butUpRoute";
            this.butUpRoute.Size = new System.Drawing.Size(132, 34);
            this.butUpRoute.TabIndex = 4;
            this.butUpRoute.Text = "Вверх";
            this.butUpRoute.UseVisualStyleBackColor = true;
            this.butUpRoute.Click += new System.EventHandler(this.butUpRoute_Click);
            // 
            // butDownRoute
            // 
            this.butDownRoute.Location = new System.Drawing.Point(391, 186);
            this.butDownRoute.Name = "butDownRoute";
            this.butDownRoute.Size = new System.Drawing.Size(132, 34);
            this.butDownRoute.TabIndex = 5;
            this.butDownRoute.Text = "Вниз";
            this.butDownRoute.UseVisualStyleBackColor = true;
            this.butDownRoute.Click += new System.EventHandler(this.butDownRoute_Click);
            // 
            // butSaveRoutes
            // 
            this.butSaveRoutes.Location = new System.Drawing.Point(293, 322);
            this.butSaveRoutes.Name = "butSaveRoutes";
            this.butSaveRoutes.Size = new System.Drawing.Size(79, 34);
            this.butSaveRoutes.TabIndex = 6;
            this.butSaveRoutes.Text = "Сохранить";
            this.butSaveRoutes.UseVisualStyleBackColor = true;
            this.butSaveRoutes.Click += new System.EventHandler(this.butSaveRoutes_Click);
            // 
            // butDeleteRoute
            // 
            this.butDeleteRoute.Location = new System.Drawing.Point(21, 322);
            this.butDeleteRoute.Name = "butDeleteRoute";
            this.butDeleteRoute.Size = new System.Drawing.Size(79, 34);
            this.butDeleteRoute.TabIndex = 7;
            this.butDeleteRoute.Text = "Удалить";
            this.butDeleteRoute.UseVisualStyleBackColor = true;
            this.butDeleteRoute.Click += new System.EventHandler(this.butDeleteRoute_Click);
            // 
            // treSaveRoutes
            // 
            this.treSaveRoutes.Location = new System.Drawing.Point(12, 29);
            this.treSaveRoutes.Name = "treSaveRoutes";
            this.treSaveRoutes.Size = new System.Drawing.Size(360, 266);
            this.treSaveRoutes.TabIndex = 8;
            this.treSaveRoutes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treSaveRoutes_AfterSelect);
            // 
            // lblSaveRoutes
            // 
            this.lblSaveRoutes.AutoSize = true;
            this.lblSaveRoutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSaveRoutes.ForeColor = System.Drawing.Color.Green;
            this.lblSaveRoutes.Location = new System.Drawing.Point(290, 368);
            this.lblSaveRoutes.Name = "lblSaveRoutes";
            this.lblSaveRoutes.Size = new System.Drawing.Size(77, 13);
            this.lblSaveRoutes.TabIndex = 9;
            this.lblSaveRoutes.Text = "  Сохранить";
            this.lblSaveRoutes.Visible = false;
            // 
            // frmEditingRoutes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSaveRoutes);
            this.Controls.Add(this.treSaveRoutes);
            this.Controls.Add(this.butDeleteRoute);
            this.Controls.Add(this.butSaveRoutes);
            this.Controls.Add(this.butDownRoute);
            this.Controls.Add(this.butUpRoute);
            this.Controls.Add(this.butEditingRoute);
            this.Controls.Add(this.butCreateRoutes);
            this.Controls.Add(this.lblSavedRoutes);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "frmEditingRoutes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Окно редактирования сохраненных маршрутов";
            this.Load += new System.EventHandler(this.frmEditingRoutes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSavedRoutes;
        private System.Windows.Forms.Button butCreateRoutes;
        private System.Windows.Forms.Button butEditingRoute;
        private System.Windows.Forms.Button butUpRoute;
        private System.Windows.Forms.Button butDownRoute;
        private System.Windows.Forms.Button butSaveRoutes;
        private System.Windows.Forms.Button butDeleteRoute;
        private System.Windows.Forms.TreeView treSaveRoutes;
        private System.Windows.Forms.Label lblSaveRoutes;
    }
}
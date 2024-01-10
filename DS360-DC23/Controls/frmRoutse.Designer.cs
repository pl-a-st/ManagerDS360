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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditingRoutes));
            this.lblSavedRoutes = new System.Windows.Forms.Label();
            this.butCreateRoutes = new System.Windows.Forms.Button();
            this.butEditingRoute = new System.Windows.Forms.Button();
            this.butDeleteRoute = new System.Windows.Forms.Button();
            this.lstSaveRoutes = new System.Windows.Forms.ListBox();
            this.butSearchRoute = new System.Windows.Forms.Button();
            this.butRenameRoute = new System.Windows.Forms.Button();
            this.butCopyRoute = new System.Windows.Forms.Button();
            this.butUp = new LibControls.ButtonForPicture();
            this.butDown = new LibControls.ButtonForPicture();
            this.SuspendLayout();
            // 
            // lblSavedRoutes
            // 
            this.lblSavedRoutes.AutoSize = true;
            this.lblSavedRoutes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSavedRoutes.Location = new System.Drawing.Point(10, 9);
            this.lblSavedRoutes.Name = "lblSavedRoutes";
            this.lblSavedRoutes.Size = new System.Drawing.Size(166, 14);
            this.lblSavedRoutes.TabIndex = 0;
            this.lblSavedRoutes.Text = "Сохраненные маршруты";
            this.lblSavedRoutes.Click += new System.EventHandler(this.lblSavedRoutes_Click);
            // 
            // butCreateRoutes
            // 
            this.butCreateRoutes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butCreateRoutes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCreateRoutes.Location = new System.Drawing.Point(492, 29);
            this.butCreateRoutes.Name = "butCreateRoutes";
            this.butCreateRoutes.Size = new System.Drawing.Size(154, 45);
            this.butCreateRoutes.TabIndex = 2;
            this.butCreateRoutes.Text = "Создать маршрут";
            this.butCreateRoutes.UseVisualStyleBackColor = true;
            this.butCreateRoutes.Click += new System.EventHandler(this.butCreateRoutes_Click);
            // 
            // butEditingRoute
            // 
            this.butEditingRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butEditingRoute.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butEditingRoute.Location = new System.Drawing.Point(492, 80);
            this.butEditingRoute.Name = "butEditingRoute";
            this.butEditingRoute.Size = new System.Drawing.Size(154, 45);
            this.butEditingRoute.TabIndex = 3;
            this.butEditingRoute.Text = "Редактировать маршрут";
            this.butEditingRoute.UseVisualStyleBackColor = true;
            this.butEditingRoute.Click += new System.EventHandler(this.butEditingRoute_Click);
            // 
            // butDeleteRoute
            // 
            this.butDeleteRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butDeleteRoute.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butDeleteRoute.Location = new System.Drawing.Point(492, 366);
            this.butDeleteRoute.Name = "butDeleteRoute";
            this.butDeleteRoute.Size = new System.Drawing.Size(154, 45);
            this.butDeleteRoute.TabIndex = 7;
            this.butDeleteRoute.Text = "Удалить маршрут";
            this.butDeleteRoute.UseVisualStyleBackColor = true;
            this.butDeleteRoute.Click += new System.EventHandler(this.butDeleteRoute_Click);
            // 
            // lstSaveRoutes
            // 
            this.lstSaveRoutes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSaveRoutes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstSaveRoutes.FormattingEnabled = true;
            this.lstSaveRoutes.ItemHeight = 14;
            this.lstSaveRoutes.Location = new System.Drawing.Point(14, 29);
            this.lstSaveRoutes.Name = "lstSaveRoutes";
            this.lstSaveRoutes.Size = new System.Drawing.Size(406, 382);
            this.lstSaveRoutes.TabIndex = 1;
            this.lstSaveRoutes.SelectedIndexChanged += new System.EventHandler(this.lstSaveRoutes_SelectedIndexChanged);
            this.lstSaveRoutes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // butSearchRoute
            // 
            this.butSearchRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSearchRoute.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butSearchRoute.Location = new System.Drawing.Point(492, 233);
            this.butSearchRoute.Name = "butSearchRoute";
            this.butSearchRoute.Size = new System.Drawing.Size(154, 45);
            this.butSearchRoute.TabIndex = 6;
            this.butSearchRoute.Text = "Найти  маршрут";
            this.butSearchRoute.UseVisualStyleBackColor = true;
            this.butSearchRoute.Click += new System.EventHandler(this.butSearchRoute_Click);
            // 
            // butRenameRoute
            // 
            this.butRenameRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butRenameRoute.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butRenameRoute.Location = new System.Drawing.Point(492, 131);
            this.butRenameRoute.Name = "butRenameRoute";
            this.butRenameRoute.Size = new System.Drawing.Size(154, 45);
            this.butRenameRoute.TabIndex = 4;
            this.butRenameRoute.Text = "Переименовать маршрут";
            this.butRenameRoute.UseVisualStyleBackColor = true;
            this.butRenameRoute.Click += new System.EventHandler(this.butRenameRoute_Click);
            // 
            // butCopyRoute
            // 
            this.butCopyRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butCopyRoute.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCopyRoute.Location = new System.Drawing.Point(492, 182);
            this.butCopyRoute.Name = "butCopyRoute";
            this.butCopyRoute.Size = new System.Drawing.Size(154, 45);
            this.butCopyRoute.TabIndex = 5;
            this.butCopyRoute.Text = "Копировать маршрут";
            this.butCopyRoute.UseVisualStyleBackColor = true;
            this.butCopyRoute.Click += new System.EventHandler(this.butCopyRoute_Click);
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
            this.butUp.Location = new System.Drawing.Point(428, 137);
            this.butUp.Name = "butUp";
            this.butUp.Size = new System.Drawing.Size(38, 39);
            this.butUp.TabIndex = 10;
            this.butUp.UseVisualStyleBackColor = false;
            this.butUp.Click += new System.EventHandler(this.butUp_Click);
            this.butUp.MouseEnter += new System.EventHandler(this.butUp_MouseEnter);
            this.butUp.MouseLeave += new System.EventHandler(this.butUp_MouseLeave);
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
            this.butDown.Location = new System.Drawing.Point(428, 233);
            this.butDown.Name = "butDown";
            this.butDown.Size = new System.Drawing.Size(38, 39);
            this.butDown.TabIndex = 11;
            this.butDown.UseVisualStyleBackColor = false;
            this.butDown.Click += new System.EventHandler(this.butDown_Click);
            this.butDown.MouseEnter += new System.EventHandler(this.butDown_MouseEnter);
            this.butDown.MouseLeave += new System.EventHandler(this.butDown_MouseLeave);
            // 
            // frmEditingRoutes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 453);
            this.Controls.Add(this.butDown);
            this.Controls.Add(this.butUp);
            this.Controls.Add(this.lstSaveRoutes);
            this.Controls.Add(this.butDeleteRoute);
            this.Controls.Add(this.butSearchRoute);
            this.Controls.Add(this.butCopyRoute);
            this.Controls.Add(this.butRenameRoute);
            this.Controls.Add(this.butEditingRoute);
            this.Controls.Add(this.butCreateRoutes);
            this.Controls.Add(this.lblSavedRoutes);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(683, 492);
            this.Name = "frmEditingRoutes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование сохраненных маршрутов";
            this.Load += new System.EventHandler(this.frmEditingRoutes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSavedRoutes;
        private System.Windows.Forms.Button butCreateRoutes;
        private System.Windows.Forms.Button butEditingRoute;
        private System.Windows.Forms.Button butDeleteRoute;
        private System.Windows.Forms.ListBox lstSaveRoutes;
        private System.Windows.Forms.Button butSearchRoute;
        private System.Windows.Forms.Button butRenameRoute;
        private System.Windows.Forms.Button butCopyRoute;
        private LibControls.ButtonForPicture butUp;
        private LibControls.ButtonForPicture butDown;
    }
}
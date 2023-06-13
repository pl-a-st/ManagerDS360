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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditingRoutes));
            this.lblSavedRoutes = new System.Windows.Forms.Label();
            this.butCreateRoutes = new System.Windows.Forms.Button();
            this.butEditingRoute = new System.Windows.Forms.Button();
            this.butUpRoute = new System.Windows.Forms.Button();
            this.butDownRoute = new System.Windows.Forms.Button();
            this.butSaveRoutes = new System.Windows.Forms.Button();
            this.butDeleteRoute = new System.Windows.Forms.Button();
            this.lblSaveRoutes = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lstSaveRoutes = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSavedRoutes
            // 
            this.lblSavedRoutes.AutoSize = true;
            this.lblSavedRoutes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSavedRoutes.Location = new System.Drawing.Point(18, 10);
            this.lblSavedRoutes.Name = "lblSavedRoutes";
            this.lblSavedRoutes.Size = new System.Drawing.Size(166, 14);
            this.lblSavedRoutes.TabIndex = 1;
            this.lblSavedRoutes.Text = "Сохраненные маршруты";
            this.lblSavedRoutes.Click += new System.EventHandler(this.lblSavedRoutes_Click);
            // 
            // butCreateRoutes
            // 
            this.butCreateRoutes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCreateRoutes.Location = new System.Drawing.Point(391, 29);
            this.butCreateRoutes.Name = "butCreateRoutes";
            this.butCreateRoutes.Size = new System.Drawing.Size(132, 45);
            this.butCreateRoutes.TabIndex = 2;
            this.butCreateRoutes.Text = "Создать маршрут";
            this.butCreateRoutes.UseVisualStyleBackColor = true;
            this.butCreateRoutes.Click += new System.EventHandler(this.butCreateRoutes_Click);
            // 
            // butEditingRoute
            // 
            this.butEditingRoute.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butEditingRoute.Location = new System.Drawing.Point(391, 82);
            this.butEditingRoute.Name = "butEditingRoute";
            this.butEditingRoute.Size = new System.Drawing.Size(132, 45);
            this.butEditingRoute.TabIndex = 3;
            this.butEditingRoute.Text = "Редактировать маршрут";
            this.butEditingRoute.UseVisualStyleBackColor = true;
            this.butEditingRoute.Click += new System.EventHandler(this.butEditingRoute_Click);
            // 
            // butUpRoute
            // 
            this.butUpRoute.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butUpRoute.Location = new System.Drawing.Point(391, 151);
            this.butUpRoute.Name = "butUpRoute";
            this.butUpRoute.Size = new System.Drawing.Size(132, 34);
            this.butUpRoute.TabIndex = 4;
            this.butUpRoute.Text = "Вверх";
            this.butUpRoute.UseVisualStyleBackColor = true;
            this.butUpRoute.Click += new System.EventHandler(this.butUpRoute_Click);
            // 
            // butDownRoute
            // 
            this.butDownRoute.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butDownRoute.Location = new System.Drawing.Point(391, 198);
            this.butDownRoute.Name = "butDownRoute";
            this.butDownRoute.Size = new System.Drawing.Size(132, 34);
            this.butDownRoute.TabIndex = 5;
            this.butDownRoute.Text = "Вниз";
            this.butDownRoute.UseVisualStyleBackColor = true;
            this.butDownRoute.Click += new System.EventHandler(this.butDownRoute_Click);
            // 
            // butSaveRoutes
            // 
            this.butSaveRoutes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butSaveRoutes.Location = new System.Drawing.Point(282, 373);
            this.butSaveRoutes.Name = "butSaveRoutes";
            this.butSaveRoutes.Size = new System.Drawing.Size(86, 34);
            this.butSaveRoutes.TabIndex = 6;
            this.butSaveRoutes.Text = "Сохранить";
            this.butSaveRoutes.UseVisualStyleBackColor = true;
            this.butSaveRoutes.Click += new System.EventHandler(this.butSaveRoutes_Click);
            // 
            // butDeleteRoute
            // 
            this.butDeleteRoute.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butDeleteRoute.Location = new System.Drawing.Point(17, 373);
            this.butDeleteRoute.Name = "butDeleteRoute";
            this.butDeleteRoute.Size = new System.Drawing.Size(84, 34);
            this.butDeleteRoute.TabIndex = 7;
            this.butDeleteRoute.Text = "Удалить";
            this.butDeleteRoute.UseVisualStyleBackColor = true;
            this.butDeleteRoute.Click += new System.EventHandler(this.butDeleteRoute_Click);
            // 
            // lblSaveRoutes
            // 
            this.lblSaveRoutes.AutoSize = true;
            this.lblSaveRoutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSaveRoutes.ForeColor = System.Drawing.Color.Green;
            this.lblSaveRoutes.Location = new System.Drawing.Point(291, 416);
            this.lblSaveRoutes.Name = "lblSaveRoutes";
            this.lblSaveRoutes.Size = new System.Drawing.Size(70, 13);
            this.lblSaveRoutes.TabIndex = 9;
            this.lblSaveRoutes.Text = "Сохранено";
            this.lblSaveRoutes.Visible = false;
            this.lblSaveRoutes.Click += new System.EventHandler(this.lblSaveRoutes_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(546, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(259, 378);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // lstSaveRoutes
            // 
            this.lstSaveRoutes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSaveRoutes.FormattingEnabled = true;
            this.lstSaveRoutes.Location = new System.Drawing.Point(12, 29);
            this.lstSaveRoutes.Name = "lstSaveRoutes";
            this.lstSaveRoutes.Size = new System.Drawing.Size(349, 316);
            this.lstSaveRoutes.TabIndex = 11;
            // 
            // frmEditingRoutes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstSaveRoutes);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblSaveRoutes);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label lblSaveRoutes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lstSaveRoutes;
    }
}
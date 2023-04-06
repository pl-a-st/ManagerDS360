﻿namespace ManagerDS360
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
            this.lstSaveRoutes = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butCreateRoutes = new System.Windows.Forms.Button();
            this.butEditingRoute = new System.Windows.Forms.Button();
            this.butUpRoute = new System.Windows.Forms.Button();
            this.butDownRoute = new System.Windows.Forms.Button();
            this.butSaveRoutes = new System.Windows.Forms.Button();
            this.butDeleteRoute = new System.Windows.Forms.Button();
            this.sbrHorizontalSaveRoutes = new System.Windows.Forms.HScrollBar();
            this.sbrVerticalSaveRoutes = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // lstSaveRoutes
            // 
            this.lstSaveRoutes.FormattingEnabled = true;
            this.lstSaveRoutes.Location = new System.Drawing.Point(21, 29);
            this.lstSaveRoutes.Name = "lstSaveRoutes";
            this.lstSaveRoutes.Size = new System.Drawing.Size(351, 277);
            this.lstSaveRoutes.TabIndex = 0;
            this.lstSaveRoutes.SelectedIndexChanged += new System.EventHandler(this.lstsaveroutes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Сохраненные маршруты";
            // 
            // butCreateRoutes
            // 
            this.butCreateRoutes.Location = new System.Drawing.Point(391, 29);
            this.butCreateRoutes.Name = "butCreateRoutes";
            this.butCreateRoutes.Size = new System.Drawing.Size(132, 34);
            this.butCreateRoutes.TabIndex = 2;
            this.butCreateRoutes.Text = "Создать маршрут";
            this.butCreateRoutes.UseVisualStyleBackColor = true;
            // 
            // butEditingRoute
            // 
            this.butEditingRoute.Location = new System.Drawing.Point(391, 74);
            this.butEditingRoute.Name = "butEditingRoute";
            this.butEditingRoute.Size = new System.Drawing.Size(132, 34);
            this.butEditingRoute.TabIndex = 3;
            this.butEditingRoute.Text = "Редактировать маршрут";
            this.butEditingRoute.UseVisualStyleBackColor = true;
            // 
            // butUpRoute
            // 
            this.butUpRoute.Location = new System.Drawing.Point(391, 139);
            this.butUpRoute.Name = "butUpRoute";
            this.butUpRoute.Size = new System.Drawing.Size(132, 34);
            this.butUpRoute.TabIndex = 4;
            this.butUpRoute.Text = "Вверх";
            this.butUpRoute.UseVisualStyleBackColor = true;
            this.butUpRoute.Click += new System.EventHandler(this.but_up_route_Click);
            // 
            // butDownRoute
            // 
            this.butDownRoute.Location = new System.Drawing.Point(391, 186);
            this.butDownRoute.Name = "butDownRoute";
            this.butDownRoute.Size = new System.Drawing.Size(132, 34);
            this.butDownRoute.TabIndex = 5;
            this.butDownRoute.Text = "Вниз";
            this.butDownRoute.UseVisualStyleBackColor = true;
            this.butDownRoute.Click += new System.EventHandler(this.but_down_route_Click);
            // 
            // butSaveRoutes
            // 
            this.butSaveRoutes.Location = new System.Drawing.Point(293, 322);
            this.butSaveRoutes.Name = "butSaveRoutes";
            this.butSaveRoutes.Size = new System.Drawing.Size(79, 34);
            this.butSaveRoutes.TabIndex = 6;
            this.butSaveRoutes.Text = "Сохранить";
            this.butSaveRoutes.UseVisualStyleBackColor = true;
            // 
            // butDeleteRoute
            // 
            this.butDeleteRoute.Location = new System.Drawing.Point(21, 322);
            this.butDeleteRoute.Name = "butDeleteRoute";
            this.butDeleteRoute.Size = new System.Drawing.Size(79, 34);
            this.butDeleteRoute.TabIndex = 7;
            this.butDeleteRoute.Text = "Удалить";
            this.butDeleteRoute.UseVisualStyleBackColor = true;
            // 
            // sbrHorizontalSaveRoutes
            // 
            this.sbrHorizontalSaveRoutes.Location = new System.Drawing.Point(21, 289);
            this.sbrHorizontalSaveRoutes.Name = "sbrHorizontalSaveRoutes";
            this.sbrHorizontalSaveRoutes.Size = new System.Drawing.Size(351, 17);
            this.sbrHorizontalSaveRoutes.TabIndex = 8;
            // 
            // sbrVerticalSaveRoutes
            // 
            this.sbrVerticalSaveRoutes.Location = new System.Drawing.Point(351, 29);
            this.sbrVerticalSaveRoutes.Name = "sbrVerticalSaveRoutes";
            this.sbrVerticalSaveRoutes.Size = new System.Drawing.Size(21, 260);
            this.sbrVerticalSaveRoutes.TabIndex = 9;
            // 
            // frmEditingRoutes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sbrVerticalSaveRoutes);
            this.Controls.Add(this.sbrHorizontalSaveRoutes);
            this.Controls.Add(this.butDeleteRoute);
            this.Controls.Add(this.butSaveRoutes);
            this.Controls.Add(this.butDownRoute);
            this.Controls.Add(this.butUpRoute);
            this.Controls.Add(this.butEditingRoute);
            this.Controls.Add(this.butCreateRoutes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstSaveRoutes);
            this.Name = "frmEditingRoutes";
            this.Text = "Окно редактирования сохраненных маршрутов";
            this.Load += new System.EventHandler(this.but_editing_routes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstSaveRoutes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butCreateRoutes;
        private System.Windows.Forms.Button butEditingRoute;
        private System.Windows.Forms.Button butUpRoute;
        private System.Windows.Forms.Button butDownRoute;
        private System.Windows.Forms.Button butSaveRoutes;
        private System.Windows.Forms.Button butDeleteRoute;
        private System.Windows.Forms.HScrollBar sbrHorizontalSaveRoutes;
        private System.Windows.Forms.VScrollBar sbrVerticalSaveRoutes;
    }
}
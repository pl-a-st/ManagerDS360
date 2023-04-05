namespace ManagerDS360
{
    partial class but_editing_routes
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
            this.lst_save_routes = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.create_routes = new System.Windows.Forms.Button();
            this.but_editing_route = new System.Windows.Forms.Button();
            this.but_up_route = new System.Windows.Forms.Button();
            this.but_down_route = new System.Windows.Forms.Button();
            this.but_save_routes = new System.Windows.Forms.Button();
            this.but_delete_route = new System.Windows.Forms.Button();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // lst_save_routes
            // 
            this.lst_save_routes.FormattingEnabled = true;
            this.lst_save_routes.Location = new System.Drawing.Point(21, 29);
            this.lst_save_routes.Name = "lst_save_routes";
            this.lst_save_routes.Size = new System.Drawing.Size(351, 277);
            this.lst_save_routes.TabIndex = 0;
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
            // create_routes
            // 
            this.create_routes.Location = new System.Drawing.Point(391, 29);
            this.create_routes.Name = "create_routes";
            this.create_routes.Size = new System.Drawing.Size(132, 34);
            this.create_routes.TabIndex = 2;
            this.create_routes.Text = "Создать маршрут";
            this.create_routes.UseVisualStyleBackColor = true;
            // 
            // but_editing_route
            // 
            this.but_editing_route.Location = new System.Drawing.Point(391, 74);
            this.but_editing_route.Name = "but_editing_route";
            this.but_editing_route.Size = new System.Drawing.Size(132, 34);
            this.but_editing_route.TabIndex = 3;
            this.but_editing_route.Text = "Редактировать маршрут";
            this.but_editing_route.UseVisualStyleBackColor = true;
            // 
            // but_up_route
            // 
            this.but_up_route.Location = new System.Drawing.Point(391, 139);
            this.but_up_route.Name = "but_up_route";
            this.but_up_route.Size = new System.Drawing.Size(132, 34);
            this.but_up_route.TabIndex = 4;
            this.but_up_route.Text = "Вверх";
            this.but_up_route.UseVisualStyleBackColor = true;
            this.but_up_route.Click += new System.EventHandler(this.but_up_route_Click);
            // 
            // but_down_route
            // 
            this.but_down_route.Location = new System.Drawing.Point(391, 186);
            this.but_down_route.Name = "but_down_route";
            this.but_down_route.Size = new System.Drawing.Size(132, 34);
            this.but_down_route.TabIndex = 5;
            this.but_down_route.Text = "Вниз";
            this.but_down_route.UseVisualStyleBackColor = true;
            this.but_down_route.Click += new System.EventHandler(this.but_down_route_Click);
            // 
            // but_save_routes
            // 
            this.but_save_routes.Location = new System.Drawing.Point(293, 322);
            this.but_save_routes.Name = "but_save_routes";
            this.but_save_routes.Size = new System.Drawing.Size(79, 34);
            this.but_save_routes.TabIndex = 6;
            this.but_save_routes.Text = "Сохранить";
            this.but_save_routes.UseVisualStyleBackColor = true;
            // 
            // but_delete_route
            // 
            this.but_delete_route.Location = new System.Drawing.Point(21, 322);
            this.but_delete_route.Name = "but_delete_route";
            this.but_delete_route.Size = new System.Drawing.Size(76, 34);
            this.but_delete_route.TabIndex = 7;
            this.but_delete_route.Text = "Удалить";
            this.but_delete_route.UseVisualStyleBackColor = true;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(21, 289);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(351, 17);
            this.hScrollBar1.TabIndex = 8;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(351, 29);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 260);
            this.vScrollBar1.TabIndex = 9;
            // 
            // but_editing_routes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.but_delete_route);
            this.Controls.Add(this.but_save_routes);
            this.Controls.Add(this.but_down_route);
            this.Controls.Add(this.but_up_route);
            this.Controls.Add(this.but_editing_route);
            this.Controls.Add(this.create_routes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lst_save_routes);
            this.Name = "but_editing_routes";
            this.Text = "Окно редактирования сохраненных маршрутов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_save_routes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button create_routes;
        private System.Windows.Forms.Button but_editing_route;
        private System.Windows.Forms.Button but_up_route;
        private System.Windows.Forms.Button but_down_route;
        private System.Windows.Forms.Button but_save_routes;
        private System.Windows.Forms.Button but_delete_route;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}
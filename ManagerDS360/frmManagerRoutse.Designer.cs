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
            this.lstsaveroutes = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butcreateroutes = new System.Windows.Forms.Button();
            this.buteditingroute = new System.Windows.Forms.Button();
            this.butuproute = new System.Windows.Forms.Button();
            this.butdownroute = new System.Windows.Forms.Button();
            this.butsaveroutes = new System.Windows.Forms.Button();
            this.butdeleteroute = new System.Windows.Forms.Button();
            this.sbrScrj = new System.Windows.Forms.HScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // lstsaveroutes
            // 
            this.lstsaveroutes.FormattingEnabled = true;
            this.lstsaveroutes.Location = new System.Drawing.Point(21, 29);
            this.lstsaveroutes.Name = "lstsaveroutes";
            this.lstsaveroutes.Size = new System.Drawing.Size(351, 277);
            this.lstsaveroutes.TabIndex = 0;
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
            // butcreateroutes
            // 
            this.butcreateroutes.Location = new System.Drawing.Point(391, 29);
            this.butcreateroutes.Name = "butcreateroutes";
            this.butcreateroutes.Size = new System.Drawing.Size(132, 34);
            this.butcreateroutes.TabIndex = 2;
            this.butcreateroutes.Text = "Создать маршрут";
            this.butcreateroutes.UseVisualStyleBackColor = true;
            // 
            // buteditingroute
            // 
            this.buteditingroute.Location = new System.Drawing.Point(391, 74);
            this.buteditingroute.Name = "buteditingroute";
            this.buteditingroute.Size = new System.Drawing.Size(132, 34);
            this.buteditingroute.TabIndex = 3;
            this.buteditingroute.Text = "Редактировать маршрут";
            this.buteditingroute.UseVisualStyleBackColor = true;
            // 
            // butuproute
            // 
            this.butuproute.Location = new System.Drawing.Point(391, 139);
            this.butuproute.Name = "butuproute";
            this.butuproute.Size = new System.Drawing.Size(132, 34);
            this.butuproute.TabIndex = 4;
            this.butuproute.Text = "Вверх";
            this.butuproute.UseVisualStyleBackColor = true;
            this.butuproute.Click += new System.EventHandler(this.but_up_route_Click);
            // 
            // butdownroute
            // 
            this.butdownroute.Location = new System.Drawing.Point(391, 186);
            this.butdownroute.Name = "butdownroute";
            this.butdownroute.Size = new System.Drawing.Size(132, 34);
            this.butdownroute.TabIndex = 5;
            this.butdownroute.Text = "Вниз";
            this.butdownroute.UseVisualStyleBackColor = true;
            this.butdownroute.Click += new System.EventHandler(this.but_down_route_Click);
            // 
            // butsaveroutes
            // 
            this.butsaveroutes.Location = new System.Drawing.Point(293, 322);
            this.butsaveroutes.Name = "butsaveroutes";
            this.butsaveroutes.Size = new System.Drawing.Size(79, 34);
            this.butsaveroutes.TabIndex = 6;
            this.butsaveroutes.Text = "Сохранить";
            this.butsaveroutes.UseVisualStyleBackColor = true;
            // 
            // butdeleteroute
            // 
            this.butdeleteroute.Location = new System.Drawing.Point(21, 322);
            this.butdeleteroute.Name = "butdeleteroute";
            this.butdeleteroute.Size = new System.Drawing.Size(76, 34);
            this.butdeleteroute.TabIndex = 7;
            this.butdeleteroute.Text = "Удалить";
            this.butdeleteroute.UseVisualStyleBackColor = true;
            // 
            // sbrScrj
            // 
            this.sbrScrj.Location = new System.Drawing.Point(21, 289);
            this.sbrScrj.Name = "sbrScrj";
            this.sbrScrj.Size = new System.Drawing.Size(351, 17);
            this.sbrScrj.TabIndex = 8;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(351, 29);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 260);
            this.vScrollBar1.TabIndex = 9;
            // 
            // frmEditingRoutes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.sbrScrj);
            this.Controls.Add(this.butdeleteroute);
            this.Controls.Add(this.butsaveroutes);
            this.Controls.Add(this.butdownroute);
            this.Controls.Add(this.butuproute);
            this.Controls.Add(this.buteditingroute);
            this.Controls.Add(this.butcreateroutes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstsaveroutes);
            this.Name = "frmEditingRoutes";
            this.Text = "Окно редактирования сохраненных маршрутов";
            this.Load += new System.EventHandler(this.but_editing_routes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstsaveroutes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butcreateroutes;
        private System.Windows.Forms.Button buteditingroute;
        private System.Windows.Forms.Button butuproute;
        private System.Windows.Forms.Button butdownroute;
        private System.Windows.Forms.Button butsaveroutes;
        private System.Windows.Forms.Button butdeleteroute;
        private System.Windows.Forms.HScrollBar sbrScrj;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}
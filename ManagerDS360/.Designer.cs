﻿
namespace ManagerDS360 {
    partial class frmManagerDS360 {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManagerDS360));
            this.butDefaultGenerator = new System.Windows.Forms.Button();
            this.cboSavedRoutes = new System.Windows.Forms.ComboBox();
            this.butGeneratorControl = new System.Windows.Forms.Button();
            this.treRouteTree = new LibControls.TreeViewWithSetting();
            this.picPlay = new System.Windows.Forms.PictureBox();
            this.picNext = new System.Windows.Forms.PictureBox();
            this.lblSelectedNode = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picPrevious = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеМаршрутовToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNext)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPrevious)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butDefaultGenerator
            // 
            this.butDefaultGenerator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.butDefaultGenerator.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.butDefaultGenerator.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.butDefaultGenerator.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butDefaultGenerator.Location = new System.Drawing.Point(12, 48);
            this.butDefaultGenerator.Name = "butDefaultGenerator";
            this.butDefaultGenerator.Size = new System.Drawing.Size(230, 38);
            this.butDefaultGenerator.TabIndex = 2;
            this.butDefaultGenerator.Text = "Генератор по умолчанию";
            this.butDefaultGenerator.UseVisualStyleBackColor = false;
            this.butDefaultGenerator.Click += new System.EventHandler(this.butDefaultGenerator_Click);
            // 
            // cboSavedRoutes
            // 
            this.cboSavedRoutes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSavedRoutes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSavedRoutes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboSavedRoutes.FormattingEnabled = true;
            this.cboSavedRoutes.Location = new System.Drawing.Point(255, 51);
            this.cboSavedRoutes.Name = "cboSavedRoutes";
            this.cboSavedRoutes.Size = new System.Drawing.Size(753, 22);
            this.cboSavedRoutes.TabIndex = 6;
            this.cboSavedRoutes.SelectedIndexChanged += new System.EventHandler(this.cboSavedRoutes_SelectedIndexChanged);
            this.cboSavedRoutes.Click += new System.EventHandler(this.cboSavedRoutes_Click);
            this.cboSavedRoutes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cboSavedRoutes_MouseClick);
            this.cboSavedRoutes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cboSavedRoutes_MouseDown);
            this.cboSavedRoutes.MouseEnter += new System.EventHandler(this.cboSavedRoutes_MouseEnter);
            // 
            // butGeneratorControl
            // 
            this.butGeneratorControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.butGeneratorControl.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.butGeneratorControl.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.butGeneratorControl.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butGeneratorControl.Location = new System.Drawing.Point(12, 92);
            this.butGeneratorControl.Name = "butGeneratorControl";
            this.butGeneratorControl.Size = new System.Drawing.Size(230, 38);
            this.butGeneratorControl.TabIndex = 9;
            this.butGeneratorControl.Text = "Управление генератором";
            this.butGeneratorControl.UseVisualStyleBackColor = false;
            this.butGeneratorControl.Click += new System.EventHandler(this.butGeneratorControl_Click);
            // 
            // treRouteTree
            // 
            this.treRouteTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treRouteTree.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treRouteTree.ImageIndex = 0;
            this.treRouteTree.Location = new System.Drawing.Point(255, 79);
            this.treRouteTree.Name = "treRouteTree";
            this.treRouteTree.SelectedImageIndex = 0;
            this.treRouteTree.Size = new System.Drawing.Size(753, 423);
            this.treRouteTree.TabIndex = 15;
            this.treRouteTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treRouteTree_AfterSelect);
            // 
            // picPlay
            // 
            this.picPlay.BackColor = System.Drawing.Color.Transparent;
            this.picPlay.Image = global::ManagerDS360.Properties.Resources.Play;
            this.picPlay.InitialImage = null;
            this.picPlay.Location = new System.Drawing.Point(86, 80);
            this.picPlay.Name = "picPlay";
            this.picPlay.Size = new System.Drawing.Size(54, 54);
            this.picPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPlay.TabIndex = 16;
            this.picPlay.TabStop = false;
            this.picPlay.Click += new System.EventHandler(this.pictureBox1_Click);
            this.picPlay.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.picPlay.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // picNext
            // 
            this.picNext.BackColor = System.Drawing.Color.Transparent;
            this.picNext.Image = global::ManagerDS360.Properties.Resources.следующий;
            this.picNext.Location = new System.Drawing.Point(164, 90);
            this.picNext.Name = "picNext";
            this.picNext.Size = new System.Drawing.Size(55, 36);
            this.picNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNext.TabIndex = 17;
            this.picNext.TabStop = false;
            this.picNext.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.picNext.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // lblSelectedNode
            // 
            this.lblSelectedNode.AutoSize = true;
            this.lblSelectedNode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSelectedNode.Location = new System.Drawing.Point(23, 23);
            this.lblSelectedNode.Name = "lblSelectedNode";
            this.lblSelectedNode.Size = new System.Drawing.Size(174, 28);
            this.lblSelectedNode.TabIndex = 18;
            this.lblSelectedNode.Text = "Отправить настройку \r\nиз маршрута в генератор";
            this.lblSelectedNode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picPrevious);
            this.groupBox1.Controls.Add(this.picPlay);
            this.groupBox1.Controls.Add(this.lblSelectedNode);
            this.groupBox1.Controls.Add(this.picNext);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 156);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // picPrevious
            // 
            this.picPrevious.BackColor = System.Drawing.Color.Transparent;
            this.picPrevious.Image = global::ManagerDS360.Properties.Resources.предыдущий;
            this.picPrevious.Location = new System.Drawing.Point(13, 90);
            this.picPrevious.Name = "picPrevious";
            this.picPrevious.Size = new System.Drawing.Size(45, 37);
            this.picPrevious.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPrevious.TabIndex = 19;
            this.picPrevious.TabStop = false;
            this.picPrevious.MouseEnter += new System.EventHandler(this.picPrevious_MouseEnter);
            this.picPrevious.MouseLeave += new System.EventHandler(this.picPrevious_MouseLeave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1020, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.редактированиеМаршрутовToolStripMenuItem1});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // редактированиеМаршрутовToolStripMenuItem1
            // 
            this.редактированиеМаршрутовToolStripMenuItem1.Name = "редактированиеМаршрутовToolStripMenuItem1";
            this.редактированиеМаршрутовToolStripMenuItem1.Size = new System.Drawing.Size(230, 22);
            this.редактированиеМаршрутовToolStripMenuItem1.Text = "Редактирование маршрутов";
            this.редактированиеМаршрутовToolStripMenuItem1.Click += new System.EventHandler(this.редактированиеМаршрутовToolStripMenuItem1_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(254, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 14);
            this.label1.TabIndex = 22;
            this.label1.Text = "Маршрут:";
            // 
            // frmManagerDS360
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 516);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treRouteTree);
            this.Controls.Add(this.butGeneratorControl);
            this.Controls.Add(this.cboSavedRoutes);
            this.Controls.Add(this.butDefaultGenerator);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1036, 553);
            this.Name = "frmManagerDS360";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DS360";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmManagerDS360_Closing);
            this.Load += new System.EventHandler(this.frmManagerDS360_Load);
            this.MouseEnter += new System.EventHandler(this.frmManagerDS360_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.picPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNext)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPrevious)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button butDefaultGenerator;
        private System.Windows.Forms.ComboBox cboSavedRoutes;
        private System.Windows.Forms.Button butGeneratorControl;
        private LibControls.TreeViewWithSetting treRouteTree;
        private System.Windows.Forms.PictureBox picPlay;
        private System.Windows.Forms.PictureBox picNext;
        private System.Windows.Forms.Label lblSelectedNode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picPrevious;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактированиеМаршрутовToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}


﻿
namespace ManagerDS360 {
    partial class frmDS360 {
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
            this.butBroadcastSettingsGenerator = new System.Windows.Forms.Button();
            this.butNextSetup = new System.Windows.Forms.Button();
            this.butDefaultGenerator = new System.Windows.Forms.Button();
            this.treFieldКouteЕree = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNameGenerator = new System.Windows.Forms.TextBox();
            this.cboSavedRoutes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butEditingRoute = new System.Windows.Forms.Button();
            this.butGeneratorControl = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butBroadcastSettingsGenerator
            // 
            this.butBroadcastSettingsGenerator.Location = new System.Drawing.Point(12, 151);
            this.butBroadcastSettingsGenerator.Name = "butBroadcastSettingsGenerator";
            this.butBroadcastSettingsGenerator.Size = new System.Drawing.Size(222, 31);
            this.butBroadcastSettingsGenerator.TabIndex = 0;
            this.butBroadcastSettingsGenerator.Text = "Передача настройки в генератор";
            this.butBroadcastSettingsGenerator.UseVisualStyleBackColor = true;
            // 
            // butNextSetup
            // 
            this.butNextSetup.Location = new System.Drawing.Point(12, 226);
            this.butNextSetup.Name = "butNextSetup";
            this.butNextSetup.Size = new System.Drawing.Size(222, 31);
            this.butNextSetup.TabIndex = 1;
            this.butNextSetup.Text = "Следующая настройка ";
            this.butNextSetup.UseVisualStyleBackColor = true;
            // 
            // butDefaultGenerator
            // 
            this.butDefaultGenerator.Location = new System.Drawing.Point(12, 42);
            this.butDefaultGenerator.Name = "butDefaultGenerator";
            this.butDefaultGenerator.Size = new System.Drawing.Size(222, 31);
            this.butDefaultGenerator.TabIndex = 2;
            this.butDefaultGenerator.Text = "Генератор по умолчанию";
            this.butDefaultGenerator.UseVisualStyleBackColor = true;
            this.butDefaultGenerator.Click += new System.EventHandler(this.button3_Click);
            // 
            // treFieldКouteЕree
            // 
            this.treFieldКouteЕree.Location = new System.Drawing.Point(254, 42);
            this.treFieldКouteЕree.Name = "treFieldКouteЕree";
            this.treFieldКouteЕree.Size = new System.Drawing.Size(494, 440);
            this.treFieldКouteЕree.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(254, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Древо жизни";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtNameGenerator
            // 
            this.txtNameGenerator.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtNameGenerator.Location = new System.Drawing.Point(12, 12);
            this.txtNameGenerator.Name = "txtNameGenerator";
            this.txtNameGenerator.Size = new System.Drawing.Size(219, 20);
            this.txtNameGenerator.TabIndex = 5;
            this.txtNameGenerator.Text = "Name generator\r\n";
            // 
            // cboSavedRoutes
            // 
            this.cboSavedRoutes.FormattingEnabled = true;
            this.cboSavedRoutes.Location = new System.Drawing.Point(815, 42);
            this.cboSavedRoutes.Name = "cboSavedRoutes";
            this.cboSavedRoutes.Size = new System.Drawing.Size(186, 21);
            this.cboSavedRoutes.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(812, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Сохраненные маршруты";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // butEditingRoute
            // 
            this.butEditingRoute.Location = new System.Drawing.Point(12, 279);
            this.butEditingRoute.Name = "butEditingRoute";
            this.butEditingRoute.Size = new System.Drawing.Size(222, 31);
            this.butEditingRoute.TabIndex = 8;
            this.butEditingRoute.Text = "Редактирование маршрутов";
            this.butEditingRoute.UseVisualStyleBackColor = true;
            this.butEditingRoute.Click += new System.EventHandler(this.butEditingRoute_Click);
            // 
            // butGeneratorControl
            // 
            this.butGeneratorControl.Location = new System.Drawing.Point(12, 91);
            this.butGeneratorControl.Name = "butGeneratorControl";
            this.butGeneratorControl.Size = new System.Drawing.Size(222, 31);
            this.butGeneratorControl.TabIndex = 9;
            this.butGeneratorControl.Text = "Управление генераторами";
            this.butGeneratorControl.UseVisualStyleBackColor = true;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(730, 42);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(18, 422);
            this.vScrollBar1.TabIndex = 10;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(254, 464);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(494, 18);
            this.hScrollBar1.TabIndex = 11;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 589);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(157, 26);
            this.button6.TabIndex = 12;
            this.button6.Text = "О программе";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // frmDS360
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 627);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.butGeneratorControl);
            this.Controls.Add(this.butEditingRoute);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboSavedRoutes);
            this.Controls.Add(this.txtNameGenerator);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treFieldКouteЕree);
            this.Controls.Add(this.butDefaultGenerator);
            this.Controls.Add(this.butNextSetup);
            this.Controls.Add(this.butBroadcastSettingsGenerator);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "frmDS360";
            this.Text = "DS360";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butBroadcastSettingsGenerator;
        private System.Windows.Forms.Button butNextSetup;
        private System.Windows.Forms.Button butDefaultGenerator;
        private System.Windows.Forms.TreeView treFieldКouteЕree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNameGenerator;
        private System.Windows.Forms.ComboBox cboSavedRoutes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butEditingRoute;
        private System.Windows.Forms.Button butGeneratorControl;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Button button6;
    }
}


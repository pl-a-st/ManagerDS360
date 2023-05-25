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
            this.butBroadcastSettingsGenerator = new System.Windows.Forms.Button();
            this.butNextSetup = new System.Windows.Forms.Button();
            this.butDefaultGenerator = new System.Windows.Forms.Button();
            this.lstRouteSettings = new System.Windows.Forms.TreeView();
            this.lblRoute = new System.Windows.Forms.Label();
            this.cboSavedRoutes = new System.Windows.Forms.ComboBox();
            this.lblSavedRoutes = new System.Windows.Forms.Label();
            this.butEditingRoute = new System.Windows.Forms.Button();
            this.butGeneratorControl = new System.Windows.Forms.Button();
            this.sbrVerticalFieldКouteЕree = new System.Windows.Forms.VScrollBar();
            this.sbrHorizontalFieldКouteЕree = new System.Windows.Forms.HScrollBar();
            this.butAboutProgram = new System.Windows.Forms.Button();
            this.lblDefaultGenerator = new System.Windows.Forms.Label();
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
            this.butBroadcastSettingsGenerator.Click += new System.EventHandler(this.butBroadcastSettingsGenerator_Click);
            // 
            // butNextSetup
            // 
            this.butNextSetup.Location = new System.Drawing.Point(12, 226);
            this.butNextSetup.Name = "butNextSetup";
            this.butNextSetup.Size = new System.Drawing.Size(222, 31);
            this.butNextSetup.TabIndex = 1;
            this.butNextSetup.Text = "Следующая настройка ";
            this.butNextSetup.UseVisualStyleBackColor = true;
            this.butNextSetup.Click += new System.EventHandler(this.butNextSetup_Click);
            // 
            // butDefaultGenerator
            // 
            this.butDefaultGenerator.Location = new System.Drawing.Point(12, 42);
            this.butDefaultGenerator.Name = "butDefaultGenerator";
            this.butDefaultGenerator.Size = new System.Drawing.Size(222, 31);
            this.butDefaultGenerator.TabIndex = 2;
            this.butDefaultGenerator.Text = "Генератор по умолчанию";
            this.butDefaultGenerator.UseVisualStyleBackColor = true;
            this.butDefaultGenerator.Click += new System.EventHandler(this.butDefaultGenerator_Click);
            // 
            // lstRouteSettings
            // 
            this.lstRouteSettings.Location = new System.Drawing.Point(254, 42);
            this.lstRouteSettings.Name = "lstRouteSettings";
            this.lstRouteSettings.Size = new System.Drawing.Size(539, 515);
            this.lstRouteSettings.TabIndex = 3;
            this.lstRouteSettings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.lstRouteSettings_AfterSelect);
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Location = new System.Drawing.Point(254, 26);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(52, 13);
            this.lblRoute.TabIndex = 4;
            this.lblRoute.Text = "Маршрут";
            this.lblRoute.Click += new System.EventHandler(this.lblRoute_Click);
            // 
            // cboSavedRoutes
            // 
            this.cboSavedRoutes.FormattingEnabled = true;
            this.cboSavedRoutes.Location = new System.Drawing.Point(809, 42);
            this.cboSavedRoutes.Name = "cboSavedRoutes";
            this.cboSavedRoutes.Size = new System.Drawing.Size(186, 21);
            this.cboSavedRoutes.TabIndex = 6;
            this.cboSavedRoutes.SelectedIndexChanged += new System.EventHandler(this.cboSavedRoutes_SelectedIndexChanged);
            // 
            // lblSavedRoutes
            // 
            this.lblSavedRoutes.AutoSize = true;
            this.lblSavedRoutes.Location = new System.Drawing.Point(806, 26);
            this.lblSavedRoutes.Name = "lblSavedRoutes";
            this.lblSavedRoutes.Size = new System.Drawing.Size(130, 13);
            this.lblSavedRoutes.TabIndex = 7;
            this.lblSavedRoutes.Text = "Сохраненные маршруты";
            this.lblSavedRoutes.Click += new System.EventHandler(this.lblSavedRoutes_Click);
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
            this.butGeneratorControl.Text = "Управление генератором";
            this.butGeneratorControl.UseVisualStyleBackColor = true;
            this.butGeneratorControl.Click += new System.EventHandler(this.butGeneratorControl_Click);
            // 
            // sbrVerticalFieldКouteЕree
            // 
            this.sbrVerticalFieldКouteЕree.Location = new System.Drawing.Point(774, 43);
            this.sbrVerticalFieldКouteЕree.Name = "sbrVerticalFieldКouteЕree";
            this.sbrVerticalFieldКouteЕree.Size = new System.Drawing.Size(18, 494);
            this.sbrVerticalFieldКouteЕree.TabIndex = 10;
            this.sbrVerticalFieldКouteЕree.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbrVerticalFieldКouteЕree_Scroll);
            // 
            // sbrHorizontalFieldКouteЕree
            // 
            this.sbrHorizontalFieldКouteЕree.Location = new System.Drawing.Point(255, 537);
            this.sbrHorizontalFieldКouteЕree.Name = "sbrHorizontalFieldКouteЕree";
            this.sbrHorizontalFieldКouteЕree.Size = new System.Drawing.Size(537, 18);
            this.sbrHorizontalFieldКouteЕree.TabIndex = 11;
            this.sbrHorizontalFieldКouteЕree.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbrHorizontalFieldКouteЕree_Scroll);
            // 
            // butAboutProgram
            // 
            this.butAboutProgram.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.butAboutProgram.Location = new System.Drawing.Point(12, 589);
            this.butAboutProgram.Name = "butAboutProgram";
            this.butAboutProgram.Size = new System.Drawing.Size(157, 26);
            this.butAboutProgram.TabIndex = 12;
            this.butAboutProgram.Text = "О программе";
            this.butAboutProgram.UseVisualStyleBackColor = true;
            this.butAboutProgram.Click += new System.EventHandler(this.butAboutProgram_Click);
            // 
            // lblDefaultGenerator
            // 
            this.lblDefaultGenerator.AutoSize = true;
            this.lblDefaultGenerator.Location = new System.Drawing.Point(9, 9);
            this.lblDefaultGenerator.Name = "lblDefaultGenerator";
            this.lblDefaultGenerator.Size = new System.Drawing.Size(134, 13);
            this.lblDefaultGenerator.TabIndex = 14;
            this.lblDefaultGenerator.Text = "Генератор по умолчанию";
            this.lblDefaultGenerator.Click += new System.EventHandler(this.lblDefaultGenerator_Click);
            // 
            // frmManagerDS360
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 627);
            this.Controls.Add(this.lblDefaultGenerator);
            this.Controls.Add(this.butAboutProgram);
            this.Controls.Add(this.sbrHorizontalFieldКouteЕree);
            this.Controls.Add(this.sbrVerticalFieldКouteЕree);
            this.Controls.Add(this.butGeneratorControl);
            this.Controls.Add(this.butEditingRoute);
            this.Controls.Add(this.lblSavedRoutes);
            this.Controls.Add(this.cboSavedRoutes);
            this.Controls.Add(this.lblRoute);
            this.Controls.Add(this.lstRouteSettings);
            this.Controls.Add(this.butDefaultGenerator);
            this.Controls.Add(this.butNextSetup);
            this.Controls.Add(this.butBroadcastSettingsGenerator);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1022, 666);
            this.MinimumSize = new System.Drawing.Size(1022, 666);
            this.Name = "frmManagerDS360";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DS360";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmManagerDS360_Closing);
            this.Load += new System.EventHandler(this.frmManagerDS360_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butBroadcastSettingsGenerator;
        private System.Windows.Forms.Button butNextSetup;
        private System.Windows.Forms.Button butDefaultGenerator;
        private System.Windows.Forms.TreeView lstRouteSettings;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.ComboBox cboSavedRoutes;
        private System.Windows.Forms.Label lblSavedRoutes;
        private System.Windows.Forms.Button butEditingRoute;
        private System.Windows.Forms.Button butGeneratorControl;
        private System.Windows.Forms.VScrollBar sbrVerticalFieldКouteЕree;
        private System.Windows.Forms.HScrollBar sbrHorizontalFieldКouteЕree;
        private System.Windows.Forms.Button butAboutProgram;
        internal System.Windows.Forms.Label lblDefaultGenerator;
    }
}


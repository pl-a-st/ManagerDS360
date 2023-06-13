
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
            this.butBroadcastSettingsGenerator = new System.Windows.Forms.Button();
            this.butNextSetup = new System.Windows.Forms.Button();
            this.butDefaultGenerator = new System.Windows.Forms.Button();
            this.lblRoute = new System.Windows.Forms.Label();
            this.cboSavedRoutes = new System.Windows.Forms.ComboBox();
            this.lblSavedRoutes = new System.Windows.Forms.Label();
            this.butEditingRoute = new System.Windows.Forms.Button();
            this.butGeneratorControl = new System.Windows.Forms.Button();
            this.butAboutProgram = new System.Windows.Forms.Button();
            this.lblDefaultGenerator = new System.Windows.Forms.Label();
            this.treRouteTree = new LibControls.TreeViewWithSetting();
            this.SuspendLayout();
            // 
            // butBroadcastSettingsGenerator
            // 
            this.butBroadcastSettingsGenerator.BackgroundImage = global::ManagerDS360.Properties.Resources.fon_knopki;
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
            this.butNextSetup.BackgroundImage = global::ManagerDS360.Properties.Resources.fon_knopki;
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
            this.butDefaultGenerator.BackgroundImage = global::ManagerDS360.Properties.Resources.fon_knopki;
            this.butDefaultGenerator.Location = new System.Drawing.Point(12, 42);
            this.butDefaultGenerator.Name = "butDefaultGenerator";
            this.butDefaultGenerator.Size = new System.Drawing.Size(222, 31);
            this.butDefaultGenerator.TabIndex = 2;
            this.butDefaultGenerator.Text = "Генератор по умолчанию";
            this.butDefaultGenerator.UseVisualStyleBackColor = true;
            this.butDefaultGenerator.Click += new System.EventHandler(this.butDefaultGenerator_Click);
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRoute.Location = new System.Drawing.Point(484, 21);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(66, 14);
            this.lblRoute.TabIndex = 4;
            this.lblRoute.Text = "Маршрут";
            this.lblRoute.Visible = false;
            this.lblRoute.Click += new System.EventHandler(this.lblRoute_Click);
            // 
            // cboSavedRoutes
            // 
            this.cboSavedRoutes.FormattingEnabled = true;
            this.cboSavedRoutes.Location = new System.Drawing.Point(821, 42);
            this.cboSavedRoutes.Name = "cboSavedRoutes";
            this.cboSavedRoutes.Size = new System.Drawing.Size(186, 21);
            this.cboSavedRoutes.TabIndex = 6;
            this.cboSavedRoutes.SelectedIndexChanged += new System.EventHandler(this.cboSavedRoutes_SelectedIndexChanged);
            // 
            // lblSavedRoutes
            // 
            this.lblSavedRoutes.AutoSize = true;
            this.lblSavedRoutes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSavedRoutes.Location = new System.Drawing.Point(831, 21);
            this.lblSavedRoutes.Name = "lblSavedRoutes";
            this.lblSavedRoutes.Size = new System.Drawing.Size(166, 14);
            this.lblSavedRoutes.TabIndex = 7;
            this.lblSavedRoutes.Text = "Сохраненные маршруты";
            this.lblSavedRoutes.Visible = false;
            this.lblSavedRoutes.Click += new System.EventHandler(this.lblSavedRoutes_Click);
            // 
            // butEditingRoute
            // 
            this.butEditingRoute.BackgroundImage = global::ManagerDS360.Properties.Resources.fon_knopki;
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
            this.butGeneratorControl.BackgroundImage = global::ManagerDS360.Properties.Resources.fon_knopki;
            this.butGeneratorControl.Location = new System.Drawing.Point(12, 91);
            this.butGeneratorControl.Name = "butGeneratorControl";
            this.butGeneratorControl.Size = new System.Drawing.Size(222, 31);
            this.butGeneratorControl.TabIndex = 9;
            this.butGeneratorControl.Text = "Управление генератором";
            this.butGeneratorControl.UseVisualStyleBackColor = true;
            this.butGeneratorControl.Click += new System.EventHandler(this.butGeneratorControl_Click);
            // 
            // butAboutProgram
            // 
            this.butAboutProgram.BackgroundImage = global::ManagerDS360.Properties.Resources.fon_knopki;
            this.butAboutProgram.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.butAboutProgram.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAboutProgram.Location = new System.Drawing.Point(12, 445);
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
            this.lblDefaultGenerator.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDefaultGenerator.Location = new System.Drawing.Point(35, 20);
            this.lblDefaultGenerator.Name = "lblDefaultGenerator";
            this.lblDefaultGenerator.Size = new System.Drawing.Size(174, 14);
            this.lblDefaultGenerator.TabIndex = 14;
            this.lblDefaultGenerator.Text = "Генератор по умолчанию";
            this.lblDefaultGenerator.Visible = false;
            this.lblDefaultGenerator.Click += new System.EventHandler(this.lblDefaultGenerator_Click);
            // 
            // treRouteTree
            // 
            this.treRouteTree.ImageIndex = 0;
            this.treRouteTree.Location = new System.Drawing.Point(255, 42);
            this.treRouteTree.Name = "treRouteTree";
            this.treRouteTree.SelectedImageIndex = 0;
            this.treRouteTree.Size = new System.Drawing.Size(550, 448);
            this.treRouteTree.TabIndex = 15;
            // 
            // frmManagerDS360
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ManagerDS360.Properties.Resources.kletka_siniy_razmetka;
            this.ClientSize = new System.Drawing.Size(1020, 514);
            this.Controls.Add(this.treRouteTree);
            this.Controls.Add(this.lblDefaultGenerator);
            this.Controls.Add(this.butAboutProgram);
            this.Controls.Add(this.butGeneratorControl);
            this.Controls.Add(this.butEditingRoute);
            this.Controls.Add(this.lblSavedRoutes);
            this.Controls.Add(this.cboSavedRoutes);
            this.Controls.Add(this.lblRoute);
            this.Controls.Add(this.butDefaultGenerator);
            this.Controls.Add(this.butNextSetup);
            this.Controls.Add(this.butBroadcastSettingsGenerator);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1036, 553);
            this.MinimumSize = new System.Drawing.Size(1036, 553);
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
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.ComboBox cboSavedRoutes;
        private System.Windows.Forms.Label lblSavedRoutes;
        private System.Windows.Forms.Button butEditingRoute;
        private System.Windows.Forms.Button butGeneratorControl;
        private System.Windows.Forms.Button butAboutProgram;
        internal System.Windows.Forms.Label lblDefaultGenerator;
        private LibControls.TreeViewWithSetting treRouteTree;
    }
}


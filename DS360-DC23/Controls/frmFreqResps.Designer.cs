namespace ManagerDS360
{
    partial class frmFreqResps
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFreqResps));
            this.lblSavedRoutes = new System.Windows.Forms.Label();
            this.butCreateFreqResp = new System.Windows.Forms.Button();
            this.butEditingFreqResp = new System.Windows.Forms.Button();
            this.butDeleteFreqResp = new System.Windows.Forms.Button();
            this.lstSaveFreqResp = new System.Windows.Forms.ListBox();
            this.butSearchFreqResp = new System.Windows.Forms.Button();
            this.butRenameFreqResp = new System.Windows.Forms.Button();
            this.butCopyFreqResp = new System.Windows.Forms.Button();
            this.butUp = new LibControls.ButtonForPicture();
            this.butDown = new LibControls.ButtonForPicture();
            this.SuspendLayout();
            // 
            // lblSavedRoutes
            // 
            this.lblSavedRoutes.AutoSize = true;
            this.lblSavedRoutes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSavedRoutes.Location = new System.Drawing.Point(9, 9);
            this.lblSavedRoutes.Name = "lblSavedRoutes";
            this.lblSavedRoutes.Size = new System.Drawing.Size(125, 14);
            this.lblSavedRoutes.TabIndex = 0;
            this.lblSavedRoutes.Text = "Сохраненные АЧХ";
            this.lblSavedRoutes.Click += new System.EventHandler(this.lblSavedRoutes_Click);
            // 
            // butCreateFreqResp
            // 
            this.butCreateFreqResp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butCreateFreqResp.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCreateFreqResp.Location = new System.Drawing.Point(422, 29);
            this.butCreateFreqResp.Name = "butCreateFreqResp";
            this.butCreateFreqResp.Size = new System.Drawing.Size(132, 45);
            this.butCreateFreqResp.TabIndex = 2;
            this.butCreateFreqResp.Text = "Создать АЧХ";
            this.butCreateFreqResp.UseVisualStyleBackColor = true;
            this.butCreateFreqResp.Click += new System.EventHandler(this.butCreateRoutes_Click);
            // 
            // butEditingFreqResp
            // 
            this.butEditingFreqResp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butEditingFreqResp.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butEditingFreqResp.Location = new System.Drawing.Point(422, 80);
            this.butEditingFreqResp.Name = "butEditingFreqResp";
            this.butEditingFreqResp.Size = new System.Drawing.Size(132, 45);
            this.butEditingFreqResp.TabIndex = 3;
            this.butEditingFreqResp.Text = "Редактировать АЧХ";
            this.butEditingFreqResp.UseVisualStyleBackColor = true;
            this.butEditingFreqResp.Click += new System.EventHandler(this.butEditingRoute_Click);
            // 
            // butDeleteFreqResp
            // 
            this.butDeleteFreqResp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butDeleteFreqResp.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butDeleteFreqResp.Location = new System.Drawing.Point(422, 366);
            this.butDeleteFreqResp.Name = "butDeleteFreqResp";
            this.butDeleteFreqResp.Size = new System.Drawing.Size(132, 45);
            this.butDeleteFreqResp.TabIndex = 7;
            this.butDeleteFreqResp.Text = "Удалить АЧХ";
            this.butDeleteFreqResp.UseVisualStyleBackColor = true;
            this.butDeleteFreqResp.Click += new System.EventHandler(this.butDeleteRoute_Click);
            // 
            // lstSaveFreqResp
            // 
            this.lstSaveFreqResp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSaveFreqResp.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstSaveFreqResp.FormattingEnabled = true;
            this.lstSaveFreqResp.ItemHeight = 14;
            this.lstSaveFreqResp.Location = new System.Drawing.Point(12, 29);
            this.lstSaveFreqResp.Name = "lstSaveFreqResp";
            this.lstSaveFreqResp.Size = new System.Drawing.Size(349, 382);
            this.lstSaveFreqResp.TabIndex = 1;
            this.lstSaveFreqResp.SelectedIndexChanged += new System.EventHandler(this.lstSaveRoutes_SelectedIndexChanged);
            this.lstSaveFreqResp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // butSearchFreqResp
            // 
            this.butSearchFreqResp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSearchFreqResp.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butSearchFreqResp.Location = new System.Drawing.Point(422, 233);
            this.butSearchFreqResp.Name = "butSearchFreqResp";
            this.butSearchFreqResp.Size = new System.Drawing.Size(132, 45);
            this.butSearchFreqResp.TabIndex = 6;
            this.butSearchFreqResp.Text = "Найти  АЧХ";
            this.butSearchFreqResp.UseVisualStyleBackColor = true;
            this.butSearchFreqResp.Click += new System.EventHandler(this.butSearchRoute_Click);
            // 
            // butRenameFreqResp
            // 
            this.butRenameFreqResp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butRenameFreqResp.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butRenameFreqResp.Location = new System.Drawing.Point(422, 131);
            this.butRenameFreqResp.Name = "butRenameFreqResp";
            this.butRenameFreqResp.Size = new System.Drawing.Size(132, 45);
            this.butRenameFreqResp.TabIndex = 4;
            this.butRenameFreqResp.Text = "Переименовать АЧХ";
            this.butRenameFreqResp.UseVisualStyleBackColor = true;
            this.butRenameFreqResp.Click += new System.EventHandler(this.butRenameRoute_Click);
            // 
            // butCopyFreqResp
            // 
            this.butCopyFreqResp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butCopyFreqResp.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCopyFreqResp.Location = new System.Drawing.Point(422, 182);
            this.butCopyFreqResp.Name = "butCopyFreqResp";
            this.butCopyFreqResp.Size = new System.Drawing.Size(132, 45);
            this.butCopyFreqResp.TabIndex = 5;
            this.butCopyFreqResp.Text = "Копировать АЧХ";
            this.butCopyFreqResp.UseVisualStyleBackColor = true;
            this.butCopyFreqResp.Click += new System.EventHandler(this.butCopyRoute_Click);
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
            this.butUp.Location = new System.Drawing.Point(367, 137);
            this.butUp.Name = "butUp";
            this.butUp.Size = new System.Drawing.Size(33, 39);
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
            this.butDown.Location = new System.Drawing.Point(367, 233);
            this.butDown.Name = "butDown";
            this.butDown.Size = new System.Drawing.Size(33, 39);
            this.butDown.TabIndex = 11;
            this.butDown.UseVisualStyleBackColor = false;
            this.butDown.Click += new System.EventHandler(this.butDown_Click);
            this.butDown.MouseEnter += new System.EventHandler(this.butDown_MouseEnter);
            this.butDown.MouseLeave += new System.EventHandler(this.butDown_MouseLeave);
            // 
            // frmEditingFreqResp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 453);
            this.Controls.Add(this.butDown);
            this.Controls.Add(this.butUp);
            this.Controls.Add(this.lstSaveFreqResp);
            this.Controls.Add(this.butDeleteFreqResp);
            this.Controls.Add(this.butSearchFreqResp);
            this.Controls.Add(this.butCopyFreqResp);
            this.Controls.Add(this.butRenameFreqResp);
            this.Controls.Add(this.butEditingFreqResp);
            this.Controls.Add(this.butCreateFreqResp);
            this.Controls.Add(this.lblSavedRoutes);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(588, 492);
            this.Name = "frmEditingFreqResp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование сохраненных АЧХ вибростендов";
            this.Load += new System.EventHandler(this.frmEditingRoutes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSavedRoutes;
        private System.Windows.Forms.Button butCreateFreqResp;
        private System.Windows.Forms.Button butEditingFreqResp;
        private System.Windows.Forms.Button butDeleteFreqResp;
        private System.Windows.Forms.ListBox lstSaveFreqResp;
        private System.Windows.Forms.Button butSearchFreqResp;
        private System.Windows.Forms.Button butRenameFreqResp;
        private System.Windows.Forms.Button butCopyFreqResp;
        private LibControls.ButtonForPicture butUp;
        private LibControls.ButtonForPicture butDown;
    }
}
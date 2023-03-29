
namespace ManagerDS360 {
    partial class Form1 {
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
            this.greyButton3 = new LibControls.GreyButton();
            this.greyButton2 = new LibControls.GreyButton();
            this.greyButton1 = new LibControls.GreyButton();
            this.greyButton4 = new LibControls.GreyButton();
            this.SuspendLayout();
            // 
            // greyButton3
            // 
            this.greyButton3.BackColor = System.Drawing.Color.Blue;
            this.greyButton3.Location = new System.Drawing.Point(729, 113);
            this.greyButton3.Name = "greyButton3";
            this.greyButton3.Size = new System.Drawing.Size(97, 104);
            this.greyButton3.TabIndex = 2;
            this.greyButton3.Text = "greyButton3";
            this.greyButton3.UseVisualStyleBackColor = false;
            // 
            // greyButton2
            // 
            this.greyButton2.BackColor = System.Drawing.Color.Blue;
            this.greyButton2.Location = new System.Drawing.Point(427, 149);
            this.greyButton2.Name = "greyButton2";
            this.greyButton2.Size = new System.Drawing.Size(171, 185);
            this.greyButton2.TabIndex = 1;
            this.greyButton2.Text = "greyButton2";
            this.greyButton2.UseVisualStyleBackColor = false;
            // 
            // greyButton1
            // 
            this.greyButton1.BackColor = System.Drawing.Color.Blue;
            this.greyButton1.Location = new System.Drawing.Point(81, 118);
            this.greyButton1.Name = "greyButton1";
            this.greyButton1.Size = new System.Drawing.Size(289, 237);
            this.greyButton1.TabIndex = 0;
            this.greyButton1.Text = "greyButton1";
            this.greyButton1.UseVisualStyleBackColor = false;
            this.greyButton1.Click += new System.EventHandler(this.greyButton1_Click);
            // 
            // greyButton4
            // 
            this.greyButton4.BackColor = System.Drawing.Color.Blue;
            this.greyButton4.Location = new System.Drawing.Point(530, 425);
            this.greyButton4.Name = "greyButton4";
            this.greyButton4.Size = new System.Drawing.Size(203, 103);
            this.greyButton4.TabIndex = 3;
            this.greyButton4.Text = "greyButton4";
            this.greyButton4.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 580);
            this.Controls.Add(this.greyButton4);
            this.Controls.Add(this.greyButton3);
            this.Controls.Add(this.greyButton2);
            this.Controls.Add(this.greyButton1);
            this.Name = "Form1";
            this.Text = "DS360";
            this.ResumeLayout(false);

        }

        #endregion

        private LibControls.GreyButton greyButton1;
        private LibControls.GreyButton greyButton2;
        private LibControls.GreyButton greyButton3;
        private LibControls.GreyButton greyButton4;
    }
}


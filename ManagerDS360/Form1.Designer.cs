
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Name_Generator = new System.Windows.Forms.ListBox();
            this.Сохраненные_маршруты = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(24, 60);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(308, 379);
            this.treeView1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(645, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(258, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Задать настройку\r\n";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(645, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(258, 35);
            this.button2.TabIndex = 3;
            this.button2.Text = "Задать следующую настройку";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(645, 181);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(257, 36);
            this.button3.TabIndex = 4;
            this.button3.Text = "Задать генератор по умолчанию";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Name_Generator
            // 
            this.Name_Generator.FormattingEnabled = true;
            this.Name_Generator.Location = new System.Drawing.Point(25, 15);
            this.Name_Generator.Name = "Name_Generator";
            this.Name_Generator.Size = new System.Drawing.Size(202, 17);
            this.Name_Generator.TabIndex = 5;
            // 
            // Сохраненные_маршруты
            // 
            this.Сохраненные_маршруты.FormattingEnabled = true;
            this.Сохраненные_маршруты.Location = new System.Drawing.Point(387, 60);
            this.Сохраненные_маршруты.Name = "Сохраненные_маршруты";
            this.Сохраненные_маршруты.Size = new System.Drawing.Size(146, 21);
            this.Сохраненные_маршруты.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(384, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Сохраненные маршруты";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Древо жизни";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(645, 243);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(257, 35);
            this.button4.TabIndex = 9;
            this.button4.Text = "Редактирование маршрутов";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(645, 303);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(254, 34);
            this.button5.TabIndex = 10;
            this.button5.Text = "Управление генератором";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 580);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Сохраненные_маршруты);
            this.Controls.Add(this.Name_Generator);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "DS360";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox Name_Generator;
        private System.Windows.Forms.ComboBox Сохраненные_маршруты;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}


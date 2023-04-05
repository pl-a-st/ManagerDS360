
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
            this.but_broadcast_settings_generator = new System.Windows.Forms.Button();
            this.but_next_setup = new System.Windows.Forms.Button();
            this.but_default_generator = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_name_generator = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.but_generator_control = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // but_broadcast_settings_generator
            // 
            this.but_broadcast_settings_generator.Location = new System.Drawing.Point(12, 151);
            this.but_broadcast_settings_generator.Name = "but_broadcast_settings_generator";
            this.but_broadcast_settings_generator.Size = new System.Drawing.Size(223, 31);
            this.but_broadcast_settings_generator.TabIndex = 0;
            this.but_broadcast_settings_generator.Text = "Передача настройки в генератор";
            this.but_broadcast_settings_generator.UseVisualStyleBackColor = true;
            // 
            // but_next_setup
            // 
            this.but_next_setup.Location = new System.Drawing.Point(12, 188);
            this.but_next_setup.Name = "but_next_setup";
            this.but_next_setup.Size = new System.Drawing.Size(223, 24);
            this.but_next_setup.TabIndex = 1;
            this.but_next_setup.Text = "Следующая настройка ";
            this.but_next_setup.UseVisualStyleBackColor = true;
            // 
            // but_default_generator
            // 
            this.but_default_generator.Location = new System.Drawing.Point(12, 42);
            this.but_default_generator.Name = "but_default_generator";
            this.but_default_generator.Size = new System.Drawing.Size(222, 31);
            this.but_default_generator.TabIndex = 2;
            this.but_default_generator.Text = "Генератор по умолчанию";
            this.but_default_generator.UseVisualStyleBackColor = true;
            this.but_default_generator.Click += new System.EventHandler(this.button3_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(254, 42);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(494, 440);
            this.treeView1.TabIndex = 3;
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
            // txt_name_generator
            // 
            this.txt_name_generator.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.txt_name_generator.Location = new System.Drawing.Point(12, 12);
            this.txt_name_generator.Name = "txt_name_generator";
            this.txt_name_generator.Size = new System.Drawing.Size(219, 20);
            this.txt_name_generator.TabIndex = 5;
            this.txt_name_generator.Text = "Name generator\r\n";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(815, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(186, 21);
            this.comboBox1.TabIndex = 6;
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 218);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(214, 29);
            this.button4.TabIndex = 8;
            this.button4.Text = "Редактирование маршрутов";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // but_generator_control
            // 
            this.but_generator_control.Location = new System.Drawing.Point(12, 91);
            this.but_generator_control.Name = "but_generator_control";
            this.but_generator_control.Size = new System.Drawing.Size(222, 31);
            this.but_generator_control.TabIndex = 9;
            this.but_generator_control.Text = "Управление генераторами";
            this.but_generator_control.UseVisualStyleBackColor = true;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 627);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.but_generator_control);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txt_name_generator);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.but_default_generator);
            this.Controls.Add(this.but_next_setup);
            this.Controls.Add(this.but_broadcast_settings_generator);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "DS360";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_broadcast_settings_generator;
        private System.Windows.Forms.Button but_next_setup;
        private System.Windows.Forms.Button but_default_generator;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_name_generator;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button but_generator_control;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Button button6;
    }
}


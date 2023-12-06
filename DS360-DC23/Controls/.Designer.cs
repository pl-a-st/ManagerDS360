
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
            this.lblSelectedNode = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butPlay = new System.Windows.Forms.Button();
            this.butNext = new System.Windows.Forms.Button();
            this.butPrevious = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.редактированиеМаршрутовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditingRoutes = new System.Windows.Forms.ToolStripMenuItem();
            this.тестОбменаДаннымиССД23ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAboutProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.labelRoute = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblTestStatus = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboTestedDevice = new System.Windows.Forms.ComboBox();
            this.lblTestedDevice = new System.Windows.Forms.Label();
            this.butStartTest = new LibControls.ButtonForPicture();
            this.butLable = new LibControls.ButtonForPicture();
            this.butStopTest = new LibControls.ButtonForPicture();
            this.label1 = new System.Windows.Forms.Label();
            this.grpTest = new System.Windows.Forms.GroupBox();
            this.treRouteTree = new LibControls.TreeViewWithSetting();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // butDefaultGenerator
            // 
            this.butDefaultGenerator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butDefaultGenerator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.butDefaultGenerator.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.butDefaultGenerator.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.butDefaultGenerator.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butDefaultGenerator.Location = new System.Drawing.Point(15, 28);
            this.butDefaultGenerator.Name = "butDefaultGenerator";
            this.butDefaultGenerator.Size = new System.Drawing.Size(230, 38);
            this.butDefaultGenerator.TabIndex = 2;
            this.butDefaultGenerator.Text = "Генератор по умолчанию";
            this.butDefaultGenerator.UseVisualStyleBackColor = false;
            this.butDefaultGenerator.Click += new System.EventHandler(this.butDefaultGenerator_Click);
            // 
            // cboSavedRoutes
            // 
            this.cboSavedRoutes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSavedRoutes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSavedRoutes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSavedRoutes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboSavedRoutes.FormattingEnabled = true;
            this.cboSavedRoutes.Location = new System.Drawing.Point(6, 28);
            this.cboSavedRoutes.Name = "cboSavedRoutes";
            this.cboSavedRoutes.Size = new System.Drawing.Size(752, 22);
            this.cboSavedRoutes.TabIndex = 6;
            this.cboSavedRoutes.SelectedIndexChanged += new System.EventHandler(this.cboSavedRoutes_SelectedIndexChanged);
            this.cboSavedRoutes.Click += new System.EventHandler(this.cboSavedRoutes_Click);
            this.cboSavedRoutes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // butGeneratorControl
            // 
            this.butGeneratorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butGeneratorControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.butGeneratorControl.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.butGeneratorControl.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.butGeneratorControl.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butGeneratorControl.Location = new System.Drawing.Point(15, 75);
            this.butGeneratorControl.Name = "butGeneratorControl";
            this.butGeneratorControl.Size = new System.Drawing.Size(230, 38);
            this.butGeneratorControl.TabIndex = 3;
            this.butGeneratorControl.Text = "Управление генератором";
            this.butGeneratorControl.UseVisualStyleBackColor = false;
            this.butGeneratorControl.Click += new System.EventHandler(this.butGeneratorControl_Click);
            // 
            // lblSelectedNode
            // 
            this.lblSelectedNode.AutoSize = true;
            this.lblSelectedNode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSelectedNode.Location = new System.Drawing.Point(11, 16);
            this.lblSelectedNode.Name = "lblSelectedNode";
            this.lblSelectedNode.Size = new System.Drawing.Size(206, 14);
            this.lblSelectedNode.TabIndex = 18;
            this.lblSelectedNode.Text = "Активировать команду дерева";
            this.lblSelectedNode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.butPlay);
            this.groupBox1.Controls.Add(this.butNext);
            this.groupBox1.Controls.Add(this.butPrevious);
            this.groupBox1.Controls.Add(this.lblSelectedNode);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(15, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 114);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // butPlay
            // 
            this.butPlay.AutoSize = true;
            this.butPlay.BackColor = System.Drawing.Color.Transparent;
            this.butPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("butPlay.BackgroundImage")));
            this.butPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butPlay.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.butPlay.FlatAppearance.BorderSize = 0;
            this.butPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butPlay.Location = new System.Drawing.Point(94, 46);
            this.butPlay.Name = "butPlay";
            this.butPlay.Size = new System.Drawing.Size(54, 54);
            this.butPlay.TabIndex = 23;
            this.butPlay.UseVisualStyleBackColor = false;
            this.butPlay.Click += new System.EventHandler(this.butPlay_Click);
            this.butPlay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.butPlay_MouseDown);
            this.butPlay.MouseEnter += new System.EventHandler(this.butPlay_MouseEnter);
            this.butPlay.MouseLeave += new System.EventHandler(this.butPlay_MouseLeave);
            this.butPlay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.butPlay_MouseUp);
            // 
            // butNext
            // 
            this.butNext.AutoSize = true;
            this.butNext.BackColor = System.Drawing.Color.Transparent;
            this.butNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("butNext.BackgroundImage")));
            this.butNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butNext.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.butNext.FlatAppearance.BorderSize = 0;
            this.butNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butNext.Location = new System.Drawing.Point(164, 55);
            this.butNext.Name = "butNext";
            this.butNext.Size = new System.Drawing.Size(55, 36);
            this.butNext.TabIndex = 23;
            this.butNext.UseVisualStyleBackColor = false;
            this.butNext.Click += new System.EventHandler(this.butNext_Click);
            this.butNext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.butNext_MouseDown);
            this.butNext.MouseEnter += new System.EventHandler(this.butNext_MouseEnter);
            this.butNext.MouseLeave += new System.EventHandler(this.butNext_MouseLeave);
            this.butNext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.butNext_MouseUp);
            // 
            // butPrevious
            // 
            this.butPrevious.AutoSize = true;
            this.butPrevious.BackColor = System.Drawing.Color.Transparent;
            this.butPrevious.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("butPrevious.BackgroundImage")));
            this.butPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butPrevious.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.butPrevious.FlatAppearance.BorderSize = 0;
            this.butPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butPrevious.Location = new System.Drawing.Point(14, 56);
            this.butPrevious.Name = "butPrevious";
            this.butPrevious.Size = new System.Drawing.Size(55, 36);
            this.butPrevious.TabIndex = 23;
            this.butPrevious.UseVisualStyleBackColor = false;
            this.butPrevious.Click += new System.EventHandler(this.butPrevious_Click);
            this.butPrevious.MouseDown += new System.Windows.Forms.MouseEventHandler(this.butPrevious_MouseDown);
            this.butPrevious.MouseEnter += new System.EventHandler(this.butPrevious_MouseEnter);
            this.butPrevious.MouseLeave += new System.EventHandler(this.butPrevious_MouseLeave);
            this.butPrevious.MouseUp += new System.Windows.Forms.MouseEventHandler(this.butPrevious_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AllowMerge = false;
            this.contextMenuStrip1.DropShadowEnabled = false;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.редактированиеМаршрутовToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.Size = new System.Drawing.Size(231, 26);
            // 
            // редактированиеМаршрутовToolStripMenuItem
            // 
            this.редактированиеМаршрутовToolStripMenuItem.Name = "редактированиеМаршрутовToolStripMenuItem";
            this.редактированиеМаршрутовToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.редактированиеМаршрутовToolStripMenuItem.Text = "Редактирование маршрутов";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.mnuInfo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1024, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditingRoutes,
            this.тестОбменаДаннымиССД23ToolStripMenuItem,
            this.mnuExit});
            this.менюToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // mnuEditingRoutes
            // 
            this.mnuEditingRoutes.Name = "mnuEditingRoutes";
            this.mnuEditingRoutes.Size = new System.Drawing.Size(268, 22);
            this.mnuEditingRoutes.Text = "Редактирование маршрутов";
            this.mnuEditingRoutes.Click += new System.EventHandler(this.mnuEditingRoutes_Click);
            // 
            // тестОбменаДаннымиССД23ToolStripMenuItem
            // 
            this.тестОбменаДаннымиССД23ToolStripMenuItem.Name = "тестОбменаДаннымиССД23ToolStripMenuItem";
            this.тестОбменаДаннымиССД23ToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.тестОбменаДаннымиССД23ToolStripMenuItem.Text = "Тест обмена данными с СД-23";
            this.тестОбменаДаннымиССД23ToolStripMenuItem.Click += new System.EventHandler(this.тестОбменаДаннымиССД23ToolStripMenuItem_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(268, 22);
            this.mnuExit.Text = "Выход";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuInfo
            // 
            this.mnuInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelp,
            this.mnuAboutProgram});
            this.mnuInfo.Name = "mnuInfo";
            this.mnuInfo.Size = new System.Drawing.Size(103, 20);
            this.mnuInfo.Text = "Информация";
            this.mnuInfo.Click += new System.EventHandler(this.mnuInfo_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(180, 22);
            this.mnuHelp.Text = "Справка";
            // 
            // mnuAboutProgram
            // 
            this.mnuAboutProgram.Name = "mnuAboutProgram";
            this.mnuAboutProgram.Size = new System.Drawing.Size(180, 22);
            this.mnuAboutProgram.Text = "О программе";
            this.mnuAboutProgram.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // labelRoute
            // 
            this.labelRoute.AutoSize = true;
            this.labelRoute.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRoute.Location = new System.Drawing.Point(3, 12);
            this.labelRoute.Name = "labelRoute";
            this.labelRoute.Size = new System.Drawing.Size(80, 14);
            this.labelRoute.TabIndex = 22;
            this.labelRoute.Text = "Маршруты:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblTestStatus);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.butStartTest);
            this.splitContainer1.Panel1.Controls.Add(this.butLable);
            this.splitContainer1.Panel1.Controls.Add(this.butStopTest);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.butDefaultGenerator);
            this.splitContainer1.Panel1.Controls.Add(this.butGeneratorControl);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.grpTest);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            this.splitContainer1.Panel1MinSize = 250;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treRouteTree);
            this.splitContainer1.Panel2.Controls.Add(this.cboSavedRoutes);
            this.splitContainer1.Panel2.Controls.Add(this.labelRoute);
            this.splitContainer1.Size = new System.Drawing.Size(1024, 688);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 23;
            // 
            // lblTestStatus
            // 
            this.lblTestStatus.AutoSize = true;
            this.lblTestStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTestStatus.Location = new System.Drawing.Point(22, 444);
            this.lblTestStatus.Name = "lblTestStatus";
            this.lblTestStatus.Size = new System.Drawing.Size(0, 16);
            this.lblTestStatus.TabIndex = 25;
            this.lblTestStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboTestedDevice);
            this.groupBox2.Controls.Add(this.lblTestedDevice);
            this.groupBox2.Location = new System.Drawing.Point(15, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 76);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // cboTestedDevice
            // 
            this.cboTestedDevice.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboTestedDevice.FormattingEnabled = true;
            this.cboTestedDevice.Location = new System.Drawing.Point(7, 39);
            this.cboTestedDevice.Name = "cboTestedDevice";
            this.cboTestedDevice.Size = new System.Drawing.Size(215, 22);
            this.cboTestedDevice.TabIndex = 1;
            this.cboTestedDevice.SelectedIndexChanged += new System.EventHandler(this.cboTestedDevice_SelectedIndexChanged_1);
            // 
            // lblTestedDevice
            // 
            this.lblTestedDevice.AutoSize = true;
            this.lblTestedDevice.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTestedDevice.Location = new System.Drawing.Point(5, 17);
            this.lblTestedDevice.Name = "lblTestedDevice";
            this.lblTestedDevice.Size = new System.Drawing.Size(222, 14);
            this.lblTestedDevice.TabIndex = 0;
            this.lblTestedDevice.Text = "Подключить поверяемый прибор";
            // 
            // butStartTest
            // 
            this.butStartTest.BackColor = System.Drawing.Color.Transparent;
            this.butStartTest.BackgroundImage = global::ManagerDS360.Properties.Resources.Заготовки;
            this.butStartTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butStartTest.FlatAppearance.BorderSize = 0;
            this.butStartTest.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butStartTest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butStartTest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butStartTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butStartTest.Location = new System.Drawing.Point(142, 378);
            this.butStartTest.Name = "butStartTest";
            this.butStartTest.Size = new System.Drawing.Size(65, 56);
            this.butStartTest.TabIndex = 24;
            this.butStartTest.UseVisualStyleBackColor = false;
            this.butStartTest.Click += new System.EventHandler(this.butStartTest_Click);
            // 
            // butLable
            // 
            this.butLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLable.BackColor = System.Drawing.Color.Transparent;
            this.butLable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("butLable.BackgroundImage")));
            this.butLable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butLable.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.butLable.FlatAppearance.BorderSize = 0;
            this.butLable.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butLable.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butLable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butLable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butLable.Location = new System.Drawing.Point(15, 560);
            this.butLable.Name = "butLable";
            this.butLable.Size = new System.Drawing.Size(217, 102);
            this.butLable.TabIndex = 20;
            this.butLable.UseVisualStyleBackColor = false;
            this.butLable.Click += new System.EventHandler(this.butLable_Click);
            // 
            // butStopTest
            // 
            this.butStopTest.BackColor = System.Drawing.Color.Transparent;
            this.butStopTest.BackgroundImage = global::ManagerDS360.Properties.Resources.Стоп_серый;
            this.butStopTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butStopTest.FlatAppearance.BorderSize = 0;
            this.butStopTest.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butStopTest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butStopTest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butStopTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butStopTest.Location = new System.Drawing.Point(56, 379);
            this.butStopTest.Name = "butStopTest";
            this.butStopTest.Size = new System.Drawing.Size(66, 52);
            this.butStopTest.TabIndex = 23;
            this.butStopTest.UseVisualStyleBackColor = false;
            this.butStopTest.Click += new System.EventHandler(this.butStopTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(28, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 28);
            this.label1.TabIndex = 22;
            this.label1.Text = "Выполнить последовательно\r\n команды";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpTest
            // 
            this.grpTest.Location = new System.Drawing.Point(15, 321);
            this.grpTest.Name = "grpTest";
            this.grpTest.Size = new System.Drawing.Size(227, 159);
            this.grpTest.TabIndex = 26;
            this.grpTest.TabStop = false;
            this.grpTest.Enter += new System.EventHandler(this.groupBox3_Enter_1);
            // 
            // treRouteTree
            // 
            this.treRouteTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treRouteTree.CheckBoxes = true;
            this.treRouteTree.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treRouteTree.ImageIndex = 0;
            this.treRouteTree.Location = new System.Drawing.Point(6, 56);
            this.treRouteTree.Name = "treRouteTree";
            this.treRouteTree.SelectedImageIndex = 0;
            this.treRouteTree.Size = new System.Drawing.Size(752, 614);
            this.treRouteTree.TabIndex = 7;
            // 
            // frmManagerDS360
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 715);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(500, 553);
            this.Name = "frmManagerDS360";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DS360";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmManagerDS360_Closing);
            this.Load += new System.EventHandler(this.frmManagerDS360_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button butDefaultGenerator;
        private System.Windows.Forms.ComboBox cboSavedRoutes;
        private System.Windows.Forms.Button butGeneratorControl;
        private LibControls.TreeViewWithSetting treRouteTree;
        private System.Windows.Forms.Label lblSelectedNode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem редактированиеМаршрутовToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEditingRoutes;
        private System.Windows.Forms.ToolStripMenuItem mnuInfo;
        private System.Windows.Forms.Label labelRoute;
        private System.Windows.Forms.Button butNext;
        private System.Windows.Forms.Button butPrevious;
        private System.Windows.Forms.Button butPlay;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAboutProgram;
        private LibControls.ButtonForPicture butLable;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem тестОбменаДаннымиССД23ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboTestedDevice;
        private System.Windows.Forms.Label lblTestedDevice;
        private System.Windows.Forms.Label lblTestStatus;
        private LibControls.ButtonForPicture butStartTest;
        private LibControls.ButtonForPicture butStopTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpTest;
    }
}


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
            this.lblSelectedNode = new System.Windows.Forms.Label();
            this.grpCommand = new System.Windows.Forms.GroupBox();
            this.butPlay = new LibControls.ButtonForPicture();
            this.lblCommandStatus = new System.Windows.Forms.Label();
            this.butNext = new System.Windows.Forms.Button();
            this.butPrevious = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.редактированиеМаршрутовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditingRoutes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFrequencyResponses = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCboFrequencyResponse = new System.Windows.Forms.ToolStripComboBox();
            this.mnuSettingFrequencyResponse = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAboutProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuForTest = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTestFirst = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.поискЗначенийСКЗНеПоддерживаемыDS360ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проверкаКоррекцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelRoute = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboTestedDevice = new System.Windows.Forms.ComboBox();
            this.lblTestedDevice = new System.Windows.Forms.Label();
            this.butStartTest = new LibControls.ButtonForPicture();
            this.butLable = new LibControls.ButtonForPicture();
            this.butStopTest = new LibControls.ButtonForPicture();
            this.label1 = new System.Windows.Forms.Label();
            this.grpTest = new System.Windows.Forms.GroupBox();
            this.lblTestStatus = new System.Windows.Forms.Label();
            this.grpStend = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblVibCalibStatus = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblCurentParametr = new System.Windows.Forms.Label();
            this.lblStendCurrent = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblParametrToHold = new System.Windows.Forms.Label();
            this.lblFreq = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.butVibCalibSetting = new LibControls.ButtonForPicture();
            this.butVibCalibStop = new LibControls.ButtonForPicture();
            this.label2 = new System.Windows.Forms.Label();
            this.treRouteTree = new LibControls.TreeViewWithSetting();
            this.grpCommand.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpTest.SuspendLayout();
            this.grpStend.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // butDefaultGenerator
            // 
            this.butDefaultGenerator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butDefaultGenerator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.butDefaultGenerator.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.butDefaultGenerator.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.butDefaultGenerator.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butDefaultGenerator.Location = new System.Drawing.Point(15, 16);
            this.butDefaultGenerator.Name = "butDefaultGenerator";
            this.butDefaultGenerator.Size = new System.Drawing.Size(230, 38);
            this.butDefaultGenerator.TabIndex = 2;
            this.butDefaultGenerator.Text = "Средства поверки";
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
            this.cboSavedRoutes.Location = new System.Drawing.Point(3, 28);
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
            this.butGeneratorControl.Location = new System.Drawing.Point(15, 63);
            this.butGeneratorControl.Name = "butGeneratorControl";
            this.butGeneratorControl.Size = new System.Drawing.Size(230, 38);
            this.butGeneratorControl.TabIndex = 3;
            this.butGeneratorControl.Text = "Управление DS360";
            this.butGeneratorControl.UseVisualStyleBackColor = false;
            this.butGeneratorControl.Click += new System.EventHandler(this.butGeneratorControl_Click);
            // 
            // lblSelectedNode
            // 
            this.lblSelectedNode.AutoSize = true;
            this.lblSelectedNode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSelectedNode.Location = new System.Drawing.Point(9, 16);
            this.lblSelectedNode.Name = "lblSelectedNode";
            this.lblSelectedNode.Size = new System.Drawing.Size(206, 14);
            this.lblSelectedNode.TabIndex = 18;
            this.lblSelectedNode.Text = "Активировать команду дерева";
            this.lblSelectedNode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpCommand
            // 
            this.grpCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCommand.Controls.Add(this.butPlay);
            this.grpCommand.Controls.Add(this.lblCommandStatus);
            this.grpCommand.Controls.Add(this.butNext);
            this.grpCommand.Controls.Add(this.butPrevious);
            this.grpCommand.Controls.Add(this.lblSelectedNode);
            this.grpCommand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpCommand.Location = new System.Drawing.Point(15, 189);
            this.grpCommand.Name = "grpCommand";
            this.grpCommand.Size = new System.Drawing.Size(227, 120);
            this.grpCommand.TabIndex = 19;
            this.grpCommand.TabStop = false;
            // 
            // butPlay
            // 
            this.butPlay.BackColor = System.Drawing.Color.Transparent;
            this.butPlay.BackgroundImage = global::ManagerDS360.Properties.Resources.Заготовки;
            this.butPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butPlay.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.butPlay.FlatAppearance.BorderSize = 0;
            this.butPlay.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butPlay.Location = new System.Drawing.Point(87, 33);
            this.butPlay.Name = "butPlay";
            this.butPlay.Size = new System.Drawing.Size(59, 65);
            this.butPlay.TabIndex = 32;
            this.butPlay.UseVisualStyleBackColor = false;
            this.butPlay.Click += new System.EventHandler(this.butPlay_Click);
            // 
            // lblCommandStatus
            // 
            this.lblCommandStatus.AutoSize = true;
            this.lblCommandStatus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCommandStatus.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCommandStatus.Location = new System.Drawing.Point(99, 101);
            this.lblCommandStatus.Name = "lblCommandStatus";
            this.lblCommandStatus.Size = new System.Drawing.Size(17, 14);
            this.lblCommandStatus.TabIndex = 31;
            this.lblCommandStatus.Text = "--";
            this.lblCommandStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.butNext.Location = new System.Drawing.Point(160, 51);
            this.butNext.Name = "butNext";
            this.butNext.Size = new System.Drawing.Size(55, 30);
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
            this.butPrevious.Location = new System.Drawing.Point(15, 51);
            this.butPrevious.Name = "butPrevious";
            this.butPrevious.Size = new System.Drawing.Size(56, 30);
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
            this.mnuInfo,
            this.mnuForTest});
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
            this.mnuFrequencyResponses,
            this.mnuExit});
            this.менюToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // mnuEditingRoutes
            // 
            this.mnuEditingRoutes.Name = "mnuEditingRoutes";
            this.mnuEditingRoutes.Size = new System.Drawing.Size(259, 22);
            this.mnuEditingRoutes.Text = "Редактирование маршрутов";
            this.mnuEditingRoutes.Click += new System.EventHandler(this.mnuEditingRoutes_Click);
            // 
            // mnuFrequencyResponses
            // 
            this.mnuFrequencyResponses.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCboFrequencyResponse,
            this.mnuSettingFrequencyResponse});
            this.mnuFrequencyResponses.Name = "mnuFrequencyResponses";
            this.mnuFrequencyResponses.Size = new System.Drawing.Size(259, 22);
            this.mnuFrequencyResponses.Text = "АЧХ вибростенда";
            this.mnuFrequencyResponses.Click += new System.EventHandler(this.аЧХВибростендаToolStripMenuItem_Click);
            // 
            // mnuCboFrequencyResponse
            // 
            this.mnuCboFrequencyResponse.Name = "mnuCboFrequencyResponse";
            this.mnuCboFrequencyResponse.Size = new System.Drawing.Size(121, 23);
            this.mnuCboFrequencyResponse.Click += new System.EventHandler(this.mnuCboFrequencyResponse_Click);
            // 
            // mnuSettingFrequencyResponse
            // 
            this.mnuSettingFrequencyResponse.Name = "mnuSettingFrequencyResponse";
            this.mnuSettingFrequencyResponse.Size = new System.Drawing.Size(181, 22);
            this.mnuSettingFrequencyResponse.Text = "Настройка";
            this.mnuSettingFrequencyResponse.Click += new System.EventHandler(this.mnuSettingFrequencyResponse_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(259, 22);
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
            this.mnuHelp.Click += new System.EventHandler(this.mnuHelp_Click);
            // 
            // mnuAboutProgram
            // 
            this.mnuAboutProgram.Name = "mnuAboutProgram";
            this.mnuAboutProgram.Size = new System.Drawing.Size(180, 22);
            this.mnuAboutProgram.Text = "О программе";
            this.mnuAboutProgram.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // mnuForTest
            // 
            this.mnuForTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTestFirst,
            this.toolStripMenuItem1,
            this.поискЗначенийСКЗНеПоддерживаемыDS360ToolStripMenuItem,
            this.проверкаКоррекцииToolStripMenuItem});
            this.mnuForTest.Name = "mnuForTest";
            this.mnuForTest.Size = new System.Drawing.Size(89, 20);
            this.mnuForTest.Text = "Для тестов";
            this.mnuForTest.Visible = false;
            // 
            // mnuTestFirst
            // 
            this.mnuTestFirst.Name = "mnuTestFirst";
            this.mnuTestFirst.Size = new System.Drawing.Size(382, 22);
            this.mnuTestFirst.Text = "тест омбена СД-23";
            this.mnuTestFirst.Click += new System.EventHandler(this.тестОбменаДаннымиССД23ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(382, 22);
            this.toolStripMenuItem1.Text = "число обращений к DS360";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // поискЗначенийСКЗНеПоддерживаемыDS360ToolStripMenuItem
            // 
            this.поискЗначенийСКЗНеПоддерживаемыDS360ToolStripMenuItem.Name = "поискЗначенийСКЗНеПоддерживаемыDS360ToolStripMenuItem";
            this.поискЗначенийСКЗНеПоддерживаемыDS360ToolStripMenuItem.Size = new System.Drawing.Size(382, 22);
            this.поискЗначенийСКЗНеПоддерживаемыDS360ToolStripMenuItem.Text = "Поиск значений СКЗ не поддерживаемы DS360";
            this.поискЗначенийСКЗНеПоддерживаемыDS360ToolStripMenuItem.Click += new System.EventHandler(this.поискЗначенийСКЗНеПоддерживаемыDS360ToolStripMenuItem_Click);
            // 
            // проверкаКоррекцииToolStripMenuItem
            // 
            this.проверкаКоррекцииToolStripMenuItem.Name = "проверкаКоррекцииToolStripMenuItem";
            this.проверкаКоррекцииToolStripMenuItem.Size = new System.Drawing.Size(382, 22);
            this.проверкаКоррекцииToolStripMenuItem.Text = "Проверка коррекции";
            this.проверкаКоррекцииToolStripMenuItem.Click += new System.EventHandler(this.проверкаКоррекцииToolStripMenuItem_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.butStartTest);
            this.splitContainer1.Panel1.Controls.Add(this.butLable);
            this.splitContainer1.Panel1.Controls.Add(this.butStopTest);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.butDefaultGenerator);
            this.splitContainer1.Panel1.Controls.Add(this.butGeneratorControl);
            this.splitContainer1.Panel1.Controls.Add(this.grpCommand);
            this.splitContainer1.Panel1.Controls.Add(this.grpTest);
            this.splitContainer1.Panel1.Controls.Add(this.grpStend);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            this.splitContainer1.Panel1MinSize = 250;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treRouteTree);
            this.splitContainer1.Panel2.Controls.Add(this.cboSavedRoutes);
            this.splitContainer1.Panel2.Controls.Add(this.labelRoute);
            this.splitContainer1.Size = new System.Drawing.Size(1024, 874);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 23;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboTestedDevice);
            this.groupBox2.Controls.Add(this.lblTestedDevice);
            this.groupBox2.Location = new System.Drawing.Point(15, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 76);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // cboTestedDevice
            // 
            this.cboTestedDevice.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboTestedDevice.FormattingEnabled = true;
            this.cboTestedDevice.Location = new System.Drawing.Point(6, 39);
            this.cboTestedDevice.Name = "cboTestedDevice";
            this.cboTestedDevice.Size = new System.Drawing.Size(215, 22);
            this.cboTestedDevice.TabIndex = 1;
            this.cboTestedDevice.SelectedIndexChanged += new System.EventHandler(this.cboTestedDevice_SelectedIndexChanged_1);
            this.cboTestedDevice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTestedDevice_KeyPress);
            // 
            // lblTestedDevice
            // 
            this.lblTestedDevice.AutoSize = true;
            this.lblTestedDevice.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTestedDevice.Location = new System.Drawing.Point(3, 17);
            this.lblTestedDevice.Name = "lblTestedDevice";
            this.lblTestedDevice.Size = new System.Drawing.Size(222, 14);
            this.lblTestedDevice.TabIndex = 0;
            this.lblTestedDevice.Text = "Подключить поверяемый прибор";
            // 
            // butStartTest
            // 
            this.butStartTest.BackColor = System.Drawing.Color.Transparent;
            this.butStartTest.BackgroundImage = global::ManagerDS360.Properties.Resources.Play;
            this.butStartTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butStartTest.FlatAppearance.BorderSize = 0;
            this.butStartTest.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butStartTest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butStartTest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butStartTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butStartTest.Location = new System.Drawing.Point(131, 359);
            this.butStartTest.Name = "butStartTest";
            this.butStartTest.Size = new System.Drawing.Size(66, 52);
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
            this.butLable.Location = new System.Drawing.Point(15, 746);
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
            this.butStopTest.Location = new System.Drawing.Point(65, 363);
            this.butStopTest.Name = "butStopTest";
            this.butStopTest.Size = new System.Drawing.Size(51, 45);
            this.butStopTest.TabIndex = 23;
            this.butStopTest.UseVisualStyleBackColor = false;
            this.butStopTest.Click += new System.EventHandler(this.butStopTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(28, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 28);
            this.label1.TabIndex = 22;
            this.label1.Text = "Выполнить последовательно\r\n команды дерева";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpTest
            // 
            this.grpTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTest.Controls.Add(this.lblTestStatus);
            this.grpTest.Location = new System.Drawing.Point(15, 309);
            this.grpTest.Name = "grpTest";
            this.grpTest.Size = new System.Drawing.Size(227, 137);
            this.grpTest.TabIndex = 26;
            this.grpTest.TabStop = false;
            this.grpTest.Enter += new System.EventHandler(this.groupBox3_Enter_1);
            // 
            // lblTestStatus
            // 
            this.lblTestStatus.AutoSize = true;
            this.lblTestStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTestStatus.Location = new System.Drawing.Point(99, 115);
            this.lblTestStatus.Name = "lblTestStatus";
            this.lblTestStatus.Size = new System.Drawing.Size(22, 16);
            this.lblTestStatus.TabIndex = 25;
            this.lblTestStatus.Text = "--";
            this.lblTestStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpStend
            // 
            this.grpStend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStend.Controls.Add(this.groupBox3);
            this.grpStend.Controls.Add(this.groupBox5);
            this.grpStend.Controls.Add(this.groupBox4);
            this.grpStend.Controls.Add(this.butVibCalibSetting);
            this.grpStend.Controls.Add(this.butVibCalibStop);
            this.grpStend.Controls.Add(this.label2);
            this.grpStend.Location = new System.Drawing.Point(15, 448);
            this.grpStend.Name = "grpStend";
            this.grpStend.Size = new System.Drawing.Size(227, 273);
            this.grpStend.TabIndex = 27;
            this.grpStend.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lblVibCalibStatus);
            this.groupBox3.Location = new System.Drawing.Point(9, 211);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(209, 50);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(76, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 14);
            this.label5.TabIndex = 30;
            this.label5.Text = "Статус:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVibCalibStatus
            // 
            this.lblVibCalibStatus.AutoSize = true;
            this.lblVibCalibStatus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVibCalibStatus.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblVibCalibStatus.Location = new System.Drawing.Point(97, 29);
            this.lblVibCalibStatus.Name = "lblVibCalibStatus";
            this.lblVibCalibStatus.Size = new System.Drawing.Size(17, 14);
            this.lblVibCalibStatus.TabIndex = 30;
            this.lblVibCalibStatus.Text = "--";
            this.lblVibCalibStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblCurentParametr);
            this.groupBox5.Controls.Add(this.lblStendCurrent);
            this.groupBox5.Location = new System.Drawing.Point(9, 75);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(209, 62);
            this.groupBox5.TabIndex = 35;
            this.groupBox5.TabStop = false;
            // 
            // lblCurentParametr
            // 
            this.lblCurentParametr.AutoSize = true;
            this.lblCurentParametr.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurentParametr.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblCurentParametr.Location = new System.Drawing.Point(96, 35);
            this.lblCurentParametr.Name = "lblCurentParametr";
            this.lblCurentParametr.Size = new System.Drawing.Size(19, 14);
            this.lblCurentParametr.TabIndex = 33;
            this.lblCurentParametr.Text = "--";
            this.lblCurentParametr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStendCurrent
            // 
            this.lblStendCurrent.AutoSize = true;
            this.lblStendCurrent.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStendCurrent.Location = new System.Drawing.Point(62, 11);
            this.lblStendCurrent.Name = "lblStendCurrent";
            this.lblStendCurrent.Size = new System.Drawing.Size(95, 14);
            this.lblStendCurrent.TabIndex = 30;
            this.lblStendCurrent.Text = "Установлено:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblParametrToHold);
            this.groupBox4.Controls.Add(this.lblFreq);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(9, 138);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(209, 72);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            // 
            // lblParametrToHold
            // 
            this.lblParametrToHold.AutoSize = true;
            this.lblParametrToHold.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblParametrToHold.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblParametrToHold.Location = new System.Drawing.Point(94, 49);
            this.lblParametrToHold.Name = "lblParametrToHold";
            this.lblParametrToHold.Size = new System.Drawing.Size(17, 14);
            this.lblParametrToHold.TabIndex = 32;
            this.lblParametrToHold.Text = "--";
            this.lblParametrToHold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFreq
            // 
            this.lblFreq.AutoSize = true;
            this.lblFreq.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFreq.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblFreq.Location = new System.Drawing.Point(94, 29);
            this.lblFreq.Name = "lblFreq";
            this.lblFreq.Size = new System.Drawing.Size(17, 14);
            this.lblFreq.TabIndex = 31;
            this.lblFreq.Text = "--";
            this.lblFreq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(76, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 14);
            this.label3.TabIndex = 30;
            this.label3.Text = "Задано:";
            // 
            // butVibCalibSetting
            // 
            this.butVibCalibSetting.BackColor = System.Drawing.Color.Transparent;
            this.butVibCalibSetting.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("butVibCalibSetting.BackgroundImage")));
            this.butVibCalibSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butVibCalibSetting.FlatAppearance.BorderSize = 0;
            this.butVibCalibSetting.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butVibCalibSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butVibCalibSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butVibCalibSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butVibCalibSetting.Location = new System.Drawing.Point(123, 33);
            this.butVibCalibSetting.Name = "butVibCalibSetting";
            this.butVibCalibSetting.Size = new System.Drawing.Size(41, 46);
            this.butVibCalibSetting.TabIndex = 29;
            this.butVibCalibSetting.UseVisualStyleBackColor = false;
            this.butVibCalibSetting.Click += new System.EventHandler(this.butVibCalibSetting_Click);
            // 
            // butVibCalibStop
            // 
            this.butVibCalibStop.BackColor = System.Drawing.Color.Transparent;
            this.butVibCalibStop.BackgroundImage = global::ManagerDS360.Properties.Resources.Стоп_серый;
            this.butVibCalibStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butVibCalibStop.FlatAppearance.BorderSize = 0;
            this.butVibCalibStop.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.butVibCalibStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butVibCalibStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butVibCalibStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butVibCalibStop.Location = new System.Drawing.Point(51, 34);
            this.butVibCalibStop.Name = "butVibCalibStop";
            this.butVibCalibStop.Size = new System.Drawing.Size(51, 42);
            this.butVibCalibStop.TabIndex = 29;
            this.butVibCalibStop.UseVisualStyleBackColor = false;
            this.butVibCalibStop.Click += new System.EventHandler(this.butVibCalibStop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(27, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 14);
            this.label2.TabIndex = 28;
            this.label2.Text = "Вибрационная установка";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // treRouteTree
            // 
            this.treRouteTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treRouteTree.CheckBoxes = true;
            this.treRouteTree.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treRouteTree.ImageIndex = 0;
            this.treRouteTree.Location = new System.Drawing.Point(3, 56);
            this.treRouteTree.Name = "treRouteTree";
            this.treRouteTree.SelectedImageIndex = 0;
            this.treRouteTree.Size = new System.Drawing.Size(752, 800);
            this.treRouteTree.TabIndex = 7;
            this.treRouteTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treRouteTree_MouseDoubleClick);
            // 
            // frmManagerDS360
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 901);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1040, 940);
            this.Name = "frmManagerDS360";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление средствами поверки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmManagerDS360_Closing);
            this.Load += new System.EventHandler(this.frmManagerDS360_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.grpCommand.ResumeLayout(false);
            this.grpCommand.PerformLayout();
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
            this.grpTest.ResumeLayout(false);
            this.grpTest.PerformLayout();
            this.grpStend.ResumeLayout(false);
            this.grpStend.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button butDefaultGenerator;
        private System.Windows.Forms.ComboBox cboSavedRoutes;
        private System.Windows.Forms.Button butGeneratorControl;
        private LibControls.TreeViewWithSetting treRouteTree;
        private System.Windows.Forms.Label lblSelectedNode;
        private System.Windows.Forms.GroupBox grpCommand;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem редактированиеМаршрутовToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEditingRoutes;
        private System.Windows.Forms.ToolStripMenuItem mnuInfo;
        private System.Windows.Forms.Label labelRoute;
        private System.Windows.Forms.Button butNext;
        private System.Windows.Forms.Button butPrevious;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAboutProgram;
        private LibControls.ButtonForPicture butLable;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboTestedDevice;
        private System.Windows.Forms.Label lblTestedDevice;
        private System.Windows.Forms.Label lblTestStatus;
        private LibControls.ButtonForPicture butStartTest;
        private LibControls.ButtonForPicture butStopTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpTest;
        private System.Windows.Forms.ToolStripMenuItem mnuForTest;
        private System.Windows.Forms.ToolStripMenuItem mnuTestFirst;
        private System.Windows.Forms.GroupBox grpStend;
        private LibControls.ButtonForPicture butVibCalibStop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVibCalibStatus;
        private System.Windows.Forms.Label lblCurentParametr;
        private System.Windows.Forms.Label lblParametrToHold;
        private System.Windows.Forms.Label lblFreq;
        private System.Windows.Forms.Label lblStendCurrent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private LibControls.ButtonForPicture butVibCalibSetting;
        private System.Windows.Forms.ToolStripMenuItem mnuFrequencyResponses;
        private System.Windows.Forms.ToolStripComboBox mnuCboFrequencyResponse;
        private System.Windows.Forms.ToolStripMenuItem mnuSettingFrequencyResponse;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem поискЗначенийСКЗНеПоддерживаемыDS360ToolStripMenuItem;
        private System.Windows.Forms.Label lblCommandStatus;
        private System.Windows.Forms.ToolStripMenuItem проверкаКоррекцииToolStripMenuItem;
        private LibControls.ButtonForPicture butPlay;
    }
}


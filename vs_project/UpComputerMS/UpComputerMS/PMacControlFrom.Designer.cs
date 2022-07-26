namespace UpComputerMS
{
    partial class PMacControlFrom
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.communicationGroup = new System.Windows.Forms.GroupBox();
            this.deSelectDevice = new System.Windows.Forms.Button();
            this.selectStatus = new System.Windows.Forms.TextBox();
            this.statuLabel = new System.Windows.Forms.Label();
            this.selectDevice = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chooseMotorV = new System.Windows.Forms.TextBox();
            this.speedChooseMotorLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chooseMotorPos = new System.Windows.Forms.TextBox();
            this.chooseMotorLabel = new System.Windows.Forms.Label();
            this.xUnitLabel = new System.Windows.Forms.Label();
            this.yUnitLabel = new System.Windows.Forms.Label();
            this.yUnitSpeedLabel = new System.Windows.Forms.Label();
            this.xUnitSpeedLabel = new System.Windows.Forms.Label();
            this.yCurrentSpeed = new System.Windows.Forms.TextBox();
            this.xCurrentSpeed = new System.Windows.Forms.TextBox();
            this.ySpeedLabel = new System.Windows.Forms.Label();
            this.xSpeedLabel = new System.Windows.Forms.Label();
            this.xPosition = new System.Windows.Forms.TextBox();
            this.xPosLabel = new System.Windows.Forms.Label();
            this.yPosition = new System.Windows.Forms.TextBox();
            this.yPosLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timerCurrentPosAndSpeedInfo = new System.Windows.Forms.Timer(this.components);
            this.dotRight = new System.Windows.Forms.Button();
            this.dotLeft = new System.Windows.Forms.Button();
            this.dotDown = new System.Windows.Forms.Button();
            this.dotUp = new System.Windows.Forms.Button();
            this.initZero = new System.Windows.Forms.Button();
            this.dotStep = new System.Windows.Forms.TextBox();
            this.dotStepLabel = new System.Windows.Forms.Label();
            this.stopMove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.stepOne = new System.Windows.Forms.CheckBox();
            this.jogHerePos = new System.Windows.Forms.TextBox();
            this.jogHere = new System.Windows.Forms.Button();
            this.motorLabel = new System.Windows.Forms.Label();
            this.ctLabel = new System.Windows.Forms.Label();
            this.motorCombo = new System.Windows.Forms.ComboBox();
            this.xMotorLabel = new System.Windows.Forms.Label();
            this.yMotorLabel = new System.Windows.Forms.Label();
            this.xMotor = new System.Windows.Forms.ComboBox();
            this.yMotor = new System.Windows.Forms.ComboBox();
            this.homeZMotor = new System.Windows.Forms.Button();
            this.speedLabel = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.setSpeedBTN = new System.Windows.Forms.Button();
            this.Group_Jog = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.communicationGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Group_Jog.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.communicationGroup, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(28, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.80597F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(677, 161);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // communicationGroup
            // 
            this.communicationGroup.Controls.Add(this.deSelectDevice);
            this.communicationGroup.Controls.Add(this.selectStatus);
            this.communicationGroup.Controls.Add(this.statuLabel);
            this.communicationGroup.Controls.Add(this.selectDevice);
            this.communicationGroup.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.communicationGroup.Location = new System.Drawing.Point(2, 2);
            this.communicationGroup.Margin = new System.Windows.Forms.Padding(2);
            this.communicationGroup.Name = "communicationGroup";
            this.communicationGroup.Padding = new System.Windows.Forms.Padding(2);
            this.communicationGroup.Size = new System.Drawing.Size(230, 152);
            this.communicationGroup.TabIndex = 19;
            this.communicationGroup.TabStop = false;
            this.communicationGroup.Text = "通讯";
            // 
            // deSelectDevice
            // 
            this.deSelectDevice.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deSelectDevice.Location = new System.Drawing.Point(148, 83);
            this.deSelectDevice.Margin = new System.Windows.Forms.Padding(2);
            this.deSelectDevice.Name = "deSelectDevice";
            this.deSelectDevice.Size = new System.Drawing.Size(71, 32);
            this.deSelectDevice.TabIndex = 16;
            this.deSelectDevice.Text = "断开";
            this.deSelectDevice.UseVisualStyleBackColor = true;
            this.deSelectDevice.Click += new System.EventHandler(this.DeSelectDevice_Click);
            // 
            // selectStatus
            // 
            this.selectStatus.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selectStatus.Location = new System.Drawing.Point(80, 35);
            this.selectStatus.Margin = new System.Windows.Forms.Padding(2);
            this.selectStatus.Name = "selectStatus";
            this.selectStatus.ReadOnly = true;
            this.selectStatus.Size = new System.Drawing.Size(57, 21);
            this.selectStatus.TabIndex = 11;
            this.selectStatus.Text = "未连接";
            this.selectStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // statuLabel
            // 
            this.statuLabel.AutoSize = true;
            this.statuLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statuLabel.Location = new System.Drawing.Point(17, 36);
            this.statuLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.statuLabel.Name = "statuLabel";
            this.statuLabel.Size = new System.Drawing.Size(59, 12);
            this.statuLabel.TabIndex = 12;
            this.statuLabel.Text = "通讯状态:";
            // 
            // selectDevice
            // 
            this.selectDevice.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selectDevice.Location = new System.Drawing.Point(148, 36);
            this.selectDevice.Margin = new System.Windows.Forms.Padding(2);
            this.selectDevice.Name = "selectDevice";
            this.selectDevice.Size = new System.Drawing.Size(71, 34);
            this.selectDevice.TabIndex = 0;
            this.selectDevice.Text = "通讯";
            this.selectDevice.UseVisualStyleBackColor = true;
            this.selectDevice.Click += new System.EventHandler(this.SelectDevice_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.chooseMotorV);
            this.groupBox1.Controls.Add(this.speedChooseMotorLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chooseMotorPos);
            this.groupBox1.Controls.Add(this.chooseMotorLabel);
            this.groupBox1.Controls.Add(this.xUnitLabel);
            this.groupBox1.Controls.Add(this.yUnitLabel);
            this.groupBox1.Controls.Add(this.yUnitSpeedLabel);
            this.groupBox1.Controls.Add(this.xUnitSpeedLabel);
            this.groupBox1.Controls.Add(this.yCurrentSpeed);
            this.groupBox1.Controls.Add(this.xCurrentSpeed);
            this.groupBox1.Controls.Add(this.ySpeedLabel);
            this.groupBox1.Controls.Add(this.xSpeedLabel);
            this.groupBox1.Controls.Add(this.xPosition);
            this.groupBox1.Controls.Add(this.xPosLabel);
            this.groupBox1.Controls.Add(this.yPosition);
            this.groupBox1.Controls.Add(this.yPosLabel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(237, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 155);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "位置速度信息";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(335, 107);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 49;
            this.label4.Text = "ct/ms";
            // 
            // chooseMotorV
            // 
            this.chooseMotorV.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chooseMotorV.Location = new System.Drawing.Point(247, 102);
            this.chooseMotorV.Margin = new System.Windows.Forms.Padding(2);
            this.chooseMotorV.Name = "chooseMotorV";
            this.chooseMotorV.ReadOnly = true;
            this.chooseMotorV.Size = new System.Drawing.Size(87, 26);
            this.chooseMotorV.TabIndex = 48;
            this.chooseMotorV.Text = "0.0";
            this.chooseMotorV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // speedChooseMotorLabel
            // 
            this.speedChooseMotorLabel.AutoSize = true;
            this.speedChooseMotorLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.speedChooseMotorLabel.Location = new System.Drawing.Point(203, 107);
            this.speedChooseMotorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.speedChooseMotorLabel.Name = "speedChooseMotorLabel";
            this.speedChooseMotorLabel.Size = new System.Drawing.Size(47, 16);
            this.speedChooseMotorLabel.TabIndex = 47;
            this.speedChooseMotorLabel.Text = "速度:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(186, 107);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 46;
            this.label3.Text = "ct";
            // 
            // chooseMotorPos
            // 
            this.chooseMotorPos.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chooseMotorPos.Location = new System.Drawing.Point(95, 101);
            this.chooseMotorPos.Margin = new System.Windows.Forms.Padding(2);
            this.chooseMotorPos.Name = "chooseMotorPos";
            this.chooseMotorPos.ReadOnly = true;
            this.chooseMotorPos.Size = new System.Drawing.Size(88, 26);
            this.chooseMotorPos.TabIndex = 45;
            this.chooseMotorPos.Text = "0.0";
            this.chooseMotorPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chooseMotorLabel
            // 
            this.chooseMotorLabel.AutoSize = true;
            this.chooseMotorLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chooseMotorLabel.Location = new System.Drawing.Point(5, 105);
            this.chooseMotorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.chooseMotorLabel.Name = "chooseMotorLabel";
            this.chooseMotorLabel.Size = new System.Drawing.Size(87, 16);
            this.chooseMotorLabel.TabIndex = 44;
            this.chooseMotorLabel.Text = "电机1坐标:";
            // 
            // xUnitLabel
            // 
            this.xUnitLabel.AutoSize = true;
            this.xUnitLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xUnitLabel.Location = new System.Drawing.Point(158, 41);
            this.xUnitLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.xUnitLabel.Name = "xUnitLabel";
            this.xUnitLabel.Size = new System.Drawing.Size(17, 12);
            this.xUnitLabel.TabIndex = 43;
            this.xUnitLabel.Text = "ct";
            // 
            // yUnitLabel
            // 
            this.yUnitLabel.AutoSize = true;
            this.yUnitLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yUnitLabel.Location = new System.Drawing.Point(158, 72);
            this.yUnitLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yUnitLabel.Name = "yUnitLabel";
            this.yUnitLabel.Size = new System.Drawing.Size(17, 12);
            this.yUnitLabel.TabIndex = 42;
            this.yUnitLabel.Text = "ct";
            // 
            // yUnitSpeedLabel
            // 
            this.yUnitSpeedLabel.AutoSize = true;
            this.yUnitSpeedLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yUnitSpeedLabel.Location = new System.Drawing.Point(335, 72);
            this.yUnitSpeedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yUnitSpeedLabel.Name = "yUnitSpeedLabel";
            this.yUnitSpeedLabel.Size = new System.Drawing.Size(35, 12);
            this.yUnitSpeedLabel.TabIndex = 41;
            this.yUnitSpeedLabel.Text = "ct/ms";
            // 
            // xUnitSpeedLabel
            // 
            this.xUnitSpeedLabel.AutoSize = true;
            this.xUnitSpeedLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xUnitSpeedLabel.Location = new System.Drawing.Point(335, 38);
            this.xUnitSpeedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.xUnitSpeedLabel.Name = "xUnitSpeedLabel";
            this.xUnitSpeedLabel.Size = new System.Drawing.Size(35, 12);
            this.xUnitSpeedLabel.TabIndex = 40;
            this.xUnitSpeedLabel.Text = "ct/ms";
            // 
            // yCurrentSpeed
            // 
            this.yCurrentSpeed.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yCurrentSpeed.Location = new System.Drawing.Point(247, 66);
            this.yCurrentSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.yCurrentSpeed.Name = "yCurrentSpeed";
            this.yCurrentSpeed.ReadOnly = true;
            this.yCurrentSpeed.Size = new System.Drawing.Size(87, 26);
            this.yCurrentSpeed.TabIndex = 39;
            this.yCurrentSpeed.Text = "0.0";
            this.yCurrentSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xCurrentSpeed
            // 
            this.xCurrentSpeed.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xCurrentSpeed.Location = new System.Drawing.Point(247, 32);
            this.xCurrentSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.xCurrentSpeed.Name = "xCurrentSpeed";
            this.xCurrentSpeed.ReadOnly = true;
            this.xCurrentSpeed.Size = new System.Drawing.Size(87, 26);
            this.xCurrentSpeed.TabIndex = 38;
            this.xCurrentSpeed.Text = "0.0";
            this.xCurrentSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ySpeedLabel
            // 
            this.ySpeedLabel.AutoSize = true;
            this.ySpeedLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ySpeedLabel.Location = new System.Drawing.Point(195, 68);
            this.ySpeedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ySpeedLabel.Name = "ySpeedLabel";
            this.ySpeedLabel.Size = new System.Drawing.Size(55, 16);
            this.ySpeedLabel.TabIndex = 37;
            this.ySpeedLabel.Text = "Y速度:";
            // 
            // xSpeedLabel
            // 
            this.xSpeedLabel.AutoSize = true;
            this.xSpeedLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xSpeedLabel.Location = new System.Drawing.Point(195, 33);
            this.xSpeedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.xSpeedLabel.Name = "xSpeedLabel";
            this.xSpeedLabel.Size = new System.Drawing.Size(55, 16);
            this.xSpeedLabel.TabIndex = 36;
            this.xSpeedLabel.Text = "X速度:";
            // 
            // xPosition
            // 
            this.xPosition.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xPosition.Location = new System.Drawing.Point(63, 34);
            this.xPosition.Margin = new System.Windows.Forms.Padding(2);
            this.xPosition.Name = "xPosition";
            this.xPosition.ReadOnly = true;
            this.xPosition.Size = new System.Drawing.Size(87, 26);
            this.xPosition.TabIndex = 32;
            this.xPosition.Text = "0.0";
            this.xPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xPosLabel
            // 
            this.xPosLabel.AutoSize = true;
            this.xPosLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xPosLabel.Location = new System.Drawing.Point(11, 36);
            this.xPosLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.xPosLabel.Name = "xPosLabel";
            this.xPosLabel.Size = new System.Drawing.Size(55, 16);
            this.xPosLabel.TabIndex = 34;
            this.xPosLabel.Text = "X坐标:";
            // 
            // yPosition
            // 
            this.yPosition.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yPosition.Location = new System.Drawing.Point(63, 66);
            this.yPosition.Margin = new System.Windows.Forms.Padding(2);
            this.yPosition.Name = "yPosition";
            this.yPosition.ReadOnly = true;
            this.yPosition.Size = new System.Drawing.Size(88, 26);
            this.yPosition.TabIndex = 33;
            this.yPosition.Text = "0.0";
            this.yPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // yPosLabel
            // 
            this.yPosLabel.AutoSize = true;
            this.yPosLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yPosLabel.Location = new System.Drawing.Point(11, 68);
            this.yPosLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yPosLabel.Name = "yPosLabel";
            this.yPosLabel.Size = new System.Drawing.Size(55, 16);
            this.yPosLabel.TabIndex = 35;
            this.yPosLabel.Text = "Y坐标:";
            // 
            // timerCurrentPosAndSpeedInfo
            // 
            this.timerCurrentPosAndSpeedInfo.Interval = 1000;
            this.timerCurrentPosAndSpeedInfo.Tick += new System.EventHandler(this.TimerCurrentPosAndSpeedInfo_Tick);
            // 
            // dotRight
            // 
            this.dotRight.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dotRight.Location = new System.Drawing.Point(60, 148);
            this.dotRight.Margin = new System.Windows.Forms.Padding(2);
            this.dotRight.Name = "dotRight";
            this.dotRight.Size = new System.Drawing.Size(42, 24);
            this.dotRight.TabIndex = 33;
            this.dotRight.Text = "X-";
            this.dotRight.UseVisualStyleBackColor = true;
            this.dotRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DotRight_MouseDown);
            this.dotRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DotRight_MouseUp);
            // 
            // dotLeft
            // 
            this.dotLeft.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dotLeft.Location = new System.Drawing.Point(151, 148);
            this.dotLeft.Margin = new System.Windows.Forms.Padding(2);
            this.dotLeft.Name = "dotLeft";
            this.dotLeft.Size = new System.Drawing.Size(44, 24);
            this.dotLeft.TabIndex = 32;
            this.dotLeft.Text = "X+";
            this.dotLeft.UseVisualStyleBackColor = true;
            this.dotLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DotLeft_MouseDown);
            this.dotLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DotLeft_MouseUp);
            // 
            // dotDown
            // 
            this.dotDown.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dotDown.Location = new System.Drawing.Point(108, 177);
            this.dotDown.Margin = new System.Windows.Forms.Padding(2);
            this.dotDown.Name = "dotDown";
            this.dotDown.Size = new System.Drawing.Size(42, 22);
            this.dotDown.TabIndex = 31;
            this.dotDown.Text = "Y-";
            this.dotDown.UseVisualStyleBackColor = true;
            this.dotDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DotDown_MouseDown);
            this.dotDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DotDown_MouseUp);
            // 
            // dotUp
            // 
            this.dotUp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dotUp.Location = new System.Drawing.Point(107, 123);
            this.dotUp.Margin = new System.Windows.Forms.Padding(2);
            this.dotUp.Name = "dotUp";
            this.dotUp.Size = new System.Drawing.Size(42, 23);
            this.dotUp.TabIndex = 30;
            this.dotUp.Text = "Y+";
            this.dotUp.UseVisualStyleBackColor = true;
            this.dotUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DotUp_MouseDown);
            this.dotUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DotUp_MouseUp);
            // 
            // initZero
            // 
            this.initZero.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.initZero.Location = new System.Drawing.Point(107, 148);
            this.initZero.Margin = new System.Windows.Forms.Padding(2);
            this.initZero.Name = "initZero";
            this.initZero.Size = new System.Drawing.Size(42, 24);
            this.initZero.TabIndex = 34;
            this.initZero.Text = "回零";
            this.initZero.UseVisualStyleBackColor = true;
            // 
            // dotStep
            // 
            this.dotStep.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dotStep.Location = new System.Drawing.Point(75, 24);
            this.dotStep.Margin = new System.Windows.Forms.Padding(2);
            this.dotStep.Name = "dotStep";
            this.dotStep.Size = new System.Drawing.Size(52, 21);
            this.dotStep.TabIndex = 35;
            this.dotStep.Text = "1000";
            this.dotStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dotStepLabel
            // 
            this.dotStepLabel.AutoSize = true;
            this.dotStepLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dotStepLabel.Location = new System.Drawing.Point(14, 27);
            this.dotStepLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dotStepLabel.Name = "dotStepLabel";
            this.dotStepLabel.Size = new System.Drawing.Size(59, 12);
            this.dotStepLabel.TabIndex = 36;
            this.dotStepLabel.Text = "点动步长:";
            // 
            // stopMove
            // 
            this.stopMove.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stopMove.Location = new System.Drawing.Point(251, 135);
            this.stopMove.Margin = new System.Windows.Forms.Padding(2);
            this.stopMove.Name = "stopMove";
            this.stopMove.Size = new System.Drawing.Size(107, 50);
            this.stopMove.TabIndex = 37;
            this.stopMove.Text = "Kill All";
            this.stopMove.UseVisualStyleBackColor = true;
            this.stopMove.Click += new System.EventHandler(this.StopMove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(126, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "cts";
            // 
            // stepOne
            // 
            this.stepOne.AutoSize = true;
            this.stepOne.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stepOne.Location = new System.Drawing.Point(17, 49);
            this.stepOne.Margin = new System.Windows.Forms.Padding(2);
            this.stepOne.Name = "stepOne";
            this.stepOne.Size = new System.Drawing.Size(72, 16);
            this.stepOne.TabIndex = 39;
            this.stepOne.Text = "点动一步";
            this.stepOne.UseVisualStyleBackColor = true;
            // 
            // jogHerePos
            // 
            this.jogHerePos.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jogHerePos.Location = new System.Drawing.Point(537, 24);
            this.jogHerePos.Margin = new System.Windows.Forms.Padding(2);
            this.jogHerePos.Name = "jogHerePos";
            this.jogHerePos.Size = new System.Drawing.Size(52, 21);
            this.jogHerePos.TabIndex = 40;
            this.jogHerePos.Text = "0";
            // 
            // jogHere
            // 
            this.jogHere.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jogHere.Location = new System.Drawing.Point(499, 23);
            this.jogHere.Margin = new System.Windows.Forms.Padding(2);
            this.jogHere.Name = "jogHere";
            this.jogHere.Size = new System.Drawing.Size(34, 21);
            this.jogHere.TabIndex = 41;
            this.jogHere.Text = "到这";
            this.jogHere.UseVisualStyleBackColor = true;
            this.jogHere.Click += new System.EventHandler(this.JogHere_Click);
            // 
            // motorLabel
            // 
            this.motorLabel.AutoSize = true;
            this.motorLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.motorLabel.Location = new System.Drawing.Point(405, 26);
            this.motorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.motorLabel.Name = "motorLabel";
            this.motorLabel.Size = new System.Drawing.Size(29, 12);
            this.motorLabel.TabIndex = 42;
            this.motorLabel.Text = "电机";
            // 
            // ctLabel
            // 
            this.ctLabel.AutoSize = true;
            this.ctLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctLabel.Location = new System.Drawing.Point(593, 27);
            this.ctLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ctLabel.Name = "ctLabel";
            this.ctLabel.Size = new System.Drawing.Size(17, 12);
            this.ctLabel.TabIndex = 43;
            this.ctLabel.Text = "ct";
            // 
            // motorCombo
            // 
            this.motorCombo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.motorCombo.FormattingEnabled = true;
            this.motorCombo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.motorCombo.Location = new System.Drawing.Point(438, 23);
            this.motorCombo.Margin = new System.Windows.Forms.Padding(2);
            this.motorCombo.Name = "motorCombo";
            this.motorCombo.Size = new System.Drawing.Size(52, 20);
            this.motorCombo.TabIndex = 44;
            this.motorCombo.Text = "1";
            // 
            // xMotorLabel
            // 
            this.xMotorLabel.AutoSize = true;
            this.xMotorLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xMotorLabel.Location = new System.Drawing.Point(156, 27);
            this.xMotorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.xMotorLabel.Name = "xMotorLabel";
            this.xMotorLabel.Size = new System.Drawing.Size(47, 12);
            this.xMotorLabel.TabIndex = 45;
            this.xMotorLabel.Text = "X轴电机";
            // 
            // yMotorLabel
            // 
            this.yMotorLabel.AutoSize = true;
            this.yMotorLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yMotorLabel.Location = new System.Drawing.Point(272, 27);
            this.yMotorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yMotorLabel.Name = "yMotorLabel";
            this.yMotorLabel.Size = new System.Drawing.Size(47, 12);
            this.yMotorLabel.TabIndex = 46;
            this.yMotorLabel.Text = "Y轴电机";
            // 
            // xMotor
            // 
            this.xMotor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xMotor.FormattingEnabled = true;
            this.xMotor.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.xMotor.Location = new System.Drawing.Point(207, 24);
            this.xMotor.Margin = new System.Windows.Forms.Padding(2);
            this.xMotor.Name = "xMotor";
            this.xMotor.Size = new System.Drawing.Size(52, 20);
            this.xMotor.TabIndex = 47;
            this.xMotor.Text = "1";
            // 
            // yMotor
            // 
            this.yMotor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yMotor.FormattingEnabled = true;
            this.yMotor.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.yMotor.Location = new System.Drawing.Point(323, 24);
            this.yMotor.Margin = new System.Windows.Forms.Padding(2);
            this.yMotor.Name = "yMotor";
            this.yMotor.Size = new System.Drawing.Size(52, 20);
            this.yMotor.TabIndex = 48;
            this.yMotor.Text = "2";
            // 
            // homeZMotor
            // 
            this.homeZMotor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.homeZMotor.Location = new System.Drawing.Point(614, 16);
            this.homeZMotor.Margin = new System.Windows.Forms.Padding(2);
            this.homeZMotor.Name = "homeZMotor";
            this.homeZMotor.Size = new System.Drawing.Size(58, 34);
            this.homeZMotor.TabIndex = 49;
            this.homeZMotor.Text = "HOME";
            this.homeZMotor.UseVisualStyleBackColor = true;
            this.homeZMotor.Click += new System.EventHandler(this.HomeZMotor_Click);
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.speedLabel.Location = new System.Drawing.Point(17, 78);
            this.speedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(53, 12);
            this.speedLabel.TabIndex = 50;
            this.speedLabel.Text = "点动速度";
            // 
            // speed
            // 
            this.speed.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.speed.Location = new System.Drawing.Point(76, 75);
            this.speed.Margin = new System.Windows.Forms.Padding(2);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(52, 21);
            this.speed.TabIndex = 51;
            this.speed.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(132, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 52;
            this.label2.Text = "cts/ms";
            // 
            // setSpeedBTN
            // 
            this.setSpeedBTN.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setSpeedBTN.Location = new System.Drawing.Point(177, 75);
            this.setSpeedBTN.Margin = new System.Windows.Forms.Padding(2);
            this.setSpeedBTN.Name = "setSpeedBTN";
            this.setSpeedBTN.Size = new System.Drawing.Size(62, 24);
            this.setSpeedBTN.TabIndex = 53;
            this.setSpeedBTN.Text = "设置速度";
            this.setSpeedBTN.UseVisualStyleBackColor = true;
            this.setSpeedBTN.Click += new System.EventHandler(this.SetSpeedBTN_Click);
            // 
            // Group_Jog
            // 
            this.Group_Jog.Controls.Add(this.setSpeedBTN);
            this.Group_Jog.Controls.Add(this.label2);
            this.Group_Jog.Controls.Add(this.speed);
            this.Group_Jog.Controls.Add(this.speedLabel);
            this.Group_Jog.Controls.Add(this.homeZMotor);
            this.Group_Jog.Controls.Add(this.yMotor);
            this.Group_Jog.Controls.Add(this.xMotor);
            this.Group_Jog.Controls.Add(this.yMotorLabel);
            this.Group_Jog.Controls.Add(this.xMotorLabel);
            this.Group_Jog.Controls.Add(this.motorCombo);
            this.Group_Jog.Controls.Add(this.ctLabel);
            this.Group_Jog.Controls.Add(this.motorLabel);
            this.Group_Jog.Controls.Add(this.jogHere);
            this.Group_Jog.Controls.Add(this.jogHerePos);
            this.Group_Jog.Controls.Add(this.stepOne);
            this.Group_Jog.Controls.Add(this.label1);
            this.Group_Jog.Controls.Add(this.stopMove);
            this.Group_Jog.Controls.Add(this.dotStepLabel);
            this.Group_Jog.Controls.Add(this.dotStep);
            this.Group_Jog.Controls.Add(this.initZero);
            this.Group_Jog.Controls.Add(this.dotUp);
            this.Group_Jog.Controls.Add(this.dotDown);
            this.Group_Jog.Controls.Add(this.dotLeft);
            this.Group_Jog.Controls.Add(this.dotRight);
            this.Group_Jog.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Group_Jog.Location = new System.Drawing.Point(28, 187);
            this.Group_Jog.Name = "Group_Jog";
            this.Group_Jog.Size = new System.Drawing.Size(677, 242);
            this.Group_Jog.TabIndex = 21;
            this.Group_Jog.TabStop = false;
            this.Group_Jog.Text = "Jog";
            // 
            // PMacControlFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(970, 550);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Group_Jog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PMacControlFrom";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.communicationGroup.ResumeLayout(false);
            this.communicationGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Group_Jog.ResumeLayout(false);
            this.Group_Jog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox communicationGroup;
        private System.Windows.Forms.Button deSelectDevice;
        private System.Windows.Forms.TextBox selectStatus;
        private System.Windows.Forms.Label statuLabel;
        private System.Windows.Forms.Button selectDevice;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timerCurrentPosAndSpeedInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox chooseMotorV;
        private System.Windows.Forms.Label speedChooseMotorLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox chooseMotorPos;
        private System.Windows.Forms.Label chooseMotorLabel;
        private System.Windows.Forms.Label xUnitLabel;
        private System.Windows.Forms.Label yUnitLabel;
        private System.Windows.Forms.Label yUnitSpeedLabel;
        private System.Windows.Forms.Label xUnitSpeedLabel;
        private System.Windows.Forms.TextBox yCurrentSpeed;
        private System.Windows.Forms.TextBox xCurrentSpeed;
        private System.Windows.Forms.Label ySpeedLabel;
        private System.Windows.Forms.Label xSpeedLabel;
        private System.Windows.Forms.TextBox xPosition;
        private System.Windows.Forms.Label xPosLabel;
        private System.Windows.Forms.TextBox yPosition;
        private System.Windows.Forms.Label yPosLabel;
        private System.Windows.Forms.Button dotRight;
        private System.Windows.Forms.Button dotLeft;
        private System.Windows.Forms.Button dotDown;
        private System.Windows.Forms.Button dotUp;
        private System.Windows.Forms.Button initZero;
        private System.Windows.Forms.TextBox dotStep;
        private System.Windows.Forms.Label dotStepLabel;
        private System.Windows.Forms.Button stopMove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox stepOne;
        private System.Windows.Forms.TextBox jogHerePos;
        private System.Windows.Forms.Button jogHere;
        private System.Windows.Forms.Label motorLabel;
        private System.Windows.Forms.Label ctLabel;
        private System.Windows.Forms.ComboBox motorCombo;
        private System.Windows.Forms.Label xMotorLabel;
        private System.Windows.Forms.Label yMotorLabel;
        private System.Windows.Forms.ComboBox xMotor;
        private System.Windows.Forms.ComboBox yMotor;
        private System.Windows.Forms.Button homeZMotor;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.TextBox speed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button setSpeedBTN;
        private System.Windows.Forms.GroupBox Group_Jog;
    }
}
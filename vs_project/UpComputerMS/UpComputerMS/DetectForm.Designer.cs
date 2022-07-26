namespace UpComputerMS
{
    partial class DetectForm
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_Check = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Tryconnect = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button_Start = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_shijie_y = new System.Windows.Forms.Label();
            this.label_shijie_x = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_y = new System.Windows.Forms.Label();
            this.label_x = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LabelMapping = new System.Windows.Forms.Label();
            this.button_Detect = new System.Windows.Forms.Button();
            this.button_mapping = new System.Windows.Forms.Button();
            this.button_stopDetect = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.MAPPINGWidth = new System.Windows.Forms.TextBox();
            this.MAPPINGHeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.write_in = new System.Windows.Forms.Button();
            this.check_using = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.scan = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.query = new System.Windows.Forms.Button();
            this.id_chip = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cur_user = new System.Windows.Forms.TextBox();
            this.button_ClearMAP = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.button_out = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Location = new System.Drawing.Point(20, 100);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(659, 494);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseClick);
            // 
            // label_Check
            // 
            this.label_Check.AutoSize = true;
            this.label_Check.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Check.Location = new System.Drawing.Point(144, 28);
            this.label_Check.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Check.Name = "label_Check";
            this.label_Check.Size = new System.Drawing.Size(100, 29);
            this.label_Check.TabIndex = 17;
            this.label_Check.Text = "未连接";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(-4, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "相机状态：";
            // 
            // button_Tryconnect
            // 
            this.button_Tryconnect.BackColor = System.Drawing.SystemColors.Control;
            this.button_Tryconnect.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.button_Tryconnect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_Tryconnect.Location = new System.Drawing.Point(316, 8);
            this.button_Tryconnect.Margin = new System.Windows.Forms.Padding(4);
            this.button_Tryconnect.Name = "button_Tryconnect";
            this.button_Tryconnect.Size = new System.Drawing.Size(152, 68);
            this.button_Tryconnect.TabIndex = 15;
            this.button_Tryconnect.Text = "尝试连接";
            this.button_Tryconnect.UseVisualStyleBackColor = false;
            this.button_Tryconnect.Click += new System.EventHandler(this.Button_Tryconnect_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.BackColor = System.Drawing.SystemColors.Control;
            this.button_Stop.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.button_Stop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_Stop.Location = new System.Drawing.Point(668, 8);
            this.button_Stop.Margin = new System.Windows.Forms.Padding(4);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(152, 70);
            this.button_Stop.TabIndex = 14;
            this.button_Stop.Text = "关闭连接";
            this.button_Stop.UseVisualStyleBackColor = false;
            this.button_Stop.Click += new System.EventHandler(this.Button_Stop_Click);
            // 
            // button_Start
            // 
            this.button_Start.BackColor = System.Drawing.SystemColors.Control;
            this.button_Start.Location = new System.Drawing.Point(490, 8);
            this.button_Start.Margin = new System.Windows.Forms.Padding(4);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(152, 70);
            this.button_Start.TabIndex = 13;
            this.button_Start.Text = "打开相机";
            this.button_Start.UseVisualStyleBackColor = false;
            this.button_Start.Click += new System.EventHandler(this.Button_Start_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label_shijie_y);
            this.groupBox2.Controls.Add(this.label_shijie_x);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(620, 972);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(548, 116);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "世界坐标（单位：微米）";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "X:";
            // 
            // label_shijie_y
            // 
            this.label_shijie_y.AutoSize = true;
            this.label_shijie_y.Location = new System.Drawing.Point(426, 68);
            this.label_shijie_y.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_shijie_y.Name = "label_shijie_y";
            this.label_shijie_y.Size = new System.Drawing.Size(58, 24);
            this.label_shijie_y.TabIndex = 17;
            this.label_shijie_y.Text = "未知";
            // 
            // label_shijie_x
            // 
            this.label_shijie_x.AutoSize = true;
            this.label_shijie_x.Location = new System.Drawing.Point(116, 68);
            this.label_shijie_x.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_shijie_x.Name = "label_shijie_x";
            this.label_shijie_x.Size = new System.Drawing.Size(58, 24);
            this.label_shijie_x.TabIndex = 15;
            this.label_shijie_x.Text = "未知";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(332, 68);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 24);
            this.label7.TabIndex = 16;
            this.label7.Text = "Y:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label_y);
            this.groupBox1.Controls.Add(this.label_x);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(30, 972);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(548, 116);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "像素坐标（单位：像素）";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "X:";
            // 
            // label_y
            // 
            this.label_y.AutoSize = true;
            this.label_y.Location = new System.Drawing.Point(426, 68);
            this.label_y.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(58, 24);
            this.label_y.TabIndex = 17;
            this.label_y.Text = "未知";
            // 
            // label_x
            // 
            this.label_x.AutoSize = true;
            this.label_x.Location = new System.Drawing.Point(116, 68);
            this.label_x.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(58, 24);
            this.label_x.TabIndex = 15;
            this.label_x.Text = "未知";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "Y:";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "未校正畸变",
            "校正畸变"});
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "未校正畸变",
            "校正畸变"});
            this.comboBox1.Location = new System.Drawing.Point(1746, 30);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 32);
            this.comboBox1.TabIndex = 22;
            // 
            // button_Save
            // 
            this.button_Save.BackColor = System.Drawing.SystemColors.Control;
            this.button_Save.Location = new System.Drawing.Point(836, 10);
            this.button_Save.Margin = new System.Windows.Forms.Padding(4);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(162, 68);
            this.button_Save.TabIndex = 23;
            this.button_Save.Text = "保存图片";
            this.button_Save.UseVisualStyleBackColor = false;
            this.button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox2.Location = new System.Drawing.Point(1172, 122);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(992, 532);
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox2_MouseClick);
            // 
            // LabelMapping
            // 
            this.LabelMapping.AutoSize = true;
            this.LabelMapping.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelMapping.Location = new System.Drawing.Point(1166, 84);
            this.LabelMapping.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LabelMapping.Name = "LabelMapping";
            this.LabelMapping.Size = new System.Drawing.Size(134, 33);
            this.LabelMapping.TabIndex = 25;
            this.LabelMapping.Text = "MAPPING";
            // 
            // button_Detect
            // 
            this.button_Detect.BackColor = System.Drawing.SystemColors.Control;
            this.button_Detect.Location = new System.Drawing.Point(1018, 12);
            this.button_Detect.Margin = new System.Windows.Forms.Padding(4);
            this.button_Detect.Name = "button_Detect";
            this.button_Detect.Size = new System.Drawing.Size(162, 68);
            this.button_Detect.TabIndex = 26;
            this.button_Detect.Text = "目标检测";
            this.button_Detect.UseVisualStyleBackColor = false;
            this.button_Detect.Click += new System.EventHandler(this.Button_Detect_Click);
            // 
            // button_mapping
            // 
            this.button_mapping.BackColor = System.Drawing.SystemColors.Control;
            this.button_mapping.Location = new System.Drawing.Point(1362, 14);
            this.button_mapping.Margin = new System.Windows.Forms.Padding(4);
            this.button_mapping.Name = "button_mapping";
            this.button_mapping.Size = new System.Drawing.Size(162, 68);
            this.button_mapping.TabIndex = 27;
            this.button_mapping.Text = "Map";
            this.button_mapping.UseVisualStyleBackColor = false;
            this.button_mapping.Click += new System.EventHandler(this.Button_mapping_Click);
            // 
            // button_stopDetect
            // 
            this.button_stopDetect.BackColor = System.Drawing.SystemColors.Control;
            this.button_stopDetect.Location = new System.Drawing.Point(1192, 14);
            this.button_stopDetect.Margin = new System.Windows.Forms.Padding(4);
            this.button_stopDetect.Name = "button_stopDetect";
            this.button_stopDetect.Size = new System.Drawing.Size(162, 68);
            this.button_stopDetect.TabIndex = 29;
            this.button_stopDetect.Text = "停止检测";
            this.button_stopDetect.UseVisualStyleBackColor = false;
            this.button_stopDetect.Click += new System.EventHandler(this.Button_stopDetect_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1168, 680);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 24);
            this.label5.TabIndex = 30;
            this.label5.Text = "芯片数量";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1282, 675);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(96, 35);
            this.textBox1.TabIndex = 31;
            this.textBox1.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1386, 88);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(90, 28);
            this.checkBox1.TabIndex = 32;
            this.checkBox1.Text = "连拍";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // MAPPINGWidth
            // 
            this.MAPPINGWidth.Location = new System.Drawing.Point(1847, 674);
            this.MAPPINGWidth.Margin = new System.Windows.Forms.Padding(6);
            this.MAPPINGWidth.Name = "MAPPINGWidth";
            this.MAPPINGWidth.Size = new System.Drawing.Size(118, 35);
            this.MAPPINGWidth.TabIndex = 33;
            this.MAPPINGWidth.Text = "5600";
            // 
            // MAPPINGHeight
            // 
            this.MAPPINGHeight.Location = new System.Drawing.Point(2086, 674);
            this.MAPPINGHeight.Margin = new System.Windows.Forms.Padding(6);
            this.MAPPINGHeight.Name = "MAPPINGHeight";
            this.MAPPINGHeight.Size = new System.Drawing.Size(68, 35);
            this.MAPPINGHeight.TabIndex = 34;
            this.MAPPINGHeight.Text = "3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1753, 680);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 24);
            this.label6.TabIndex = 35;
            this.label6.Text = "MAP宽度";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1980, 680);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 24);
            this.label8.TabIndex = 36;
            this.label8.Text = "MAP行数";
            // 
            // write_in
            // 
            this.write_in.Location = new System.Drawing.Point(1560, 1072);
            this.write_in.Margin = new System.Windows.Forms.Padding(4);
            this.write_in.Name = "write_in";
            this.write_in.Size = new System.Drawing.Size(190, 68);
            this.write_in.TabIndex = 40;
            this.write_in.Text = "芯片信息写入";
            this.write_in.UseVisualStyleBackColor = true;
            this.write_in.Click += new System.EventHandler(this.Write_in_Click);
            // 
            // check_using
            // 
            this.check_using.Location = new System.Drawing.Point(1344, 1072);
            this.check_using.Margin = new System.Windows.Forms.Padding(4);
            this.check_using.Name = "check_using";
            this.check_using.Size = new System.Drawing.Size(216, 68);
            this.check_using.TabIndex = 39;
            this.check_using.Text = "查询使用日志";
            this.check_using.UseVisualStyleBackColor = true;
            this.check_using.Click += new System.EventHandler(this.check_using_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(1192, 760);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(580, 300);
            this.listView1.TabIndex = 38;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // scan
            // 
            this.scan.Location = new System.Drawing.Point(1188, 1072);
            this.scan.Margin = new System.Windows.Forms.Padding(4);
            this.scan.Name = "scan";
            this.scan.Size = new System.Drawing.Size(156, 68);
            this.scan.TabIndex = 37;
            this.scan.Text = "扫描芯片";
            this.scan.UseVisualStyleBackColor = true;
            this.scan.Click += new System.EventHandler(this.Scan_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(1776, 820);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(434, 124);
            this.listBox1.TabIndex = 44;
            // 
            // query
            // 
            this.query.Location = new System.Drawing.Point(1896, 1064);
            this.query.Margin = new System.Windows.Forms.Padding(4);
            this.query.Name = "query";
            this.query.Size = new System.Drawing.Size(188, 54);
            this.query.TabIndex = 43;
            this.query.Text = "查询";
            this.query.UseVisualStyleBackColor = true;
            this.query.Click += new System.EventHandler(this.query_Click);
            // 
            // id_chip
            // 
            this.id_chip.Location = new System.Drawing.Point(1896, 996);
            this.id_chip.Margin = new System.Windows.Forms.Padding(4);
            this.id_chip.Name = "id_chip";
            this.id_chip.Size = new System.Drawing.Size(186, 35);
            this.id_chip.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1788, 1002);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 24);
            this.label9.TabIndex = 41;
            this.label9.Text = "芯片编号";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1786, 760);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 24);
            this.label10.TabIndex = 45;
            this.label10.Text = "当前用户";
            // 
            // cur_user
            // 
            this.cur_user.Location = new System.Drawing.Point(1896, 754);
            this.cur_user.Margin = new System.Windows.Forms.Padding(6);
            this.cur_user.Name = "cur_user";
            this.cur_user.ReadOnly = true;
            this.cur_user.Size = new System.Drawing.Size(148, 35);
            this.cur_user.TabIndex = 46;
            this.cur_user.Text = "无";
            // 
            // button_ClearMAP
            // 
            this.button_ClearMAP.BackColor = System.Drawing.SystemColors.Control;
            this.button_ClearMAP.Location = new System.Drawing.Point(1560, 14);
            this.button_ClearMAP.Margin = new System.Windows.Forms.Padding(4);
            this.button_ClearMAP.Name = "button_ClearMAP";
            this.button_ClearMAP.Size = new System.Drawing.Size(162, 68);
            this.button_ClearMAP.TabIndex = 47;
            this.button_ClearMAP.Text = "清空MAP";
            this.button_ClearMAP.UseVisualStyleBackColor = false;
            this.button_ClearMAP.Click += new System.EventHandler(this.Button_ClearMAP_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1584, 674);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 35);
            this.textBox2.TabIndex = 48;
            this.textBox2.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1446, 680);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 24);
            this.label11.TabIndex = 49;
            this.label11.Text = "点击芯片ID";
            // 
            // date
            // 
            this.date.CustomFormat = "yyyy-MM-dd";
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(1188, 1149);
            this.date.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(298, 35);
            this.date.TabIndex = 50;
            // 
            // button_out
            // 
            this.button_out.Location = new System.Drawing.Point(2122, 1163);
            this.button_out.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_out.Name = "button_out";
            this.button_out.Size = new System.Drawing.Size(112, 37);
            this.button_out.TabIndex = 51;
            this.button_out.Text = "退出";
            this.button_out.UseVisualStyleBackColor = true;
            this.button_out.Click += new System.EventHandler(this.button_out_Click);
            // 
            // DetectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_out);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button_ClearMAP);
            this.Controls.Add(this.cur_user);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.query);
            this.Controls.Add(this.id_chip);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.write_in);
            this.Controls.Add(this.check_using);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.scan);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MAPPINGHeight);
            this.Controls.Add(this.MAPPINGWidth);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_stopDetect);
            this.Controls.Add(this.button_mapping);
            this.Controls.Add(this.button_Detect);
            this.Controls.Add(this.LabelMapping);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_Check);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Tryconnect);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "DetectForm";
            this.Size = new System.Drawing.Size(2250, 1222);
            this.Load += new System.EventHandler(this.DetectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_Check;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Tryconnect;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_shijie_y;
        private System.Windows.Forms.Label label_shijie_x;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_y;
        private System.Windows.Forms.Label label_x;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label LabelMapping;
        private System.Windows.Forms.Button button_Detect;
        private System.Windows.Forms.Button button_mapping;
        private System.Windows.Forms.Button button_stopDetect;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox MAPPINGWidth;
        private System.Windows.Forms.TextBox MAPPINGHeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button write_in;
        private System.Windows.Forms.Button check_using;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button scan;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button query;
        private System.Windows.Forms.TextBox id_chip;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox cur_user;
        private System.Windows.Forms.Button button_ClearMAP;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Button button_out;
    }
}

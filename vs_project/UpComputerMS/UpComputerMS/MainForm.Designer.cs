namespace UpComputerMS
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Show_Panel = new System.Windows.Forms.Panel();
            this.Show_What = new System.Windows.Forms.GroupBox();
            this.Show_Calibration = new System.Windows.Forms.Button();
            this.Show_DB = new System.Windows.Forms.Button();
            this.Show_DC = new System.Windows.Forms.Button();
            this.Show_PMACControl = new System.Windows.Forms.Button();
            this.Main_Panel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeCurrent = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.dateCurrent = new System.Windows.Forms.TextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.timerCurrentDateTime = new System.Windows.Forms.Timer(this.components);
            this.Show_Panel.SuspendLayout();
            this.Show_What.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Show_Panel
            // 
            this.Show_Panel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Show_Panel.Controls.Add(this.Show_What);
            this.Show_Panel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Show_Panel.Location = new System.Drawing.Point(0, 100);
            this.Show_Panel.Margin = new System.Windows.Forms.Padding(6);
            this.Show_Panel.Name = "Show_Panel";
            this.Show_Panel.Size = new System.Drawing.Size(226, 2688);
            this.Show_Panel.TabIndex = 0;
            // 
            // Show_What
            // 
            this.Show_What.Controls.Add(this.Show_Calibration);
            this.Show_What.Controls.Add(this.Show_DB);
            this.Show_What.Controls.Add(this.Show_DC);
            this.Show_What.Controls.Add(this.Show_PMACControl);
            this.Show_What.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Show_What.Location = new System.Drawing.Point(6, 6);
            this.Show_What.Margin = new System.Windows.Forms.Padding(6);
            this.Show_What.Name = "Show_What";
            this.Show_What.Padding = new System.Windows.Forms.Padding(6);
            this.Show_What.Size = new System.Drawing.Size(214, 5152);
            this.Show_What.TabIndex = 0;
            this.Show_What.TabStop = false;
            this.Show_What.Text = "功能区";
            // 
            // Show_Calibration
            // 
            this.Show_Calibration.Location = new System.Drawing.Point(12, 204);
            this.Show_Calibration.Margin = new System.Windows.Forms.Padding(6);
            this.Show_Calibration.Name = "Show_Calibration";
            this.Show_Calibration.Size = new System.Drawing.Size(190, 86);
            this.Show_Calibration.TabIndex = 3;
            this.Show_Calibration.Text = "标定设置";
            this.Show_Calibration.UseVisualStyleBackColor = true;
            this.Show_Calibration.Click += new System.EventHandler(this.Show_Calibration_Click);
            // 
            // Show_DB
            // 
            this.Show_DB.Location = new System.Drawing.Point(12, 446);
            this.Show_DB.Margin = new System.Windows.Forms.Padding(6);
            this.Show_DB.Name = "Show_DB";
            this.Show_DB.Size = new System.Drawing.Size(190, 92);
            this.Show_DB.TabIndex = 2;
            this.Show_DB.Text = "登录数据库";
            this.Show_DB.UseVisualStyleBackColor = true;
            this.Show_DB.Click += new System.EventHandler(this.Show_DB_Click);
            // 
            // Show_DC
            // 
            this.Show_DC.Location = new System.Drawing.Point(12, 320);
            this.Show_DC.Margin = new System.Windows.Forms.Padding(6);
            this.Show_DC.Name = "Show_DC";
            this.Show_DC.Size = new System.Drawing.Size(190, 92);
            this.Show_DC.TabIndex = 1;
            this.Show_DC.Text = "检测";
            this.Show_DC.UseVisualStyleBackColor = true;
            this.Show_DC.Click += new System.EventHandler(this.Show_DC_Click);
            // 
            // Show_PMACControl
            // 
            this.Show_PMACControl.Location = new System.Drawing.Point(12, 90);
            this.Show_PMACControl.Margin = new System.Windows.Forms.Padding(6);
            this.Show_PMACControl.Name = "Show_PMACControl";
            this.Show_PMACControl.Size = new System.Drawing.Size(190, 84);
            this.Show_PMACControl.TabIndex = 0;
            this.Show_PMACControl.Text = "运动控制";
            this.Show_PMACControl.UseVisualStyleBackColor = true;
            this.Show_PMACControl.Click += new System.EventHandler(this.Show_PMACControl_Click);
            // 
            // Main_Panel
            // 
            this.Main_Panel.AutoScroll = true;
            this.Main_Panel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Main_Panel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Main_Panel.Location = new System.Drawing.Point(238, 100);
            this.Main_Panel.Margin = new System.Windows.Forms.Padding(6);
            this.Main_Panel.Name = "Main_Panel";
            this.Main_Panel.Size = new System.Drawing.Size(6362, 2688);
            this.Main_Panel.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hELPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(6600, 39);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hELPToolStripMenuItem
            // 
            this.hELPToolStripMenuItem.Name = "hELPToolStripMenuItem";
            this.hELPToolStripMenuItem.Size = new System.Drawing.Size(88, 35);
            this.hELPToolStripMenuItem.Text = "Help";
            // 
            // timeCurrent
            // 
            this.timeCurrent.Location = new System.Drawing.Point(1852, 0);
            this.timeCurrent.Margin = new System.Windows.Forms.Padding(4);
            this.timeCurrent.Name = "timeCurrent";
            this.timeCurrent.ReadOnly = true;
            this.timeCurrent.Size = new System.Drawing.Size(164, 35);
            this.timeCurrent.TabIndex = 28;
            this.timeCurrent.Text = "00:00";
            this.timeCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(1774, 4);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(70, 24);
            this.timeLabel.TabIndex = 27;
            this.timeLabel.Text = "时间:";
            // 
            // dateCurrent
            // 
            this.dateCurrent.Location = new System.Drawing.Point(1478, 0);
            this.dateCurrent.Margin = new System.Windows.Forms.Padding(4);
            this.dateCurrent.Name = "dateCurrent";
            this.dateCurrent.ReadOnly = true;
            this.dateCurrent.Size = new System.Drawing.Size(288, 35);
            this.dateCurrent.TabIndex = 26;
            this.dateCurrent.Text = "2022/1/1";
            this.dateCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(1416, 4);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(70, 24);
            this.dateLabel.TabIndex = 25;
            this.dateLabel.Text = "日期:";
            // 
            // timerCurrentDateTime
            // 
            this.timerCurrentDateTime.Tick += new System.EventHandler(this.TimerCurrentDateTime_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(2742, 1428);
            this.Controls.Add(this.timeCurrent);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.dateCurrent);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.Main_Panel);
            this.Controls.Add(this.Show_Panel);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Show_Panel.ResumeLayout(false);
            this.Show_What.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Show_Panel;
        private System.Windows.Forms.Panel Main_Panel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hELPToolStripMenuItem;
        private System.Windows.Forms.GroupBox Show_What;
        private System.Windows.Forms.Button Show_DB;
        private System.Windows.Forms.Button Show_DC;
        private System.Windows.Forms.Button Show_PMACControl;
        private System.Windows.Forms.Button Show_Calibration;
        private System.Windows.Forms.TextBox timeCurrent;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.TextBox dateCurrent;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Timer timerCurrentDateTime;
    }
}


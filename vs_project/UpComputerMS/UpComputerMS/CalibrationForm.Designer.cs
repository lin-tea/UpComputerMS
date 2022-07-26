namespace UpComputerMS
{
    partial class CalibrationForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.button_yunsuan = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_pic_biaoding = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_shiping = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_shuzhi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_bianchang = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(278, 54);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "相机参数";
            // 
            // button_yunsuan
            // 
            this.button_yunsuan.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_yunsuan.Location = new System.Drawing.Point(74, 252);
            this.button_yunsuan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_yunsuan.Name = "button_yunsuan";
            this.button_yunsuan.Size = new System.Drawing.Size(99, 28);
            this.button_yunsuan.TabIndex = 8;
            this.button_yunsuan.Text = "运算";
            this.button_yunsuan.UseVisualStyleBackColor = true;
            this.button_yunsuan.Click += new System.EventHandler(this.Button_yunsuan_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_pic_biaoding);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_shiping);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_shuzhi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_bianchang);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(32, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(213, 214);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "标定参数(边长单位:微米）";
            // 
            // label_pic_biaoding
            // 
            this.label_pic_biaoding.AutoSize = true;
            this.label_pic_biaoding.Location = new System.Drawing.Point(3, 168);
            this.label_pic_biaoding.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_pic_biaoding.Name = "label_pic_biaoding";
            this.label_pic_biaoding.Size = new System.Drawing.Size(89, 19);
            this.label_pic_biaoding.TabIndex = 10;
            this.label_pic_biaoding.Text = "标定图片";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(92, 138);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 20);
            this.button1.TabIndex = 9;
            this.button1.Text = "选取图片";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 138);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "标定图片";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "水平角点";
            // 
            // textBox_shiping
            // 
            this.textBox_shiping.Location = new System.Drawing.Point(92, 110);
            this.textBox_shiping.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_shiping.Name = "textBox_shiping";
            this.textBox_shiping.Size = new System.Drawing.Size(112, 29);
            this.textBox_shiping.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "竖直角点";
            // 
            // textBox_shuzhi
            // 
            this.textBox_shuzhi.Location = new System.Drawing.Point(92, 78);
            this.textBox_shuzhi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_shuzhi.Name = "textBox_shuzhi";
            this.textBox_shuzhi.Size = new System.Drawing.Size(112, 29);
            this.textBox_shuzhi.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "格子边长";
            // 
            // textBox_bianchang
            // 
            this.textBox_bianchang.Location = new System.Drawing.Point(92, 47);
            this.textBox_bianchang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_bianchang.Name = "textBox_bianchang";
            this.textBox_bianchang.Size = new System.Drawing.Size(112, 29);
            this.textBox_bianchang.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(272, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "棋盘格法--标定";
            // 
            // CalibrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_yunsuan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CalibrationForm";
            this.Size = new System.Drawing.Size(1194, 630);
            this.Load += new System.EventHandler(this.CalibrationForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_yunsuan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_pic_biaoding;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_shiping;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_shuzhi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_bianchang;
        private System.Windows.Forms.Label label1;
    }
}

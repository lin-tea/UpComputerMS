namespace UpComputerMS
{
    partial class DBLogForm
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
            this.date = new System.Windows.Forms.DateTimePicker();
            this.button_date_delete = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // date
            // 
            this.date.CustomFormat = "yyyy-MM-dd";
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(1211, 240);
            this.date.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(298, 35);
            this.date.TabIndex = 9;
            // 
            // button_date_delete
            // 
            this.button_date_delete.Location = new System.Drawing.Point(1236, 386);
            this.button_date_delete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_date_delete.Name = "button_date_delete";
            this.button_date_delete.Size = new System.Drawing.Size(190, 77);
            this.button_date_delete.TabIndex = 8;
            this.button_date_delete.Text = "删除该日期日志";
            this.button_date_delete.UseVisualStyleBackColor = true;
            this.button_date_delete.Click += new System.EventHandler(this.button_date_delete_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(28, 50);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1154, 676);
            this.listBox1.TabIndex = 5;
            // 
            // DBLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1522, 775);
            this.Controls.Add(this.date);
            this.Controls.Add(this.button_date_delete);
            this.Controls.Add(this.listBox1);
            this.Name = "DBLogForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.DBLogForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Button button_date_delete;
        private System.Windows.Forms.ListBox listBox1;
    }
}
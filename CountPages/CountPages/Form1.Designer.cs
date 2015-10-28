namespace CountPages
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.beginBox = new System.Windows.Forms.TextBox();
            this.endBox = new System.Windows.Forms.TextBox();
            this.runButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.logBox = new System.Windows.Forms.TextBox();
            this.folderButton = new System.Windows.Forms.Button();
            this.folderBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.pagesLabel = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "开始病历号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "结束病历号";
            // 
            // beginBox
            // 
            this.beginBox.Location = new System.Drawing.Point(96, 44);
            this.beginBox.Name = "beginBox";
            this.beginBox.Size = new System.Drawing.Size(100, 20);
            this.beginBox.TabIndex = 3;
            this.beginBox.Text = "0";
            this.beginBox.LostFocus += new System.EventHandler(this.beginBox_LostFocus);
            // 
            // endBox
            // 
            this.endBox.Location = new System.Drawing.Point(340, 46);
            this.endBox.Name = "endBox";
            this.endBox.Size = new System.Drawing.Size(100, 20);
            this.endBox.TabIndex = 5;
            this.endBox.Text = "9999999";
            this.endBox.LostFocus += new System.EventHandler(this.endBox_LostFocus);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(458, 46);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 6;
            this.runButton.Text = "运行";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(15, 114);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(518, 368);
            this.logBox.TabIndex = 7;
            // 
            // folderButton
            // 
            this.folderButton.Location = new System.Drawing.Point(15, 13);
            this.folderButton.Name = "folderButton";
            this.folderButton.Size = new System.Drawing.Size(75, 23);
            this.folderButton.TabIndex = 0;
            this.folderButton.Text = "选择目录";
            this.folderButton.UseVisualStyleBackColor = true;
            this.folderButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // folderBox
            // 
            this.folderBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::CountPages.Properties.Settings.Default, "LastFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.folderBox.Location = new System.Drawing.Point(96, 15);
            this.folderBox.Name = "folderBox";
            this.folderBox.Size = new System.Drawing.Size(436, 20);
            this.folderBox.TabIndex = 1;
            this.folderBox.Text = global::CountPages.Properties.Settings.Default.LastFolder;
            this.folderBox.LostFocus += new System.EventHandler(this.folderBox_LostFocus);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "总页数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "总文件数";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(93, 82);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(13, 13);
            this.countLabel.TabIndex = 10;
            this.countLabel.Text = "0";
            // 
            // pagesLabel
            // 
            this.pagesLabel.AutoSize = true;
            this.pagesLabel.Location = new System.Drawing.Point(340, 82);
            this.pagesLabel.Name = "pagesLabel";
            this.pagesLabel.Size = new System.Drawing.Size(13, 13);
            this.pagesLabel.TabIndex = 11;
            this.pagesLabel.Text = "0";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(458, 77);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 12;
            this.clearButton.Text = "清空";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 504);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.pagesLabel);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.folderBox);
            this.Controls.Add(this.folderButton);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.endBox);
            this.Controls.Add(this.beginBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "扫描页数记录器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox beginBox;
        private System.Windows.Forms.TextBox endBox;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Button folderButton;
        private System.Windows.Forms.TextBox folderBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Label pagesLabel;

        private int _begin;
        private int _end;
        private System.Windows.Forms.Button clearButton;
    }
}


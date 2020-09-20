namespace FKMaster
{
    partial class FKFrom1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FKFrom1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lable111 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BroadcastTextBox = new System.Windows.Forms.TextBox();
            this.BroadcastButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.MouseXBox = new System.Windows.Forms.TextBox();
            this.MouseYBox = new System.Windows.Forms.TextBox();
            this.MouseSeterButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FKMaster.Properties.Resources.FK_ICON;
            this.pictureBox1.Location = new System.Drawing.Point(10, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 152);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lable111
            // 
            this.lable111.AutoSize = true;
            this.lable111.Font = new System.Drawing.Font("微软雅黑 Light", 30F);
            this.lable111.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lable111.Location = new System.Drawing.Point(154, 30);
            this.lable111.Name = "lable111";
            this.lable111.Size = new System.Drawing.Size(426, 52);
            this.lable111.TabIndex = 1;
            this.lable111.Text = "第三组FK黑客管理系统";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "广播公告：";
            // 
            // BroadcastTextBox
            // 
            this.BroadcastTextBox.Location = new System.Drawing.Point(86, 163);
            this.BroadcastTextBox.Name = "BroadcastTextBox";
            this.BroadcastTextBox.Size = new System.Drawing.Size(285, 21);
            this.BroadcastTextBox.TabIndex = 3;
            // 
            // BroadcastButton
            // 
            this.BroadcastButton.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BroadcastButton.ForeColor = System.Drawing.Color.Black;
            this.BroadcastButton.Location = new System.Drawing.Point(378, 163);
            this.BroadcastButton.Name = "BroadcastButton";
            this.BroadcastButton.Size = new System.Drawing.Size(75, 23);
            this.BroadcastButton.TabIndex = 4;
            this.BroadcastButton.Text = "发送";
            this.BroadcastButton.UseVisualStyleBackColor = true;
            this.BroadcastButton.Click += new System.EventHandler(this.BroadcastButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "修改鼠标：";
            // 
            // MouseXBox
            // 
            this.MouseXBox.Location = new System.Drawing.Point(86, 194);
            this.MouseXBox.Name = "MouseXBox";
            this.MouseXBox.Size = new System.Drawing.Size(37, 21);
            this.MouseXBox.TabIndex = 6;
            // 
            // MouseYBox
            // 
            this.MouseYBox.Location = new System.Drawing.Point(129, 194);
            this.MouseYBox.Name = "MouseYBox";
            this.MouseYBox.Size = new System.Drawing.Size(37, 21);
            this.MouseYBox.TabIndex = 7;
            // 
            // MouseSeterButton
            // 
            this.MouseSeterButton.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MouseSeterButton.ForeColor = System.Drawing.Color.Black;
            this.MouseSeterButton.Location = new System.Drawing.Point(172, 192);
            this.MouseSeterButton.Name = "MouseSeterButton";
            this.MouseSeterButton.Size = new System.Drawing.Size(75, 23);
            this.MouseSeterButton.TabIndex = 8;
            this.MouseSeterButton.Text = "设置";
            this.MouseSeterButton.UseVisualStyleBackColor = true;
            this.MouseSeterButton.Click += new System.EventHandler(this.MouseSeterButton_Click);
            // 
            // FKFrom1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 450);
            this.Controls.Add(this.MouseSeterButton);
            this.Controls.Add(this.MouseYBox);
            this.Controls.Add(this.MouseXBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BroadcastButton);
            this.Controls.Add(this.BroadcastTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lable111);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.Cornsilk;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FKFrom1";
            this.Text = "FK黑客管理端";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FKFrom1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lable111;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BroadcastTextBox;
        private System.Windows.Forms.Button BroadcastButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MouseXBox;
        private System.Windows.Forms.TextBox MouseYBox;
        private System.Windows.Forms.Button MouseSeterButton;
    }
}


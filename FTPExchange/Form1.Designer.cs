namespace FTPExchange
{
    partial class FTPExchange
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTPExchange));
            this.label1 = new System.Windows.Forms.Label();
            this.ftp_sc = new System.Windows.Forms.TextBox();
            this.port_sc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passwd_sc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.user_sc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.passwd_kf = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ftp_kf = new System.Windows.Forms.TextBox();
            this.user_kf = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.port_kf = new System.Windows.Forms.TextBox();
            this.radioButton_sc2kf = new System.Windows.Forms.RadioButton();
            this.radioButton_kf2sc = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.filename = new System.Windows.Forms.TextBox();
            this.radioButton_kf2loc = new System.Windows.Forms.RadioButton();
            this.radioButton_sc2loc = new System.Windows.Forms.RadioButton();
            this.prcBar = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "生产FTP";
            // 
            // ftp_sc
            // 
            this.ftp_sc.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ftp_sc.Location = new System.Drawing.Point(82, 15);
            this.ftp_sc.Name = "ftp_sc";
            this.ftp_sc.Size = new System.Drawing.Size(190, 26);
            this.ftp_sc.TabIndex = 1;
            this.ftp_sc.Text = "192.168.173.12";
            this.ftp_sc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // port_sc
            // 
            this.port_sc.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.port_sc.Location = new System.Drawing.Point(340, 16);
            this.port_sc.Name = "port_sc";
            this.port_sc.Size = new System.Drawing.Size(60, 26);
            this.port_sc.TabIndex = 3;
            this.port_sc.Text = "21";
            this.port_sc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(297, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "端口";
            // 
            // passwd_sc
            // 
            this.passwd_sc.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwd_sc.Location = new System.Drawing.Point(278, 50);
            this.passwd_sc.Name = "passwd_sc";
            this.passwd_sc.Size = new System.Drawing.Size(122, 26);
            this.passwd_sc.TabIndex = 7;
            this.passwd_sc.Text = "f3t2p1";
            this.passwd_sc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwd_sc.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(235, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "密码";
            // 
            // user_sc
            // 
            this.user_sc.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.user_sc.Location = new System.Drawing.Point(82, 50);
            this.user_sc.Name = "user_sc";
            this.user_sc.Size = new System.Drawing.Size(133, 26);
            this.user_sc.TabIndex = 5;
            this.user_sc.Text = "ftp";
            this.user_sc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(15, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "用户名";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.passwd_sc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ftp_sc);
            this.groupBox1.Controls.Add(this.user_sc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.port_sc);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 84);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.passwd_kf);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.ftp_kf);
            this.groupBox2.Controls.Add(this.user_kf);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.port_kf);
            this.groupBox2.Location = new System.Drawing.Point(12, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 84);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // passwd_kf
            // 
            this.passwd_kf.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwd_kf.Location = new System.Drawing.Point(278, 50);
            this.passwd_kf.Name = "passwd_kf";
            this.passwd_kf.Size = new System.Drawing.Size(122, 26);
            this.passwd_kf.TabIndex = 7;
            this.passwd_kf.Text = "f3t2p1";
            this.passwd_kf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwd_kf.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(15, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "开发FTP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(235, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "密码";
            // 
            // ftp_kf
            // 
            this.ftp_kf.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ftp_kf.Location = new System.Drawing.Point(82, 15);
            this.ftp_kf.Name = "ftp_kf";
            this.ftp_kf.Size = new System.Drawing.Size(190, 26);
            this.ftp_kf.TabIndex = 1;
            this.ftp_kf.Text = "192.168.168.45";
            this.ftp_kf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // user_kf
            // 
            this.user_kf.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.user_kf.Location = new System.Drawing.Point(82, 50);
            this.user_kf.Name = "user_kf";
            this.user_kf.Size = new System.Drawing.Size(133, 26);
            this.user_kf.TabIndex = 5;
            this.user_kf.Text = "ftp";
            this.user_kf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(297, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "端口";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(15, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "用户名";
            // 
            // port_kf
            // 
            this.port_kf.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.port_kf.Location = new System.Drawing.Point(340, 16);
            this.port_kf.Name = "port_kf";
            this.port_kf.Size = new System.Drawing.Size(60, 26);
            this.port_kf.TabIndex = 3;
            this.port_kf.Text = "21";
            this.port_kf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioButton_sc2kf
            // 
            this.radioButton_sc2kf.AutoSize = true;
            this.radioButton_sc2kf.Checked = true;
            this.radioButton_sc2kf.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_sc2kf.Location = new System.Drawing.Point(31, 235);
            this.radioButton_sc2kf.Name = "radioButton_sc2kf";
            this.radioButton_sc2kf.Size = new System.Drawing.Size(105, 24);
            this.radioButton_sc2kf.TabIndex = 10;
            this.radioButton_sc2kf.TabStop = true;
            this.radioButton_sc2kf.Text = "生产-->开发";
            this.radioButton_sc2kf.UseVisualStyleBackColor = true;
            // 
            // radioButton_kf2sc
            // 
            this.radioButton_kf2sc.AutoSize = true;
            this.radioButton_kf2sc.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_kf2sc.Location = new System.Drawing.Point(166, 235);
            this.radioButton_kf2sc.Name = "radioButton_kf2sc";
            this.radioButton_kf2sc.Size = new System.Drawing.Size(105, 24);
            this.radioButton_kf2sc.TabIndex = 11;
            this.radioButton_kf2sc.Text = "开发-->生产";
            this.radioButton_kf2sc.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(290, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 38);
            this.button1.TabIndex = 13;
            this.button1.Text = "开始传送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(27, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "文件名";
            // 
            // filename
            // 
            this.filename.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.filename.Location = new System.Drawing.Point(94, 193);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(318, 26);
            this.filename.TabIndex = 9;
            this.filename.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioButton_kf2loc
            // 
            this.radioButton_kf2loc.AutoSize = true;
            this.radioButton_kf2loc.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_kf2loc.Location = new System.Drawing.Point(166, 264);
            this.radioButton_kf2loc.Name = "radioButton_kf2loc";
            this.radioButton_kf2loc.Size = new System.Drawing.Size(105, 24);
            this.radioButton_kf2loc.TabIndex = 15;
            this.radioButton_kf2loc.Text = "开发-->本地";
            this.radioButton_kf2loc.UseVisualStyleBackColor = true;
            // 
            // radioButton_sc2loc
            // 
            this.radioButton_sc2loc.AutoSize = true;
            this.radioButton_sc2loc.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_sc2loc.Location = new System.Drawing.Point(31, 264);
            this.radioButton_sc2loc.Name = "radioButton_sc2loc";
            this.radioButton_sc2loc.Size = new System.Drawing.Size(105, 24);
            this.radioButton_sc2loc.TabIndex = 14;
            this.radioButton_sc2loc.Text = "生产-->本地";
            this.radioButton_sc2loc.UseVisualStyleBackColor = true;
            // 
            // prcBar
            // 
            this.prcBar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.prcBar.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.prcBar.Location = new System.Drawing.Point(-1, 313);
            this.prcBar.Name = "prcBar";
            this.prcBar.Size = new System.Drawing.Size(445, 18);
            this.prcBar.TabIndex = 16;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(290, 269);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 38);
            this.button2.TabIndex = 17;
            this.button2.Text = "中止传输";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label10.Location = new System.Drawing.Point(27, 290);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "准备就绪";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FTPExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 328);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.prcBar);
            this.Controls.Add(this.radioButton_kf2loc);
            this.Controls.Add(this.radioButton_sc2loc);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.filename);
            this.Controls.Add(this.radioButton_kf2sc);
            this.Controls.Add(this.radioButton_sc2kf);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FTPExchange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTPExchange";
            this.Shown += new System.EventHandler(this.FTPExchange_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ftp_sc;
        private System.Windows.Forms.TextBox port_sc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwd_sc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox user_sc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox passwd_kf;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ftp_kf;
        private System.Windows.Forms.TextBox user_kf;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox port_kf;
        private System.Windows.Forms.RadioButton radioButton_sc2kf;
        private System.Windows.Forms.RadioButton radioButton_kf2sc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox filename;
        private System.Windows.Forms.RadioButton radioButton_kf2loc;
        private System.Windows.Forms.RadioButton radioButton_sc2loc;
        private System.Windows.Forms.ProgressBar prcBar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label10;
    }
}


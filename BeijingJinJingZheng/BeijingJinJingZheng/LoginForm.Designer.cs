namespace BeijingJinJingZheng
{
    partial class FormLogin
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
            if (disposing && (components != null)) {
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
            this.button_sendverfiy = new System.Windows.Forms.Button();
            this.textBox_phonenum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_code = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_login = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_main = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_saveconfig = new System.Windows.Forms.Button();
            this.textBox_interval = new System.Windows.Forms.TextBox();
            this.textBox_personphoto = new System.Windows.Forms.TextBox();
            this.textBox_driverphoto = new System.Windows.Forms.TextBox();
            this.textBox_carphoto = new System.Windows.Forms.TextBox();
            this.textBox_drivingphoto = new System.Windows.Forms.TextBox();
            this.textBox_vehicletype = new System.Windows.Forms.TextBox();
            this.textBox_cartypecode = new System.Windows.Forms.TextBox();
            this.textBox_inbjduration = new System.Windows.Forms.TextBox();
            this.textBox_driverlicenseno = new System.Windows.Forms.TextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox_userid = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_uid = new System.Windows.Forms.TextBox();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.button_run = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage_main.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_sendverfiy
            // 
            this.button_sendverfiy.Location = new System.Drawing.Point(255, 119);
            this.button_sendverfiy.Name = "button_sendverfiy";
            this.button_sendverfiy.Size = new System.Drawing.Size(75, 23);
            this.button_sendverfiy.TabIndex = 0;
            this.button_sendverfiy.Text = "发送";
            this.button_sendverfiy.UseVisualStyleBackColor = true;
            this.button_sendverfiy.Click += new System.EventHandler(this.button_sendverfiy_Click);
            // 
            // textBox_phonenum
            // 
            this.textBox_phonenum.Location = new System.Drawing.Point(149, 119);
            this.textBox_phonenum.Name = "textBox_phonenum";
            this.textBox_phonenum.Size = new System.Drawing.Size(100, 21);
            this.textBox_phonenum.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "手机号:";
            // 
            // textBox_code
            // 
            this.textBox_code.Location = new System.Drawing.Point(149, 147);
            this.textBox_code.Name = "textBox_code";
            this.textBox_code.Size = new System.Drawing.Size(100, 21);
            this.textBox_code.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "验证码:";
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(256, 144);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(75, 23);
            this.button_login.TabIndex = 5;
            this.button_login.Text = "登陆";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_main);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(518, 452);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage_main
            // 
            this.tabPage_main.Controls.Add(this.textBox_uid);
            this.tabPage_main.Controls.Add(this.label1);
            this.tabPage_main.Controls.Add(this.button_login);
            this.tabPage_main.Controls.Add(this.button_sendverfiy);
            this.tabPage_main.Controls.Add(this.label2);
            this.tabPage_main.Controls.Add(this.textBox_phonenum);
            this.tabPage_main.Controls.Add(this.textBox_code);
            this.tabPage_main.Location = new System.Drawing.Point(4, 22);
            this.tabPage_main.Name = "tabPage_main";
            this.tabPage_main.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_main.Size = new System.Drawing.Size(510, 426);
            this.tabPage_main.TabIndex = 0;
            this.tabPage_main.Text = "登陆";
            this.tabPage_main.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button_run);
            this.tabPage2.Controls.Add(this.textBox_log);
            this.tabPage2.Controls.Add(this.button_saveconfig);
            this.tabPage2.Controls.Add(this.textBox_interval);
            this.tabPage2.Controls.Add(this.textBox_personphoto);
            this.tabPage2.Controls.Add(this.textBox_driverphoto);
            this.tabPage2.Controls.Add(this.textBox_carphoto);
            this.tabPage2.Controls.Add(this.textBox_drivingphoto);
            this.tabPage2.Controls.Add(this.textBox_vehicletype);
            this.tabPage2.Controls.Add(this.textBox_cartypecode);
            this.tabPage2.Controls.Add(this.textBox_inbjduration);
            this.tabPage2.Controls.Add(this.textBox_driverlicenseno);
            this.tabPage2.Controls.Add(this.textBox_name);
            this.tabPage2.Controls.Add(this.textBox_userid);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(510, 426);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button_saveconfig
            // 
            this.button_saveconfig.Location = new System.Drawing.Point(38, 343);
            this.button_saveconfig.Name = "button_saveconfig";
            this.button_saveconfig.Size = new System.Drawing.Size(75, 23);
            this.button_saveconfig.TabIndex = 3;
            this.button_saveconfig.Text = "保存配置";
            this.button_saveconfig.UseVisualStyleBackColor = true;
            this.button_saveconfig.Click += new System.EventHandler(this.button_saveconfig_Click);
            // 
            // textBox_interval
            // 
            this.textBox_interval.Location = new System.Drawing.Point(119, 297);
            this.textBox_interval.Name = "textBox_interval";
            this.textBox_interval.Size = new System.Drawing.Size(100, 21);
            this.textBox_interval.TabIndex = 2;
            this.textBox_interval.Text = "10";
            // 
            // textBox_personphoto
            // 
            this.textBox_personphoto.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox_personphoto.Location = new System.Drawing.Point(119, 269);
            this.textBox_personphoto.Name = "textBox_personphoto";
            this.textBox_personphoto.Size = new System.Drawing.Size(100, 21);
            this.textBox_personphoto.TabIndex = 2;
            // 
            // textBox_driverphoto
            // 
            this.textBox_driverphoto.Location = new System.Drawing.Point(119, 241);
            this.textBox_driverphoto.Name = "textBox_driverphoto";
            this.textBox_driverphoto.Size = new System.Drawing.Size(100, 21);
            this.textBox_driverphoto.TabIndex = 2;
            // 
            // textBox_carphoto
            // 
            this.textBox_carphoto.Location = new System.Drawing.Point(119, 213);
            this.textBox_carphoto.Name = "textBox_carphoto";
            this.textBox_carphoto.Size = new System.Drawing.Size(100, 21);
            this.textBox_carphoto.TabIndex = 2;
            // 
            // textBox_drivingphoto
            // 
            this.textBox_drivingphoto.Location = new System.Drawing.Point(119, 185);
            this.textBox_drivingphoto.Name = "textBox_drivingphoto";
            this.textBox_drivingphoto.Size = new System.Drawing.Size(100, 21);
            this.textBox_drivingphoto.TabIndex = 2;
            // 
            // textBox_vehicletype
            // 
            this.textBox_vehicletype.Location = new System.Drawing.Point(119, 157);
            this.textBox_vehicletype.Name = "textBox_vehicletype";
            this.textBox_vehicletype.Size = new System.Drawing.Size(100, 21);
            this.textBox_vehicletype.TabIndex = 2;
            // 
            // textBox_cartypecode
            // 
            this.textBox_cartypecode.Location = new System.Drawing.Point(119, 129);
            this.textBox_cartypecode.Name = "textBox_cartypecode";
            this.textBox_cartypecode.Size = new System.Drawing.Size(100, 21);
            this.textBox_cartypecode.TabIndex = 2;
            // 
            // textBox_inbjduration
            // 
            this.textBox_inbjduration.Location = new System.Drawing.Point(119, 101);
            this.textBox_inbjduration.Name = "textBox_inbjduration";
            this.textBox_inbjduration.Size = new System.Drawing.Size(100, 21);
            this.textBox_inbjduration.TabIndex = 2;
            // 
            // textBox_driverlicenseno
            // 
            this.textBox_driverlicenseno.Location = new System.Drawing.Point(119, 73);
            this.textBox_driverlicenseno.Name = "textBox_driverlicenseno";
            this.textBox_driverlicenseno.Size = new System.Drawing.Size(100, 21);
            this.textBox_driverlicenseno.TabIndex = 2;
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(119, 45);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(100, 21);
            this.textBox_name.TabIndex = 1;
            // 
            // textBox_userid
            // 
            this.textBox_userid.Location = new System.Drawing.Point(119, 17);
            this.textBox_userid.Name = "textBox_userid";
            this.textBox_userid.Size = new System.Drawing.Size(100, 21);
            this.textBox_userid.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(36, 300);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "检查周期(秒)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 272);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "本人持身份证照片";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(48, 244);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "驾驶证照片";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 216);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "车辆正面照片";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "行驶证正面照片";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "机动车类型";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "号牌类型";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "自动续签时长(天)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "驾驶证号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "姓名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "用户ID";
            // 
            // textBox_uid
            // 
            this.textBox_uid.Location = new System.Drawing.Point(28, 195);
            this.textBox_uid.Name = "textBox_uid";
            this.textBox_uid.ReadOnly = true;
            this.textBox_uid.Size = new System.Drawing.Size(395, 21);
            this.textBox_uid.TabIndex = 6;
            // 
            // textBox_log
            // 
            this.textBox_log.BackColor = System.Drawing.Color.Black;
            this.textBox_log.ForeColor = System.Drawing.Color.White;
            this.textBox_log.Location = new System.Drawing.Point(226, 17);
            this.textBox_log.MaxLength = 32767000;
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ReadOnly = true;
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_log.Size = new System.Drawing.Size(278, 301);
            this.textBox_log.TabIndex = 4;
            // 
            // button_run
            // 
            this.button_run.Location = new System.Drawing.Point(226, 343);
            this.button_run.Name = "button_run";
            this.button_run.Size = new System.Drawing.Size(278, 23);
            this.button_run.TabIndex = 5;
            this.button_run.Text = "启动";
            this.button_run.UseVisualStyleBackColor = true;
            this.button_run.Click += new System.EventHandler(this.button_run_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 476);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormLogin";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_main.ResumeLayout(false);
            this.tabPage_main.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_sendverfiy;
        private System.Windows.Forms.TextBox textBox_phonenum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_code;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_main;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox_userid;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_interval;
        private System.Windows.Forms.TextBox textBox_personphoto;
        private System.Windows.Forms.TextBox textBox_driverphoto;
        private System.Windows.Forms.TextBox textBox_carphoto;
        private System.Windows.Forms.TextBox textBox_drivingphoto;
        private System.Windows.Forms.TextBox textBox_vehicletype;
        private System.Windows.Forms.TextBox textBox_cartypecode;
        private System.Windows.Forms.TextBox textBox_inbjduration;
        private System.Windows.Forms.TextBox textBox_driverlicenseno;
        private System.Windows.Forms.Button button_saveconfig;
        private System.Windows.Forms.TextBox textBox_uid;
        private System.Windows.Forms.Button button_run;
        private System.Windows.Forms.TextBox textBox_log;
    }
}


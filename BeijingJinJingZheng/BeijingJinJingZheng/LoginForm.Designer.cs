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
            this.button_entercarlist = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_sendverfiy
            // 
            this.button_sendverfiy.Location = new System.Drawing.Point(156, 27);
            this.button_sendverfiy.Name = "button_sendverfiy";
            this.button_sendverfiy.Size = new System.Drawing.Size(75, 23);
            this.button_sendverfiy.TabIndex = 0;
            this.button_sendverfiy.Text = "发送";
            this.button_sendverfiy.UseVisualStyleBackColor = true;
            this.button_sendverfiy.Click += new System.EventHandler(this.button_sendverfiy_Click);
            // 
            // textBox_phonenum
            // 
            this.textBox_phonenum.Location = new System.Drawing.Point(50, 27);
            this.textBox_phonenum.Name = "textBox_phonenum";
            this.textBox_phonenum.Size = new System.Drawing.Size(100, 21);
            this.textBox_phonenum.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "手机号:";
            // 
            // textBox_code
            // 
            this.textBox_code.Location = new System.Drawing.Point(50, 55);
            this.textBox_code.Name = "textBox_code";
            this.textBox_code.Size = new System.Drawing.Size(100, 21);
            this.textBox_code.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "验证码:";
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(157, 52);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(75, 23);
            this.button_login.TabIndex = 5;
            this.button_login.Text = "登陆";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // button_entercarlist
            // 
            this.button_entercarlist.Location = new System.Drawing.Point(5, 96);
            this.button_entercarlist.Name = "button_entercarlist";
            this.button_entercarlist.Size = new System.Drawing.Size(114, 23);
            this.button_entercarlist.TabIndex = 6;
            this.button_entercarlist.Text = "获取申请信息列表";
            this.button_entercarlist.UseVisualStyleBackColor = true;
            this.button_entercarlist.Click += new System.EventHandler(this.button_entercarlist_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 205);
            this.Controls.Add(this.button_entercarlist);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_code);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_phonenum);
            this.Controls.Add(this.button_sendverfiy);
            this.Name = "FormLogin";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_sendverfiy;
        private System.Windows.Forms.TextBox textBox_phonenum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_code;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Button button_entercarlist;
    }
}


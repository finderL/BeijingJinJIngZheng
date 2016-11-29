using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JinjingZheng;
using System.Diagnostics;

namespace BeijingJinJingZheng
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button_sendverfiy_Click(object sender, EventArgs e)
        {
            JinJingZhengAPI.SendVerifyCode(textBox_phonenum.Text, "1", (result, ex) => {
                if (ex == null) {
                    MessageBox.Show(result["resdes"].ToString(),result["rescode"].ToString());
                } else {
                    MessageBox.Show(ex.Message, "短信发送失败");
                }
            });
        }
    }
}

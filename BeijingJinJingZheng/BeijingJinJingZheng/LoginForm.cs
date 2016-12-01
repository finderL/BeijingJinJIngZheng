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
            LogWrapper.OnRecvLog += OnRecvLog;
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

        private void button_login_Click(object sender, EventArgs e)
        {
            JinJingZhengAPI.Login(textBox_phonenum.Text, textBox_code.Text, (result, ex) => {
                if (ex == null) {
                    MessageBox.Show(result["resdes"].ToString(), result["rescode"].ToString());
                    Debug.Write(result);
                    RunInMainthread(() => {
                        textBox_uid.Text = "您的用户ID是:" + result["userid"];
                    });
                    
                } else {
                    MessageBox.Show(ex.Message, "登陆失败");
                }
            });
        }

        private void button_entercarlist_Click(object sender, EventArgs e)
        {
            //JinJingZhengAPI.GetEnterCarList(textBox_phonenum.Text,(result, ex) => {
            //    if (ex == null) {
            //        MessageBox.Show(result["resdes"].ToString(), result["rescode"].ToString());
            //        Debug.Write(result);
            //    } else {
            //        MessageBox.Show(ex.Message, "获取申请信息列表失败");
            //    }
            //});


            //base64 test
            var img = Image.FromFile("d:/test.jpg");
            string b64 = Utils.Image2Base64(img);
            Console.WriteLine("==============================");
            Console.WriteLine(b64);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }

        private void button_saveconfig_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void LoadConfig()
        {
            mConfig = UserConfig.FormFile("./config.json");
            textBox_userid.Text = mConfig.UserID;
            textBox_name.Text = mConfig.DriverName;
            textBox_driverlicenseno.Text = mConfig.DriverLicenseno;
            textBox_inbjduration.Text= mConfig.InbjDuration.ToString();
            textBox_cartypecode.Text= mConfig.CarTypeCode;
            textBox_vehicletype.Text= mConfig.VehicleType;
            textBox_drivingphoto.Text = mConfig.DrivingPhoto;
            textBox_carphoto.Text = mConfig.CarPhoto;
            textBox_driverphoto.Text= mConfig.DriverPhoto;
            textBox_personphoto.Text= mConfig.PersonPhoto;
            textBox_interval.Text= mConfig.Interval.ToString();
        }

        private void SaveConfig()
        {
            mConfig.UserID = textBox_userid.Text;
            mConfig.DriverName = textBox_name.Text;
            mConfig.DriverLicenseno = textBox_driverlicenseno.Text;
            mConfig.InbjDuration = int.Parse(textBox_inbjduration.Text);
            mConfig.CarTypeCode = textBox_cartypecode.Text;
            mConfig.VehicleType = textBox_vehicletype.Text;
            mConfig.DrivingPhoto = textBox_drivingphoto.Text;
            mConfig.CarPhoto = textBox_carphoto.Text;
            mConfig.DriverPhoto = textBox_driverphoto.Text;
            mConfig.PersonPhoto = textBox_personphoto.Text;
            mConfig.Interval = int.Parse(textBox_interval.Text);
            mConfig.Save("./config.json");
        }


        private UserConfig mConfig;
        private JinjingZhengAutoRenew auto = new JinjingZhengAutoRenew();

        void RunInMainthread(Action action)
        {
            this.BeginInvoke((Action)(delegate () {
                action?.Invoke();
            }));
        }

        private void button_run_Click(object sender, EventArgs e)
        {
            
            auto.Run(mConfig);
        }

        void OnRecvLog(LogLevel lv, string info)
        {

            string log = string.Format("{0} [{1}]:{2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
               lv.ToString(), info);

            RunInMainthread(() => {
                textBox_log.Text += log + "\r\n";
            });
        }
    }
}

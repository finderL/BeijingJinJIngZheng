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
using Microsoft.Win32;

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

            if (mConfig.ActAsStartup) {
                button_run_Click(null, null);
            }
            if (mConfig.AutoHide) {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
                this.ShowInTaskbar = false;
                this.notifyIcon1.Visible = true;
            }

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
            checkBox_actonStartup.Checked = mConfig.ActAsStartup;
            checkBox_autostart.Checked = mConfig.RunOnSystemStartup;
            checkBox_autuhide.Checked = mConfig.AutoHide;

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
            mConfig.ActAsStartup = checkBox_actonStartup.Checked;
            mConfig.AutoHide = checkBox_autuhide.Checked;
            if (mConfig.RunOnSystemStartup != checkBox_autostart.Checked) {
                mConfig.RunOnSystemStartup = checkBox_autostart.Checked;
                SetAutoRun(mConfig.RunOnSystemStartup);
            }
            
            mConfig.Save("./config.json");
        }

        void SetAutoRun(bool run)
        {
            if (run) //设置开机自启动  
{
                MessageBox.Show("设置开机自启动，需要修改注册表", "提示");
                string path = Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                rk2.SetValue("JcShutdown", path);
                rk2.Close();
                rk.Close();
            } else //取消开机自启动  
              {
                MessageBox.Show("取消开机自启动，需要修改注册表", "提示");
                string path = Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                rk2.DeleteValue("JcShutdown", false);
                rk2.Close();
                rk.Close();
            }
        }

        private UserConfig mConfig;
        private JinjingZhengAutoRenew auto = new JinjingZhengAutoRenew();

        void RunInMainthread(Action action)
        {
            try
            {
                this.BeginInvoke((Action)(delegate () {
                    action?.Invoke();
                }));
            }
            catch (System.Exception ex)
            {
                Debug.Write(ex.Message);
            }

        }

        private void button_run_Click(object sender, EventArgs e)
        {
            if (!auto.IsRun) {
                auto.Run(mConfig);
                button_run.Text = "停止";
            } else {
                auto.Stop();
                button_run.Text = "启动";
            }



        }

        void OnRecvLog(LogLevel lv, string info)
        {

            string log = string.Format("{0} [{1}]:{2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
               lv.ToString(), info);

            RunInMainthread(() => {
                textBox_log.Text += log + "\r\n";
            });
        }

        private void FormLogin_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) {
                this.Hide();
                this.ShowInTaskbar = false;
                this.notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
                this.ShowInTaskbar = true;
            }
        }



        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("你确定要关闭应用程序吗？", "关闭提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)) {
                this.FormClosing -= new FormClosingEventHandler(this.FormLogin_FormClosing);
                auto.Stop();
                Application.Exit();//退出整个应用程序
            } else {
                e.Cancel = true;  //取消关闭事件,并最小化;
            }
        }
    }
}

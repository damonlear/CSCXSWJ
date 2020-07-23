using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Text.RegularExpressions;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private IPAddress serverIP = IPAddress.Parse("127.0.0.1");
        private int serverPort = 8375;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitEvent();
        }

        private void InitEvent()
        {
            checkADBEnvironment();

            setButtonEnable(0);
            timer_total.Start();

            Thread thrListener = new Thread(new ThreadStart(checkADBDeviceList));
            thrListener.Start();
        }

        private void checkADBEnvironment()
        {
            if (cmdShell("adb version").Length <= 0)
            {
                DialogResult dialogResult = MessageBox.Show("系统缺少ADB运行环境，无法运行", "警告");
                if (dialogResult == DialogResult.OK || dialogResult == DialogResult.Yes)
                {
                    System.Environment.Exit(0);
                }
            }
        }

        private void checkADBDeviceList()
        {
            while (true)
            {
                string online = cmdShell("adb shell getprop ro.product.model");
                Console.WriteLine(online);
                Console.WriteLine(online.Contains("device not found"));
                if (online.Length <= 0 || online.Contains("device not found"))
                {
                    this.Invoke(new EventHandler(delegate {
                        text_status.Text = "设备未连接USB";
                    }));
                    Thread.Sleep(1000);
                    continue;
                }
                else
                {
                    this.Invoke(new EventHandler(delegate {
                        text_status.Text = online;
                    }));
                }
                string isForward = cmdShell("adb forward --list");
                if (isForward.Length <= 0 || isForward.Contains("device not found"))
                {
                    this.Invoke(new EventHandler(delegate {
                        text_status.Text = "USB已连接，转发通道未连接";
                    }));
                    Thread.Sleep(1000);
                    continue;
                }
                if(tcpClient == null || !tcpClient.Connected)
                {
                    this.Invoke(new EventHandler(delegate {
                        text_status.Text = "USB已连接，socket未连接";
                    }));
                    Thread.Sleep(5000);
                }
                else
                {
                    this.Invoke(new EventHandler(delegate {
                        text_status.Text = "USB已连接，socket已连接";
                    }));
                    Thread.Sleep(10000);
                }

            }
        }

        //-1false 0 null 1download 2unload 3select
        private void setButtonEnable(int status)
        {
            if (status < 0)
            {
                button_select.Enabled = false;
                button_download.Enabled = false;
                button_upload.Enabled = false;
                button_connect_device.Enabled = false;
                button_disconnect_device.Enabled = false;
            }
            else if (status == 0)
            {
                button_select.Enabled = true;
                button_download.Enabled = true;
                button_upload.Enabled = true;
                button_connect_device.Enabled = true;
                button_disconnect_device.Enabled = true;
            }
            else if (status == 1)
            {
                button_select.Enabled = false;
                button_download.Enabled = true;
                button_upload.Enabled = false;
            }
            else if (status == 2)
            {
                button_select.Enabled = false;
                button_download.Enabled = false;
                button_upload.Enabled = true;
            }
            else if (status == 3)
            {
                button_select.Enabled = true;
                button_download.Enabled = false;
                button_upload.Enabled = false;
            }
        }
        //CMD 命令
        private String cmdShell(String command)
        {
            try
            {
                Process p = new Process();
                //设置要启动的应用程序
                p.StartInfo.FileName = "cmd.exe";
                //是否使用操作系统shell启动
                p.StartInfo.UseShellExecute = false;
                // 接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardInput = true;
                //输出信息
                p.StartInfo.RedirectStandardOutput = true;
                // 输出错误
                p.StartInfo.RedirectStandardError = true;
                //不显示程序窗口
                p.StartInfo.CreateNoWindow = true;


                //向cmd窗口发送输入信息
                p.StartInfo.Arguments = "/c" + command;
                p.Start();

                //获取输出信息
                string resultInfo = p.StandardOutput.ReadToEnd();
                string errorInfo = p.StandardError.ReadToEnd();

                Console.WriteLine(resultInfo);
                Console.WriteLine(errorInfo);
                //等待程序执行完退出进程
                p.WaitForExit();
                p.Close();

                return resultInfo;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "";
        }
        //文件选择
        private void button_select_Click(object sender, EventArgs e)
        {
            setButtonEnable(3);
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择需要下载的文件";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = dialog.FileName;
                text_url.Text = filePath;

                System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);
                string size = $"{fileInfo.Length}字节";
                text_size.Text = size;
            }
            setButtonEnable(0);
        }
        //时间
        private void timer_total_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            text_time.Text = "当前时间：" + time;
        }

        private void button_download_Click(object sender, EventArgs e)
        {

        }
        private void button_upload_Click(object sender, EventArgs e)
        {

        }
        //IP输入
        private void edittext_ip_TextChanged(object sender, EventArgs e)
        {
            if (IPAddress.TryParse(edittext_ip.Text, out serverIP))
            {
                serverIP = IPAddress.Parse(edittext_ip.Text);
                text_ip_regex.Text = "";
            }
            else
            {
                text_ip_regex.Text = "(非法合格IP)";
            }
        }
        //端口输入 正则
        private Regex portRegex = new Regex(@"^[1-9]$|(^[1-9][0-9]$)|(^[1-9][0-9][0-9]$)|(^[1-9][0-9][0-9][0-9]$)|(^[1-6][0-5][0-5][0-3][0-5]$)");
        //端口输入
        private void edittext_port_TextChanged(object sender, EventArgs e)
        {
            Match match = portRegex.Match(edittext_port.Text);
            if (match.Success)
            {
                serverPort = int.Parse(edittext_port.Text);
                text_port_regex.Text = "";
            }
            else
            {
                text_port_regex.Text = "(非法合格端口号)";
            }
        }

        private void adbForward()
        {
            this.Invoke(new EventHandler(delegate
            {
                setButtonEnable(-1);
            }));
            cmdShell("adb kill-server");
            cmdShell("adb devices");
            cmdShell($"adb forward tcp:{serverPort} tcp:{serverPort}");
            string s = cmdShell("adb forward --list");
            if (s.Contains("device not found") || s.Trim().Length <= 0)
            {
                text_status.Invoke(new EventHandler(delegate
                {
                    text_status.Text = "ADB-TCP通道建立失败或设备未连接";
                }));
            }
            this.Invoke(new EventHandler(delegate
            {
                setButtonEnable(0);
            }));
            // TODO connet device
        }
        private void button_connect_device_Click(object sender, EventArgs e)
        {
            Thread thrListener = new Thread(new ThreadStart(adbForward));
            thrListener.Start();

        }

        private void button_disconnect_device_Click(object sender, EventArgs e)
        {
            //   cmdShell($"adb forward --remove tcp:{serverPort}");
            Thread tcpServerListener = new Thread(new ThreadStart(TcpClient));
            tcpServerListener.Start();
        }

        //安卓设备作为服务端
        //pc作为客户端
        private TcpClient tcpClient;
        private void TcpClient()
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(serverIP, serverPort);

            NetworkStream ntwStream = tcpClient.GetStream();
            if (ntwStream.CanWrite)
            {
                //    Byte[] bytSend = Encoding.UTF8.GetBytes(txtSendMssg.Text);
                Byte[] bytSend = new byte[] { 0xE9 , 0x01 , 0x02 , 0x03 , 0x04 };
                ntwStream.Write(bytSend, 0, bytSend.Length);
            }
            else
            {
                MessageBox.Show("无法写入数据流");

                ntwStream.Close();
                tcpClient.Close();

                return;
            }

            ntwStream.Close();
            tcpClient.Close();
        }
    }
}


﻿using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private IPAddress serverIP = IPAddress.Parse("127.0.0.1");
        private int serverPort = 8375;

        private Socket clientSocket;
        private Thread threadReceive;
        private static string FILE_NAME = "文件名称：";
        private static string FILE_LENGTH = "文件大小：";
        private static int TARGET_LENGTH = 15;
        private static string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (checkMicrosoftNetFramework())
                InitEvent();    
            
        }

        private void InitEvent()
        {
            checkADBEnvironment();

            setButtonEnable(0);
            timer_total.Start();

            Thread thrListener = new Thread(new ThreadStart(checkADBDeviceList));
            thrListener.IsBackground = true;
            thrListener.Start();
        }

        private bool checkMicrosoftNetFramework()
        {
            string strCmd = @"dir %windir%\\Microsoft.Net\\Framework\\v4.*";
            string versionDotNetFrameWork = cmdShell(strCmd);
            if (!versionDotNetFrameWork.Contains("v4.0.30319"))
            {
                DialogResult dialogResult = MessageBox.Show("检测到系统可能未安装.Net FrameWork 4.*,如果已安装更高版本则继续运行，否则请安装该环境！");
                if (dialogResult == DialogResult.OK || dialogResult == DialogResult.Yes)
                {
                    System.Environment.Exit(0);
                }
                return false;
            }
            else
            {
                return true;
            }
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

        //检查adb及socket当前状态
        private void checkADBDeviceList()
        {
            
            while (true && this.IsHandleCreated)
            {
                string online = cmdShell("adb shell getprop ro.product.model");
                Console.WriteLine(online);
                Console.WriteLine(online.Contains("device not found"));
                if (string.IsNullOrEmpty(online) || online.Contains("device not found"))
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        text_status.Text = "设备未连接USB";
                        text_status.ForeColor = System.Drawing.Color.Red;

                        text_model.Text = "获取设备型号失败";
                        text_model.ForeColor = System.Drawing.Color.Red;
                    }));
                    Thread.Sleep(1000);
                    continue;
                }
                else
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        text_model.Text = online;
                        text_model.ForeColor = System.Drawing.Color.Green;
                    }));
                }
                string isForward = cmdShell("adb forward --list");
                if (isForward.Length <= 0 || isForward.Contains("device not found"))
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        text_status.Text = "USB已连接，转发通道未连接";
                        text_status.ForeColor = System.Drawing.Color.OrangeRed;
                    }));
                    Thread.Sleep(1000);
                    continue;
                }
                if (clientSocket == null || !clientSocket.Connected)
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        text_status.Text = "USB已连接，socket未连接";
                        text_status.ForeColor = System.Drawing.Color.OrangeRed;
                    }));
                    Thread.Sleep(5000);
                }
                else
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        text_status.Text = "USB已连接，socket已连接";
                        text_status.ForeColor = System.Drawing.Color.Green;
                    }));
                    Thread.Sleep(1000);
                }
            }
        }
        //-1false 0 null 1download 2unload 3select
        private void setButtonEnable(int status)
        {
            this.Invoke(new EventHandler(delegate { 

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
            }));
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
        //下载
        private void button_download_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(downloadFile)).Start();
        }
        private void button_upload_Click(object sender, EventArgs e)
        {
            if (clientSocket == null)
            {
                MessageBox.Show("请先连接设备");
                return;
            }
            if (!clientSocket.Connected)
            {
                MessageBox.Show("通道未连接");
                return;
            }
            Form_IMG form_IMG = new Form_IMG();
            form_IMG.Show();

            // MessageBox.Show( $"文件上传由PDA发起\n上传文件默认保存在：{CurrentDirectory}" , "默认开启接收文件状态");
            // System.Diagnostics.Process.Start(CurrentDirectory);
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
        //adb forward tcp 命令创建通道
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
                this.Invoke(new EventHandler(delegate
                {
                    text_status.Text = "ADB-TCP通道建立失败或设备未连接";
                    MessageBox.Show("ADB-TCP通道建立失败或设备未连接");
                }));
            }
            else
            {
                // TODO connet device
                socketConnect();
            }

            this.Invoke(new EventHandler(delegate
            {
                setButtonEnable(0);
            }));
        }
        private void socketConnect()
        {
            socketDisconnect();
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                //连接服务端
                clientSocket.Connect(serverIP, serverPort);
                //开启线程不停的接收服务端发送的数据
                threadReceive = new Thread(new ThreadStart(Receive));
                threadReceive.IsBackground = true;
                threadReceive.Start();

            }
            catch
            {
                MessageBox.Show("连接服务端失败，请确认ip和端口是否填写正确", "连接服务端失败");
            }
        }

        private void socketDisconnect()
        {
            if (clientSocket != null)
                clientSocket.Close();

            if (threadReceive != null)
                threadReceive.Abort();

        }

        private void button_connect_device_Click(object sender, EventArgs e)
        {
            Thread thrListener = new Thread(new ThreadStart(adbForward));
            thrListener.Start();
        }


        private void button_disconnect_device_Click(object sender, EventArgs e)
        {
            socketDisconnect();
        }

        //下载文件 运行在子线程中
        private void downloadFile()
        {
            if (String.IsNullOrEmpty(text_url.Text))
            {
                MessageBox.Show("选择需要下载的文件");
                return;
            }
            if(clientSocket == null)
            {
                MessageBox.Show("请先连接设备");
                return;
            }
            if(!clientSocket.Connected)
            {
                MessageBox.Show("通道未连接");
                return;
            }

            try
            {
                long length = new System.IO.FileInfo(text_url.Text).Length;
                int sendCount = 0;
                //初始化进度条
                this.Invoke(new EventHandler(delegate {
                    setButtonEnable(-1);
                    progressBar.Minimum = 0;
                    progressBar.Maximum = (int)length;
                    progressBar.Value = sendCount;
                }));

                string fileName = System.IO.Path.GetFileName(text_url.Text);
                byte[] buffer = Encoding.UTF8.GetBytes($"{FILE_NAME}{fileName}");
                clientSocket.Send(buffer);
                Thread.Sleep(200);

                using (FileStream fileStream = new FileStream(text_url.Text, FileMode.Open))
                {
                    buffer = Encoding.UTF8.GetBytes($"{FILE_LENGTH}{fileStream.Length}");
                    clientSocket.Send(buffer);
                    Thread.Sleep(200);

                    buffer = new byte[1024 * 1024 * 10];
                    int count = 0;
                    while (true)
                    {
                        count = fileStream.Read(buffer, 0, buffer.Length);
                        if (count == 0)
                        {
                            MessageBox.Show("文件下发结束", "文件下发", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            break;
                        }
                        clientSocket.Send(buffer, 0, count, SocketFlags.None);

                        //进度条
                        this.Invoke(new EventHandler(delegate
                        {
                            edittext_result.Text = $"count:{count} length:{length} sendcount:{sendCount}";
                            sendCount += count;
                            progressBar.Value = sendCount;
                        }));
                    }
                }
            }
            catch (Exception e1)
            {
                this.Invoke(new EventHandler(delegate {
                    MessageBox.Show("发送失败" + e1.Message);
                    progressBar.Value = 0;
                    setButtonEnable(0);
                }));
            }
            finally
            {
                this.Invoke(new EventHandler(delegate {
                    setButtonEnable(0);
                }));
                

            }
        }

        //接收服务端消息的线程方法
        private void Receive()
        {
            try
            {
                while (true)
                {
                    if (clientSocket == null) continue;

                    byte[] buff = new byte[1024 * 1024 * 10];
                    int r = clientSocket.Receive(buff);
                    if (r > 0)
                    {
                        parserReceiver(buff , 0 , r);
                        String str = Encoding.UTF8.GetString(buff, 0, r);

                        this.Invoke(new Action(() => { this.edittext_result.Text = str; }));
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show($"不要重复连接设备，获取服务端参数失败:{e.Message}", "连接断开，获取服务端参数失败");
            }
        }

        private int receiveIndex = 0;
        private long receiveLength = 0;
        private string receivePath = null;
        private FileStream fileStream = null;

        private void parserReceiver(byte[] buffer , int index , int offset)
        {
            String target = Encoding.UTF8.GetString(buffer, 0, TARGET_LENGTH);
            if(target.Equals(FILE_NAME))
            {
                string name = Encoding.UTF8.GetString(buffer, 0, offset).Split('：')[1];
                Console.Write(name);
                receivePath = CurrentDirectory + "\\" + name;
                receiveIndex = 0;
                receiveLength = 0;

                bool exists = File.Exists(receivePath);
                if (exists || receiveIndex == 0)
                {
                    File.Delete(receivePath);
                }
                try
                {
                    if (fileStream != null)
                    {
                        try
                        {
                            fileStream.Close();
                            fileStream = null;
                        }
                        catch { }
                    }
                    fileStream = new FileStream(receivePath, FileMode.Create, FileAccess.Write);
                }
                catch (Exception e)
                {
                    Console.Write(e);
                }
            }
            else if (target.Equals(FILE_LENGTH))
            {
                string len = Encoding.UTF8.GetString(buffer, 0, offset).Split('：')[1];
                Console.Write(len);
                receiveLength = long.Parse(len);

                this.Invoke(new EventHandler(delegate {
                    setButtonEnable(-1);
                    progressBar.Minimum = 0;
                    progressBar.Maximum = (int)receiveLength;
                    progressBar.Value = 0;
                }));
            }
            else
            {
                // 写文件
                try
                {
                    if(fileStream == null)
                    {
                        return;
                    }
                    fileStream.Position = fileStream.Length;
                    fileStream.Write(buffer, index , offset);
                    receiveIndex += (offset - index);
                }
                catch(Exception e)
                {
                    Console.Write(e);
                }
                finally
                {
                    this.Invoke(new EventHandler(delegate { 
                        if(fileStream!=null)
                        progressBar.Value = (int) fileStream.Length;
                    }));
                }

                if(fileStream.Position >= receiveLength)
                {
                    fileStream.Close();
                    fileStream = null;

                    MessageBox.Show("接收完成", "接收完成", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    setButtonEnable(0);
                }
                else
                {
                    Console.Write($"{fileStream.Position} - {fileStream.Length} - {receiveLength} - {receiveIndex}");
                }
            }
        }
    }


    //流程
    //没有信息都是文件传输
    //先传输文件名
    //再传输文件大小
    //发货或接收文件
}


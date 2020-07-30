namespace WindowsFormsApp3
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_select = new System.Windows.Forms.Button();
            this.text_url_title = new System.Windows.Forms.Label();
            this.timer_total = new System.Windows.Forms.Timer(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.button_download = new System.Windows.Forms.Button();
            this.button_upload = new System.Windows.Forms.Button();
            this.text_model_title = new System.Windows.Forms.Label();
            this.text_url = new System.Windows.Forms.Label();
            this.text_size_title = new System.Windows.Forms.Label();
            this.text_size = new System.Windows.Forms.Label();
            this.text_time = new System.Windows.Forms.Label();
            this.timer_progressBar = new System.Windows.Forms.Timer(this.components);
            this.edittext_port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.text_ip_title = new System.Windows.Forms.Label();
            this.edittext_ip = new System.Windows.Forms.TextBox();
            this.edittext_result = new System.Windows.Forms.TextBox();
            this.text_ip_regex = new System.Windows.Forms.Label();
            this.text_port_regex = new System.Windows.Forms.Label();
            this.button_connect_device = new System.Windows.Forms.Button();
            this.button_disconnect_device = new System.Windows.Forms.Button();
            this.text_model = new System.Windows.Forms.Label();
            this.text_status_title = new System.Windows.Forms.Label();
            this.text_status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_select
            // 
            this.button_select.Location = new System.Drawing.Point(14, 120);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(75, 23);
            this.button_select.TabIndex = 0;
            this.button_select.Text = "选择要下载的文件";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // text_url_title
            // 
            this.text_url_title.AutoSize = true;
            this.text_url_title.Location = new System.Drawing.Point(95, 125);
            this.text_url_title.Name = "text_url_title";
            this.text_url_title.Size = new System.Drawing.Size(41, 12);
            this.text_url_title.TabIndex = 1;
            this.text_url_title.Text = "路径：";
            // 
            // timer_total
            // 
            this.timer_total.Tick += new System.EventHandler(this.timer_total_Tick);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(13, 276);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(559, 23);
            this.progressBar.TabIndex = 2;
            // 
            // button_download
            // 
            this.button_download.Location = new System.Drawing.Point(94, 305);
            this.button_download.Name = "button_download";
            this.button_download.Size = new System.Drawing.Size(75, 23);
            this.button_download.TabIndex = 3;
            this.button_download.Text = "文件下发";
            this.button_download.UseVisualStyleBackColor = true;
            this.button_download.Click += new System.EventHandler(this.button_download_Click);
            // 
            // button_upload
            // 
            this.button_upload.Location = new System.Drawing.Point(175, 305);
            this.button_upload.Name = "button_upload";
            this.button_upload.Size = new System.Drawing.Size(75, 23);
            this.button_upload.TabIndex = 4;
            this.button_upload.Text = "文件接收";
            this.button_upload.UseVisualStyleBackColor = true;
            this.button_upload.Click += new System.EventHandler(this.button_upload_Click);
            // 
            // text_model_title
            // 
            this.text_model_title.AutoSize = true;
            this.text_model_title.Location = new System.Drawing.Point(10, 9);
            this.text_model_title.Name = "text_model_title";
            this.text_model_title.Size = new System.Drawing.Size(89, 12);
            this.text_model_title.TabIndex = 5;
            this.text_model_title.Text = "设备连接状态：";
            // 
            // text_url
            // 
            this.text_url.AutoSize = true;
            this.text_url.Location = new System.Drawing.Point(142, 125);
            this.text_url.Name = "text_url";
            this.text_url.Size = new System.Drawing.Size(0, 12);
            this.text_url.TabIndex = 7;
            // 
            // text_size_title
            // 
            this.text_size_title.AutoSize = true;
            this.text_size_title.Location = new System.Drawing.Point(94, 154);
            this.text_size_title.Name = "text_size_title";
            this.text_size_title.Size = new System.Drawing.Size(65, 12);
            this.text_size_title.TabIndex = 8;
            this.text_size_title.Text = "文件大小：";
            // 
            // text_size
            // 
            this.text_size.AutoSize = true;
            this.text_size.Location = new System.Drawing.Point(165, 154);
            this.text_size.Name = "text_size";
            this.text_size.Size = new System.Drawing.Size(0, 12);
            this.text_size.TabIndex = 9;
            // 
            // text_time
            // 
            this.text_time.AutoSize = true;
            this.text_time.Location = new System.Drawing.Point(11, 340);
            this.text_time.Name = "text_time";
            this.text_time.Size = new System.Drawing.Size(41, 12);
            this.text_time.TabIndex = 10;
            this.text_time.Text = "时间：";
            // 
            // edittext_port
            // 
            this.edittext_port.Location = new System.Drawing.Point(83, 77);
            this.edittext_port.Name = "edittext_port";
            this.edittext_port.Size = new System.Drawing.Size(75, 21);
            this.edittext_port.TabIndex = 11;
            this.edittext_port.Text = "8375";
            this.edittext_port.TextChanged += new System.EventHandler(this.edittext_port_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "转发端口：";
            // 
            // text_ip_title
            // 
            this.text_ip_title.AutoSize = true;
            this.text_ip_title.Location = new System.Drawing.Point(12, 58);
            this.text_ip_title.Name = "text_ip_title";
            this.text_ip_title.Size = new System.Drawing.Size(53, 12);
            this.text_ip_title.TabIndex = 14;
            this.text_ip_title.Text = "转发IP：";
            // 
            // edittext_ip
            // 
            this.edittext_ip.Location = new System.Drawing.Point(83, 55);
            this.edittext_ip.Name = "edittext_ip";
            this.edittext_ip.Size = new System.Drawing.Size(75, 21);
            this.edittext_ip.TabIndex = 15;
            this.edittext_ip.Text = "127.0.0.1";
            this.edittext_ip.TextChanged += new System.EventHandler(this.edittext_ip_TextChanged);
            // 
            // edittext_result
            // 
            this.edittext_result.Location = new System.Drawing.Point(12, 211);
            this.edittext_result.Multiline = true;
            this.edittext_result.Name = "edittext_result";
            this.edittext_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.edittext_result.Size = new System.Drawing.Size(560, 59);
            this.edittext_result.TabIndex = 13;
            // 
            // text_ip_regex
            // 
            this.text_ip_regex.AutoSize = true;
            this.text_ip_regex.ForeColor = System.Drawing.Color.Red;
            this.text_ip_regex.Location = new System.Drawing.Point(165, 58);
            this.text_ip_regex.Name = "text_ip_regex";
            this.text_ip_regex.Size = new System.Drawing.Size(0, 12);
            this.text_ip_regex.TabIndex = 16;
            // 
            // text_port_regex
            // 
            this.text_port_regex.AutoSize = true;
            this.text_port_regex.ForeColor = System.Drawing.Color.Red;
            this.text_port_regex.Location = new System.Drawing.Point(164, 80);
            this.text_port_regex.Name = "text_port_regex";
            this.text_port_regex.Size = new System.Drawing.Size(0, 12);
            this.text_port_regex.TabIndex = 17;
            // 
            // button_connect_device
            // 
            this.button_connect_device.Location = new System.Drawing.Point(13, 305);
            this.button_connect_device.Name = "button_connect_device";
            this.button_connect_device.Size = new System.Drawing.Size(75, 23);
            this.button_connect_device.TabIndex = 18;
            this.button_connect_device.Text = "连接设备";
            this.button_connect_device.UseVisualStyleBackColor = true;
            this.button_connect_device.Click += new System.EventHandler(this.button_connect_device_Click);
            // 
            // button_disconnect_device
            // 
            this.button_disconnect_device.Location = new System.Drawing.Point(256, 305);
            this.button_disconnect_device.Name = "button_disconnect_device";
            this.button_disconnect_device.Size = new System.Drawing.Size(75, 23);
            this.button_disconnect_device.TabIndex = 19;
            this.button_disconnect_device.Text = "断开设备";
            this.button_disconnect_device.UseVisualStyleBackColor = true;
            this.button_disconnect_device.Click += new System.EventHandler(this.button_disconnect_device_Click);
            // 
            // text_model
            // 
            this.text_model.AutoSize = true;
            this.text_model.Location = new System.Drawing.Point(94, 9);
            this.text_model.Name = "text_model";
            this.text_model.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.text_model.Size = new System.Drawing.Size(53, 12);
            this.text_model.TabIndex = 20;
            this.text_model.Text = "未知型号";
            // 
            // text_status_title
            // 
            this.text_status_title.AutoSize = true;
            this.text_status_title.Location = new System.Drawing.Point(10, 32);
            this.text_status_title.Name = "text_status_title";
            this.text_status_title.Size = new System.Drawing.Size(89, 12);
            this.text_status_title.TabIndex = 21;
            this.text_status_title.Text = "设备连接状态：";
            // 
            // text_status
            // 
            this.text_status.AutoSize = true;
            this.text_status.Location = new System.Drawing.Point(92, 32);
            this.text_status.Name = "text_status";
            this.text_status.Size = new System.Drawing.Size(65, 12);
            this.text_status.TabIndex = 22;
            this.text_status.Text = "设备未连接";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.text_status);
            this.Controls.Add(this.text_status_title);
            this.Controls.Add(this.text_model);
            this.Controls.Add(this.button_disconnect_device);
            this.Controls.Add(this.button_connect_device);
            this.Controls.Add(this.text_port_regex);
            this.Controls.Add(this.text_ip_regex);
            this.Controls.Add(this.edittext_ip);
            this.Controls.Add(this.text_ip_title);
            this.Controls.Add(this.edittext_result);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edittext_port);
            this.Controls.Add(this.text_time);
            this.Controls.Add(this.text_size);
            this.Controls.Add(this.text_size_title);
            this.Controls.Add(this.text_url);
            this.Controls.Add(this.text_model_title);
            this.Controls.Add(this.button_upload);
            this.Controls.Add(this.button_download);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.text_url_title);
            this.Controls.Add(this.button_select);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "外部拓展接口测试上位机";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.Label text_url_title;
        private System.Windows.Forms.Timer timer_total;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button button_download;
        private System.Windows.Forms.Button button_upload;
        private System.Windows.Forms.Label text_model_title;
        private System.Windows.Forms.Label text_url;
        private System.Windows.Forms.Label text_size_title;
        private System.Windows.Forms.Label text_size;
        private System.Windows.Forms.Label text_time;
        private System.Windows.Forms.Timer timer_progressBar;
        private System.Windows.Forms.TextBox edittext_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label text_ip_title;
        private System.Windows.Forms.TextBox edittext_ip;
        private System.Windows.Forms.TextBox edittext_result;
        private System.Windows.Forms.Label text_ip_regex;
        private System.Windows.Forms.Label text_port_regex;
        private System.Windows.Forms.Button button_connect_device;
        private System.Windows.Forms.Button button_disconnect_device;
        private System.Windows.Forms.Label text_model;
        private System.Windows.Forms.Label text_status_title;
        private System.Windows.Forms.Label text_status;
    }
}


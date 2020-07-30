namespace WindowsFormsApp3
{
    partial class Form_IMG
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_IMG));
            this.text_upload_opt = new System.Windows.Forms.Label();
            this.button_go2path = new System.Windows.Forms.Button();
            this.button_sure = new System.Windows.Forms.Button();
            this.picturebox_opt = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_opt)).BeginInit();
            this.SuspendLayout();
            // 
            // text_upload_opt
            // 
            this.text_upload_opt.AutoSize = true;
            this.text_upload_opt.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_upload_opt.Location = new System.Drawing.Point(12, 9);
            this.text_upload_opt.Name = "text_upload_opt";
            this.text_upload_opt.Size = new System.Drawing.Size(49, 20);
            this.text_upload_opt.TabIndex = 1;
            this.text_upload_opt.Text = "提示";
            // 
            // button_go2path
            // 
            this.button_go2path.Location = new System.Drawing.Point(12, 426);
            this.button_go2path.Name = "button_go2path";
            this.button_go2path.Size = new System.Drawing.Size(125, 23);
            this.button_go2path.TabIndex = 2;
            this.button_go2path.Text = "打开上传保存目录";
            this.button_go2path.UseVisualStyleBackColor = true;
            this.button_go2path.Click += new System.EventHandler(this.button_go2path_Click);
            // 
            // button_sure
            // 
            this.button_sure.Location = new System.Drawing.Point(147, 426);
            this.button_sure.Name = "button_sure";
            this.button_sure.Size = new System.Drawing.Size(125, 23);
            this.button_sure.TabIndex = 3;
            this.button_sure.Text = "确定";
            this.button_sure.UseVisualStyleBackColor = true;
            this.button_sure.Click += new System.EventHandler(this.button_sure_Click);
            // 
            // picturebox_opt
            // 
            this.picturebox_opt.InitialImage = global::WindowsFormsApp3.Properties.Resources.pic_upload_opt;
            this.picturebox_opt.Location = new System.Drawing.Point(13, 32);
            this.picturebox_opt.Name = "picturebox_opt";
            this.picturebox_opt.Size = new System.Drawing.Size(259, 388);
            this.picturebox_opt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturebox_opt.TabIndex = 0;
            this.picturebox_opt.TabStop = false;
            // 
            // Form_IMG
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(284, 461);
            this.Controls.Add(this.button_sure);
            this.Controls.Add(this.button_go2path);
            this.Controls.Add(this.text_upload_opt);
            this.Controls.Add(this.picturebox_opt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_IMG";
            this.Text = "操作提示";
            this.Load += new System.EventHandler(this.Form_IMG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_opt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picturebox_opt;
        private System.Windows.Forms.Label text_upload_opt;
        private System.Windows.Forms.Button button_go2path;
        private System.Windows.Forms.Button button_sure;
    }
}
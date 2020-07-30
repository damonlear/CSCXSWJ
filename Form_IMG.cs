using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form_IMG : Form
    {
        public Form_IMG()
        {
            InitializeComponent();
        }

        private void button_go2path_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory());
 
        }

        private void button_sure_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_IMG_Load(object sender, EventArgs e)
        {
            picturebox_opt.Image = Properties.Resources.pic_upload_opt;

            text_upload_opt.Text = "文件上传由PDA主动发起";
        }
    }
}

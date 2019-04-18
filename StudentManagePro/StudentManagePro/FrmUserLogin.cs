using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StudentManagePro.UserinfoService;

namespace StudentManagePro
{
    public partial class FrmUserLogin : Form
    {
        public FrmUserLogin()
        {
            InitializeComponent();
        }

        private void FrmUserLogin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        //登录按钮
        private void button1_Click(object sender, EventArgs e)
        {


            string user_id = txtUser.Text.Trim();//读取user_id不包含空格

            string user_pwd = txtPwd.Text;
            UserinfoServiceSoapClient us = new UserinfoServiceSoapClient();
            bool flag= us.Login(user_id,user_pwd);
            if (flag)
            {
                //MessageBox.Show("登录成功","信息提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                FrmMain frm = new FrmMain();//跳转到主界面
                frm.Show();
                //this.Close();
            }
            else
            {
                MessageBox.Show("登录失败，用户名或密码错误","信息提示",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //取消按钮
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmRes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


            FemRess frm = new FemRess();
            frm.ShowDialog();//跳转到FrmRess.cs
            
        }
    }
}

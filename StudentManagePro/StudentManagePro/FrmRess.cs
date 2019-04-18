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
    public partial class FemRess : Form
    {
        public FemRess()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {

            string user_id = textUser.Text.Trim();

            string user_pwd = textPwd.Text;
            UserinfoServiceSoapClient us = new UserinfoServiceSoapClient();
            bool flag = us.Register(user_id, user_pwd,"");
            if (flag)
            {
                MessageBox.Show("注册成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("注册失败，用户名或密码错误", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        // 用户名注册
        private void textUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }
        //用户名密码注册
        private void textPwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

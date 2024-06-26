﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 学生成绩管理系统
{
    public partial class 学生端_守则 : Form
    {
        public 学生端_守则()
        {
            InitializeComponent();
            toolStripLabel3.Text = LoadInfor.X_Sname;
            toolStripLabel2.Text = LoadInfor.X_Sno;
        }

        private void 成绩查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端_成绩查询().Show();
        }

        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端个人信息().Show();
        }

        private void 综测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端_综测().Show();
        }

        private void 管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端_管理登录().Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端登录界面().Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void 学生端_守则_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(LoadInfor.G_Mess))
            {
                MessageBox.Show(LoadInfor.G_Mess);
            }

        }
    }
}

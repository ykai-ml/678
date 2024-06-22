using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 学生成绩管理系统
{
    public partial class 教师端_成绩录入 : Form
    {
        public 教师端_成绩录入()
        {
            InitializeComponent();
        }

        private void 成绩查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 教师端_成绩查询().Show();
        }

        private void 成绩分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 教师端_成绩分析().Show();
        }

        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 教师端_个人信息().Show();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 教师端登录界面().Show();
        }
    }
}

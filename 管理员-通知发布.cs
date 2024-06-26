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
    public partial class 管理员_通知发布 : Form
    {
        public 管理员_通知发布()
        {
            InitializeComponent();
            toolStripLabel3.Text = LoadInfor.G_Sname;
            toolStripLabel2.Text = LoadInfor.G_Sno;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 学生列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            new 管理员_学生列表().Show();
        }

        private void 教师列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            new 管理员_教师列表().Show();
        }

        private void 课程列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            new 管理员_课程列表().Show();
        }

        private void 班级列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            new 管理员_班级列表().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadInfor.G_Mess = richTextBox1.Text;
            MessageBox.Show("发布成功");
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form1().Show();
        }
    }
}

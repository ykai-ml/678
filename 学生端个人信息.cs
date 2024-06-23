using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 学生成绩管理系统
{
    public partial class 学生端个人信息 : Form
    {
        public 学生端个人信息()
        {
            InitializeComponent();
            toolStripLabel3.Text = LoadInfor.X_Sname;
            toolStripLabel2.Text = LoadInfor.X_Sno;
            label7.Text = LoadInfor.X_Sname;
            label8.Text = LoadInfor.X_Sno;
            label9.Text = LoadInfor.X_Class;
        }

        private void 综测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端_综测().Show();
        }

        private void 成绩查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端_成绩查询().Show();
        }

        private void 管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端_管理().Show();
        }

        private void 课程信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端_课程信息().Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.Close();
            new 学生端登录界面().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();  //打开文件
            ofd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);//设置系统目录

            //图片的类型定义
            ofd.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.pictureBox1.Image = Image.FromStream(ofd.OpenFile());  //获取当前选择的图片
                string path = ofd.FileName.ToString(); //获取当前图片的路径
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read); //将指定路径的图片添加到FileStream类中
                BinaryReader br = new BinaryReader(fs);//通过FileStream对象实例化BinaryReader对象

            }
        }
    }
}

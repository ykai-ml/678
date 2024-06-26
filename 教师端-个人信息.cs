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
    public partial class 教师端_个人信息 : Form
    {
        public 教师端_个人信息()
        {
            InitializeComponent();
            toolStripLabel3.Text = LoadInfor.T_Sname;
            toolStripLabel2.Text = LoadInfor.T_Sno;
            label7.Text = LoadInfor.T_Sname;
            label8.Text = LoadInfor.T_Sno;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 教师端_修改密码().Show();
        }

        private void 成绩查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 教师端_成绩查询().Show();
        }

        private void 成绩录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 教师端_成绩录入().Show();
        }

        private void 成绩分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 教师端_成绩分析().Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 教师端登录界面().Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void imagee()
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
        private void button2_Click(object sender, EventArgs e)
        {
            imagee();
        }

        private void 教师端_个人信息_Load(object sender, EventArgs e)
        {
            
        }
    }
}

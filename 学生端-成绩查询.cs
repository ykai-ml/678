using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 学生成绩管理系统
{
    public partial class 学生端_成绩查询 : Form
    {
        string strCon = @"server=(local);database=学生成绩管理系统;Integrated security=true";
        public 学生端_成绩查询()
        {
            InitializeComponent();
            toolStripTextBox1.Text = LoadInfor.X_Sname;
            toolStripTextBox2.Text = LoadInfor.X_Sno;
        }
        public void InitStudent()
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "select 学生$.学号,姓名,班级号,课程名,成绩 from 学生$,选课$,课程$ where 学生$.学号='{0}' and 学生$.学号=选课$.学号 and 选课$.课程号=课程$.课程号";
                strCmd = string.Format(strCmd, LoadInfor.X_Sno);
                SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void 学生端_成绩查询_Load(object sender, EventArgs e)
        {
            InitStudent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "select 学生$.学号,姓名,班级号,课程名,成绩 from 学生$,选课$,课程$ where 学生$.学号='{0}' and 课程名='{1}' and 学生$.学号=选课$.学号 and 选课$.课程号=课程$.课程号";
                strCmd = string.Format(strCmd, LoadInfor.X_Sno,textBox2.Text);
                SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InitStudent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}

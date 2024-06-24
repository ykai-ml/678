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
    public partial class 学生端_管理登录 : Form
    {
        string strCon = @"server=(local);database=学生成绩管理系统;Integrated security=true";
        public 学生端_管理登录()
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string strCon = @"server=(local);database=学生成绩管理系统;Integrated security=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = strCon;
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string strCmd = "select * from 学生$ where 学号='{0}' and 授权码='{1}'";
                strCmd = string.Format(strCmd, LoadInfor.X_Sno, textBox1.Text.Trim());
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = strCmd;
                SqlDataReader dr = command.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    this.Close();
                    new 学生端_管理().Show();
                }
                else
                {
                    MessageBox.Show("授权码不正确或你无权进入");
                }
            }
            else
            {
                MessageBox.Show("授权码不正确或你无权进入");
            }
        
        }
    }
}

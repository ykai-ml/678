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
    public partial class 教师端_成绩查询 : Form
    {
        string strCon = @"server=(local);database=成绩系统;Integrated security=true";
        public 教师端_成绩查询()
        {
            InitializeComponent();
            toolStripTextBox1.Text = LoadInfor.T_Sname;
            toolStripTextBox2.Text = LoadInfor.T_Sno;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "select * from book where 年级='{0}' and 班级='{0}' and 学号='{0}'";
                strCmd = string.Format(strCmd, comboBox1.Text, comboBox2.Text, textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
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

        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 教师端_个人信息().Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 教师端登录界面().Show();
        }
    }
}

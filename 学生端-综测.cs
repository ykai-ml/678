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

namespace 学生成绩管理系统
{
    public partial class 学生端_综测 : Form
    {
        public 学生端_综测()
        {
            InitializeComponent();
            toolStripTextBox1.Text = LoadInfor.X_Sname;
            toolStripTextBox2.Text = LoadInfor.X_Sno;
        }

        private void 成绩查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端_成绩查询().Show();
        }

        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端_成绩查询().Show();
        }

        private void 管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端_管理登录().Show();
        }

        private void 课程信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端_课程信息().Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端登录界面().Show();
        }
        SqlConnection Con = new SqlConnection(@"server=(local);database=学生成绩管理系统;Integrated security=true");
        //底部显示表格
        private void populate()
        {
            Con.Open();
            string query = "select * from 综测";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);//创建数据的批量抓取
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);//组合使用可用来批量处理数据库数据
            //创建虚拟数据库
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || pictureBox1.Image != null)
            {
                MessageBox.Show("信息缺失！请检查条件是否完整！");
            }
            else
            {
                try
                {
                    Con.Open();
                    string shzt2 = "未审核";
                    string query = "insert into 综测 values('" + LoadInfor.X_Sno + "','" + LoadInfor.X_Class + "','"+null+"', '" + textBox2.Text + "','" + textBox3.Text + "' , '" + textBox4.Text + "','" + shzt2 + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);//cmd对象向数据库发送增删改查操作的sql语句
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("该条信息保存成功！！");
                    Con.Close();
                    populate();
                    Reset();
                }
                
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

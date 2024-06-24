using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 学生成绩管理系统
{
    public partial class 教师端_成绩查询 : Form
    {
        

        public 教师端_成绩查询()
        {
            InitializeComponent();
            toolStripLabel3.Text = LoadInfor.T_Sname;
            toolStripLabel2.Text = LoadInfor.T_Sno;
            

        }
        string strCon = @"server=(local);database=学生成绩管理系统;Integrated security=true";
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();
                string query = @"SELECT c.课程名,cl.班级名,s.学号,s.姓名,sc.成绩
                          FROM 学生$ s
                          JOIN 班级$ cl ON s.班级号 = cl.班级号
                          JOIN 选课$ sc ON s.学号 = sc.学号
                          JOIN 课程$ c ON sc.课程号 = c.课程号
                          WHERE 1=1";
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    query += " AND cl.班级号 = @班级号";
                }
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    query += " AND c.课程号 = @课程号";
                }
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    query += " AND s.学号 = @学号";
                }
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(textBox1.Text))
                    {
                        command.Parameters.AddWithValue("@班级号", textBox1.Text);
                    }
                    if (!string.IsNullOrEmpty(textBox2.Text))
                    {
                        command.Parameters.AddWithValue("@课程号", textBox2.Text);
                    }
                    if (!string.IsNullOrEmpty(textBox3.Text))
                    {
                        command.Parameters.AddWithValue("@学号", textBox3.Text);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
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

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void 教师端_成绩查询_Load(object sender, EventArgs e)
        {

        }
    }
}

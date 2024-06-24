using System;
using System.Collections;
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
                string query = @"SELECT 课程$.课程名, 班级$.班级名, 学生$.学号, 学生$.姓名, 选课$.成绩
                          FROM 学生$
                          JOIN 班级$ ON 学生$.班级号 = 班级$.班级号
                          JOIN 选课$ ON 学生$.学号 = 选课$.学号
                          JOIN 课程$ ON 选课$.课程号 = 课程$.课程号
                          WHERE 1=1";
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    query += " AND 班级$.班级号 = @班级号";
                }
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    query += " AND 课程$.课程号 = @课程号";
                }
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    query += " AND 学生$.学号 = @学号";
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
        //chaxun();
        /* 
         if (textBox1.Text != "" && textBox2.Text == "" && textBox3.Text == "")
         {
             try
             {
                 Con.Open();
                 string query = "select  班级名,学号,成绩 from 选课$,学生$,班级$ where ";
                 SqlCommand cmd = new SqlCommand(query, Con);//cmd对象向数据库发送增删改查操作的sql语句
                 cmd.ExecuteNonQuery();
                 MessageBox.Show("该条信息保存成功！！");
                 Con.Close();
             }
             catch (Exception Ex)
             {
                 MessageBox.Show(Ex.Message);
             }
         }
        else if(textBox1.Text == "" && textBox2.Text != "" && textBox3.Text == "")
         {

         }
         else if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text != "")
         {

         }
         else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text == "")
         {

         }
         else if (textBox1.Text != "" && textBox2.Text == "" && textBox3.Text != "")
         {

         }
         else if (textBox1.Text == "" && textBox2.Text != "" && textBox3.Text != "")
         {

         }
         else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
         {

         }
         */


        /*using (SqlConnection con = new SqlConnection(strCon))
        {
            if (textBox1.Text != "")
            {
                string strCmd1 = "select 课程名,班级名,学生$.学号,姓名,成绩 from 课程$,班级$,学生$,选课$ where 班级$.班级号={0} and 学生$.学号=选课$.学号  and 学生$.班级号=班级$.班级号 and 课程$.课程号=选课$.课程号";
                //string strCmd2 = "select 课程名,班级名,学生$.学号,姓名,成绩 from 课程$,班级$,学生$,选课$ where 选课$.课程号={0} and 学生$.学号=选课$.学号  and 学生$.班级号=班级$.班级号 and 课程$.课程号=选课$.课程号";

                strCmd1 = string.Format(strCmd1, textBox1.Text);
                //strCmd2 = string.Format(strCmd2, textBox2.Text);

                SqlDataAdapter da1 = new SqlDataAdapter(strCmd1, con);
                //SqlDataAdapter da2 = new SqlDataAdapter(strCmd2, con);

                DataSet ds1 = new DataSet();
                //DataSet ds2 = new DataSet();

                da1.Fill(ds1);
                //da2.Fill(ds2);

                //dataGridView1.DataSource = ds2.Tables[0].DefaultView;
                dataGridView1.DataSource = ds1.Tables[0].DefaultView;
            }
            else if(textBox2.Text !="")
            {
                string strCmd2 = "select 课程名,班级名,学生$.学号,姓名,成绩 from 课程$,班级$,学生$,选课$ where 课程$.课程号={0} and 学生$.学号=选课$.学号  and 学生$.班级号=班级$.班级号 and 课程$.课程号=选课$.课程号";
                strCmd2 = string.Format(strCmd2, textBox2.Text);
                SqlDataAdapter da2 = new SqlDataAdapter(strCmd2, con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dataGridView1.DataSource = ds2.Tables[0].DefaultView;

            }
            */

        /*
        string strCmd2 = "select 课程名,班级名,学生$.学号,姓名,成绩 from 课程$,班级$,学生$,选课$ where 课程号={0} and 学生$.学号=选课$.学号  and 学生$.班级号=班级$.班级号 and 课程$.课程号=选课$.课程号";
        strCmd2 = string.Format(strCmd2, textBox2.Text);
        SqlDataAdapter da2 = new SqlDataAdapter(strCmd2, con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        dataGridView1.DataSource = ds2.Tables[0].DefaultView;
        */

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
    }
}

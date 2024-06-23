using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 学生成绩管理系统
{
    public partial class 教师端_成绩录入 : Form
    {
        //SqlConnection Con = new SqlConnection(@"server=(local);database=学生成绩管理系统;Integrated security=true");
        public 教师端_成绩录入()
        {
            InitializeComponent();//初始化
            toolStripTextBox1.Text = LoadInfor.T_Sname;
            toolStripTextBox2.Text = LoadInfor.T_Sno;
            populate();//将函数写入
        }
        
        SqlConnection Con = new SqlConnection(@"server=(local);database=学生成绩管理系统;Integrated security=true");
        //底部显示表格
        private void populate()
        {
            Con.Open();
            string query = "select * from 选课$";
            SqlDataAdapter sda = new SqlDataAdapter(query,Con);//创建数据的批量抓取
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);//组合使用可用来批量处理数据库数据
            //创建虚拟数据库
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();
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

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //录入保存
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox3.Text == "" || textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("信息缺失！请检查条件是否完整！");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into 选课$ values('"+ textBox1.Text + "' , '"+ textBox2.Text  + "','"+ textBox3.Text+ "')";
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
        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //修改
        private void button2_Click(object sender, EventArgs e)
        {
            using (Con)
            {
               Con.Open();
                string query = @"UPDATE 选课$
                         SET 成绩 = @成绩
                         WHERE 学号 = @学号 AND 课程号 = @课程号";
                if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
                {
                    using (SqlCommand command = new SqlCommand(query, Con))
                    {
                        command.Parameters.AddWithValue("@学号", textBox1.Text);
                        command.Parameters.AddWithValue("@课程号", textBox2.Text);
                        command.Parameters.AddWithValue("@成绩", textBox3.Text);
                        int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("修改成功！");
                            }
                            else
                            {
                                MessageBox.Show("修改失败！");
                            }
                    }
                }
                else
                {
                    MessageBox.Show("请输入完整的学号、课程号和成绩！");
                }
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["学号"].Value.ToString();
                textBox2.Text = row.Cells["课程号"].Value.ToString();
                textBox3.Text = row.Cells["成绩"].Value.ToString();
            }
        }

        //删除
        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                
                using (Con)
                {
                    Con.Open();
                    string deleteCommand = "DELETE FROM 选课$ WHERE 学号=@学号 AND 课程号=@课程号 AND 成绩=@成绩";
                    using (SqlCommand command = new SqlCommand(deleteCommand, Con))
                    {
                        command.Parameters.AddWithValue("@学号", textBox1.Text);
                        command.Parameters.AddWithValue("@课程号", textBox2.Text);
                        command.Parameters.AddWithValue("@成绩", textBox3.Text);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("删除成功");
                            // 更新dataGridView的数据源
                            // dataGridView.DataSource = GetUpdatedDataSource();
                        }
                        else
                        {
                            MessageBox.Show("未找到匹配的记录");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请输入完整的学号、课程号和成绩");
            }
        }
        //重置，清空输入框内容
        
        private void button4_Click(object sender, EventArgs e)
        {
            Reset();

        }
       
        private void Reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        //更新
        private void button5_Click(object sender, EventArgs e)
        {
            //populate();
        }
        int key = 0;

        //将选中的行信息显示到三个文本框里
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                  if(textBox1.Text == "")
                    {
                         key = 0;
                    }
            else
            {
                key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
            
    }


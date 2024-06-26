﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 学生成绩管理系统
{
    public partial class 学生端_综测 : Form
    {
        public 学生端_综测()
        {
            InitializeComponent();
            toolStripLabel3.Text = LoadInfor.X_Sname;
            toolStripLabel2.Text = LoadInfor.X_Sno;
            populate();
        }
        string Con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\学生成绩管理系统.mdf;Integrated Security=True;Connect Timeout=30";
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
            new 学生端_守则().Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端登录界面().Show();
        }
        
        //底部显示表格
        private void populate()
        {
            using (SqlConnection con = new SqlConnection(Con))
            {
                con.Open();
                string query = "select * from 综测 where 学号='" + LoadInfor.X_Sno + "'";

                //string query = "select * from 综测";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);//创建数据的批量抓取
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);//组合使用可用来批量处理数据库数据
                                                                       //创建虚拟数据库
                var ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
                 
        }
        private void Reset()
        {
            textBox2.Text = "";
            comboBox1.SelectedIndex =-1;
            textBox4.Text = "";
        }

        //修改
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Con))
              
                if (textBox2.Text == "" ||comboBox1.SelectedIndex == -1 || textBox4.Text == "" || pictureBox1.Image == null)
                {
                    MessageBox.Show("信息缺失！请检查条件是否完整！");
                }
                else
                {
                    try
                    {
                        con.Open();
                        string shzt2 = "未审核";
                        string query = "insert into 综测 values('" + LoadInfor.X_Sno + "','" + LoadInfor.X_Class + "','" + pictureBox1.Image + "', '" + textBox2.Text + "','" + comboBox1.Text + "' , '" + textBox4.Text + "','" + shzt2 + "')";
                        SqlCommand cmd = new SqlCommand(query, con);//cmd对象向数据库发送增删改查操作的sql语句
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("该条信息保存成功！！");
                        con.Close();
                        populate();
                        Reset();
                    }

                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }

                }
        }
        //删除
        private void button2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells["学号"].Value.ToString();
            using (SqlConnection con = new SqlConnection(Con))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string strCmd = "delete from 综测 where 学号={0}";
                    strCmd = string.Format(strCmd, id);
                    SqlCommand command = new SqlCommand(strCmd, con);
                    command.ExecuteNonQuery();
                    populate();
                }
            }


            /*if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(comboBox1.SelectedIndex.ToString()) && !string.IsNullOrEmpty(textBox4.Text))
            {

            using (SqlConnection con = new SqlConnection(Con))
                {
                    con.Open();
                    string deleteCommand = "DELETE FROM 综测 WHERE 学号='" + LoadInfor.X_Sno + "' AND 活动名称=@活动名称 AND 加分类型=@加分类型";
                    using (SqlCommand command = new SqlCommand(deleteCommand, con))
                    {


                        command.Parameters.AddWithValue("@学号", LoadInfor.X_Sno);
                        command.Parameters.AddWithValue("@活动名称", textBox2.Text);
                        command.Parameters.AddWithValue("@加分类型", comboBox1.SelectedIndex.ToString());
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
                        con.Close();
                        populate(); 
                        Reset();
                }
            }
            else
            {
                MessageBox.Show("请输入完整的信息！！！");
            }*/
        }
        //修改
        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Con))
            {
                con.Open();
                string query = @"UPDATE 综测
                         SET  分值=@分值
                         WHERE 学号 = @学号 AND 活动名称 = @活动名称 AND 加分类型 =@加分类型";
                if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(comboBox1.SelectedIndex.ToString()) && !string.IsNullOrEmpty(textBox4.Text))
                {
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@学号", LoadInfor.X_Sno);

                        command.Parameters.AddWithValue("@活动名称", textBox2.Text);
                        command.Parameters.AddWithValue("@加分类型", comboBox1.SelectedIndex.ToString()     );
                        command.Parameters.AddWithValue("@分值", textBox4.Text);
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
                    MessageBox.Show("请输入完整的信息！！");
                }
                con.Close();
                populate();
                Reset();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

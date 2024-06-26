﻿using System;
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
    public partial class 学生端_管理 : Form
    {
        string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\学生成绩管理系统.mdf;Integrated Security=True;Connect Timeout=30";
        public 学生端_管理()
        {
            InitializeComponent();
            toolStripLabel3.Text = LoadInfor.X_Sname;
            toolStripLabel2.Text = LoadInfor.X_Sno;
        }
        public void InitZc()
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string strCmd = "select * from 综测 where 班级名='{0}'";
                strCmd = string.Format(strCmd, LoadInfor.X_Class);
                SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }
        private void button1_Click(object sender, EventArgs e)//修改
        {
            string id = dataGridView1.CurrentRow.Cells["学号"].Value.ToString();
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string strCmd = "update 综测 set 状态='{0}' where 学号='{1}'";
                    strCmd = string.Format(strCmd, comboBox1.Text, id);
                    SqlCommand command = new SqlCommand(strCmd, con);
                    command.ExecuteNonQuery();
                    InitZc();
                }
            }
        }

        private void 学生端_管理_Load(object sender, EventArgs e)
        {
            InitZc();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                comboBox1.Text = row.Cells["状态"].Value.ToString();
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.Close();
            new 学生端登录界面().Show();
        }

        private void 课程信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端_守则().Show();
        }

        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端个人信息().Show();
        }

        private void 成绩查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端_成绩查询().Show();
        }

        private void 综测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 学生端_综测().Show();
        }
    }
}

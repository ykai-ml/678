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
    public partial class 管理员登录界面 : Form
    {
        public 管理员登录界面()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strCon = @"server=(local);database=学生成绩管理系统;Integrated security=true";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = strCon;
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string strCmd = "select * from 管理员$ where 职工号='{0}' and 密码='{1}'";
                strCmd = string.Format(strCmd, textBox1.Text.Trim(), textBox2.Text.Trim());
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = strCmd;
                SqlDataReader dr = command.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    this.Hide();
                    //管理员端窗口显示
                    new 管理员_学生列表().Show();
                }
                else
                {
                    MessageBox.Show("职工号或密码不正确");
                }
            }
            else
            {
                MessageBox.Show("职工号或密码不正确");
            }
        }
    }
}

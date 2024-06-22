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
    public partial class 学生端登录界面 : Form
    {
        public 学生端登录界面()
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
                LoadInfor.X_Sno = textBox1.Text;
                string Name = "select * from 学生$ where 学号='{0}'";
                Name = string.Format(Name, textBox1.Text.Trim());
                SqlCommand command1 = new SqlCommand();
                command1.Connection = con;
                command1.CommandText = Name;
                SqlDataReader reader = command1.ExecuteReader();
                reader.Read();
                LoadInfor.X_Sname = (string)reader["姓名"];
                reader.Close();

                string strCmd = "select * from 学生$ where 学号='{0}' and 密码='{1}'";
                strCmd = string.Format(strCmd, textBox1.Text.Trim(), textBox2.Text.Trim());
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = strCmd;
                SqlDataReader dr = command.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    this.Hide();
                    //学生端窗口显示
                    new 学生端个人信息().Show();
                }
                else
                {
                    MessageBox.Show("学号或密码不正确");
                }
            }
            else
            {
                MessageBox.Show("学号或密码不正确");
            }
        }
    }
}

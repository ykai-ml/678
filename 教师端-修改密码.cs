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
    public partial class 教师端_修改密码 : Form
    {
        public 教师端_修改密码()
        {
            InitializeComponent();
            label3.Text = LoadInfor.T_Sno;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. 从textBox1中获取新密码
            string newPassword = textBox1.Text;

            // 2. 使用ADO.NET连接数据库
            string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\学生成绩管理系统.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                // 3. 编写SQL语句，用于更新学生表中的密码
                string updateSql = "UPDATE 教师表$ SET 密码 = @新密码 WHERE 教工号 = @教工号";
                using (SqlCommand command = new SqlCommand(updateSql, connection))
                {
                    command.Parameters.AddWithValue("@新密码", newPassword);
                    command.Parameters.AddWithValue("@教工号", label3.Text);

                    // 4. 执行SQL语句，完成密码的修改
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("密码修改成功！");
                        }
                        else
                        {
                            MessageBox.Show("密码修改失败，请重试！");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发生错误：" + ex.Message);
                    }
                }
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

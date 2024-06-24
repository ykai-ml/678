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
    public partial class 学生端_管理 : Form
    {
        string strCon = @"server=(local);database=学生成绩管理系统;Integrated security=true";
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
    }
}

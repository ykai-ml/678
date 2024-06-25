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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace 学生成绩管理系统
{
    public partial class 教师端_成绩分析 : Form
    {
        private SqlConnection connection;
        public 教师端_成绩分析()
        {
            InitializeComponent();
            toolStripLabel3.Text = LoadInfor.T_Sname;
            toolStripLabel2.Text = LoadInfor.T_Sno;
            ConnectToDatabase();
        }
        private void ConnectToDatabase()
        {
            //string connectionString = "server=(local);database=学生成绩管理系统;Integrated security=true";
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\学生成绩管理系统.mdf;Integrated Security=True;Connect Timeout=30";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 成绩查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 教师端_成绩查询().Show();
        }

        private void 成绩录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 教师端_成绩录入().Show();
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

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }
        private void DisplayCourseStatistics(string classId, string courseId)
        {
            string query = @"SELECT c.课程号, c.课程名, cl.班级号, AVG(sc.成绩) AS 平均分, COUNT(CASE WHEN sc.成绩 < 60 THEN 1 ELSE NULL END) AS 不及格人数, COUNT(CASE WHEN sc.成绩 >= 60 THEN 1 ELSE NULL END) / COUNT(*) * 100 AS 及格率
                             FROM 选课$ sc
                             INNER JOIN 学生$ cl ON sc.学号 = cl.学号
                             INNER JOIN 课程$ c ON sc.课程号 = c.课程号
                             WHERE cl.班级号 = @班级号 AND c.课程号 = @课程号
                             GROUP BY c.课程号, c.课程名, cl.班级号";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@班级号", classId);
            command.Parameters.AddWithValue("@课程号", courseId);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }

        private void DisplayStudentStatistics(string studentId, string courseId)
        {
            string query = @"SELECT c.课程号, c.课程名, st.学号, st.姓名
                             FROM 选课$ sc
                             INNER JOIN 学生$ st ON sc.学号 = st.学号
                             INNER JOIN 课程$ c ON sc.课程号 = c.课程号
                             WHERE st.学号 = @学号 AND c.课程号 = @课程号";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@学号", studentId);
            command.Parameters.AddWithValue("@课程号", courseId);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }

        private void DisplayStudentGrades(string studentId)
        {
            string query = @"SELECT c.课程号, c.课程名, sc.成绩
                             FROM 选课$ sc
                             INNER JOIN 课程$ c ON sc.课程号 = c.课程号
                             WHERE sc.学号 = @学号";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@学号", studentId);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }
        private void DisplayingCourseStatistics(string courseId)
        {
            string query = @"SELECT c.课程号, c.课程名, cl.班级号, cls.班级名, AVG(sc.成绩) AS 平均分, COUNT(CASE WHEN sc.成绩 < 60 THEN 1 ELSE NULL END) AS 不及格人数, COUNT(CASE WHEN sc.成绩 >= 60 THEN 1 ELSE NULL END) / COUNT(*) * 100 AS 及格率
                     FROM 选课$ sc
                     INNER JOIN 学生$ cl ON sc.学号 = cl.学号
                     INNER JOIN 课程$ c ON sc.课程号 = c.课程号
                     INNER JOIN 班级$ cls ON cl.班级号 = cls.班级号
                     WHERE c.课程号 = @课程号
                     GROUP BY c.课程号, c.课程名, cl.班级号, cls.班级名";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@课程号", courseId);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }


        //分析按钮
        // ...

        private void button1_Click(object sender, EventArgs e)
        {
            string classId = textBox1.Text;
            string courseId = textBox2.Text;
            string studentId = textBox3.Text;

            if (!string.IsNullOrEmpty(classId) && !string.IsNullOrEmpty(courseId))
            {
                DisplayCourseStatistics(classId, courseId);
            }
            else if (!string.IsNullOrEmpty(studentId) && !string.IsNullOrEmpty(courseId))
            {
                DisplayStudentStatistics(studentId, courseId);
            }
            else if (!string.IsNullOrEmpty(studentId))
            {
                DisplayStudentGrades(studentId);
            }
            else if (!string.IsNullOrEmpty(courseId))
            {
                DisplayingCourseStatistics(courseId);
            }


        }
    }
}
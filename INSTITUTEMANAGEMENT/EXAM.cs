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
using System.Configuration;

namespace INSTITUTEMANAGEMENT
{
    public partial class exam : Form
    {
        public exam()
        {
            InitializeComponent();
        }
        public string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;

        private void Guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (txtsid.Text != string.Empty && subject.Text != string.Empty && course.Text != string.Empty && txtdid.Text != string.Empty)
            {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO exam (stdid, coursename, sub, deptid) VALUES (@stdid, @coursename, @sub, @deptid)", conn);

                cmd.Parameters.AddWithValue("@stdid", txtsid.Text);
                cmd.Parameters.AddWithValue("@coursename", course.Text);
                cmd.Parameters.AddWithValue("@sub", subject.Text);
                cmd.Parameters.AddWithValue("@deptid", txtdid.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Exam record added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                conn.Close();
            }
            else
            {
                MessageBox.Show("Please fill all the fields", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void EXAM_Load(object sender, EventArgs e)
        {
            course.Items.AddRange(new string[] { "BCA", "BBA", "B.COM", "BSW", "BSC", "BA" });
            course.SelectedIndex = 0;

            course.SelectedIndexChanged += Course_SelectedIndexChanged;
        }

        private void Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            subject.Items.Clear();

            string selectedCourse = course.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedCourse)) return;

            if (selectedCourse == "BCA")
            {
                subject.Items.AddRange(new string[] {
            "Fundamentals of IT", "C Programming", "Digital Electronics", "Operating System",
            "Data Structures", "Database Management System", "Java Programming","Python Programming","Webdevelopment",
            "Mobile App Development","Cloud Computing","Cyber Security","Artificial Intelligence"
        });
            }
            else if (selectedCourse == "BBA")
            {
                subject.Items.AddRange(new string[] {
            "Management Principles", "Marketing", "HRM", "Business Law","Financial Management", "Operations Management", "E-Commerce",
            "Business Ethics", "Organizational Behaviour", "Entrepreneurship"
        });
            }
            else if (selectedCourse == "B.COM")
            {
                subject.Items.AddRange(new string[] {
            "Financial Accounting", "Business Economics", "Corporate Law", "Taxation","Cost Accounting", "Auditing", "Banking & Insurance",
            "Statistics for Business", "Investment Analysis", "E-Filing of Tax"
        });
            }
            else if (selectedCourse == "BSW")
            {
                subject.Items.AddRange(new string[] {
            "Social Work", "Field Work", "Human Behavior", "Case Work","Community Organization", "Social Policy", "Social Legislation",
            "Welfare Administration", "Counseling Techniques", "NGO Management",
        });
            }
            else if (selectedCourse == "BSC")
            {
                subject.Items.AddRange(new string[] {
            "Physics", "Chemistry", "Biology", "Maths","Zoology", "Botany", "Environmental Science",
            "Biochemistry", "Microbiology", "Geology"
        });
            }
            else if (selectedCourse == "BA")
            {
                subject.Items.AddRange(new string[]{
            "History", "Sociology", "Psychology", "Political Science","Economics", "English Literature", "Hindi Literature",
            "Geography", "Education", "Public Administration"
            });
            }

            subject.SelectedIndex = 0;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (txtsid.Text != "")
            {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE exam SET coursename=@coursename, sub=@sub, deptid=@deptid WHERE stdid=@stdid", conn);
                cmd.Parameters.AddWithValue("@stdid", txtsid.Text);
                cmd.Parameters.AddWithValue("@coursename", subject.Text);
                cmd.Parameters.AddWithValue("@sub", course.Text);
                cmd.Parameters.AddWithValue("@deptid", txtdid.Text);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Record updated successfully");

            }
            else
            {
                MessageBox.Show("Enter Student ID to update");
            }

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (txtsid.Text != "")
            {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM exam WHERE stdid=@stdid", conn);
                cmd.Parameters.AddWithValue("@stdid", txtsid.Text);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Record deleted successfully");

            }
            else
            {
                MessageBox.Show("Enter Student ID to delete");
            }

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (txtsid.Text != "")
            {
               SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM exam WHERE stdid=@stdid", conn);
                cmd.Parameters.AddWithValue("@stdid", txtsid.Text);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                   
                    course.Text = reader["CourseName"].ToString();
                    txtdid.Text = reader["deptid"].ToString();
                    subject.Text = reader["sub"].ToString();
                }
                else
                {
                    MessageBox.Show("No record found");
                }

                conn.Close();
            }
            else
            {
                MessageBox.Show("Enter Student ID to search");
            }
        }

        private void course_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void aTTENDENCEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ATTENTENDANCE att = new ATTENTENDANCE();
            att.Show();
            this.Hide();
        }

        private void cOURSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Course c = new Course();
            c.Show();
            this.Hide();
        }

        private void sTUDENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TEACHING_STAFF ts = new TEACHING_STAFF();
            ts.Hide();
            this.Show();
        }

        private void sTUDENTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            STUDENT S = new STUDENT();
            S.Show();
            this.Hide();
        }

        private void tEACHINGSTAFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TEACHING_STAFF te = new TEACHING_STAFF();
            te.Show();
            this.Hide();
        }

        private void oFFOCESTSFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Officestaff os = new Officestaff();
            os.Show();
            this.Hide();
        }

        private void cOURSEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Course c = new Course();
            c.Show();
            this.Hide();
        }

        private void dEPARTMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Department dep = new Department();
            dep.Show();
            this.Hide();
        }

        private void eXAMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            exam em = new exam();
            em.Show();
            this.Hide();
        }
       

        private void rESULTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RESULT res = new RESULT();
            res.Show();
            this.Hide();
        }

        private void rESULTVIEWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void fEEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Fee f = new Fee();
            f.Show();
            this.Hide();
        }

        private void fEEVIEWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FEEVIEW fv = new FEEVIEW();
            fv.Show();
            this.Hide();
        }

        private void pERSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PERSON p = new PERSON();
            p.Show();
            this.Hide();
        }

        private void rESULTToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RESULT res = new RESULT();
            res.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN l = new LOGIN();
            l.Show();
        }

        private void rESULTVIEWToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RESULTVIEW rv = new RESULTVIEW();
            rv.Show();
            this.Hide();

        }

        private void fEEToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Fee f = new Fee();
            f.Show();
            this.Hide();

        }

        private void fEEVIEWToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FEEVIEW fv = new FEEVIEW();
            fv.Show();
            this.Hide();

        }

        private void pERSONToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            PERSON p = new PERSON();
            p.Show();
            this.Hide();

        }
    }
}

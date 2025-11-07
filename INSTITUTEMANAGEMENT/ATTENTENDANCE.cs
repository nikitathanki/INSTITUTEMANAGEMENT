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
    public partial class ATTENTENDANCE : Form
    {
        
        public ATTENTENDANCE()
        {
            InitializeComponent();
        }
        public string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;

        private void Guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Guna2Button3_Click(object sender, EventArgs e)
        {

              if (txtstdid.Text != "")
                {
                SqlConnection conn = new SqlConnection(cs);
                       conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM attendance WHERE stdid = @stdid AND attendancedate = @attendancedate", conn);
                    cmd.Parameters.AddWithValue("@stdid", txtstdid.Text);
                    cmd.Parameters.AddWithValue("@attendancedate", dtpdate.Value.Date);

                    int i = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (i > 0)
                    {
                        MessageBox.Show("Record deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       // guna2Button3.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("No matching record found to delete.", "Incorrect Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Enter Student ID to delete.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
        }
        

        private void Guna2Button2_Click(object sender, EventArgs e)
        {
           
                if (txtdpid.Text != "" && txtstdnm.Text != "" && txtstdid.Text != "" &&
                    course.Text != "" && subject.Text != "" &&
                    (guna2RadioButton1.Checked || guna2RadioButton2.Checked))
                {
                    string status = guna2RadioButton1.Checked ? "Present" : "Absent";
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE attendance SET deptid=@deptid, stdnm=@stdnm, coursenm=@coursenm, sub=@sub, status=@status WHERE stdid=@stdid AND attendancedate=@attendancedate", conn);

                    cmd.Parameters.AddWithValue("@deptid", txtdpid.Text);
                    cmd.Parameters.AddWithValue("@stdnm", txtstdnm.Text);
                    cmd.Parameters.AddWithValue("@coursenm", course.Text);
                    cmd.Parameters.AddWithValue("@sub", subject.Text);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@stdid", txtstdid.Text);
                    cmd.Parameters.AddWithValue("@attendancedate", dtpdate.Value.Date);

                    int i = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (i > 0)
                    {
                        MessageBox.Show("Attendance record updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No matching record found to update.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all fields and select Present/Absent.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            

        }
        

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
               if (txtdpid.Text != "" && txtstdnm.Text != "" && txtstdid.Text != "" &&
                    course.Text != "" && subject.Text != "" &&
                    (guna2RadioButton1.Checked || guna2RadioButton2.Checked))
                {
                    string status = guna2RadioButton1.Checked ? "Present" : "Absent";

                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO attendance (deptid, stdnm, stdid, coursenm, sub, status, attendancedate) VALUES (@deptid, @stdnm, @stdid, @coursenm, @sub, @status, @attendancedate)", conn);

                    cmd.Parameters.AddWithValue("@deptid", txtdpid.Text);
                    cmd.Parameters.AddWithValue("@stdnm", txtstdnm.Text);
                    cmd.Parameters.AddWithValue("@stdid", txtstdid.Text);
                    cmd.Parameters.AddWithValue("@coursenm", course.Text);
                    cmd.Parameters.AddWithValue("@sub", subject.Text);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@attendancedate", dtpdate.Value);

                    int i = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (i > 0)
                {
                    MessageBox.Show("Attendance record added successfully.", "Add Data", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    
                }
                else
                    {
                        MessageBox.Show("Failed to add record." ,"Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all fields and select Present/Absent.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
        }


            private void Guna2TextBox5_TextChanged(object sender, EventArgs e)
            {

        }

        private void Guna2Button4_Click(object sender, EventArgs e)
        {
           
                if (txtstdid.Text != "")
                {
                SqlConnection conn = new SqlConnection(cs);   
                conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM attendance WHERE stdid = @stdid AND attendancedate = @attendancedate", conn);
                    cmd.Parameters.AddWithValue("@stdid", txtstdid.Text);
                    cmd.Parameters.AddWithValue("@attendancedate", dtpdate.Value.Date);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtdpid.Text = dr["deptid"].ToString();
                        txtstdnm.Text = dr["stdnm"].ToString();
                        course.Text = dr["coursenm"].ToString();
                        subject.Text = dr["sub"].ToString();
                        string status = dr["status"].ToString();

                        guna2RadioButton1.Checked = (status == "Present");
                        guna2RadioButton2.Checked = (status == "Absent");
                    }
                    else
                    {
                        MessageBox.Show("No record found.");
                    }
                    dr.Close();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Enter Student ID to search.");
                }
            


        }
        

        private void Guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtatt_Click(object sender, EventArgs e)
        {
            // ATTENTENDANCE att = new ATTENTENDANCE();
            // att.txtdpid = int.Parse(txtdpid.Text);
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ATTENTENDANCE_Load(object sender, EventArgs e)
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

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void course_SelectedIndexChanged_1(object sender, EventArgs e)
        {
         
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
                txtdpid.Clear();
                txtstdnm.Clear();
                txtstdid.Clear();
                course.SelectedIndex = -1;
                subject.SelectedIndex = -1;
                guna2RadioButton1.Checked = false;
                guna2RadioButton2.Checked = false;
                dtpdate.Value = DateTime.Now;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
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

        private void sUBJECTToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            RESULTVIEW rv = new RESULTVIEW();
            rv.Show();
            this.Hide();
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

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN l = new LOGIN();
            l.Show();

        }

        private void fEEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
    }
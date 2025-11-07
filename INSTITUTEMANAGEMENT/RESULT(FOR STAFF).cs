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
    public partial class RESULT : Form
    {
        public RESULT()
        {
            InitializeComponent();
        }
        public string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (txtterm.Text != "" && coursec.Text != "" && subjectc.Text != "" && txtmarks.Text != "" && txtstdid.Text != "")
            {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM student WHERE stdid = @stdid", conn);
                checkCmd.Parameters.AddWithValue("@stdid", txtstdid.Text);
                int exists = (int)checkCmd.ExecuteScalar();

                if (exists == 0)
                {
                    MessageBox.Show("Student ID not found. Please enter a valid Student ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return;
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO finalresult (term, course, sub, marks, stdid) VALUES ( @term, @course, @sub, @marks, @stdid)", conn);
                cmd.Parameters.AddWithValue("@term", txtterm.Text);
                cmd.Parameters.AddWithValue("@course", coursec.Text);
                cmd.Parameters.AddWithValue("@sub", subjectc.Text);
                cmd.Parameters.AddWithValue("@marks", txtmarks.Text);
                cmd.Parameters.AddWithValue("@stdid", txtstdid.Text);

                int rowsAffected = cmd.ExecuteNonQuery(); // Add this line
                conn.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Result Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Insert failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void RESULT_Load(object sender, EventArgs e)
        {
            txtresultid.ReadOnly = true;
            txtresultid.TabStop = false;
            txtresultid.Enabled = false;
            coursec.Items.Clear();
            coursec.Items.AddRange(new string[]
            {
                "BCA","BBA","BSW","B.SC","B.COM","BA"
            });
           
            coursec.SelectedIndexChanged += Coursec_SelectedIndexChanged;
            
        }

        private void Coursec_SelectedIndexChanged(object sender, EventArgs e)
        {
            subjectc.Items.Clear();

            string selectedCourse = coursec.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedCourse)) return;

            if (selectedCourse == "BCA")
            {
                subjectc.Items.AddRange(new string[] {
            "Fundamentals of IT", "C Programming", "Digital Electronics", "Operating System",
            "Data Structures", "Database Management System", "Java Programming","Python Programming","Webdevelopment",
            "Mobile App Development","Cloud Computing","Cyber Security","Artificial Intelligence"
        });
            }
            else if (selectedCourse == "BBA")
            {
                subjectc.Items.AddRange(new string[] {
            "Management Principles", "Marketing", "HRM", "Business Law","Financial Management", "Operations Management", "E-Commerce",
            "Business Ethics", "Organizational Behaviour", "Entrepreneurship"
        });
            }
            else if (selectedCourse == "B.COM")
            {
                subjectc.Items.AddRange(new string[] {
            "Financial Accounting", "Business Economics", "Corporate Law", "Taxation","Cost Accounting", "Auditing", "Banking & Insurance",
            "Statistics for Business", "Investment Analysis", "E-Filing of Tax"
        });
            }
            else if (selectedCourse == "BSW")
            {
                subjectc.Items.AddRange(new string[] {
            "Social Work", "Field Work", "Human Behavior", "Case Work","Community Organization", "Social Policy", "Social Legislation",
            "Welfare Administration", "Counseling Techniques", "NGO Management",
        });
            }
            else if (selectedCourse == "B.SC")
            {
                subjectc.Items.AddRange(new string[] {
            "Physics", "Chemistry", "Biology", "Maths","Zoology", "Botany", "Environmental Science",
            "Biochemistry", "Microbiology", "Geology"
        });
            }
            else if (selectedCourse == "BA")
            {
                subjectc.Items.AddRange(new string[]{
            "History", "Sociology", "Psychology", "Political Science","Economics", "English Literature", "Hindi Literature",
            "Geography", "Education", "Public Administration"
            });
            }

           if(subjectc.Items.Count>0)
            {
                subjectc.SelectedIndex = 0;
            }

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtstdid.Text))
            {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE TOP (1) finalresult SET term = @term, course = @course, sub = @sub, marks = @marks WHERE stdid = @stdid", conn);

                // Truncate inputs to avoid SQL size errors
                cmd.Parameters.AddWithValue("@term", txtterm.Text.Trim().Substring(0, Math.Min(25, txtterm.Text.Trim().Length)));
                cmd.Parameters.AddWithValue("@course", coursec.Text.Trim().Substring(0, Math.Min(20, coursec.Text.Trim().Length)));
                cmd.Parameters.AddWithValue("@sub", subjectc.Text.Trim().Substring(0, Math.Min(20, subjectc.Text.Trim().Length)));
                cmd.Parameters.AddWithValue("@marks", txtmarks.Text.Trim());
                cmd.Parameters.AddWithValue("@stdid", txtstdid.Text.Trim().Substring(0, Math.Min(20, txtstdid.Text.Trim().Length)));

                int i = cmd.ExecuteNonQuery();
                conn.Close();

                if (i > 0)
                {
                    MessageBox.Show("Student result updated successfully.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No matching record found for the given Student ID.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter Student ID to update the record.", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            txtresultid.Clear();
            txtterm.Clear();
            coursec.SelectedIndex = -1;
            subjectc.Items.Clear();
            txtmarks.Clear();
            txtstdid.Clear();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void sTUDENTToolStripMenuItem_Click(object sender, EventArgs e)
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
            em.Hide();
        }
        private void rESULTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RESULT res = new RESULT();
            res.Show();
            res.Hide();
        }

        private void rESULTVIEWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RESULTVIEW rv = new RESULTVIEW();
            rv.Show();
            rv.Hide();
        }

        private void fEEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Fee f = new Fee();
            f.Show();
            f.Hide();
        }

        private void fEEVIEWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FEEVIEW fv = new FEEVIEW();
            fv.Show();
            fv.Hide();
        }

        private void pERSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PERSON p = new PERSON();
            p.Show();
            p.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN l = new LOGIN();
            l.Show();
        }

        private void rESULTToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RESULT res = new RESULT();
            res.Show();
            this.Hide();
        }

        private void rESULTVIEWToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

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
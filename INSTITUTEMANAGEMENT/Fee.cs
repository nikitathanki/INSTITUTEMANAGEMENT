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
    public partial class Fee : Form
    {
        public Fee()
        {
            InitializeComponent();
        }
        public string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;

        private void Guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }
       
        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Fee_Load(object sender, EventArgs e)
        {
            //course categories into combobox
            coursecc.Items.AddRange(new string[] { "BCA", "BBA", "B.COM", "BSW", "BSC", "BA" });
            coursecc.SelectedIndex = 0;
            coursecc.SelectedIndexChanged += Coursecc_SelectedIndexChanged;

            // Load Fee Categories into ComboBox manually
            feecatc.Items.AddRange(new string[]
                {
        "Admission Fee", "Game Fee", "Electricity Fee", "Exam Fee","Education Fee", "Library Fee",
        "Common Fee", "Transportation Fee", "Lab Fee", "Development Fee"
                });
            feecatc.SelectedIndex = 0;
            feecatc.SelectedIndexChanged += Feecatc_SelectedIndexChanged;


               
            
        }

        private void Feecatc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Coursecc_SelectedIndexChanged(object sender, EventArgs e)
        {
            subject.Items.Clear();
            amountc.Items.Clear();

            string selectedCourse = coursecc.Text;
           // if (string.IsNullOrEmpty(selectedCourse)) return;

            if (selectedCourse == "BCA")
            {
                amountc.Items.AddRange(new string[]
                    { "Admission Fee:1000", "Game Fee:500", "Electricity Fee:1000", "Exam Fee:1000","Education Fee:20000", "Library Fee:500",
                    "Common Fee:700", "Transportation Fee:2000", "Lab Fee:1000", "Development Fee:300"  });

                subject.Items.AddRange(new string[] {
            "Fundamentals of IT", "C Programming", "Digital Electronics", "Operating System",
            "Data Structures", "Database Management System", "Java Programming","Python Programming","Webdevelopment",
            "Mobile App Development","Cloud Computing","Cyber Security","Artificial Intelligence"
        });
            }
            else if (selectedCourse == "BBA")
            {
                amountc.Items.AddRange(new string[]
                    { "Admission Fee:1000", "Game Fee:500", "Electricity Fee:500", "Exam Fee:800","Education Fee:15000", "Library Fee:500",
                    "Common Fee:700", "Transportation Fee:2000", "Lab Fee:500", "Development Fee:300"  });

                subject.Items.AddRange(new string[] {
            "Management Principles", "Marketing", "HRM", "Business Law","Financial Management", "Operations Management", "E-Commerce",
            "Business Ethics", "Organizational Behaviour", "Entrepreneurship"
        });
            }
            else if (selectedCourse == "B.COM")
            {
                amountc.Items.AddRange(new string[]
                    { "Admission Fee:1000", "Game Fee:500", "Electricity Fee:200", "Exam Fee:800","Education Fee:18000", "Library Fee:500",
                    "Common Fee:700", "Transportation Fee:2000", "Lab Fee:100", "Development Fee:300"  });

                subject.Items.AddRange(new string[] {
            "Financial Accounting", "Business Economics", "Corporate Law", "Taxation","Cost Accounting", "Auditing", "Banking & Insurance",
            "Statistics for Business", "Investment Analysis", "E-Filing of Tax"
        });
            }
            else if (selectedCourse == "BSW")
            {
                amountc.Items.AddRange(new string[]
                    { "Admission Fee:1000", "Game Fee:500", "Electricity Fee:100", "Exam Fee:800","Education Fee:12000", "Library Fee:500",
                    "Common Fee:700", "Transportation Fee:2000", "Lab Fee:0", "Development Fee:300"  });

                subject.Items.AddRange(new string[] {
            "Social Work", "Field Work", "Human Behavior", "Case Work","Community Organization", "Social Policy", "Social Legislation",
            "Welfare Administration", "Counseling Techniques", "NGO Management",
        });
            }
            else if (selectedCourse == "BSC")
            {
                amountc.Items.AddRange(new string[]
                    { "Admission Fee:1000", "Game Fee:500", "Electricity Fee:1000", "Exam Fee:1000","Education Fee:25000", "Library Fee:500",
                    "Common Fee:700", "Transportation Fee:2000", "Lab Fee:1000", "Development Fee:3000"  });

                subject.Items.AddRange(new string[] {
            "Physics", "Chemistry", "Biology", "Maths","Zoology", "Botany", "Environmental Science",
            "Biochemistry", "Microbiology", "Geology"
        });
            }
            else if (selectedCourse == "BA")
            {
                amountc.Items.AddRange(new string[]
                    { "Admission Fee:500", "Game Fee:500", "Electricity Fee:100", "Exam Fee:500","Education Fee:10000", "Library Fee:500",
                    "Common Fee:700", "Transportation Fee:2000", "Lab Fee:100", "Development Fee:300"  });

                subject.Items.AddRange(new string[]{
            "History", "Sociology", "Psychology", "Political Science","Economics", "English Literature", "Hindi Literature",
            "Geography", "Education", "Public Administration"
            });
            }

            subject.SelectedIndex = 0;
            amountc.SelectedIndex = 0;
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        } 

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void coursecc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void subjcatc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtstdid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button8_Click_1(object sender, EventArgs e)
        {
           
                if (!string.IsNullOrWhiteSpace(txtstdid.Text) &&
                    !string.IsNullOrWhiteSpace(feecatc.Text) &&
                    !string.IsNullOrWhiteSpace(subject.Text) &&
                    !string.IsNullOrWhiteSpace(coursecc.Text) &&
                    !string.IsNullOrWhiteSpace(amountc.Text))
                {
                 SqlConnection conn = new SqlConnection(cs);

                conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO feemaster (stdid, course,sub,feecategory,amount) VALUES(@stdid,@course,@sub,@feecategory,@amount)", conn);
                    cmd.Parameters.AddWithValue("@stdid", txtstdid.Text);
                    cmd.Parameters.AddWithValue("@course", coursecc.Text);
                    cmd.Parameters.AddWithValue("@sub", subject.Text);
                    cmd.Parameters.AddWithValue("@feecategory", feecatc.Text);
                    cmd.Parameters.AddWithValue("@amount", amountc.Text);

                    int i = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (i > 0)
                        MessageBox.Show("Fee record added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Failed to add fee record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Please fill all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


        

        private void guna2TextBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button7_Click_1(object sender, EventArgs e)
        {
            
                if (!string.IsNullOrWhiteSpace(txtstdid.Text) &&
                    !string.IsNullOrWhiteSpace(coursecc.Text) &&
                    !string.IsNullOrWhiteSpace(subject.Text) &&
                    !string.IsNullOrWhiteSpace(feecatc.Text) &&
                    !string.IsNullOrWhiteSpace(amountc.Text))
                {
                SqlConnection conn = new SqlConnection(cs);

                conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE feemaster SET course = @course, sub = @sub, feecategory = @feecategory, amount = @amount WHERE stdid = @stdid", conn);
                    cmd.Parameters.AddWithValue("@course", coursecc.Text);
                    cmd.Parameters.AddWithValue("@sub", subject.Text);
                    cmd.Parameters.AddWithValue("@feecategory", feecatc.Text);
                    cmd.Parameters.AddWithValue("@amount", amountc.Text);
                    cmd.Parameters.AddWithValue("@stdid", txtstdid.Text);

                    int i = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (i > 0)
                        MessageBox.Show("Fee record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No record found with the given Student ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Please fill all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        

       
        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
              if (!string.IsNullOrWhiteSpace(txtstdid.Text))
                {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT course, sub, feecategory, amount FROM feemaster WHERE stdid = @stdid", conn);
                    cmd.Parameters.AddWithValue("@stdid", txtstdid.Text);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        string course = dr["course"].ToString();
                        string subjectVal = dr["sub"].ToString();
                        string feecat = dr["feecategory"].ToString();
                        string amt = dr["amount"].ToString();

                        // Add values if not in ComboBox already
                        if (!coursecc.Items.Contains(course)) coursecc.Items.Add(course);
                        if (!subject.Items.Contains(subjectVal)) subject.Items.Add(subjectVal);
                        if (!feecatc.Items.Contains(feecat)) feecatc.Items.Add(feecat);
                        if (!amountc.Items.Contains(amt)) amountc.Items.Add(amt);

                        // Set values
                        coursecc.Text = course;
                        subject.Text = subjectVal;
                        feecatc.Text = feecat;
                        amountc.Text = amt;
                    }
                    else
                    {
                        MessageBox.Show("No record found with this Student ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Please enter a Student ID to search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            

        }

        private void timer1_Tick(object sender, EventArgs e)
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

        private void rESULTToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RESULTVIEW rv = new RESULTVIEW();
            rv.Show();
            rv.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
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

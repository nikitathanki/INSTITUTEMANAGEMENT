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
    public partial class Course : Form
    {
        public Course()
        {
            InitializeComponent();
        }
        public string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtcid.Text != string.Empty && txtcourse.Text != string.Empty && txtdid.Text != string.Empty
               && txtdura.Text != string.Empty)
            {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO course (courseid, coursenm, deptid, duration)" +
                    " VALUES (@courseid, @coursenm, @deptid, @duration)", conn);
                cmd.Parameters.AddWithValue("@courseid", txtcid.Text);
                cmd.Parameters.AddWithValue("@coursenm", txtcourse.Text);
                cmd.Parameters.AddWithValue("@deptid", txtdid.Text);
                cmd.Parameters.AddWithValue("@duration", txtdura.Text);


                cmd.ExecuteNonQuery();


                MessageBox.Show("Course Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                conn.Close();
            }
            else
            {
                MessageBox.Show("Please fill all the fields", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (txtcid.Text != "")
            {
               SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM course WHERE courseid=@courseid", conn);
                cmd.Parameters.AddWithValue("@courseid", txtcid.Text);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Record deleted successfully");

            }
            else
            {
                MessageBox.Show("Enter Course ID to delete");
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txtcid.Text != "")
            {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE course SET courseid=@courseid, coursenm=@coursenm , deptid=@deptid, duration=@duration WHERE courseid=@courseid", conn);
                cmd.Parameters.AddWithValue("@courseid", txtcid.Text);
                cmd.Parameters.AddWithValue("@coursenm", txtcourse.Text);
                cmd.Parameters.AddWithValue("@deptid", txtdid.Text);
                cmd.Parameters.AddWithValue("@duration", txtdura.Text);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Record updated successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Enter Course ID to update", "Data Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            
           
                if (txtcid.Text != string.Empty)
                {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM course WHERE courseid = @courseid", conn);
                    cmd.Parameters.AddWithValue("@courseid", txtcid.Text);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        txtcourse.Text = dr["coursenm"].ToString();
                        txtdid.Text = dr["deptid"].ToString();
                        txtdura.Text = dr["duration"].ToString();

                        MessageBox.Show("Course Found Successfully", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No Course Found with this ID", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    dr.Close();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Please enter Course ID to search", "Input Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            

        }

        private void txtcourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectcourse = txtcourse.SelectedItem.ToString();
            if (selectcourse == "BCA")
            {
                txtdura.Text = "3 YEARS";
            }
            else if (selectcourse == "BBA")
            {
                txtdura.Text = "3 YEARS";
            }
            else if (selectcourse == "B.COM")
            {
                txtdura.Text = "3 YEARS";
            }
            else if (selectcourse == "BSW")
            {
                txtdura.Text = "3 YEARS";
            }
            else if (selectcourse == "BSC")
            {
                txtdura.Text = "3 YEARS";
            }
            else if (selectcourse == "BA")
            {
                txtdura.Text = "3 YEARS";
            }

        }

        private void Course_Load(object sender, EventArgs e)
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

        private void guna2Button6_Click(object sender, EventArgs e)
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

        private void rESULTToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RESULT res = new RESULT();
            res.Show();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

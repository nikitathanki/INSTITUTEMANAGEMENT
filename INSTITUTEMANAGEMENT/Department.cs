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
    public partial class Department : Form
    {
        public Department()
        {
            InitializeComponent();
        }
        public string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;

        private void Guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
              if (txtdeptid.Text != "" && txtdeptnm.Text != "")
                {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO department (deptid, deptnm) VALUES (@deptid, @deptnm)", conn);
                    cmd.Parameters.AddWithValue("@deptid", txtdeptid.Text);
                    cmd.Parameters.AddWithValue("@deptnm", txtdeptnm.Text);

                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Department added successfully.", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please enter all fields.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
             if (txtdeptid.Text != "" && txtdeptnm.Text != "")
                {
                SqlConnection conn = new SqlConnection(cs);

                conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE department SET deptnm = @deptnm WHERE deptid = @deptid", conn);
                    cmd.Parameters.AddWithValue("@deptid", txtdeptid.Text);
                    cmd.Parameters.AddWithValue("@deptnm", txtdeptnm.Text);

                    int i = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (i > 0)
                        MessageBox.Show("Department updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Department not found to update.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Please fill both fields.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
           
                if (txtdeptid.Text != "")
                {
                SqlConnection conn = new SqlConnection(cs);

                conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM department WHERE deptid = @deptid", conn);
                    cmd.Parameters.AddWithValue("@deptid", txtdeptid.Text);

                    int i = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (i > 0)
                    {
                        MessageBox.Show("Department removed successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtdeptid.Clear();
                        txtdeptnm.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Department not found to delete.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter Department ID to delete.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            
           
                if (txtdeptid.Text != "")
                {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM department WHERE deptid = @deptid", conn);
                    cmd.Parameters.AddWithValue("@deptid", txtdeptid.Text);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtdeptnm.Text = dr["deptnm"].ToString();
                        MessageBox.Show("Department found.", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Department not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    dr.Close();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Please enter Department ID to search.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            

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

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            LOGIN l = new LOGIN();
            l.Show();
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace INSTITUTEMANAGEMENT
{
    public partial class STAFF_ATTENDANCE : Form
    {
        public STAFF_ATTENDANCE()
        {
            InitializeComponent();
        }
        public string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;

        private void panel2_Paint(object sender, PaintEventArgs e)
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

        private void guna2Button6_Click(object sender, EventArgs e)
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

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            if (txtdpid.Text != "" && txtname.Text != "" && txtstaffid.Text != "" &&
                   (guna2RadioButton1.Checked || guna2RadioButton2.Checked))
            {
                string status = guna2RadioButton1.Checked ? "Present" : "Absent";
                SqlConnection conn = new SqlConnection(cs);

                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO staffatt (deptid, name, staffid, status, attendancedate) VALUES (@deptid, @name, @staffid, @status, @attendancedate)", conn);
                cmd.Parameters.AddWithValue("@deptid", txtdpid.Text);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@staffid", txtstaffid.Text);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@attendancedate", dtpdate.Value.Date);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Staff attendance added successfully.", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please fill all fields and select Present/Absent.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

            txtdpid.Clear();
            txtname.Clear();
            txtstaffid.Clear();
            guna2RadioButton1.Checked = false;
            guna2RadioButton2.Checked = false;
            dtpdate.Value = DateTime.Now;

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (txtstaffid.Text != "")
            {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM staffatt WHERE staffid = @staffid AND attendancedate = @attendancedate", conn);
                cmd.Parameters.AddWithValue("@staffid", txtstaffid.Text);
                cmd.Parameters.AddWithValue("@attendancedate", dtpdate.Value.Date);

                int i = cmd.ExecuteNonQuery();
                conn.Close();

                if (i > 0)
                {
                    MessageBox.Show("Record deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //guna2Button3.PerformClick();
                }
                else
                {
                    MessageBox.Show("No record found to delete.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Enter Staff ID to delete.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            if (txtdpid.Text != "" && txtname.Text != "" && txtstaffid.Text != "" &&
                   (guna2RadioButton1.Checked || guna2RadioButton2.Checked))
            {
                string status = guna2RadioButton1.Checked ? "Present" : "Absent";

                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE staffatt SET deptid=@deptid, name=@name, status=@status WHERE staffid=@staffid AND attendancedate=@attendancedate", conn);
                cmd.Parameters.AddWithValue("@deptid", txtdpid.Text);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@staffid", txtstaffid.Text);
                cmd.Parameters.AddWithValue("@attendancedate", dtpdate.Value.Date);

                int i = cmd.ExecuteNonQuery();
                conn.Close();

                if (i > 0)
                {
                    MessageBox.Show("Attendance updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No record found to update.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please fill all fields and select Present/Absent.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (txtstaffid.Text != "")
            {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM staffatt WHERE staffid = @staffid AND attendancedate = @attendancedate", conn);
                cmd.Parameters.AddWithValue("@staffid", txtstaffid.Text);
                cmd.Parameters.AddWithValue("@attendancedate", dtpdate.Value.Date);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtdpid.Text = dr["deptid"].ToString();
                    txtname.Text = dr["name"].ToString();
                    string status = dr["status"].ToString();

                    guna2RadioButton1.Checked = (status == "Present");
                    guna2RadioButton2.Checked = (status == "Absent");

                    MessageBox.Show("Record found successfully.", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No matching record found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                dr.Close();
                conn.Close();
            }
            else
            {
                MessageBox.Show("Enter Staff ID to search.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

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
using Microsoft.VisualBasic;
using System.Configuration;

namespace INSTITUTEMANAGEMENT
{
    public partial class Officestaff : Form
    {
        public string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        public Officestaff()
        {
            InitializeComponent();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Officestaff_Load(object sender, EventArgs e)
        {

        }

        private void Guna2Button8_Click(object sender, EventArgs e)
        {
            if (txtdes.Text != string.Empty && txtper.Text != string.Empty && txtpid.Text != string.Empty && txtquali.Text != string.Empty && txtsal.Text != string.Empty && txtsid.Text != string.Empty)
            {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO officestaff (staff_id,pid,designation,salary,qualification,preexp) VALUES (@staff_id,@pid,@designation,@salary,@qualification,@preexp)", conn);

                cmd.Parameters.AddWithValue("@staff_id", txtsid.Text);
                cmd.Parameters.AddWithValue("@pid", txtpid.Text);
                cmd.Parameters.AddWithValue("@designation", txtdes.Text);
                cmd.Parameters.AddWithValue("@salary", txtsal.Text);
                cmd.Parameters.AddWithValue("@qualification", txtquali.Text);
                cmd.Parameters.AddWithValue("@preexp", txtper.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Enter Successful", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dashboard db = new Dashboard();
                db.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please fill all the fields", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Txtsal_TextChanged(object sender, EventArgs e)
        {

        }

        private void Guna2Button6_Click(object sender, EventArgs e)
        {

           
                if (txtsid.Text != string.Empty)
                {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                    // Check if record exists
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM officestaff WHERE staff_id = @staff_id", conn);
                    checkCmd.Parameters.AddWithValue("@staff_id", txtsid.Text);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // Proceed with delete
                        SqlCommand deleteCmd = new SqlCommand("DELETE FROM officestaff WHERE staff_id = @staff_id", conn);
                        deleteCmd.Parameters.AddWithValue("@staff_id", txtsid.Text);
                        deleteCmd.ExecuteNonQuery();

                        MessageBox.Show("Record Deleted Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Record not found with the given Staff ID", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Please enter the Staff ID to delete", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        private void Guna2Button7_Click(object sender, EventArgs e)
        {
           
                if (txtdes.Text != string.Empty && txtper.Text != string.Empty && txtpid.Text != string.Empty &&
                    txtquali.Text != string.Empty && txtsal.Text != string.Empty && txtsid.Text != string.Empty)
                {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                    // Check if the record with given staff_id exists
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM officestaff WHERE staff_id = @staff_id", conn);
                    checkCmd.Parameters.AddWithValue("@staff_id", txtsid.Text);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // If record found, update it
                        SqlCommand cmd = new SqlCommand("UPDATE officestaff SET pid = @pid, designation = @designation, salary = @salary, qualification = @qualification, preexp = @preexp WHERE staff_id = @staff_id", conn);
                        cmd.Parameters.AddWithValue("@staff_id", txtsid.Text);
                        cmd.Parameters.AddWithValue("@pid", txtpid.Text);
                        cmd.Parameters.AddWithValue("@designation", txtdes.Text);
                        cmd.Parameters.AddWithValue("@salary", txtsal.Text);
                        cmd.Parameters.AddWithValue("@qualification", txtquali.Text);
                        cmd.Parameters.AddWithValue("@preexp", txtper.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Record Updated Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Record not found with the given Staff ID", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Please fill all the fields", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        private void Guna2Button5_Click(object sender, EventArgs e)
        {
           
                if (txtsid.Text != string.Empty)

                {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM officestaff WHERE staff_id = @staff_id", conn);
                    cmd.Parameters.AddWithValue("@staff_id", txtsid.Text);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        txtpid.Text = dr["pid"].ToString();
                        txtdes.Text = dr["designation"].ToString();
                        txtsal.Text = dr["salary"].ToString();
                        txtquali.Text = dr["qualification"].ToString();
                        txtper.Text = dr["preexp"].ToString();

                        MessageBox.Show("Record Found", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No Record Found with the given Staff ID", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Please enter Staff ID to search", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
           
                txtsid.Text = "";
                txtpid.Text = "";
                txtdes.Text = "";
                txtsal.Text = "";
                txtquali.Text = "";
                txtper.Text = "";

                txtsid.Focus(); 
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pERSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PERSON p = new PERSON();
            p.Show();
            p.Hide();
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
    }
    }




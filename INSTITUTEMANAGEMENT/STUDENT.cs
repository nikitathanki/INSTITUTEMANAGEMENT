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
    public partial class STUDENT : Form
    {
        public STUDENT()
        {
            InitializeComponent();
        }
        public string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;

        private void STUDENT_Load(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Guna2Button8_Click(object sender, EventArgs e)
        {
            if (txtstid.Text != string.Empty && txtpid.Text != string.Empty && txtdeptid.Text != string.Empty && txtbatchno.Text != string.Empty && txthobby.Text != string.Empty && txtcs.Text != string.Empty)
            {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO student (stdid, pid, deptid, batchno, hobby, cursem) VALUES (@stdid, @pid, @deptid, @batchno, @hobby, @cursem)", conn);
                cmd.Parameters.AddWithValue("@stdid", txtstid.Text);
                cmd.Parameters.AddWithValue("@pid", txtpid.Text);
                cmd.Parameters.AddWithValue("@deptid", txtdeptid.Text);
                cmd.Parameters.AddWithValue("@batchno", txtbatchno.Text);
                cmd.Parameters.AddWithValue("@hobby", txthobby.Text);
                cmd.Parameters.AddWithValue("@cursem", txtcs.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Student Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Dashboard db = new Dashboard();
                db.Show();
                this.Hide();


                conn.Close();


            }
            else
            {
                MessageBox.Show("Please fill all the fields", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void Guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Guna2Button7_Click(object sender, EventArgs e)
        {
           
                if (txtstid.Text != string.Empty && txtpid.Text != string.Empty && txtdeptid.Text != string.Empty && txtbatchno.Text != string.Empty && txthobby.Text != string.Empty && txtcs.Text != string.Empty)
                {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                    // Check if student exists
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM student WHERE stdid = @stdid", conn);
                    checkCmd.Parameters.AddWithValue("@stdid", txtstid.Text);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // Update the student record
                        SqlCommand cmd = new SqlCommand("UPDATE student SET pid = @pid, deptid = @deptid, batchno = @batchno, hobby = @hobby, cursem = @cursem WHERE stdid = @stdid", conn);
                        cmd.Parameters.AddWithValue("@stdid", txtstid.Text);
                        cmd.Parameters.AddWithValue("@pid", txtpid.Text);
                        cmd.Parameters.AddWithValue("@deptid", txtdeptid.Text);
                        cmd.Parameters.AddWithValue("@batchno", txtbatchno.Text);
                        cmd.Parameters.AddWithValue("@hobby", txthobby.Text);
                        cmd.Parameters.AddWithValue("@cursem", txtcs.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Student Record Updated Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Dashboard db = new Dashboard();
                    db.Show();
                    this.Hide();
                }
                    else
                    {
                        MessageBox.Show("Student ID not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Please fill all the fields", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        

        private void Guna2Button6_Click(object sender, EventArgs e)
        {
           
                if (txtstid.Text != string.Empty)
                {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                    // Check if student exists
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM student WHERE stdid = @stdid", conn);
                    checkCmd.Parameters.AddWithValue("@stdid", txtstid.Text);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // Delete the record
                        SqlCommand deleteCmd = new SqlCommand("DELETE FROM student WHERE stdid = @stdid", conn);
                        deleteCmd.Parameters.AddWithValue("@stdid", txtstid.Text);
                        deleteCmd.ExecuteNonQuery();

                        MessageBox.Show("Student Record Deleted Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Dashboard db = new Dashboard();
                        db.Show();
                        this.Hide();
                }
                    else
                    {
                        MessageBox.Show("Student ID not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Please enter the Student ID to delete", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        

        private void Guna2Button5_Click(object sender, EventArgs e)
        {
           
                if (txtstid.Text != string.Empty)
                {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM student WHERE stdid = @stdid", conn);
                    cmd.Parameters.AddWithValue("@stdid", txtstid.Text);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        txtpid.Text = dr["pid"].ToString();
                        txtdeptid.Text = dr["deptid"].ToString();
                        txtbatchno.Text = dr["batchno"].ToString();
                        txthobby.Text = dr["hobby"].ToString();
                        txtcs.Text = dr["cursem"].ToString();

                        MessageBox.Show("Student Record Found", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Dashboard db = new Dashboard();
                        db.Show();
                        this.Hide();
                }
                    else
                    {
                        MessageBox.Show("Student ID not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Please enter the Student ID to search", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
           
                txtstid.Text = "";
                txtpid.Text = "";
                txtdeptid.Text = "";
                txtbatchno.Text = "";
                txthobby.Text = "";
                txtcs.Text = "";

                txtstid.Focus(); 
            }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
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


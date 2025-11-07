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
    public partial class TEACHING_STAFF : Form
    {
        public TEACHING_STAFF()
        {
            InitializeComponent();
        }

        public string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Guna2Button8_Click(object sender, EventArgs e)
        {

            if (txttid.Text != string.Empty && txtpersonid.Text != string.Empty && txtdes.Text != string.Empty 
                && txtsal.Text != string.Empty && txtqua.Text != string.Empty && txtpreexp.Text != string.Empty
                && txtspe.Text != string.Empty && txtdeptid.Text != string.Empty)
            {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO tstaff (tsid, pid, designation, salary, qualification, preworkexp,specialization,deptid)" +
                    " VALUES (@tsid, @pid, @designation, @salary, @qualification, @preworkexp,@specialization,@deptid)", conn);
                cmd.Parameters.AddWithValue("@tsid", txttid.Text);
                cmd.Parameters.AddWithValue("@pid", txtpersonid.Text);
                cmd.Parameters.AddWithValue("@designation", txtdes.Text);
                cmd.Parameters.AddWithValue("@salary", txtsal.Text);
                cmd.Parameters.AddWithValue("@qualification", txtqua.Text);
                cmd.Parameters.AddWithValue("@preworkexp", txtpreexp.Text);
                cmd.Parameters.AddWithValue("@specialization", txtspe.Text);
                cmd.Parameters.AddWithValue("@deptid", txtdeptid.Text);

                cmd.ExecuteNonQuery();


                MessageBox.Show("Teacher Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            else
            {
                MessageBox.Show("Please fill all the fields", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }


            private void Guna2Button7_Click(object sender, EventArgs e)
        {
           
                if (txttid.Text != string.Empty && txtpersonid.Text != string.Empty &&
                    txtdes.Text != string.Empty && txtqua.Text != string.Empty &&
                    txtspe.Text != string.Empty && txtsal.Text != string.Empty &&
                    txtpreexp.Text != string.Empty && txtdeptid.Text != string.Empty)
                {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                    // Check if record exists
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM tstaff WHERE teacherid = @tid", conn);
                    checkCmd.Parameters.AddWithValue("@tid", txttid.Text);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        // Update the record
                        SqlCommand cmd = new SqlCommand("UPDATE tstaff SET personid = @pid, designation = @desg, " +
                            "qualification = @qual, specialization = @spec, salary = @salary, preworkexperience = @pre, departmentid = @dept " +
                            "WHERE teacherid = @tid", conn);

                        cmd.Parameters.AddWithValue("@tid", txttid.Text);
                        cmd.Parameters.AddWithValue("@pid", txtpersonid.Text);
                        cmd.Parameters.AddWithValue("@desg", txtdes.Text);
                        cmd.Parameters.AddWithValue("@qual", txtqua.Text);
                        cmd.Parameters.AddWithValue("@spec", txtspe.Text);
                        cmd.Parameters.AddWithValue("@salary", txtsal.Text);
                        cmd.Parameters.AddWithValue("@pre", txtpreexp.Text);
                        cmd.Parameters.AddWithValue("@dept", txtdeptid.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Teaching Staff Record Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
                    
                        
                    }
                    else
                    {
                        MessageBox.Show("Teacher ID not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


            if (txttid.Text != string.Empty)
            {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                // Check if student exists
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM tstaff WHERE stdid = @stdid", conn);
                checkCmd.Parameters.AddWithValue("@stdid", txttid.Text);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    // Delete the record
                    SqlCommand deleteCmd = new SqlCommand("DELETE FROM teachingstaff WHERE stdid = @stdid", conn);
                    deleteCmd.Parameters.AddWithValue("@stdid", txttid.Text);
                    deleteCmd.ExecuteNonQuery();

                    MessageBox.Show("Student Record Deleted Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Teacher ID not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Please enter the Teacher ID to delete", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            
                if (txttid.Text != string.Empty)
                {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tstaff WHERE tsid = @tsid", conn);
                    cmd.Parameters.AddWithValue("@tsid", txttid.Text);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        txtpersonid.Text = dr["pid"].ToString();
                        txtdes.Text = dr["designation"].ToString();
                        txtsal.Text = dr["salary"].ToString();
                        txtqua.Text = dr["qualification"].ToString();
                        txtpreexp.Text = dr["preworkexp"].ToString();
                        txtspe.Text = dr["specialization"].ToString();
                        txtdeptid.Text = dr["deptid"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No record found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Please enter Teacher ID to search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
                txttid.Text = "";
                txtpersonid.Text = "";
                txtdes.Text = "";
                txtsal.Text = "";
                txtqua.Text = "";
                txtpreexp.Text = "";
                txtspe.Text = "";
                txtdeptid.Text = "";
            
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
            Department dep =  new Department();
            dep.Show();
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN l = new LOGIN();
            l.Show();
        }

        private void eXAMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void pERSONToolStripMenuItem_Click_1(object sender, EventArgs e)
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
    
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
    public partial class Forgetpswd : Form
    {
        public string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;

        public Forgetpswd()
        {
            InitializeComponent();
        }
       
          
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
                string email = txtemail.Text.Trim(); // This should be your username textbox

                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Please enter your Username first.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    return;
                }

            SqlConnection conn = new SqlConnection(cs);

            conn.Open();

                string query = "SELECT pswd FROM reg WHERE email = @email";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@email", email);
             

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    MessageBox.Show("Your password is: " + result.ToString(), "Password Found");
                }
                else
                {
                    MessageBox.Show("Invalid Username or Email.", "Error");
                }

                conn.Close();
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

        private void sUDENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            STUDENT S = new STUDENT();
            S.Show();
            this.Hide();
        }

        private void tEACHINGSTAFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TEACHING_STAFF te= new TEACHING_STAFF();
            te.Hide();
            this.Show();
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

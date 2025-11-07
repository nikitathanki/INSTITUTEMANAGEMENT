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
using Microsoft.VisualBasic;

namespace INSTITUTEMANAGEMENT
{
    public partial class REGISTRATION : Form
    {

        public string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        public REGISTRATION()
        {
            InitializeComponent();
        }

        private void Guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtfn.Text != string.Empty && txtln.Text != string.Empty && txtpswd.Text != string.Empty &&
                txtemail.Text != string.Empty && txtpid.Text != string.Empty)
            {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO reg (fn,ln,pswd,email,pid) VALUES (@fn,@ln,@pswd,@email,@pid)", conn);
                cmd.Parameters.AddWithValue("@fn", txtfn.Text);
                cmd.Parameters.AddWithValue("@ln", txtln.Text);
                cmd.Parameters.AddWithValue("@pswd", txtpswd.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@pid", txtpid.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Registration Successful", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void aTTENDENCEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cOURSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sTUDENTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void tEACHINGSTAFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void oFFOCESTSFFToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cOURSEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }

        private void dEPARTMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eXAMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
         }  
        private void rESULTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void rESULTVIEWToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void fEEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void fEEVIEWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void pERSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}

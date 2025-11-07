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

    public partial class LOGIN : Form
    {
        
        public void clear()
        {
            txtpswd.Clear();
            txtusnm.Clear();
        }

        public string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;

        public LOGIN()
        {
            InitializeComponent();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();

            string sql = "SELECT count(*) FROM reg WHERE email=@email and pswd=@pswd";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@email", txtusnm.Text);
            cmd.Parameters.AddWithValue("@pswd", txtpswd.Text);

            int obj = (Int32)cmd.ExecuteScalar();



            if (Convert.ToInt32(obj) > 0)
            {
                Dashboard ds = new Dashboard();
                ds.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Username and or Password are mismatched... Please try again...");
            }





            conn.Close();
        }



        private void Label4_Click(object sender, EventArgs e)
        {
            Forgetpswd f = new Forgetpswd();
            f.Show();

            this.Hide();

        }



        private void Guna2Button3_Click(object sender, EventArgs e)
        {
            clear();
            MessageBox.Show("Re-Enter The Values", "RE-ENTER DATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void Guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {


           REGISTRATION RG = new REGISTRATION();
            RG.Show();
            this.Hide();
        }
    }
}
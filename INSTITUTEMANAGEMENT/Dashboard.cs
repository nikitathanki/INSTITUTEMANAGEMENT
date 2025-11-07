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

namespace INSTITUTEMANAGEMENT
{
    public partial class Dashboard : Form
    {
       // SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\INSTITUTEMANAGEMENT\INSTITUTEMANAGEMENT\Database1.mdf;Integrated Security=True");
        public Dashboard()
        {
           
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click_1(object sender, EventArgs e)
        {
           
            
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            Officestaff os = new Officestaff();
            os.Show();
            this.Hide();
        }

        private void guna2PictureBox8_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2PictureBox18_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2PictureBox19_Click(object sender, EventArgs e)
        {
            LOGIN lg = new LOGIN();
            lg.Show();
            this.Hide();
        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox9_Click(object sender, EventArgs e)
        {
            Course c = new Course();
            c.Show();
            this.Hide();
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            STUDENT std= new STUDENT();
            std.Show();
            this.Hide();
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            TEACHING_STAFF ts = new TEACHING_STAFF();
            ts.Show();
            this.Hide();
        }

        private void guna2PictureBox11_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2PictureBox10_Click(object sender, EventArgs e)
        {
           RESULTVIEW res = new RESULTVIEW();
            res.Show();
            this.Hide();
        }

        private void guna2PictureBox17_Click(object sender, EventArgs e)
        {
            FEEVIEW f = new FEEVIEW();
            f.Show();
            this.Hide();
        }

        private void guna2PictureBox16_Click(object sender, EventArgs e)
        {
            PERSON p = new PERSON();
            p.Show();
            this.Hide();
        }

        private void guna2PictureBox14_Click(object sender, EventArgs e)
        {
          
           
        }

        private void guna2PictureBox15_Click(object sender, EventArgs e)
        {
        }

        private void guna2PictureBox12_Click(object sender, EventArgs e)
        {
            Department d = new Department();
            d.Show();
            this.Hide();
        }

        private void guna2PictureBox13_Click(object sender, EventArgs e)
        {
            Fee fe = new Fee();
            fe.Show();
            this.Hide();
        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            ATTENTENDANCE att = new ATTENTENDANCE();
            att.Show();
            this.Hide();
        }

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {
            exam ex = new exam();
            ex.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dddd, dd-MM-yyyy");
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void guna2PictureBox2_Click_2(object sender, EventArgs e)
        {
          
                DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Hide(); // Hide current form (Dashboard)
                    LOGIN lg = new LOGIN(); // Replace with your actual login form name
                    lg.Show();
                
            }
        }
    }
}

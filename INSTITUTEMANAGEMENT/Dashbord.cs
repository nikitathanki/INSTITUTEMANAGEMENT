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
    public partial class Dashbord : Form
    {
        public Dashbord()
        {
            InitializeComponent();
        }

        private void Guna2GradientButton1_Click(object sender, EventArgs e)
        {

        }

        private void Button11_Click(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashbord_Load(object sender, EventArgs e)
        {

        }

        private void Admin_Click(object sender, EventArgs e)
        {
            LOGIN log = new LOGIN ();
            log.Show();
            this.Hide();
        }

        private void PictureBox11_Click(object sender, EventArgs e)
        {
            Department dep = new Department();
            dep.Show();
            this.Hide();

        }

        private void PictureBox15_Click(object sender, EventArgs e)
        {
            ATTENTENDANCE att = new ATTENTENDANCE();
            att.Show();
            this.Hide();
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            RESULT res = new RESULT();
            res.Show();
            this.Hide();
        }

        private void PictureBox9_Click(object sender, EventArgs e)
        {
            EXAM ex = new EXAM();
            ex.Show();
            this.Hide();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            subject sub = new subject();
            sub.Show();
            this.Hide();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            PERSON per = new PERSON();
            per.Show();
            this.Hide();
        }

        private void PictureBox12_Click(object sender, EventArgs e)
        {
            SEMESTER sem = new SEMESTER();
            sem.Show();
            this.Hide();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox13_Click(object sender, EventArgs e)
        {
            Fee f = new Fee();
            f.Show();
            this.Hide();
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            REGISTRATION reg = new REGISTRATION();
            reg.Show();
            this.Hide();
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            Officestaff ofs = new Officestaff();
            ofs.Show();
            this.Hide();
        }

        private void PictureBox10_Click(object sender, EventArgs e)
        {
            STUDENT std = new STUDENT();
            std.Show();
            this.Hide();
        }

        private void PictureBox16_Click(object sender, EventArgs e)
        {
            TEACHING_STAFF ts = new TEACHING_STAFF();
            ts.Show();
            this.Hide();
        }

        private void PictureBox17_Click(object sender, EventArgs e)
        {
            LOGOUT lot = new LOGOUT();
            lot.Show();
            this.Hide();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

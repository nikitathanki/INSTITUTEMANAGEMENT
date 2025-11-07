using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INSTITUTEMANAGEMENT
{
    public partial class PROGRESS_BAR : Form
    {
        public PROGRESS_BAR()
        {
            InitializeComponent();
        }

        private void PROGRESS_BAR_Load(object sender, EventArgs e)
        {
            guna2ProgressBar1.Maximum = 100;
            guna2ProgressBar1.Value = 0;
            timer1.Interval = 100;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(guna2ProgressBar1.Value< guna2ProgressBar1.Maximum)
            {

                guna2ProgressBar1.Value += 2;
                lblper.Text = guna2ProgressBar1.Value + "%";
            }
            else 
            {
                timer1.Stop();
                //lblper.Text = "100%";
               

                LOGIN lg = new LOGIN();
                lg.Show();
                this.Hide();

            }

        }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }
    }
}

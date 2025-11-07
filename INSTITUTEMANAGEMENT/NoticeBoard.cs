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
    public partial class NoticeBoard : Form
    {
        public NoticeBoard()
        {
            InitializeComponent();
        }
        public string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTitle.Text) &&
                  !string.IsNullOrWhiteSpace(txtMessage.Text) &&
                  !string.IsNullOrWhiteSpace(txtPostedBy.Text))
            {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO NoticeBoard (title, description,postedby,postedate) VALUES (@title, @description,@postedby,@postedate)", conn);
                cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@description", txtMessage.Text);
                cmd.Parameters.AddWithValue("@postedby", txtPostedBy.Text);
                cmd.Parameters.AddWithValue("@postedate", dtpDate.Value);

                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                    MessageBox.Show("Notice added.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else
                {
                    MessageBox.Show("Notice not added.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("please fill all fileds", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblnb_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txttitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmesg_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtpost_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            
                txtTitle.Text = "";
                txtMessage.Text = "";
                dtpDate.Value = DateTime.Now;
                txtPostedBy.Text = "";
            
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    SqlConnection conn = new SqlConnection(cs);
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM NoticeBoard WHERE title = @title", conn);
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        txtMessage.Text = dr["description"].ToString();
                        dtpDate.Value = Convert.ToDateTime(dr["postdate"]);
                        txtPostedBy.Text = dr["postedby"].ToString();
                        MessageBox.Show("Notice found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No record found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    dr.Close();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Please enter the title to search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
           
                if (!string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    SqlConnection conn = new SqlConnection(cs);
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM NoticeBoard WHERE title = @title", conn);
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text);

                    int i = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (i > 0)
                    {
                        MessageBox.Show("Notice removed successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       // ResetFields();
                    }
                    else
                    {
                        MessageBox.Show("Delete failed. Title not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter the title to remove.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
                    if (!string.IsNullOrWhiteSpace(txtTitle.Text) &&
                        !string.IsNullOrWhiteSpace(txtMessage.Text) &&
                        !string.IsNullOrWhiteSpace(txtPostedBy.Text))
                    {
                    SqlConnection conn = new SqlConnection(cs);
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE NoticeBoard SET description = @description, postdate = @postdate, postedby = @postedby WHERE title = @title", conn);
                        cmd.Parameters.AddWithValue("@description", txtMessage.Text);
                        cmd.Parameters.AddWithValue("@postdate", dtpDate.Value);
                        cmd.Parameters.AddWithValue("@postedby", txtPostedBy.Text);
                        cmd.Parameters.AddWithValue("@title", txtTitle.Text);

                        int i = cmd.ExecuteNonQuery();
                        conn.Close();

                        if (i > 0)
                            MessageBox.Show("Notice updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Update failed. Title not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Please fill all fields to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                
            }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

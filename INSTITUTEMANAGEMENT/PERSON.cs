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
    public partial class PERSON : Form
    {
        public PERSON()
        {
            InitializeComponent();
        }
        public string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;

        private void Guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Guna2TextBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void Guna2TextBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label21_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PERSON_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {


            // Check if all required fields are filled
            if (
                !string.IsNullOrWhiteSpace(txtfn.Text) &&
                !string.IsNullOrWhiteSpace(txtmn.Text) &&
                !string.IsNullOrWhiteSpace(txtln.Text) &&
                !string.IsNullOrWhiteSpace(txtffnm.Text) &&
                !string.IsNullOrWhiteSpace(txtfmn.Text) &&
                !string.IsNullOrWhiteSpace(txtfln.Text) &&
                !string.IsNullOrWhiteSpace(txtmfn.Text) &&
                !string.IsNullOrWhiteSpace(txtmmnm.Text) &&
                !string.IsNullOrWhiteSpace(txtmlnm.Text) &&
                !string.IsNullOrWhiteSpace(txtnation.Text) &&
                !string.IsNullOrWhiteSpace(txtstate.Text) &&
                !string.IsNullOrWhiteSpace(txtdis.Text) &&
                !string.IsNullOrWhiteSpace(txtpcode.Text) && txtpcode.Text.Length == 6 &&
                !string.IsNullOrWhiteSpace(txtadd.Text) &&
                !string.IsNullOrWhiteSpace(txtloc.Text) &&
                !string.IsNullOrWhiteSpace(txtpno.Text) && txtpno.Text.Length == 10 &&
                !string.IsNullOrWhiteSpace(txtemail.Text) &&
                !string.IsNullOrWhiteSpace(txtbg.Text) &&
                (guna2RadioButton1.Checked || guna2RadioButton2.Checked || guna2RadioButton3.Checked) &&
                !string.IsNullOrWhiteSpace(txtreg.Text) &&
                !string.IsNullOrWhiteSpace(txtcaste.Text)
            )
            {
                string gender = guna2RadioButton1.Checked ? "Male" : guna2RadioButton2.Checked ? "Female" : "Other";
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"INSERT INTO PERSON (
                     doj, fname, mname, lname,
                     ffname, fmname, flname,
                     mfname, mmname, mlname,
                     nationality, state, district, pincode, address, locality,
                     phoneno, email, dob, bg, gender, religion, caste) VALUES (@doj, @fname, @mname, @lname,
                     @ffname, @fmname, @flname,@mfname, @mmname, @mlname,
                     @nationality, @state, @district, @pincode, @address, @locality,
                     @phoneno, @email, @dob, @bg, @gender, @religion, @caste)", conn);

                // Add parameters
                cmd.Parameters.AddWithValue("@doj", dateofjoind.Value.Date);
                cmd.Parameters.AddWithValue("@fname", txtfn.Text);
                cmd.Parameters.AddWithValue("@mname", txtmn.Text);
                cmd.Parameters.AddWithValue("@lname", txtln.Text);
                cmd.Parameters.AddWithValue("@ffname", txtffnm.Text);
                cmd.Parameters.AddWithValue("@fmname", txtfmn.Text);
                cmd.Parameters.AddWithValue("@flname", txtfln.Text);
                cmd.Parameters.AddWithValue("@mfname", txtmfn.Text);
                cmd.Parameters.AddWithValue("@mmname", txtmmnm.Text);
                cmd.Parameters.AddWithValue("@mlname", txtmlnm.Text);
                cmd.Parameters.AddWithValue("@nationality", txtnation.Text);
                cmd.Parameters.AddWithValue("@state", txtstate.Text);
                cmd.Parameters.AddWithValue("@district", txtdis.Text);
                cmd.Parameters.AddWithValue("@pincode", txtpcode.Text);
                cmd.Parameters.AddWithValue("@address", txtadd.Text);
                cmd.Parameters.AddWithValue("@locality", txtloc.Text);
                cmd.Parameters.AddWithValue("@phoneno", txtpno.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@dob", dateofbirth.Value.Date);
                cmd.Parameters.AddWithValue("@bg", txtbg.Text);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@religion", txtreg.Text);
                cmd.Parameters.AddWithValue("@caste", txtcaste.Text);

                int i = cmd.ExecuteNonQuery();
                conn.Close();

                if (i > 0)
                    MessageBox.Show("Record Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Insert Failed", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Please fill all fields correctly, including valid 10-digit phone and 6-digit pincode.", "Missing Data",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        private void txtmn_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtfn_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            if (
                !string.IsNullOrWhiteSpace(txtemail.Text) && // used for lookup
                !string.IsNullOrWhiteSpace(txtfn.Text) &&
                !string.IsNullOrWhiteSpace(txtmn.Text) &&
                !string.IsNullOrWhiteSpace(txtln.Text) &&
                !string.IsNullOrWhiteSpace(txtffnm.Text) &&
                !string.IsNullOrWhiteSpace(txtfmn.Text) &&
                !string.IsNullOrWhiteSpace(txtfln.Text) &&
                !string.IsNullOrWhiteSpace(txtmfn.Text) &&
                !string.IsNullOrWhiteSpace(txtmmnm.Text) &&
                !string.IsNullOrWhiteSpace(txtmlnm.Text) &&
                !string.IsNullOrWhiteSpace(txtnation.Text) &&
                !string.IsNullOrWhiteSpace(txtstate.Text) &&
                !string.IsNullOrWhiteSpace(txtdis.Text) &&
                !string.IsNullOrWhiteSpace(txtpcode.Text) && txtpcode.Text.Length == 6 &&
                !string.IsNullOrWhiteSpace(txtadd.Text) &&
                !string.IsNullOrWhiteSpace(txtloc.Text) &&
                !string.IsNullOrWhiteSpace(txtpno.Text) && txtpno.Text.Length == 10 &&
                !string.IsNullOrWhiteSpace(txtbg.Text) &&
                (guna2RadioButton1.Checked || guna2RadioButton2.Checked || guna2RadioButton3.Checked) &&
                !string.IsNullOrWhiteSpace(txtreg.Text) &&
                !string.IsNullOrWhiteSpace(txtcaste.Text)
            )
            {
                string gender = guna2RadioButton1.Checked ? "Male" : guna2RadioButton2.Checked ? "Female" : "Other";
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"UPDATE PERSON SET 
            doj = @doj, fname = @fname, mname = @mname, lname = @lname,
            ffname = @ffname, fmname = @fmname, flname = @flname,
            mfname = @mfname, mmname = @mmname, mlname = @mlname,
            nationality = @nationality, state = @state, district = @district,
            pincode = @pincode, address = @address, locality = @locality,
            phoneno = @phoneno, dob = @dob, bg = @bg, gender = @gender,
            religion = @religion, caste = @caste
            WHERE email = @email", conn);

                cmd.Parameters.AddWithValue("@doj", dateofjoind.Value.Date);
                cmd.Parameters.AddWithValue("@fname", txtfn.Text);
                cmd.Parameters.AddWithValue("@mname", txtmn.Text);
                cmd.Parameters.AddWithValue("@lname", txtln.Text);
                cmd.Parameters.AddWithValue("@ffname", txtffnm.Text);
                cmd.Parameters.AddWithValue("@fmname", txtfmn.Text);
                cmd.Parameters.AddWithValue("@flname", txtfln.Text);
                cmd.Parameters.AddWithValue("@mfname", txtmfn.Text);
                cmd.Parameters.AddWithValue("@mmname", txtmmnm.Text);
                cmd.Parameters.AddWithValue("@mlname", txtmlnm.Text);
                cmd.Parameters.AddWithValue("@nationality", txtnation.Text);
                cmd.Parameters.AddWithValue("@state", txtstate.Text);
                cmd.Parameters.AddWithValue("@district", txtdis.Text);
                cmd.Parameters.AddWithValue("@pincode", txtpcode.Text);
                cmd.Parameters.AddWithValue("@address", txtadd.Text);
                cmd.Parameters.AddWithValue("@locality", txtloc.Text);
                cmd.Parameters.AddWithValue("@phoneno", txtpno.Text);
                cmd.Parameters.AddWithValue("@dob", dateofbirth.Value.Date);
                cmd.Parameters.AddWithValue("@bg", txtbg.Text);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@religion", txtreg.Text);
                cmd.Parameters.AddWithValue("@caste", txtcaste.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text); // for WHERE condition

                int i = cmd.ExecuteNonQuery();
                conn.Close();

                if (i > 0)
                    MessageBox.Show("Record Updated Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Update Failed. No record found for this email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Please fill all fields correctly including Email.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtemail.Text))
            {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM PERSON WHERE email = @email", conn);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtpid.Text = dr["pid"].ToString(); // auto-filled even if it's read-only
                    dateofjoind.Value = Convert.ToDateTime(dr["doj"]);
                    txtfn.Text = dr["fname"].ToString();
                    txtmn.Text = dr["mname"].ToString();
                    txtln.Text = dr["lname"].ToString();
                    txtffnm.Text = dr["ffname"].ToString();
                    txtfmn.Text = dr["fmname"].ToString();
                    txtfln.Text = dr["flname"].ToString();
                    txtmfn.Text = dr["mfname"].ToString();
                    txtmmnm.Text = dr["mmname"].ToString();
                    txtmlnm.Text = dr["mlname"].ToString();
                    txtnation.Text = dr["nationality"].ToString();
                    txtstate.Text = dr["state"].ToString();
                    txtdis.Text = dr["district"].ToString();
                    txtpcode.Text = dr["pincode"].ToString();
                    txtadd.Text = dr["address"].ToString();
                    txtloc.Text = dr["locality"].ToString();
                    txtpno.Text = dr["phoneno"].ToString();
                    dateofbirth.Value = Convert.ToDateTime(dr["dob"]);
                    txtbg.Text = dr["bg"].ToString();
                    string gender = dr["gender"].ToString();
                    guna2RadioButton1.Checked = (gender == "Male");
                    guna2RadioButton2.Checked = (gender == "Female");
                    guna2RadioButton3.Checked = (gender == "Other");
                    txtreg.Text = dr["religion"].ToString();
                    txtcaste.Text = dr["caste"].ToString();
                }
                else
                {
                    MessageBox.Show("No record found for this email.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                dr.Close();
                conn.Close();
            }
            else
            {
                MessageBox.Show("Please enter Email to search.", "Input Needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
                if (!string.IsNullOrWhiteSpace(txtemail.Text))
                {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM PERSON WHERE email = @email", conn);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);

                    int i = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (i > 0)
                    {
                        MessageBox.Show("Record Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    guna2Button5_Click(sender, e); // Clear the form after delete
                    }
                    else
                    {
                        MessageBox.Show("No record found for this email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter an Email ID to delete the record.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            {
                txtpid.Text = "";
                txtfn.Text = "";
                txtmn.Text = "";
                txtln.Text = "";
                txtffnm.Text = "";
                txtfmn.Text = "";
                txtfln.Text = "";
                txtmfn.Text = "";
                txtmmnm.Text = "";
                txtmlnm.Text = "";
                txtnation.Text = "";
                txtstate.Text = "";
                txtdis.Text = "";
                txtpcode.Text = "";
                txtadd.Text = "";
                txtloc.Text = "";
                txtpno.Text = "";
                txtemail.Text = "";
                txtbg.Text = "";
                txtreg.Text = "";
                txtcaste.Text = "";
                dateofjoind.Value = DateTime.Now;
                dateofbirth.Value = DateTime.Now;
                guna2RadioButton1.Checked = false;
                guna2RadioButton2.Checked = false;
                guna2RadioButton3.Checked = false;

            }
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
            this.Hide(); ;
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

        private void guna2Button6_Click(object sender, EventArgs e)
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

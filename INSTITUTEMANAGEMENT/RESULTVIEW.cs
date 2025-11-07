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
    public partial class RESULTVIEW : Form
    {
        public RESULTVIEW()
        {
            InitializeComponent();
        }
        public string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtem_Click(object sender, EventArgs e)
        {

        }

        private void btnview_Click(object sender, EventArgs e)
        {
           
                if (!string.IsNullOrWhiteSpace(txtstdid.Text))
                {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT course, sub, marks, term FROM finalresult WHERE stdid = @stdid", conn);
                    cmd.Parameters.AddWithValue("@stdid", txtstdid.Text.Trim());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dt.Columns.Add("S.No.", typeof(int)).SetOrdinal(0);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["S.No."] = i + 1;
                    }

                    guna2DataGridView1.DataSource = null;
                    guna2DataGridView1.AutoGenerateColumns = true;
                    guna2DataGridView1.DataSource = dt;

                    conn.Close();

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No result found for this Student ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter your Student ID to view results.", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
        }

        private void RESULTVIEW_Load(object sender, EventArgs e)
        {
                guna2DataGridView1.DataBindingComplete += Guna2DataGridView1_DataBindingComplete;
                guna2DataGridView1.ReadOnly = true;
                guna2DataGridView1.AllowUserToAddRows = false;
                guna2DataGridView1.AllowUserToDeleteRows = false;
                guna2DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                guna2DataGridView1.ColumnHeadersVisible = true;
                guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                guna2DataGridView1.AutoGenerateColumns = true;     
                guna2DataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                guna2DataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                guna2DataGridView1.ColumnHeadersVisible = true;
                guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                guna2DataGridView1.AutoGenerateColumns = true;
            


        }

        private void Guna2DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           if(guna2DataGridView1.Columns.Count==5)
            {
                guna2DataGridView1.Columns[0].HeaderText = "S.No.";
                guna2DataGridView1.Columns[1].HeaderText = "Course";
                guna2DataGridView1.Columns[2].HeaderText = "Subject";
                guna2DataGridView1.Columns[3].HeaderText = "Marks";
                guna2DataGridView1.Columns[4].HeaderText = "Term";
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
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

        private void guna2Button1_Click(object sender, EventArgs e)
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            PERSON p = new PERSON();
            p.Show();
            this.Hide();

        }
    }
}

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
    public partial class NoticeBoardView : Form
    {
        public NoticeBoardView()
        {
            InitializeComponent();
        }
        public string cs = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();

            
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM NoticeBoard", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            guna2DataGridView1.DataSource = dt;

            conn.Close();
        }

        private void NoticeBoardView_Load(object sender, EventArgs e)
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
                guna2DataGridView1.Columns[1].HeaderText = "Title";
                guna2DataGridView1.Columns[2].HeaderText = "Description";
                guna2DataGridView1.Columns[3].HeaderText = "Posted By";
                guna2DataGridView1.Columns[4].HeaderText = "Date";
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

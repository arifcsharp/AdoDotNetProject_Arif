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


namespace AdoDotNetProject_Arif
{
    public partial class Branch : Form
    {

        string cs = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
        SqlConnection con;
        //SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        //DataRow dr;

        addBranch obBranchAdd = new addBranch();

        DeleteBranchInfo obBranchDelete = new DeleteBranchInfo();

        UpdateBranchInfo obUpdateBranch = new UpdateBranchInfo();
        public Branch()
        {
            InitializeComponent();
            RefreshBranchinfo();
        }

        private void Branch_Load(object sender, EventArgs e)
        {

        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearBranchInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            obBranchDelete.DeleteBranchData("Delete Branch Where BranchID='" + lblBranchID.Text + "'");
            MessageBox.Show("Data Deleted SuccessFully");

            ClearBranchInfo();
            RefreshBranchinfo();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        public void RefreshBranchinfo()
        {
            using (con = new SqlConnection(cs))
            {
                adapter = new SqlDataAdapter("SELECT * FROM Branch", con);
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        public void ClearBranchInfo()
        {
            txtBranchName.Text = "";
            txtCity.Text = "";
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            obBranchAdd.addBranchData("Insert Into Branch Values('" + txtBranchName.Text + "','" + txtCity.Text+ "')");
            MessageBox.Show("Data Inserted Successfully");
            RefreshBranchinfo();
            ClearBranchInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            obUpdateBranch.UpdateBranchData("Update Branch Set BranchName= '" + txtBranchName.Text + "', City= '" + txtCity.Text + "' Where BranchID='" + lblBranchID.Text + "'");

            MessageBox.Show("Data Updated SuccessFully");
            ClearBranchInfo();

            RefreshBranchinfo();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblBranchID.Text = this.dataGridView1.CurrentRow.Cells["BranchID"].Value.ToString();
            txtBranchName.Text = this.dataGridView1.CurrentRow.Cells["BranchName"].Value.ToString();
            txtCity.Text = this.dataGridView1.CurrentRow.Cells["City"].Value.ToString();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.ShowDialog();
        }
    }
}

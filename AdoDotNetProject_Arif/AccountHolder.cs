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
using System.IO;

namespace AdoDotNetProject_Arif
{
    public partial class AccountHolder : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;

        public void RefreshData()
        {
            using (con = new SqlConnection(cs))
            {
                adapter = new SqlDataAdapter("SELECT * FROM Accounts_Holder", con);
                dt = new DataTable();
                adapter.Fill(dt);
                dgViewAccountHolder.DataSource = dt;
            }
        }

        public void ClearAllData()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtMobileNo.Text = "";
            txtBranchID.Text = "";
            txtImageLink.Text = "";         
            PictureBoxForImage.Image = null;

        }

        addAccountHolder obAdd = new addAccountHolder();

        UpdateAccountHolder obUpdate = new UpdateAccountHolder();

        deleteAccountHolder obDelete = new deleteAccountHolder();
        public AccountHolder()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*jpg; *jpeg; *gif; *bmp;)|*jpg; *jpeg; *gif; *bmp;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtImageLink.Text = open.FileName;
                PictureBoxForImage.Image = new Bitmap(open.FileName);

            }
        }

        private void AccountHolder_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            File.Copy(txtImageLink.Text, Path.Combine(@"C:\Users\idb_c#.NH\Desktop\AdoDotNetProject_Arif\AdoDotNetProject_Arif\Images", Path.GetFileName(txtImageLink.Text)), true);


            obAdd.AddData("Insert Into Accounts_Holder Values('" + txtName.Text + "','" + txtAddress.Text + "','" + txtMobileNo.Text + "','" + txtImageLink.Text + "','" + txtBranchID.Text + "')");
            MessageBox.Show("Data Inserted Successfully");
            RefreshData();
            ClearAllData();
        }

        private void dgViewAccountHolder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = this.dgViewAccountHolder.CurrentRow.Cells["Acc_HolderName"].Value.ToString();
            txtAddress.Text = this.dgViewAccountHolder.CurrentRow.Cells["Address"].Value.ToString();
            txtMobileNo.Text = this.dgViewAccountHolder.CurrentRow.Cells["MobileNo"].Value.ToString(); 
            txtImageLink.Text = this.dgViewAccountHolder.CurrentRow.Cells["Image"].Value.ToString();
            lblAId.Text = this.dgViewAccountHolder.CurrentRow.Cells["AccountNo"].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            obUpdate.UpdateData("Update Accounts_Holder Set Acc_HolderName= '" + txtName.Text + "', Address= '" + txtAddress.Text + "', MobileNo= '" + txtMobileNo.Text + "',Image= '" + txtImageLink.Text + "' Where AccountNo='" + lblAId.Text + "'");

            MessageBox.Show("Data Updated Successfully");
            RefreshData();
            ClearAllData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAllData();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            obDelete.DeleteData("Delete Accounts_Holder Where AccountNo='" + lblAId.Text + "'");
            MessageBox.Show("Data Deleted Successfully");
            RefreshData();
            ClearAllData();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.ShowDialog();
        }
    }
}

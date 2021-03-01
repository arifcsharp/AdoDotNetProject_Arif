using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoDotNetProject_Arif
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBranch_Click(object sender, EventArgs e)
        {
            Branch br = new Branch();
            this.Hide();
            br.ShowDialog();
        }

        private void btnAccountHolder_Click(object sender, EventArgs e)
        {
            AccountHolder ah = new AccountHolder();
            this.Hide();
            ah.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Report rpt = new Report();
            this.Hide();
            rpt.ShowDialog();
        }
    }
}

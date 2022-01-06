using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Secure_file_storage_system__RSA_
{
    public partial class Verify_key : Form
    {
        public Verify_key()
        {
            InitializeComponent();
        }

        private void Key_Enter(object sender, EventArgs e)
        {
            if (privateKey.Text == "private key (d)")
            {
                privateKey.Text = "";
                privateKey.ForeColor = Color.White;

            }
        }

        private void Key_Leave(object sender, EventArgs e)
        {
            if (privateKey.Text == "")
            {
                privateKey.Text = "private key (d)";
                privateKey.ForeColor = Color.Gray;

            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
        }
    }

}

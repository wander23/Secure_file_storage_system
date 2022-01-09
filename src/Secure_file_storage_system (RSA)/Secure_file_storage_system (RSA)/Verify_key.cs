using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

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
            announce.Visible = false; 

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
            
            announce.Visible = true;
            announce.Text = "Verifying....";
            announce.ForeColor = System.Drawing.Color.Gray;

            int m = 30;
            GFG test = new GFG();
            int c = test.PowerMod(m, int.Parse(Sign_Up.instance.pubkeye.Text), int.Parse(Sign_Up.instance.pubkeyn.Text));
            int m1 = test.PowerMod(c, int.Parse(privateKey.Text), int.Parse(Sign_Up.instance.pubkeyn.Text));

            // case private key mismatch with public key
            if (m != m1)
            {
                announce.Text = "Key mismatch";
                announce.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show("This key mismatched with public key!", "Mismatched", MessageBoxButtons.OK, MessageBoxIcon.Error);

                privateKey.Text = "private key (d)";
                privateKey.ForeColor = Color.Gray;
                announce.Visible = false;
                return;
            }

            // case private key match with public key 
            HttpClient client = new HttpClient();
            UserModel user = new UserModel()
            {
                username = Sign_Up.instance.userName.Text,
                fullname = Sign_Up.instance.fName.Text,
                n = int.Parse(Sign_Up.instance.pubkeyn.Text),
                e = int.Parse(Sign_Up.instance.pubkeye.Text),
                password = Sign_Up.instance.password.Text
            };

            var responseTask = client.PostAsJsonAsync("https://slave-of-deadlines.herokuapp.com/customers/register", user);
            responseTask.Wait();

            announce.Visible = false;
            MessageBox.Show("           >> Congratulation!! << \nThis key matched with public key! \n\n Click OK to return SIGN IN form", "Infornation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnVerify_MouseHover(object sender, EventArgs e)
        {
            btnVerify.Cursor = Cursors.Hand;

        }

        private void Verify_key_Click(object sender, EventArgs e)
        {
            announce.Visible = false;
        }

        private void privateKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }

}

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
            int m = 30;
            GFG test = new GFG();
            int c = test.PowerMod(m, int.Parse(Sign_Up.instance.pubkeye.Text), int.Parse(Sign_Up.instance.pubkeyn.Text));
            int m1 = test.PowerMod(c, int.Parse(privateKey.Text), int.Parse(Sign_Up.instance.pubkeyn.Text));

            if(m!=m1)
            {
                MessageBox.Show("its not RSA");
                return;
            }

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

        }

        private void btnVerify_MouseHover(object sender, EventArgs e)
        {
            btnVerify.Cursor = Cursors.Hand;

        }
    }

}

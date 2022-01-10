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
    public partial class Sign_Up : Form
    {
        public static Sign_Up instance;
        public TextBox pubkeyn;
        public TextBox pubkeye;
        public TextBox userName;
        public TextBox fName;
        public TextBox password;
        public Sign_Up()
        {
            InitializeComponent();
            instance = this;
            pubkeyn = pubkey_n;
            pubkeye = pubkey_e;
            userName = usrname;
            fName = fullname;
            password = passwrd;
        }

        private void Sign_Up_Load(object sender, EventArgs e)
        {
            this.ActiveControl = lb_Signup;
        }

        private void usrname_Enter(object sender, EventArgs e)
        {
            if (usrname.Text == "Username")
            {
                usrname.Text = "";
                usrname.ForeColor = Color.White;
            }
        }

        private void usrname_Leave(object sender, EventArgs e)
        {
            if (usrname.Text == "")
            {
                usrname.Text = "Username";
                usrname.ForeColor = Color.Gray;
            }
        }

        private void fullname_Enter(object sender, EventArgs e)
        {
            if (fullname.Text == "Full name")
            {
                fullname.Text = "";
                fullname.ForeColor = Color.White;
            }
        }

        private void fullname_Leave(object sender, EventArgs e)
        {
            if (fullname.Text == "")
            {
                fullname.Text = "Full name";
                fullname.ForeColor = Color.Gray;
            }
        }

        private void passwrd_Enter(object sender, EventArgs e)
        {
            if (passwrd.Text == "Password")
            {
                passwrd.Text = "";
                passwrd.ForeColor = Color.White;
            }
        }

        private void passwrd_Leave(object sender, EventArgs e)
        {
            if (passwrd.Text == "")
            {
                passwrd.Text = "Password";
                passwrd.ForeColor = Color.Gray;
            }
        }

        private void pubkeyn_Leave(object sender, EventArgs e)
        {
            if (pubkey_n.Text == "")
            {
                pubkey_n.Text = "Public key (n)";
                pubkey_n.ForeColor = Color.Gray;
            }
        }

        private void pubkeyn_Enter(object sender, EventArgs e)
        {
            if (pubkey_n.Text == "Public key (n)")
            {
                pubkey_n.Text = "";
                pubkey_n.ForeColor = Color.White;
            }
        }

        private void pubkey_e_Enter(object sender, EventArgs e)
        {
            if (pubkey_e.Text == "Public key (e)")
            {
                pubkey_e.Text = "";
                pubkey_e.ForeColor = Color.White;
            }
        }

        private void pubkey_e_Leave(object sender, EventArgs e)
        {
            if (pubkey_e.Text == "")
            {
                pubkey_e.Text = "Public key (e)";
                pubkey_e.ForeColor = Color.Gray;
            }
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            if (usrname.Text == "Username" || fullname.Text == "Full name"
               || passwrd.Text == "Password" || pubkey_e.Text == "Public key (e)" 
               || pubkey_n.Text == "Public key (n)")
            {
                MessageBox.Show("Please fill all input field!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string trimmed = String.Concat(usrname.Text.Where(c => !Char.IsWhiteSpace(c)));
            if (trimmed.Length != usrname.Text.Length)
            {
                MessageBox.Show("Your username Illegal", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                usrname.Text = "";
                return;
            }   

            foreach (char d in pubkey_n.Text)
            {
                int iN = (int)d;
                if ((iN > 57) || (iN < 48))
                {
                    MessageBox.Show("Please fill nummer for public key n and e!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pubkey_n.Text = "";
                    pubkey_e.Text = "";
                    return;
                }
            }

            foreach (char d in pubkey_e.Text)
            {
                int iN = (int)d;
                if ((iN > 57) || (iN < 48))
                {
                    MessageBox.Show("Please fill nummer for public key n and e!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pubkey_e.Text = "";
                    pubkey_n.Text = "";
                    return;
                }
            }

            HttpClient client = new HttpClient();

            var responseTask = client.GetAsync("https://slave-of-deadlines.herokuapp.com/customers/username/"+ usrname.Text);
            responseTask.Wait();
            if (responseTask.IsCompleted)
            {
                var result = responseTask.Result;
                if (!result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Username already taken", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    usrname.Text = "";
                    return;
                }
            }

            var responseTask2 = client.GetAsync("https://slave-of-deadlines.herokuapp.com/customers/publickey/" + pubkey_e.Text+'&'+ pubkey_n.Text);
            responseTask2.Wait();
            if (responseTask2.IsCompleted)
            {
                var result = responseTask2.Result;
                if (!result.IsSuccessStatusCode)
                {
                    MessageBox.Show("public key already taken", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pubkey_e.Text = "";
                    pubkey_n.Text = "";
                    return;
                }
            }

            Verify_key verify_form = new Verify_key();
            verify_form.ShowDialog();
            this.Close();
        }

        private void passwrd_TextChanged(object sender, EventArgs e)
        {
            passwrd.ForeColor = Color.White;
            passwrd.PasswordChar = '*';
        }


        private void Sign_Up_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sign_In.instance.Show();
        }

        private void btn_signup_MouseHover(object sender, EventArgs e)
        {
            btn_signup.Cursor = Cursors.Hand;
        }

        private void pubkey_n_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void pubkey_e_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Sign_Up_Click(object sender, EventArgs e)
        {
            this.ActiveControl = lb_Signup;
        }
    }
}

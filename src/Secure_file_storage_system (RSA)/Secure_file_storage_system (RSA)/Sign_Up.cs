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

        private void confirm_Enter(object sender, EventArgs e)
        {
            if (confirm.Text == "Confirm password")
            {
                confirm.Text = "";
                confirm.ForeColor = Color.White;
            }
        }

        private void confirm_Leave(object sender, EventArgs e)
        {
            if (confirm.Text == "")
            {
                confirm.Text = "Confirm password";
                confirm.ForeColor = Color.Gray;
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
               || pubkey_n.Text == "Public key (n)" || confirm.Text == "Confirm password")
            {
                MessageBox.Show("Fill all pls");
                return;
            }

            Verify_key verify_form = new Verify_key();
            verify_form.ShowDialog();
            this.Close();
        }

        private void passwrd_TextChanged(object sender, EventArgs e)
        {
            passwrd.ForeColor = Color.Black;
            passwrd.PasswordChar = '*';
        }

        private void confirm_TextChanged(object sender, EventArgs e)
        {
            confirm.ForeColor = Color.Black;
            confirm.PasswordChar = '*';
        }

        private void Sign_Up_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sign_In.instance.Show();
        }

        private void btn_signup_MouseHover(object sender, EventArgs e)
        {
            btn_signup.Cursor = Cursors.Hand;
        }
    }
}

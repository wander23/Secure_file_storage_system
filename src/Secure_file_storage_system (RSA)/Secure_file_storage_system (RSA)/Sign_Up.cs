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
        public Sign_Up()
        {
            InitializeComponent();
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
            if(usrname.Text == ""|| passwrd.Text == "" || pubkey_n.Text == "" || pubkey_e.Text == "" || fullname.Text == "" )
            {
                mess.Text = "Please fill all";
                mess.Visible = true;
                return;
            }

            HttpClient client = new HttpClient();
            UserModel user = new UserModel()
            {
                username = usrname.Text,
                password = passwrd.Text,
                n = int.Parse(pubkey_n.Text),
                e = int.Parse(pubkey_e.Text),
                fullname = fullname.Text
            };

            var responseTask = client.PostAsJsonAsync("https://slave-of-deadlines.herokuapp.com/customers/register", user);
            responseTask.Wait();
            if (responseTask.IsCompleted)
            {
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var messageTask = result.Content.ReadAsStringAsync();
                    messageTask.Wait();
                }
                else
                {
                    var messageTask = result.Content.ReadAsStringAsync();
                    mess.Text = messageTask.Result;
                    messageTask.Wait();
                }
            }

            Verify_key verify_form = new Verify_key();
            verify_form.ShowDialog();
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace Secure_file_storage_system__RSA_
{
    public partial class Sign_In : Form
    {
      

        public Sign_In()
        {
            InitializeComponent();

        }
      

        private void btn_signup_Click(object sender, EventArgs e)
        {

        }

        private void username_Enter(object sender, EventArgs e)
        {
            if (username.Text == "type your username")
            {
                username.Text = "";
                username.ForeColor = Color.White;

            }
        }

        private void username_Leave(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                username.Text = "type your username";
                username.ForeColor = Color.Gray;

            }
        }

        private void passwrd_Enter(object sender, EventArgs e)
        {
            if (passwrd.Text == "type your password")
            {
                passwrd.Text = "";
                passwrd.ForeColor = Color.White;

            }
        }

        private void passwrd_Leave(object sender, EventArgs e)
        {
            if (passwrd.Text == "")
            {
                passwrd.Text = "type your password";
                passwrd.ForeColor = Color.Gray;

            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            UserModel user = new UserModel()
            {
                username = username.Text,
                password = passwrd.Text
            };

            var responseTask = client.PostAsJsonAsync("http://localhost:8080/customers/login", user);
            responseTask.Wait();
            if (responseTask.IsCompleted)
            {
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var messageTask = result.Content.ReadAsStringAsync();
                    messageTask.Wait();
                    MessageBox.Show("mess: " + messageTask.Result);
                }
                else
                {
                    MessageBox.Show("error ");
                }
            }
        }

        private void passwrd_TextChanged(object sender, EventArgs e)
        {
            passwrd.ForeColor = Color.Black;
            passwrd.PasswordChar = '*';
        }
    }
}

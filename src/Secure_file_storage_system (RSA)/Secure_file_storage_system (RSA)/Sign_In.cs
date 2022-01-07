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

        public static Sign_In instance;
        public Sign_In()
        {
            InitializeComponent();
            instance = this;

        }
      
        private void btn_signup_Click(object sender, EventArgs e)
        {
            // call SignUp form
            this.Hide();
            Sign_Up signUp_form = new Sign_Up();
            signUp_form.ShowDialog();
        }

        private void username_Enter(object sender, EventArgs e)
        {
            if (username.Text == "type your username")
            {
                lb_announce.Visible = false;
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
                lb_announce.Visible = false;
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
            if(username.Text =="" || passwrd.Text =="")
            {
                lb_announce.Visible = true;
                lb_announce.Text= "fill all";
                return;
            }
            HttpClient client = new HttpClient();
            UserModel user = new UserModel()
            {
                username = username.Text,
                password = passwrd.Text
            };

            var responseTask = client.PostAsJsonAsync("https://slave-of-deadlines.herokuapp.com/customers/login", user);
            responseTask.Wait();
            if (responseTask.IsCompleted)
            {
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode) // login successfull
                {
                    var messageTask = result.Content.ReadAsStringAsync();
                    messageTask.Wait();

                    this.Hide();
                    Main main_form = new Main();
                    main_form.ShowDialog();
                }
                else
                {
                    lb_announce.Visible = true;
                    lb_announce.Text = "Login Fail";
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

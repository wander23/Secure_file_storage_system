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
using Newtonsoft.Json;

namespace Secure_file_storage_system__RSA_
{
    public partial class Sign_In : Form
    {

        public static Sign_In instance;
        public string user_name;
        public string full_name;
        public string id_;
        public int pub_e;
        public int pub_n;
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
            lb_announce.Visible = false;

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
            lb_announce.Visible = false;

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
            lb_announce.Visible = true;

            if (username.Text == "type your username" || passwrd.Text == "type your password")
            {
                lb_announce.ForeColor = System.Drawing.Color.Red;
                lb_announce.Text= "Fill all";
                return;
            }

            lb_announce.Text = "Verifying....";
            lb_announce.ForeColor = System.Drawing.Color.Gray;

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
                    lb_announce.Text = "Login Success";
                    lb_announce.ForeColor = System.Drawing.Color.Green;

                    var messageTask = result.Content.ReadAsStringAsync();
                    messageTask.Wait();

                    dynamic json = JsonConvert.DeserializeObject(messageTask.Result);

                    user_name = json.data.username.ToString();
                    full_name = json.data.fullname.ToString();
                    id_ = json.data.id.ToString();
                    pub_e = Convert.ToInt32(json.data.e);
                    pub_n = Convert.ToInt32(json.data.n);

                    this.Hide();
                    Main main_form = new Main();
                    main_form.ShowDialog();
                }
                else
                {
                    lb_announce.ForeColor = System.Drawing.Color.Red;
                    lb_announce.Text = "Login Fail";
                }
            }
        }

        private void passwrd_TextChanged(object sender, EventArgs e)
        {
            passwrd.ForeColor = Color.Black;
            passwrd.PasswordChar = '*';
        }

        private void Sign_In_Click(object sender, EventArgs e)
        {
            lb_announce.Visible = false;
        }

        private void btn_login_MouseHover(object sender, EventArgs e)
        {
            btn_login.Cursor = Cursors.Hand;
        }

        private void btn_signup_MouseHover(object sender, EventArgs e)
        {
            btn_signup.Cursor = Cursors.Hand;

        }
    }
}

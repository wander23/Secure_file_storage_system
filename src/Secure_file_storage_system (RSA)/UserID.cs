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
    public partial class UserID : Form
    {
        public static UserID instance;
        public TextBox idUser;
        public TextBox privkey;
        public UserID()
        {
            InitializeComponent();
            instance = this;
            idUser = id;
            privkey = key_d;
        }



        private void id_Enter(object sender, EventArgs e)
        {
            lb_announce.Visible = false;

            if (id.Text == "ID" || id.Text == "\r\nID")
            {
                id.Text = "";
                id.ForeColor = Color.White;
            }
        }

        private void id_Leave(object sender, EventArgs e)
        {
            if (id.Text == "")
            {
                id.Text = "ID";
                id.ForeColor = Color.Gray;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            lb_announce.Visible = true;

            if (id.Text == "" || id.Text == "ID" || id.Text == "\r\nID" || key_d.Text == "private key (d)" || key_d.Text == "\r\nprivate key (d)" || key_d.Text == "")
            {
                lb_announce.Text = "Please fill all input field";
                lb_announce.ForeColor = Color.Red;

                id.Text = "";
                id_Leave(sender, e);

                key_d.Text = "";
                key_d_Leave(sender, e);
                
                this.ActiveControl = lb_Login;
                return;
            }

            // ------- NOTE ---------- (KHOA)
            // check user ID
            //true -> this.close

            //false -> lb_announce = "this user ID does not exist"
            


            this.Close();
        }

        private void UserID_FormClosing(object sender, FormClosingEventArgs e)
        {
            //id.Text = "ID";
        }

        private void UserID_Click(object sender, EventArgs e)
        {
            lb_announce.Visible = false;
            id.Text = "ID";
            id.ForeColor = Color.Gray;

            key_d.Text = "private key (d)";
            key_d.ForeColor = Color.Gray;


            this.ActiveControl = lb_Login;
        }

        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToInt16(Keys.Enter))
            {
                btnSend_Click(sender, e);
            }
        }

        private void key_d_Enter(object sender, EventArgs e)
        {
            lb_announce.Visible = false;

            if (key_d.Text == "private key (d)" || key_d.Text == "\r\nprivate key (d)")
            {
                key_d.Text = "";
                key_d.ForeColor = Color.White;
            }
        }

        private void key_d_Leave(object sender, EventArgs e)
        {
            if (key_d.Text == "")
            {
                key_d.Text = "private key (d)";
                key_d.ForeColor = Color.Gray;

            }
        }

        private void key_d_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToInt16(Keys.Enter))
            {
                btnSend_Click(sender, e);
                return;
            }

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}

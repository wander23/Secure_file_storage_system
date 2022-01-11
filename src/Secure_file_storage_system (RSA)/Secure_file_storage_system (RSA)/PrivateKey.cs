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
    public partial class PrivateKey : Form
    {
        public PrivateKey()
        {
            InitializeComponent();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            lb_announce.Visible = true;

            if (key_d.Text == "" || key_d.Text == "private key (d)")
            {
                lb_announce.Text = "Please fill PRIVATE KEY (d)";
                lb_announce.ForeColor = Color.Red;

                key_d.Text = "";
                key_d_Leave(sender, e);
                this.ActiveControl = lb_Login;
                return;
            }

            this.Close();
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

        private void btn_send_MouseHover(object sender, EventArgs e)
        {
            btn_send.Cursor = Cursors.Hand;
        }

        private void key_d_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToInt16(Keys.Enter))
            {
                btn_send_Click(sender, e);
                return;
            }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void PrivateKey_Click(object sender, EventArgs e)
        {
            lb_announce.Visible = false;
        }
    }
}

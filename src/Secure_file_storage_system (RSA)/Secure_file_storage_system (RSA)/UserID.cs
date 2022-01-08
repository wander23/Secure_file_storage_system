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
        public UserID()
        {
            InitializeComponent();
            instance = this;
            idUser = id;
        }

        private void privateKey_Enter(object sender, EventArgs e)
        {

        }

        private void id_Enter(object sender, EventArgs e)
        {

            if (id.Text == "ID")
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
            this.Close();
        }

        private void id_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

namespace Secure_file_storage_system__RSA_
{
    partial class PrivateKey
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrivateKey));
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.lb_Login = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_usrname = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.key_d = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(51, 39);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(110, 110);
            this.pictureBox3.TabIndex = 27;
            this.pictureBox3.TabStop = false;
            // 
            // btn_send
            // 
            this.btn_send.BackColor = System.Drawing.Color.Black;
            this.btn_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.26415F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.ForeColor = System.Drawing.Color.White;
            this.btn_send.Location = new System.Drawing.Point(159, 320);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(126, 53);
            this.btn_send.TabIndex = 26;
            this.btn_send.Text = "SEND";
            this.btn_send.UseVisualStyleBackColor = false;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            this.btn_send.MouseHover += new System.EventHandler(this.btn_send_MouseHover);
            // 
            // lb_Login
            // 
            this.lb_Login.AutoSize = true;
            this.lb_Login.BackColor = System.Drawing.Color.Transparent;
            this.lb_Login.Font = new System.Drawing.Font("Neue Haas Grotesk Text Pro", 23.77358F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Login.ForeColor = System.Drawing.Color.White;
            this.lb_Login.Location = new System.Drawing.Point(151, 68);
            this.lb_Login.Name = "lb_Login";
            this.lb_Login.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lb_Login.Size = new System.Drawing.Size(252, 45);
            this.lb_Login.TabIndex = 25;
            this.lb_Login.Text = "PRIVATE KEY";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Font = new System.Drawing.Font("Neue Haas Grotesk Text Pro", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(101, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 73);
            this.label1.TabIndex = 33;
            this.label1.Text = "We just use this key for Decrypt puppose  only. It do not save!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_usrname
            // 
            this.lb_usrname.AutoSize = true;
            this.lb_usrname.BackColor = System.Drawing.Color.Transparent;
            this.lb_usrname.Font = new System.Drawing.Font("Neue Haas Grotesk Text Pro", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_usrname.ForeColor = System.Drawing.Color.White;
            this.lb_usrname.Location = new System.Drawing.Point(71, 238);
            this.lb_usrname.Name = "lb_usrname";
            this.lb_usrname.Size = new System.Drawing.Size(143, 24);
            this.lb_usrname.TabIndex = 31;
            this.lb_usrname.Text = "Private key (d)";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.key_d);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.panel1.Location = new System.Drawing.Point(75, 265);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 47);
            this.panel1.TabIndex = 32;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // key_d
            // 
            this.key_d.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.key_d.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.key_d.Font = new System.Drawing.Font("Neue Haas Grotesk Text Pro Ligh", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key_d.ForeColor = System.Drawing.Color.Gray;
            this.key_d.Location = new System.Drawing.Point(42, 8);
            this.key_d.Multiline = true;
            this.key_d.Name = "key_d";
            this.key_d.Size = new System.Drawing.Size(254, 30);
            this.key_d.TabIndex = 9;
            this.key_d.Text = "private key (d)";
            this.key_d.Enter += new System.EventHandler(this.key_d_Enter);
            this.key_d.Leave += new System.EventHandler(this.key_d_Leave);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(75)))), ((int)(((byte)(56)))));
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.panel3.Location = new System.Drawing.Point(0, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(363, 5);
            this.panel3.TabIndex = 12;
            // 
            // PrivateKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(434, 429);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_usrname);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.lb_Login);
            this.Font = new System.Drawing.Font("Neue Haas Grotesk Text Pro", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "PrivateKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Storage File System";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Label lb_Login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_usrname;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox key_d;
        private System.Windows.Forms.Panel panel3;
    }
}
﻿namespace Secure_file_storage_system__RSA_
{
    partial class UserID
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserID));
            this.lb_Login = new System.Windows.Forms.Label();
            this.lb_usrname = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.id = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.key_d = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lb_announce = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_Login
            // 
            this.lb_Login.AutoSize = true;
            this.lb_Login.BackColor = System.Drawing.Color.Transparent;
            this.lb_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.81132F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Login.ForeColor = System.Drawing.Color.White;
            this.lb_Login.Location = new System.Drawing.Point(114, 139);
            this.lb_Login.Name = "lb_Login";
            this.lb_Login.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lb_Login.Size = new System.Drawing.Size(230, 44);
            this.lb_Login.TabIndex = 30;
            this.lb_Login.Text = "FIND USER";
            // 
            // lb_usrname
            // 
            this.lb_usrname.AutoSize = true;
            this.lb_usrname.BackColor = System.Drawing.Color.Transparent;
            this.lb_usrname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_usrname.ForeColor = System.Drawing.Color.White;
            this.lb_usrname.Location = new System.Drawing.Point(67, 288);
            this.lb_usrname.Name = "lb_usrname";
            this.lb_usrname.Size = new System.Drawing.Size(78, 24);
            this.lb_usrname.TabIndex = 33;
            this.lb_usrname.Text = "User ID";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.id);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.panel1.Location = new System.Drawing.Point(71, 315);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 47);
            this.panel1.TabIndex = 34;
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
            // id
            // 
            this.id.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.ForeColor = System.Drawing.Color.Gray;
            this.id.Location = new System.Drawing.Point(45, 10);
            this.id.Multiline = true;
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(254, 30);
            this.id.TabIndex = 9;
            this.id.Text = "ID";
            this.id.Enter += new System.EventHandler(this.id_Enter);
            this.id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.id_KeyPress);
            this.id.Leave += new System.EventHandler(this.id_Leave);
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
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Black;
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.26415F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(149, 479);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(126, 53);
            this.btnSend.TabIndex = 32;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(165, 35);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(110, 110);
            this.pictureBox3.TabIndex = 31;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(67, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 24);
            this.label1.TabIndex = 36;
            this.label1.Text = "Private key (d)";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.key_d);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.panel2.Location = new System.Drawing.Point(71, 401);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(299, 47);
            this.panel2.TabIndex = 37;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(6, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Padding = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // key_d
            // 
            this.key_d.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.key_d.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.key_d.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key_d.ForeColor = System.Drawing.Color.Gray;
            this.key_d.Location = new System.Drawing.Point(45, 8);
            this.key_d.Multiline = true;
            this.key_d.Name = "key_d";
            this.key_d.Size = new System.Drawing.Size(251, 30);
            this.key_d.TabIndex = 9;
            this.key_d.Text = "private key (d)";
            this.key_d.Enter += new System.EventHandler(this.key_d_Enter);
            this.key_d.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key_d_KeyPress);
            this.key_d.Leave += new System.EventHandler(this.key_d_Leave);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(75)))), ((int)(((byte)(56)))));
            this.panel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.panel4.Location = new System.Drawing.Point(0, 42);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(363, 5);
            this.panel4.TabIndex = 12;
            // 
            // lb_announce
            // 
            this.lb_announce.AutoSize = true;
            this.lb_announce.BackColor = System.Drawing.Color.Transparent;
            this.lb_announce.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_announce.ForeColor = System.Drawing.Color.Black;
            this.lb_announce.Location = new System.Drawing.Point(130, 456);
            this.lb_announce.Name = "lb_announce";
            this.lb_announce.Size = new System.Drawing.Size(51, 20);
            this.lb_announce.TabIndex = 35;
            this.lb_announce.Text = "label2";
            this.lb_announce.Visible = false;
            // 
            // UserID
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(434, 609);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lb_announce);
            this.Controls.Add(this.lb_Login);
            this.Controls.Add(this.lb_usrname);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.pictureBox3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Storage File System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserID_FormClosing);
            this.Click += new System.EventHandler(this.UserID_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Login;
        private System.Windows.Forms.Label lb_usrname;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox key_d;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lb_announce;
    }
}
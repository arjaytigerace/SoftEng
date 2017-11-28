namespace Accounting
{
    partial class UserPass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserPass));
            this.buttonupd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtusr = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtpswdold = new System.Windows.Forms.TextBox();
            this.txtpswdnew = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonupdpass = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtpswdnew2 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonupd
            // 
            this.buttonupd.BackColor = System.Drawing.Color.Khaki;
            this.buttonupd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonupd.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonupd.Location = new System.Drawing.Point(13, 199);
            this.buttonupd.Margin = new System.Windows.Forms.Padding(4);
            this.buttonupd.Name = "buttonupd";
            this.buttonupd.Size = new System.Drawing.Size(147, 69);
            this.buttonupd.TabIndex = 2;
            this.buttonupd.Text = "Update";
            this.buttonupd.UseVisualStyleBackColor = false;
            this.buttonupd.Click += new System.EventHandler(this.buttonupd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 46);
            this.label1.TabIndex = 19;
            this.label1.Text = "New Username";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtusr
            // 
            this.txtusr.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusr.Location = new System.Drawing.Point(13, 131);
            this.txtusr.Margin = new System.Windows.Forms.Padding(4);
            this.txtusr.Name = "txtusr";
            this.txtusr.Size = new System.Drawing.Size(300, 60);
            this.txtusr.TabIndex = 1;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Location = new System.Drawing.Point(2, 3);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(85, 53);
            this.pictureBox4.TabIndex = 20;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 280);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(306, 46);
            this.label4.TabIndex = 16;
            this.label4.Text = "Old Password";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtpswdold
            // 
            this.txtpswdold.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpswdold.Location = new System.Drawing.Point(13, 332);
            this.txtpswdold.Margin = new System.Windows.Forms.Padding(4);
            this.txtpswdold.Name = "txtpswdold";
            this.txtpswdold.PasswordChar = '*';
            this.txtpswdold.Size = new System.Drawing.Size(300, 60);
            this.txtpswdold.TabIndex = 3;
            this.txtpswdold.TextChanged += new System.EventHandler(this.txtpswdold_TextChanged);
            // 
            // txtpswdnew
            // 
            this.txtpswdnew.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpswdnew.Location = new System.Drawing.Point(13, 452);
            this.txtpswdnew.Margin = new System.Windows.Forms.Padding(4);
            this.txtpswdnew.Name = "txtpswdnew";
            this.txtpswdnew.PasswordChar = '*';
            this.txtpswdnew.Size = new System.Drawing.Size(300, 60);
            this.txtpswdnew.TabIndex = 4;
            this.txtpswdnew.TextChanged += new System.EventHandler(this.txtpswdnew_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 396);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 46);
            this.label3.TabIndex = 19;
            this.label3.Text = "New Password";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonupdpass
            // 
            this.buttonupdpass.BackColor = System.Drawing.Color.Khaki;
            this.buttonupdpass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonupdpass.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonupdpass.Location = new System.Drawing.Point(13, 640);
            this.buttonupdpass.Margin = new System.Windows.Forms.Padding(4);
            this.buttonupdpass.Name = "buttonupdpass";
            this.buttonupdpass.Size = new System.Drawing.Size(147, 69);
            this.buttonupdpass.TabIndex = 6;
            this.buttonupdpass.Text = "Update";
            this.buttonupdpass.UseVisualStyleBackColor = false;
            this.buttonupdpass.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 516);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 46);
            this.label5.TabIndex = 21;
            this.label5.Text = "Confirm";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtpswdnew2
            // 
            this.txtpswdnew2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpswdnew2.Location = new System.Drawing.Point(13, 572);
            this.txtpswdnew2.Margin = new System.Windows.Forms.Padding(4);
            this.txtpswdnew2.Name = "txtpswdnew2";
            this.txtpswdnew2.PasswordChar = '*';
            this.txtpswdnew2.Size = new System.Drawing.Size(300, 60);
            this.txtpswdnew2.TabIndex = 5;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(259, 3);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(82, 57);
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // UserPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(346, 717);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtpswdnew2);
            this.Controls.Add(this.buttonupd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.buttonupdpass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtusr);
            this.Controls.Add(this.txtpswdnew);
            this.Controls.Add(this.txtpswdold);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserPass";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserPass_FormClosing);
            this.Load += new System.EventHandler(this.UserPass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonupd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtusr;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtpswdold;
        private System.Windows.Forms.TextBox txtpswdnew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonupdpass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtpswdnew2;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
﻿namespace Accounting
{
    partial class BRWupdate
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.yc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.sID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.sLName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.sFName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.qty = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.itemName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rstatus = new System.Windows.Forms.ComboBox();
            this.labell = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.qty)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(443, 696);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(147, 69);
            this.buttonCancel.TabIndex = 26;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.Location = new System.Drawing.Point(288, 696);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(147, 69);
            this.buttonLogin.TabIndex = 25;
            this.buttonLogin.Text = "Update";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // yc
            // 
            this.yc.BackColor = System.Drawing.SystemColors.Control;
            this.yc.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yc.Location = new System.Drawing.Point(276, 359);
            this.yc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.yc.Name = "yc";
            this.yc.ReadOnly = true;
            this.yc.Size = new System.Drawing.Size(319, 34);
            this.yc.TabIndex = 57;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(9, 359);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(160, 29);
            this.label12.TabIndex = 56;
            this.label12.Text = "Year/Course";
            // 
            // sID
            // 
            this.sID.BackColor = System.Drawing.SystemColors.Control;
            this.sID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sID.Location = new System.Drawing.Point(276, 236);
            this.sID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sID.Name = "sID";
            this.sID.Size = new System.Drawing.Size(319, 34);
            this.sID.TabIndex = 55;
            this.sID.Leave += new System.EventHandler(this.sID_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 236);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 29);
            this.label11.TabIndex = 54;
            this.label11.Text = "Student ID";
            // 
            // sLName
            // 
            this.sLName.BackColor = System.Drawing.SystemColors.Control;
            this.sLName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sLName.Location = new System.Drawing.Point(276, 322);
            this.sLName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sLName.Name = "sLName";
            this.sLName.ReadOnly = true;
            this.sLName.Size = new System.Drawing.Size(319, 34);
            this.sLName.TabIndex = 53;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 322);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(233, 29);
            this.label10.TabIndex = 52;
            this.label10.Text = "Student Last Name";
            // 
            // sFName
            // 
            this.sFName.BackColor = System.Drawing.SystemColors.Control;
            this.sFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sFName.Location = new System.Drawing.Point(276, 274);
            this.sFName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sFName.Name = "sFName";
            this.sFName.ReadOnly = true;
            this.sFName.Size = new System.Drawing.Size(319, 34);
            this.sFName.TabIndex = 51;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(237, 29);
            this.label7.TabIndex = 50;
            this.label7.Text = "Student First Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(405, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 17);
            this.label6.TabIndex = 49;
            this.label6.Text = "--";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "HH:mm:ss";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(447, 176);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(148, 22);
            this.dateTimePicker2.TabIndex = 48;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(276, 175);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(159, 22);
            this.dateTimePicker1.TabIndex = 47;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 29);
            this.label8.TabIndex = 46;
            this.label8.Text = "Return Date";
            // 
            // qty
            // 
            this.qty.Location = new System.Drawing.Point(276, 85);
            this.qty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.qty.Name = "qty";
            this.qty.Size = new System.Drawing.Size(107, 22);
            this.qty.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 29);
            this.label5.TabIndex = 43;
            this.label5.Text = "Quantity";
            // 
            // itemName
            // 
            this.itemName.BackColor = System.Drawing.SystemColors.Control;
            this.itemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemName.Location = new System.Drawing.Point(276, 23);
            this.itemName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemName.Name = "itemName";
            this.itemName.Size = new System.Drawing.Size(319, 34);
            this.itemName.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 29);
            this.label2.TabIndex = 40;
            this.label2.Text = "Item Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 29);
            this.label3.TabIndex = 42;
            this.label3.Text = "Date Borrowed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(275, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 45;
            this.label1.Text = "label1";
            // 
            // rstatus
            // 
            this.rstatus.FormattingEnabled = true;
            this.rstatus.Items.AddRange(new object[] {
            "Unreleased",
            "Released",
            "Cancelled"});
            this.rstatus.Location = new System.Drawing.Point(275, 412);
            this.rstatus.Margin = new System.Windows.Forms.Padding(4);
            this.rstatus.Name = "rstatus";
            this.rstatus.Size = new System.Drawing.Size(320, 24);
            this.rstatus.TabIndex = 58;
            // 
            // labell
            // 
            this.labell.AutoSize = true;
            this.labell.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labell.Location = new System.Drawing.Point(15, 407);
            this.labell.Name = "labell";
            this.labell.Size = new System.Drawing.Size(85, 29);
            this.labell.TabIndex = 59;
            this.labell.Text = "Status";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(9, 459);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 29);
            this.label15.TabIndex = 70;
            this.label15.Text = "Remarks";
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.Control;
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(278, 456);
            this.textBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(260, 168);
            this.textBox9.TabIndex = 69;
            // 
            // BRWupdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(729, 803);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.labell);
            this.Controls.Add(this.rstatus);
            this.Controls.Add(this.yc);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.sID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.sLName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.sFName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.qty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.itemName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BRWupdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BRWupdate";
            this.Load += new System.EventHandler(this.BRWupdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox yc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox sID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox sLName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox sFName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown qty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox itemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox rstatus;
        private System.Windows.Forms.Label labell;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox9;
    }
}
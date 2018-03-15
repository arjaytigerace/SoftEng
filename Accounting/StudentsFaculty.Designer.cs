namespace Accounting
{
    partial class StudentsFaculty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentsFaculty));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ID = new System.Windows.Forms.Label();
            this.sID = new System.Windows.Forms.TextBox();
            this.sdeselect = new System.Windows.Forms.Button();
            this.screate = new System.Windows.Forms.Button();
            this.supdate = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.scourse = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sfname = new System.Windows.Forms.TextBox();
            this.slname = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.facID = new System.Windows.Forms.TextBox();
            this.fdeselect = new System.Windows.Forms.Button();
            this.fcreate = new System.Windows.Forms.Button();
            this.fupdate = new System.Windows.Forms.Button();
            this.facstatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.facfname = new System.Windows.Forms.TextBox();
            this.faclname = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Location = new System.Drawing.Point(806, 23);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(82, 63);
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(64, 44);
            this.pictureBox4.TabIndex = 32;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(375, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(275, 29);
            this.label7.TabIndex = 33;
            this.label7.Text = "Students and Faculty";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1002, 292);
            this.dataGridView1.TabIndex = 34;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 92);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1057, 684);
            this.tabControl1.TabIndex = 37;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ID);
            this.tabPage1.Controls.Add(this.sID);
            this.tabPage1.Controls.Add(this.sdeselect);
            this.tabPage1.Controls.Add(this.screate);
            this.tabPage1.Controls.Add(this.supdate);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.scourse);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.sfname);
            this.tabPage1.Controls.Add(this.slname);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1049, 658);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Students";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.Location = new System.Drawing.Point(29, 367);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(44, 29);
            this.ID.TabIndex = 47;
            this.ID.Text = "ID";
            this.ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sID
            // 
            this.sID.BackColor = System.Drawing.SystemColors.Control;
            this.sID.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sID.Location = new System.Drawing.Point(190, 364);
            this.sID.Name = "sID";
            this.sID.Size = new System.Drawing.Size(297, 35);
            this.sID.TabIndex = 46;
            // 
            // sdeselect
            // 
            this.sdeselect.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sdeselect.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.sdeselect.Location = new System.Drawing.Point(641, 460);
            this.sdeselect.Margin = new System.Windows.Forms.Padding(2);
            this.sdeselect.Name = "sdeselect";
            this.sdeselect.Size = new System.Drawing.Size(134, 43);
            this.sdeselect.TabIndex = 44;
            this.sdeselect.Text = "Deselect";
            this.sdeselect.UseVisualStyleBackColor = true;
            this.sdeselect.Click += new System.EventHandler(this.sdeselect_Click);
            // 
            // screate
            // 
            this.screate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.screate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.screate.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.screate.Location = new System.Drawing.Point(641, 406);
            this.screate.Name = "screate";
            this.screate.Size = new System.Drawing.Size(117, 43);
            this.screate.TabIndex = 43;
            this.screate.Text = "Create";
            this.screate.UseVisualStyleBackColor = false;
            this.screate.Click += new System.EventHandler(this.screate_Click);
            // 
            // supdate
            // 
            this.supdate.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.supdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.supdate.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supdate.Location = new System.Drawing.Point(641, 508);
            this.supdate.Name = "supdate";
            this.supdate.Size = new System.Drawing.Size(122, 43);
            this.supdate.TabIndex = 45;
            this.supdate.Text = "Update";
            this.supdate.UseVisualStyleBackColor = false;
            this.supdate.Click += new System.EventHandler(this.supdate_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Undergraduate",
            "Graduate"});
            this.comboBox1.Location = new System.Drawing.Point(190, 588);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(297, 21);
            this.comboBox1.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 581);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 29);
            this.label4.TabIndex = 41;
            this.label4.Text = "Status";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 531);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 29);
            this.label3.TabIndex = 40;
            this.label3.Text = "Course";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scourse
            // 
            this.scourse.BackColor = System.Drawing.SystemColors.Control;
            this.scourse.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scourse.Location = new System.Drawing.Point(190, 525);
            this.scourse.Name = "scourse";
            this.scourse.Size = new System.Drawing.Size(297, 35);
            this.scourse.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 474);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 29);
            this.label1.TabIndex = 38;
            this.label1.Text = "Lastname";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 29);
            this.label2.TabIndex = 37;
            this.label2.Text = "Firstname";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sfname
            // 
            this.sfname.BackColor = System.Drawing.SystemColors.Control;
            this.sfname.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfname.Location = new System.Drawing.Point(190, 414);
            this.sfname.Name = "sfname";
            this.sfname.Size = new System.Drawing.Size(297, 35);
            this.sfname.TabIndex = 35;
            // 
            // slname
            // 
            this.slname.BackColor = System.Drawing.SystemColors.Control;
            this.slname.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slname.Location = new System.Drawing.Point(190, 468);
            this.slname.Name = "slname";
            this.slname.Size = new System.Drawing.Size(297, 35);
            this.slname.TabIndex = 36;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.facID);
            this.tabPage2.Controls.Add(this.fdeselect);
            this.tabPage2.Controls.Add(this.fcreate);
            this.tabPage2.Controls.Add(this.fupdate);
            this.tabPage2.Controls.Add(this.facstatus);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.facfname);
            this.tabPage2.Controls.Add(this.faclname);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1049, 658);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Faculty";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 330);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 29);
            this.label6.TabIndex = 50;
            this.label6.Text = "ID";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // facID
            // 
            this.facID.BackColor = System.Drawing.SystemColors.Control;
            this.facID.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.facID.Location = new System.Drawing.Point(208, 327);
            this.facID.Name = "facID";
            this.facID.Size = new System.Drawing.Size(297, 35);
            this.facID.TabIndex = 49;
            // 
            // fdeselect
            // 
            this.fdeselect.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fdeselect.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.fdeselect.Location = new System.Drawing.Point(763, 330);
            this.fdeselect.Margin = new System.Windows.Forms.Padding(2);
            this.fdeselect.Name = "fdeselect";
            this.fdeselect.Size = new System.Drawing.Size(134, 43);
            this.fdeselect.TabIndex = 47;
            this.fdeselect.Text = "Deselect";
            this.fdeselect.UseVisualStyleBackColor = true;
            this.fdeselect.Click += new System.EventHandler(this.fdeselect_Click);
            // 
            // fcreate
            // 
            this.fcreate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.fcreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fcreate.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fcreate.Location = new System.Drawing.Point(641, 330);
            this.fcreate.Name = "fcreate";
            this.fcreate.Size = new System.Drawing.Size(117, 43);
            this.fcreate.TabIndex = 46;
            this.fcreate.Text = "Create";
            this.fcreate.UseVisualStyleBackColor = false;
            this.fcreate.Click += new System.EventHandler(this.fcreate_Click);
            // 
            // fupdate
            // 
            this.fupdate.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.fupdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fupdate.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fupdate.Location = new System.Drawing.Point(902, 330);
            this.fupdate.Name = "fupdate";
            this.fupdate.Size = new System.Drawing.Size(122, 43);
            this.fupdate.TabIndex = 48;
            this.fupdate.Text = "Update";
            this.fupdate.UseVisualStyleBackColor = false;
            this.fupdate.Click += new System.EventHandler(this.fupdate_Click);
            // 
            // facstatus
            // 
            this.facstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.facstatus.FormattingEnabled = true;
            this.facstatus.Items.AddRange(new object[] {
            "Full Time",
            "Part Time",
            "Inactive"});
            this.facstatus.Location = new System.Drawing.Point(208, 494);
            this.facstatus.Name = "facstatus";
            this.facstatus.Size = new System.Drawing.Size(297, 21);
            this.facstatus.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 485);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 29);
            this.label5.TabIndex = 42;
            this.label5.Text = "Status";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(46, 439);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 29);
            this.label8.TabIndex = 39;
            this.label8.Text = "Lastname";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(47, 384);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 29);
            this.label9.TabIndex = 38;
            this.label9.Text = "Firstname";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // facfname
            // 
            this.facfname.BackColor = System.Drawing.SystemColors.Control;
            this.facfname.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.facfname.Location = new System.Drawing.Point(208, 379);
            this.facfname.Name = "facfname";
            this.facfname.Size = new System.Drawing.Size(297, 35);
            this.facfname.TabIndex = 36;
            // 
            // faclname
            // 
            this.faclname.BackColor = System.Drawing.SystemColors.Control;
            this.faclname.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.faclname.Location = new System.Drawing.Point(208, 433);
            this.faclname.Name = "faclname";
            this.faclname.Size = new System.Drawing.Size(297, 35);
            this.faclname.TabIndex = 37;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(22, 19);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1002, 283);
            this.dataGridView2.TabIndex = 35;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // StudentsFaculty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1093, 788);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentsFaculty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentsFaculty";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentsFaculty_FormClosing);
            this.Load += new System.EventHandler(this.StudentsFaculty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox scourse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sfname;
        private System.Windows.Forms.TextBox slname;
        private System.Windows.Forms.Button sdeselect;
        private System.Windows.Forms.Button screate;
        private System.Windows.Forms.Button supdate;
        private System.Windows.Forms.ComboBox facstatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox facfname;
        private System.Windows.Forms.TextBox faclname;
        private System.Windows.Forms.Button fdeselect;
        private System.Windows.Forms.Button fcreate;
        private System.Windows.Forms.Button fupdate;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.TextBox sID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox facID;
    }
}
namespace Accounting
{
    partial class ChemicalManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChemicalManagement));
            this.searchchem = new System.Windows.Forms.Button();
            this.searchc = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.specificsearch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rnum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // searchchem
            // 
            this.searchchem.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.searchchem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchchem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchchem.Location = new System.Drawing.Point(724, 547);
            this.searchchem.Margin = new System.Windows.Forms.Padding(2);
            this.searchchem.Name = "searchchem";
            this.searchchem.Size = new System.Drawing.Size(91, 33);
            this.searchchem.TabIndex = 55;
            this.searchchem.Text = "Search";
            this.searchchem.UseVisualStyleBackColor = false;
            this.searchchem.Click += new System.EventHandler(this.searchchem_Click);
            // 
            // searchc
            // 
            this.searchc.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.searchc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchc.Location = new System.Drawing.Point(610, 488);
            this.searchc.Margin = new System.Windows.Forms.Padding(2);
            this.searchc.Name = "searchc";
            this.searchc.Size = new System.Drawing.Size(323, 29);
            this.searchc.TabIndex = 56;
            this.searchc.TextChanged += new System.EventHandler(this.searchc_TextChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(182, 488);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 37);
            this.button3.TabIndex = 58;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(26, 488);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 37);
            this.button1.TabIndex = 57;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Location = new System.Drawing.Point(12, 6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(68, 37);
            this.pictureBox4.TabIndex = 59;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 48);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1273, 379);
            this.dataGridView1.TabIndex = 60;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // specificsearch
            // 
            this.specificsearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.specificsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.specificsearch.FormattingEnabled = true;
            this.specificsearch.Items.AddRange(new object[] {
            "Item Name",
            "Subject",
            "Student First Name",
            "Student Last Name"});
            this.specificsearch.Location = new System.Drawing.Point(398, 488);
            this.specificsearch.Margin = new System.Windows.Forms.Padding(2);
            this.specificsearch.Name = "specificsearch";
            this.specificsearch.Size = new System.Drawing.Size(140, 33);
            this.specificsearch.TabIndex = 61;
            this.specificsearch.SelectedIndexChanged += new System.EventHandler(this.specificsearch_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(967, 494);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 20);
            this.label1.TabIndex = 62;
            this.label1.Text = "Total number of requests:";
            // 
            // rnum
            // 
            this.rnum.AutoSize = true;
            this.rnum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rnum.Location = new System.Drawing.Point(1163, 494);
            this.rnum.Name = "rnum";
            this.rnum.Size = new System.Drawing.Size(51, 20);
            this.rnum.TabIndex = 63;
            this.rnum.Text = "label2";
            // 
            // ChemicalManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1339, 703);
            this.Controls.Add(this.rnum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.specificsearch);
            this.Controls.Add(this.searchchem);
            this.Controls.Add(this.searchc);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ChemicalManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChemicalManagement";
            this.Activated += new System.EventHandler(this.ChemicalManagement_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChemicalManagement_FormClosing);
            this.Load += new System.EventHandler(this.ChemicalManagement_Load);
            this.Shown += new System.EventHandler(this.ChemicalManagement_Shown);
            this.Leave += new System.EventHandler(this.ChemicalManagement_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button searchchem;
        private System.Windows.Forms.TextBox searchc;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox specificsearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label rnum;
    }
}
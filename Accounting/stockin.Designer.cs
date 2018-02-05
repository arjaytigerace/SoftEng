namespace Accounting
{
    partial class stockin
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sqty = new System.Windows.Forms.NumericUpDown();
            this.stockinbutton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.sItemName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.stocknew = new System.Windows.Forms.Button();
            this.estlife = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.purchasedate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.eItemCode = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.equipStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.costunit = new System.Windows.Forms.TextBox();
            this.brand = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.eitemname = new System.Windows.Forms.TextBox();
            this.emeasuretype = new System.Windows.Forms.ComboBox();
            this.eqty = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sqty)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eqty)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(667, 478);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.textBox9);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.sqty);
            this.tabPage1.Controls.Add(this.stockinbutton);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.sItemName);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(659, 452);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Existing Item";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(47, 249);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 25);
            this.label11.TabIndex = 67;
            this.label11.Text = "Remarks";
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.Control;
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(244, 236);
            this.textBox9.Margin = new System.Windows.Forms.Padding(2);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(196, 137);
            this.textBox9.TabIndex = 66;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 187);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 56;
            this.label3.Text = "Reason";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "New Arrival",
            "Returned",
            "Repaired",
            "Found"});
            this.comboBox1.Location = new System.Drawing.Point(244, 184);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 28);
            this.comboBox1.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(47, 123);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 25);
            this.label5.TabIndex = 54;
            this.label5.Text = "Quantity";
            // 
            // sqty
            // 
            this.sqty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sqty.Location = new System.Drawing.Point(244, 125);
            this.sqty.Margin = new System.Windows.Forms.Padding(2);
            this.sqty.Name = "sqty";
            this.sqty.Size = new System.Drawing.Size(74, 26);
            this.sqty.TabIndex = 53;
            // 
            // stockinbutton
            // 
            this.stockinbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.stockinbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stockinbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockinbutton.Location = new System.Drawing.Point(254, 385);
            this.stockinbutton.Margin = new System.Windows.Forms.Padding(2);
            this.stockinbutton.Name = "stockinbutton";
            this.stockinbutton.Size = new System.Drawing.Size(123, 51);
            this.stockinbutton.TabIndex = 52;
            this.stockinbutton.Text = "Stock In";
            this.stockinbutton.UseVisualStyleBackColor = false;
            this.stockinbutton.Click += new System.EventHandler(this.stockinbutton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 61);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 25);
            this.label4.TabIndex = 51;
            this.label4.Text = "Item Name";
            // 
            // sItemName
            // 
            this.sItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sItemName.Location = new System.Drawing.Point(244, 62);
            this.sItemName.Margin = new System.Windows.Forms.Padding(2);
            this.sItemName.Name = "sItemName";
            this.sItemName.Size = new System.Drawing.Size(196, 26);
            this.sItemName.TabIndex = 50;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Controls.Add(this.stocknew);
            this.tabPage2.Controls.Add(this.estlife);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.purchasedate);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label26);
            this.tabPage2.Controls.Add(this.eItemCode);
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.equipStatus);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.costunit);
            this.tabPage2.Controls.Add(this.brand);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.eitemname);
            this.tabPage2.Controls.Add(this.emeasuretype);
            this.tabPage2.Controls.Add(this.eqty);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(659, 452);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "New Item";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(78, 302);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 25);
            this.label6.TabIndex = 69;
            this.label6.Text = "Reason";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "New Arrival",
            "Returned",
            "Repaired",
            "Found"});
            this.comboBox2.Location = new System.Drawing.Point(299, 299);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(196, 28);
            this.comboBox2.TabIndex = 68;
            // 
            // stocknew
            // 
            this.stocknew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.stocknew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stocknew.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stocknew.Location = new System.Drawing.Point(250, 351);
            this.stocknew.Margin = new System.Windows.Forms.Padding(2);
            this.stocknew.Name = "stocknew";
            this.stocknew.Size = new System.Drawing.Size(123, 51);
            this.stocknew.TabIndex = 67;
            this.stocknew.Text = "Stock In";
            this.stocknew.UseVisualStyleBackColor = false;
            // 
            // estlife
            // 
            this.estlife.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estlife.Location = new System.Drawing.Point(299, 269);
            this.estlife.Margin = new System.Windows.Forms.Padding(2);
            this.estlife.Name = "estlife";
            this.estlife.Size = new System.Drawing.Size(303, 26);
            this.estlife.TabIndex = 64;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(74, 268);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(162, 25);
            this.label10.TabIndex = 66;
            this.label10.Text = "Estimated Life";
            // 
            // purchasedate
            // 
            this.purchasedate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchasedate.Location = new System.Drawing.Point(299, 237);
            this.purchasedate.Margin = new System.Windows.Forms.Padding(2);
            this.purchasedate.Name = "purchasedate";
            this.purchasedate.Size = new System.Drawing.Size(304, 26);
            this.purchasedate.TabIndex = 63;
            this.purchasedate.Value = new System.DateTime(2017, 10, 2, 0, 0, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(74, 237);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(194, 25);
            this.label9.TabIndex = 65;
            this.label9.Text = "Date of Purchase";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(70, 47);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(118, 25);
            this.label26.TabIndex = 62;
            this.label26.Text = "Item Code";
            // 
            // eItemCode
            // 
            this.eItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eItemCode.Location = new System.Drawing.Point(299, 47);
            this.eItemCode.Margin = new System.Windows.Forms.Padding(2);
            this.eItemCode.Name = "eItemCode";
            this.eItemCode.Size = new System.Drawing.Size(196, 26);
            this.eItemCode.TabIndex = 61;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(70, 197);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 25);
            this.label22.TabIndex = 60;
            this.label22.Text = "Status";
            // 
            // equipStatus
            // 
            this.equipStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.equipStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipStatus.FormattingEnabled = true;
            this.equipStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.equipStatus.Location = new System.Drawing.Point(299, 196);
            this.equipStatus.Margin = new System.Windows.Forms.Padding(2);
            this.equipStatus.Name = "equipStatus";
            this.equipStatus.Size = new System.Drawing.Size(196, 28);
            this.equipStatus.TabIndex = 59;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(70, 167);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 25);
            this.label8.TabIndex = 58;
            this.label8.Text = "Cost/Unit";
            // 
            // costunit
            // 
            this.costunit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costunit.Location = new System.Drawing.Point(299, 166);
            this.costunit.Margin = new System.Windows.Forms.Padding(2);
            this.costunit.Name = "costunit";
            this.costunit.Size = new System.Drawing.Size(196, 26);
            this.costunit.TabIndex = 54;
            // 
            // brand
            // 
            this.brand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brand.Location = new System.Drawing.Point(299, 136);
            this.brand.Margin = new System.Windows.Forms.Padding(2);
            this.brand.Name = "brand";
            this.brand.Size = new System.Drawing.Size(196, 26);
            this.brand.TabIndex = 53;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(70, 137);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 25);
            this.label7.TabIndex = 57;
            this.label7.Text = "Brand and Model";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 55;
            this.label1.Text = "Item Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 56;
            this.label2.Text = "Quantity";
            // 
            // eitemname
            // 
            this.eitemname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eitemname.Location = new System.Drawing.Point(299, 75);
            this.eitemname.Margin = new System.Windows.Forms.Padding(2);
            this.eitemname.Name = "eitemname";
            this.eitemname.Size = new System.Drawing.Size(196, 26);
            this.eitemname.TabIndex = 50;
            // 
            // emeasuretype
            // 
            this.emeasuretype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.emeasuretype.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emeasuretype.FormattingEnabled = true;
            this.emeasuretype.Items.AddRange(new object[] {
            "Unit(s)",
            "Piece(s)",
            "ml",
            "g",
            "L",
            "Kg"});
            this.emeasuretype.Location = new System.Drawing.Point(377, 105);
            this.emeasuretype.Margin = new System.Windows.Forms.Padding(2);
            this.emeasuretype.Name = "emeasuretype";
            this.emeasuretype.Size = new System.Drawing.Size(118, 28);
            this.emeasuretype.TabIndex = 52;
            // 
            // eqty
            // 
            this.eqty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eqty.Location = new System.Drawing.Point(299, 106);
            this.eqty.Margin = new System.Windows.Forms.Padding(2);
            this.eqty.Name = "eqty";
            this.eqty.Size = new System.Drawing.Size(74, 26);
            this.eqty.TabIndex = 51;
            // 
            // stockin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 502);
            this.Controls.Add(this.tabControl1);
            this.Name = "stockin";
            this.Text = "stockin";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sqty)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eqty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sItemName;
        private System.Windows.Forms.Button stockinbutton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown sqty;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox eItemCode;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox equipStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox costunit;
        private System.Windows.Forms.TextBox brand;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox eitemname;
        private System.Windows.Forms.ComboBox emeasuretype;
        private System.Windows.Forms.NumericUpDown eqty;
        private System.Windows.Forms.Button stocknew;
        private System.Windows.Forms.TextBox estlife;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker purchasedate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox9;
    }
}
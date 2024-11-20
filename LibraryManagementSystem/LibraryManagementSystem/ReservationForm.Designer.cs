namespace LibraryManagementSystem
{
    partial class ReservationForm
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
            btnPlaceHold = new Button();
            panel1 = new Panel();
            dgv = new DataGridView();
            panel2 = new Panel();
            label15 = new Label();
            txtStatus1 = new TextBox();
            label7 = new Label();
            txtPrice = new TextBox();
            label1 = new Label();
            txtISBN = new TextBox();
            dtpReservationDate = new DateTimePicker();
            cbbBookTitle = new ComboBox();
            cbbUsername = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtRefCode = new TextBox();
            btnCheck = new Button();
            label6 = new Label();
            txtUsername = new TextBox();
            groupBox1 = new GroupBox();
            dtpReservationDate1 = new DateTimePicker();
            label11 = new Label();
            txtStatus = new TextBox();
            label10 = new Label();
            txtISBN1 = new TextBox();
            label9 = new Label();
            txtBookTitle = new TextBox();
            label8 = new Label();
            label13 = new Label();
            cbbGenre = new ComboBox();
            btnSearch = new Button();
            txtSearch = new TextBox();
            label14 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnPlaceHold
            // 
            btnPlaceHold.Location = new Point(105, 357);
            btnPlaceHold.Name = "btnPlaceHold";
            btnPlaceHold.Size = new Size(89, 39);
            btnPlaceHold.TabIndex = 5;
            btnPlaceHold.Text = "Place hold";
            btnPlaceHold.UseVisualStyleBackColor = true;
            btnPlaceHold.Click += btnPlaceHold_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgv);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(469, 426);
            panel1.TabIndex = 8;
            // 
            // dgv
            // 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new Point(3, 3);
            dgv.Name = "dgv";
            dgv.Size = new Size(463, 420);
            dgv.TabIndex = 0;
            dgv.CellContentClick += dgv_CellContentClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(label15);
            panel2.Controls.Add(txtStatus1);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtPrice);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnPlaceHold);
            panel2.Controls.Add(txtISBN);
            panel2.Controls.Add(dtpReservationDate);
            panel2.Controls.Add(cbbBookTitle);
            panel2.Controls.Add(cbbUsername);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(487, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(301, 426);
            panel2.TabIndex = 9;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(11, 238);
            label15.Name = "label15";
            label15.Size = new Size(39, 15);
            label15.TabIndex = 39;
            label15.Text = "Status";
            // 
            // txtStatus1
            // 
            txtStatus1.Location = new Point(88, 235);
            txtStatus1.Name = "txtStatus1";
            txtStatus1.ReadOnly = true;
            txtStatus1.Size = new Size(184, 23);
            txtStatus1.TabIndex = 38;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 287);
            label7.Name = "label7";
            label7.Size = new Size(33, 15);
            label7.TabIndex = 37;
            label7.Text = "Price";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(87, 284);
            txtPrice.Name = "txtPrice";
            txtPrice.ReadOnly = true;
            txtPrice.Size = new Size(184, 23);
            txtPrice.TabIndex = 36;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 101);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 35;
            label1.Text = "ISBN";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(88, 98);
            txtISBN.Name = "txtISBN";
            txtISBN.ReadOnly = true;
            txtISBN.Size = new Size(184, 23);
            txtISBN.TabIndex = 3;
            // 
            // dtpReservationDate
            // 
            dtpReservationDate.Location = new Point(11, 181);
            dtpReservationDate.Name = "dtpReservationDate";
            dtpReservationDate.Size = new Size(259, 23);
            dtpReservationDate.TabIndex = 4;
            // 
            // cbbBookTitle
            // 
            cbbBookTitle.FormattingEnabled = true;
            cbbBookTitle.Location = new Point(88, 53);
            cbbBookTitle.Name = "cbbBookTitle";
            cbbBookTitle.Size = new Size(183, 23);
            cbbBookTitle.TabIndex = 2;
            cbbBookTitle.SelectedIndexChanged += cbbBookTitle_SelectedIndexChanged;
            // 
            // cbbUsername
            // 
            cbbUsername.FormattingEnabled = true;
            cbbUsername.Location = new Point(88, 9);
            cbbUsername.Name = "cbbUsername";
            cbbUsername.Size = new Size(183, 23);
            cbbUsername.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 56);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 31;
            label3.Text = "Book Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 12);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 30;
            label2.Text = "Username";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 148);
            label4.Name = "label4";
            label4.Size = new Size(95, 15);
            label4.TabIndex = 12;
            label4.Text = "Reservation Date";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 524);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 39;
            label5.Text = "REF CODE";
            // 
            // txtRefCode
            // 
            txtRefCode.Location = new Point(96, 521);
            txtRefCode.Name = "txtRefCode";
            txtRefCode.Size = new Size(184, 23);
            txtRefCode.TabIndex = 6;
            // 
            // btnCheck
            // 
            btnCheck.Location = new Point(303, 521);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(77, 26);
            btnCheck.TabIndex = 7;
            btnCheck.Text = "Check";
            btnCheck.UseVisualStyleBackColor = true;
            btnCheck.Click += btnCheck_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 25);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 42;
            label6.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(98, 22);
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new Size(151, 23);
            txtUsername.TabIndex = 41;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtpReservationDate1);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(txtStatus);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(txtISBN1);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(txtBookTitle);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Controls.Add(label6);
            groupBox1.Location = new Point(15, 550);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(773, 100);
            groupBox1.TabIndex = 43;
            groupBox1.TabStop = false;
            groupBox1.Text = "Reservation Information";
            // 
            // dtpReservationDate1
            // 
            dtpReservationDate1.Location = new Point(560, 60);
            dtpReservationDate1.Name = "dtpReservationDate1";
            dtpReservationDate1.Size = new Size(207, 23);
            dtpReservationDate1.TabIndex = 50;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(560, 28);
            label11.Name = "label11";
            label11.Size = new Size(95, 15);
            label11.TabIndex = 49;
            label11.Text = "Reservation Date";
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(358, 63);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(151, 23);
            txtStatus.TabIndex = 47;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(281, 66);
            label10.Name = "label10";
            label10.Size = new Size(39, 15);
            label10.TabIndex = 48;
            label10.Text = "Status";
            // 
            // txtISBN1
            // 
            txtISBN1.Location = new Point(358, 25);
            txtISBN1.Name = "txtISBN1";
            txtISBN1.ReadOnly = true;
            txtISBN1.Size = new Size(151, 23);
            txtISBN1.TabIndex = 45;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(281, 28);
            label9.Name = "label9";
            label9.Size = new Size(32, 15);
            label9.TabIndex = 46;
            label9.Text = "ISBN";
            // 
            // txtBookTitle
            // 
            txtBookTitle.Location = new Point(98, 60);
            txtBookTitle.Name = "txtBookTitle";
            txtBookTitle.ReadOnly = true;
            txtBookTitle.Size = new Size(151, 23);
            txtBookTitle.TabIndex = 43;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(21, 63);
            label8.Name = "label8";
            label8.Size = new Size(59, 15);
            label8.TabIndex = 44;
            label8.Text = "Book Title";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(15, 472);
            label13.Name = "label13";
            label13.Size = new Size(38, 15);
            label13.TabIndex = 57;
            label13.Text = "Genre";
            // 
            // cbbGenre
            // 
            cbbGenre.FormattingEnabled = true;
            cbbGenre.Location = new Point(96, 469);
            cbbGenre.Name = "cbbGenre";
            cbbGenre.Size = new Size(178, 23);
            cbbGenre.TabIndex = 56;
            cbbGenre.SelectedIndexChanged += cbbGenre_SelectedIndexChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(622, 467);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(77, 25);
            btnSearch.TabIndex = 55;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(422, 469);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(178, 23);
            txtSearch.TabIndex = 54;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(346, 473);
            label14.Name = "label14";
            label14.Size = new Size(59, 15);
            label14.TabIndex = 53;
            label14.Text = "Book Title";
            // 
            // ReservationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 662);
            Controls.Add(label13);
            Controls.Add(cbbGenre);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(label14);
            Controls.Add(groupBox1);
            Controls.Add(btnCheck);
            Controls.Add(label5);
            Controls.Add(txtRefCode);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "ReservationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReservationForm";
            Load += ReservationForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPlaceHold;
        private Panel panel1;
        private Panel panel2;
        private DateTimePicker dtpReservationDate;
        private Label label4;
        private Label label1;
        private TextBox txtISBN;
        private ComboBox cbbBookTitle;
        private ComboBox cbbUsername;
        private Label label3;
        private Label label2;
        private Label label7;
        private TextBox txtPrice;
        private DataGridView dgv;
        private Label label5;
        private TextBox txtRefCode;
        private Button btnCheck;
        private Label label6;
        private TextBox txtUsername;
        private GroupBox groupBox1;
        private DateTimePicker dtpReservationDate1;
        private Label label11;
        private TextBox txtStatus;
        private Label label10;
        private TextBox txtISBN1;
        private Label label9;
        private TextBox txtBookTitle;
        private Label label8;
        private Label label13;
        private ComboBox cbbGenre;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label label14;
        private Label label15;
        private TextBox txtStatus1;
    }
}
namespace LibraryManagementSystem
{
    partial class LoanForm
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
            label7 = new Label();
            txtPrice = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            button7 = new Button();
            label1 = new Label();
            txtISBN = new TextBox();
            cbbBookTitle = new ComboBox();
            cbbUsername = new ComboBox();
            dtpReturnDate = new DateTimePicker();
            dtpLoanDate = new DateTimePicker();
            panel1 = new Panel();
            dgv = new DataGridView();
            groupBox1 = new GroupBox();
            dtpReservationDate1 = new DateTimePicker();
            label11 = new Label();
            txtStatus = new TextBox();
            label10 = new Label();
            txtISBN1 = new TextBox();
            label9 = new Label();
            txtBookTitle = new TextBox();
            label8 = new Label();
            txtUsername = new TextBox();
            label6 = new Label();
            btnCheck = new Button();
            label12 = new Label();
            txtRefCode = new TextBox();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(11, 323);
            label7.Name = "label7";
            label7.Size = new Size(33, 15);
            label7.TabIndex = 18;
            label7.Text = "Price";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(88, 320);
            txtPrice.Name = "txtPrice";
            txtPrice.ReadOnly = true;
            txtPrice.Size = new Size(184, 23);
            txtPrice.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 226);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 14;
            label5.Text = "Return Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 151);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 12;
            label4.Text = "Loan Date";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 58);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 10;
            label3.Text = "Book Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 14);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 8;
            label2.Text = "Username";
            // 
            // panel2
            // 
            panel2.Controls.Add(button7);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtISBN);
            panel2.Controls.Add(cbbBookTitle);
            panel2.Controls.Add(cbbUsername);
            panel2.Controls.Add(dtpReturnDate);
            panel2.Controls.Add(dtpLoanDate);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtPrice);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(487, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(301, 426);
            panel2.TabIndex = 4;
            // 
            // button7
            // 
            button7.Location = new Point(108, 373);
            button7.Name = "button7";
            button7.Size = new Size(89, 39);
            button7.TabIndex = 7;
            button7.Text = "Borrow book";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 103);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 29;
            label1.Text = "ISBN";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(89, 100);
            txtISBN.Name = "txtISBN";
            txtISBN.ReadOnly = true;
            txtISBN.Size = new Size(184, 23);
            txtISBN.TabIndex = 3;
            // 
            // cbbBookTitle
            // 
            cbbBookTitle.FormattingEnabled = true;
            cbbBookTitle.Location = new Point(89, 55);
            cbbBookTitle.Name = "cbbBookTitle";
            cbbBookTitle.Size = new Size(183, 23);
            cbbBookTitle.TabIndex = 2;
            cbbBookTitle.SelectedIndexChanged += cbbBookTitle_SelectedIndexChanged;
            // 
            // cbbUsername
            // 
            cbbUsername.FormattingEnabled = true;
            cbbUsername.Location = new Point(89, 11);
            cbbUsername.Name = "cbbUsername";
            cbbUsername.Size = new Size(183, 23);
            cbbUsername.TabIndex = 1;
            // 
            // dtpReturnDate
            // 
            dtpReturnDate.Location = new Point(12, 253);
            dtpReturnDate.Name = "dtpReturnDate";
            dtpReturnDate.Size = new Size(260, 23);
            dtpReturnDate.TabIndex = 5;
            // 
            // dtpLoanDate
            // 
            dtpLoanDate.Location = new Point(12, 178);
            dtpLoanDate.Name = "dtpLoanDate";
            dtpLoanDate.Size = new Size(261, 23);
            dtpLoanDate.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgv);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(469, 426);
            panel1.TabIndex = 3;
            // 
            // dgv
            // 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new Point(3, 3);
            dgv.Name = "dgv";
            dgv.Size = new Size(463, 420);
            dgv.TabIndex = 0;
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
            groupBox1.Location = new Point(15, 505);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(773, 100);
            groupBox1.TabIndex = 47;
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
            // txtUsername
            // 
            txtUsername.Location = new Point(98, 22);
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new Size(151, 23);
            txtUsername.TabIndex = 41;
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
            // btnCheck
            // 
            btnCheck.Location = new Point(303, 476);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(77, 26);
            btnCheck.TabIndex = 45;
            btnCheck.Text = "Check";
            btnCheck.UseVisualStyleBackColor = true;
            btnCheck.Click += btnCheck_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(15, 479);
            label12.Name = "label12";
            label12.Size = new Size(60, 15);
            label12.TabIndex = 46;
            label12.Text = "REF CODE";
            // 
            // txtRefCode
            // 
            txtRefCode.Location = new Point(96, 476);
            txtRefCode.Name = "txtRefCode";
            txtRefCode.Size = new Size(184, 23);
            txtRefCode.TabIndex = 44;
            // 
            // LoanForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(815, 635);
            Controls.Add(groupBox1);
            Controls.Add(btnCheck);
            Controls.Add(label12);
            Controls.Add(txtRefCode);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "LoanForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoanForm";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label7;
        private TextBox txtPrice;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Panel panel2;
        private Panel panel1;
        private DateTimePicker dtpReturnDate;
        private DateTimePicker dtpLoanDate;
        private ComboBox cbbBookTitle;
        private ComboBox cbbUsername;
        private Label label1;
        private TextBox txtISBN;
        private Button button7;
        private DataGridView dgv;
        private GroupBox groupBox1;
        private DateTimePicker dtpReservationDate1;
        private Label label11;
        private TextBox txtStatus;
        private Label label10;
        private TextBox txtISBN1;
        private Label label9;
        private TextBox txtBookTitle;
        private Label label8;
        private TextBox txtUsername;
        private Label label6;
        private Button btnCheck;
        private Label label12;
        private TextBox txtRefCode;
    }
}
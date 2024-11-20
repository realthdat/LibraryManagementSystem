namespace LibraryManagementSystem
{
    partial class BorrowRequest
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
            panel1 = new Panel();
            dgv = new DataGridView();
            panel2 = new Panel();
            label9 = new Label();
            txtUsername = new TextBox();
            buttonRequest = new Button();
            txtStatus = new TextBox();
            label2 = new Label();
            txtISBN = new TextBox();
            cbbBookTitle = new ComboBox();
            dtpReturnDate = new DateTimePicker();
            dtpLoanDate = new DateTimePicker();
            label7 = new Label();
            txtPrice = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label6 = new Label();
            groupBox1 = new GroupBox();
            label8 = new Label();
            cbbGenre = new ComboBox();
            btnSearch = new Button();
            txtBookTitle = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dgv);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(469, 426);
            panel1.TabIndex = 4;
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
            panel2.Controls.Add(label9);
            panel2.Controls.Add(txtUsername);
            panel2.Controls.Add(buttonRequest);
            panel2.Controls.Add(txtStatus);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtISBN);
            panel2.Controls.Add(cbbBookTitle);
            panel2.Controls.Add(dtpReturnDate);
            panel2.Controls.Add(dtpLoanDate);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtPrice);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(487, 15);
            panel2.Name = "panel2";
            panel2.Size = new Size(301, 426);
            panel2.TabIndex = 6;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(11, 292);
            label9.Name = "label9";
            label9.Size = new Size(39, 15);
            label9.TabIndex = 31;
            label9.Text = "Status";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(89, 11);
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new Size(184, 23);
            txtUsername.TabIndex = 1;
            // 
            // buttonRequest
            // 
            buttonRequest.Location = new Point(108, 373);
            buttonRequest.Name = "buttonRequest";
            buttonRequest.Size = new Size(103, 39);
            buttonRequest.TabIndex = 6;
            buttonRequest.Text = "Request Borrow ";
            buttonRequest.UseVisualStyleBackColor = true;
            buttonRequest.Click += buttonRequest_Click;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(88, 289);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(184, 23);
            txtStatus.TabIndex = 30;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 103);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 29;
            label2.Text = "ISBN";
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
            cbbBookTitle.SelectedIndexChanged += cbbBookTitle_SelectedIndexChanged_1;
            // 
            // dtpReturnDate
            // 
            dtpReturnDate.Location = new Point(12, 243);
            dtpReturnDate.Name = "dtpReturnDate";
            dtpReturnDate.Size = new Size(260, 23);
            dtpReturnDate.TabIndex = 5;
            // 
            // dtpLoanDate
            // 
            dtpLoanDate.Location = new Point(12, 170);
            dtpLoanDate.Name = "dtpLoanDate";
            dtpLoanDate.Size = new Size(261, 23);
            dtpLoanDate.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(11, 336);
            label7.Name = "label7";
            label7.Size = new Size(33, 15);
            label7.TabIndex = 18;
            label7.Text = "Price";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(88, 333);
            txtPrice.Name = "txtPrice";
            txtPrice.ReadOnly = true;
            txtPrice.Size = new Size(184, 23);
            txtPrice.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 216);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 14;
            label5.Text = "Return Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 143);
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
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 14);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 8;
            label6.Text = "Username";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(cbbGenre);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtBookTitle);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(15, 463);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(773, 95);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filter/ Search book";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(24, 47);
            label8.Name = "label8";
            label8.Size = new Size(38, 15);
            label8.TabIndex = 4;
            label8.Text = "Genre";
            // 
            // cbbGenre
            // 
            cbbGenre.FormattingEnabled = true;
            cbbGenre.Location = new Point(100, 43);
            cbbGenre.Name = "cbbGenre";
            cbbGenre.Size = new Size(178, 23);
            cbbGenre.TabIndex = 3;
            cbbGenre.SelectedIndexChanged += cbbGenre_SelectedIndexChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(623, 41);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(77, 25);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtBookTitle
            // 
            txtBookTitle.Location = new Point(423, 43);
            txtBookTitle.Name = "txtBookTitle";
            txtBookTitle.Size = new Size(178, 23);
            txtBookTitle.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(347, 47);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "Book Title";
            // 
            // BorrowRequest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 577);
            Controls.Add(groupBox1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "BorrowRequest";
            Text = "BorrowRequest";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgv;
        private Panel panel2;
        private TextBox txtUsername;
        private Button buttonRequest;
        private Label label2;
        private TextBox txtISBN;
        private ComboBox cbbBookTitle;
        private DateTimePicker dtpReturnDate;
        private DateTimePicker dtpLoanDate;
        private Label label7;
        private TextBox txtPrice;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label6;
        private GroupBox groupBox1;
        private ComboBox cbbGenre;
        private Button btnSearch;
        private TextBox txtBookTitle;
        private Label label1;
        private Label label9;
        private Label label8;
        private TextBox txtStatus;
    }
}
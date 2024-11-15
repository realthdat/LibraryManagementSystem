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
            txtUsername = new TextBox();
            buttonRequest = new Button();
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
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            panel2.SuspendLayout();
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
            // 
            // panel2
            // 
            panel2.Controls.Add(txtUsername);
            panel2.Controls.Add(buttonRequest);
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
            txtPrice.TabIndex = 10;
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
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 14);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 8;
            label6.Text = "Username";
            // 
            // BorrowRequest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "BorrowRequest";
            Text = "BorrowRequest";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
    }
}
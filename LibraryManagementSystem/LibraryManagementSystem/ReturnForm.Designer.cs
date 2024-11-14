namespace LibraryManagementSystem
{
    partial class ReturnForm
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
            txtBookTitle = new TextBox();
            btnCheck = new Button();
            label5 = new Label();
            txtRefCode = new TextBox();
            label1 = new Label();
            btnReturnBook = new Button();
            dtpActualReturnDate = new DateTimePicker();
            txtISBN = new TextBox();
            label7 = new Label();
            txtOverdueFee = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
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
            panel1.TabIndex = 6;
            // 
            // dgv
            // 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new Point(4, 5);
            dgv.Name = "dgv";
            dgv.Size = new Size(463, 420);
            dgv.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtBookTitle);
            panel2.Controls.Add(btnCheck);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtRefCode);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnReturnBook);
            panel2.Controls.Add(dtpActualReturnDate);
            panel2.Controls.Add(txtISBN);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtOverdueFee);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtUsername);
            panel2.Location = new Point(487, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(301, 426);
            panel2.TabIndex = 7;
            // 
            // txtBookTitle
            // 
            txtBookTitle.Location = new Point(88, 143);
            txtBookTitle.Name = "txtBookTitle";
            txtBookTitle.Size = new Size(184, 23);
            txtBookTitle.TabIndex = 4;
            // 
            // btnCheck
            // 
            btnCheck.Location = new Point(88, 53);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(75, 23);
            btnCheck.TabIndex = 2;
            btnCheck.Text = "Check";
            btnCheck.UseVisualStyleBackColor = true;
            btnCheck.Click += btnCheck_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 146);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 29;
            label5.Text = "Book Title";
            // 
            // txtRefCode
            // 
            txtRefCode.Location = new Point(88, 21);
            txtRefCode.Name = "txtRefCode";
            txtRefCode.Size = new Size(184, 23);
            txtRefCode.TabIndex = 1;
            txtRefCode.TextChanged += txtRefCode_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 24);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 27;
            label1.Text = "REF CODE";
            // 
            // btnReturnBook
            // 
            btnReturnBook.Location = new Point(113, 374);
            btnReturnBook.Name = "btnReturnBook";
            btnReturnBook.Size = new Size(89, 39);
            btnReturnBook.TabIndex = 7;
            btnReturnBook.Text = "Return book";
            btnReturnBook.UseVisualStyleBackColor = true;
            btnReturnBook.Click += btnReturnBook_Click;
            // 
            // dtpActualReturnDate
            // 
            dtpActualReturnDate.Location = new Point(13, 261);
            dtpActualReturnDate.Name = "dtpActualReturnDate";
            dtpActualReturnDate.Size = new Size(259, 23);
            dtpActualReturnDate.TabIndex = 6;
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(88, 185);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(184, 23);
            txtISBN.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(11, 311);
            label7.Name = "label7";
            label7.Size = new Size(73, 15);
            label7.TabIndex = 18;
            label7.Text = "Overdue Fee";
            // 
            // txtOverdueFee
            // 
            txtOverdueFee.Location = new Point(88, 308);
            txtOverdueFee.Name = "txtOverdueFee";
            txtOverdueFee.ReadOnly = true;
            txtOverdueFee.Size = new Size(184, 23);
            txtOverdueFee.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 231);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 12;
            label4.Text = "Actual Return Date";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 188);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 10;
            label3.Text = "ISBN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 101);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 8;
            label2.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(88, 98);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(184, 23);
            txtUsername.TabIndex = 3;
            // 
            // ReturnForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 453);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "ReturnForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReturnForm";
            Load += ReturnForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private DateTimePicker dtpActualReturnDate;
        private TextBox txtISBN;
        private Label label7;
        private TextBox txtOverdueFee;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtUsername;
        private Button btnReturnBook;
        private Button btnCheck;
        private DataGridView dgv;
        private TextBox txtRefCode;
        private Label label1;
        private TextBox txtBookTitle;
        private Label label5;
    }
}
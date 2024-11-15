namespace LibraryManagementSystem
{
    partial class ManageLoan
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
            btnDelete = new Button();
            btnSave = new Button();
            btnAdd = new Button();
            btnExport = new Button();
            btnCancel = new Button();
            groupBox1 = new GroupBox();
            btnEdit = new Button();
            panel2 = new Panel();
            label6 = new Label();
            txtRefCode = new TextBox();
            label8 = new Label();
            txtFine = new TextBox();
            dtpActualReturnDate = new DateTimePicker();
            label3 = new Label();
            dtpReturnDate = new DateTimePicker();
            cbbBook = new ComboBox();
            dtpLoanDate = new DateTimePicker();
            label5 = new Label();
            label2 = new Label();
            label4 = new Label();
            cbbUser = new ComboBox();
            label1 = new Label();
            dgvLoan = new DataGridView();
            panel1 = new Panel();
            cbbStatus = new ComboBox();
            label7 = new Label();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoan).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(375, 22);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(89, 39);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(262, 22);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(89, 39);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(36, 22);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(89, 39);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(601, 22);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(89, 39);
            btnExport.TabIndex = 13;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(488, 22);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(89, 39);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnExport);
            groupBox1.Controls.Add(btnCancel);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(btnEdit);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Location = new Point(12, 502);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 67);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Function";
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(149, 22);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(89, 39);
            btnEdit.TabIndex = 9;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(cbbStatus);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(txtRefCode);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtFine);
            panel2.Controls.Add(dtpActualReturnDate);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(dtpReturnDate);
            panel2.Controls.Add(cbbBook);
            panel2.Controls.Add(dtpLoanDate);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(cbbUser);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(487, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(301, 484);
            panel2.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 452);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 35;
            label6.Text = "REF Code";
            // 
            // txtRefCode
            // 
            txtRefCode.Location = new Point(89, 449);
            txtRefCode.Name = "txtRefCode";
            txtRefCode.Size = new Size(184, 23);
            txtRefCode.TabIndex = 7;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 409);
            label8.Name = "label8";
            label8.Size = new Size(29, 15);
            label8.TabIndex = 33;
            label8.Text = "Fine";
            // 
            // txtFine
            // 
            txtFine.Location = new Point(89, 406);
            txtFine.Name = "txtFine";
            txtFine.Size = new Size(184, 23);
            txtFine.TabIndex = 6;
            // 
            // dtpActualReturnDate
            // 
            dtpActualReturnDate.Location = new Point(14, 286);
            dtpActualReturnDate.Name = "dtpActualReturnDate";
            dtpActualReturnDate.Size = new Size(260, 23);
            dtpActualReturnDate.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 259);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 30;
            label3.Text = "Actual Return Date";
            // 
            // dtpReturnDate
            // 
            dtpReturnDate.Location = new Point(13, 212);
            dtpReturnDate.Name = "dtpReturnDate";
            dtpReturnDate.Size = new Size(260, 23);
            dtpReturnDate.TabIndex = 4;
            // 
            // cbbBook
            // 
            cbbBook.FormattingEnabled = true;
            cbbBook.Location = new Point(96, 57);
            cbbBook.Name = "cbbBook";
            cbbBook.Size = new Size(184, 23);
            cbbBook.TabIndex = 2;
            // 
            // dtpLoanDate
            // 
            dtpLoanDate.Location = new Point(13, 137);
            dtpLoanDate.Name = "dtpLoanDate";
            dtpLoanDate.Size = new Size(261, 23);
            dtpLoanDate.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 185);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 27;
            label5.Text = "Return Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 60);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 25;
            label2.Text = "Book";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 110);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 26;
            label4.Text = "Loan Date";
            // 
            // cbbUser
            // 
            cbbUser.FormattingEnabled = true;
            cbbUser.Location = new Point(96, 17);
            cbbUser.Name = "cbbUser";
            cbbUser.Size = new Size(184, 23);
            cbbUser.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 20);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 20;
            label1.Text = "User";
            // 
            // dgvLoan
            // 
            dgvLoan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLoan.Location = new Point(12, 6);
            dgvLoan.Name = "dgvLoan";
            dgvLoan.Size = new Size(446, 466);
            dgvLoan.TabIndex = 0;
            dgvLoan.CellContentClick += dgvLoan_CellContentClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvLoan);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(469, 484);
            panel1.TabIndex = 3;
            // 
            // cbbStatus
            // 
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Location = new Point(89, 351);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(184, 23);
            cbbStatus.TabIndex = 36;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 354);
            label7.Name = "label7";
            label7.Size = new Size(39, 15);
            label7.TabIndex = 37;
            label7.Text = "Status";
            // 
            // ManageLoan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(811, 581);
            Controls.Add(groupBox1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ManageLoan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ManageLoan";
            groupBox1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoan).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnDelete;
        private Button btnSave;
        private Button btnAdd;
        private Button btnExport;
        private Button btnCancel;
        private GroupBox groupBox1;
        private Button btnEdit;
        private Panel panel2;
        private ComboBox cbbBook;
        private Label label2;
        private ComboBox cbbUser;
        private Label label1;
        private DataGridView dgvLoan;
        private Panel panel1;
        private DateTimePicker dtpActualReturnDate;
        private Label label3;
        private DateTimePicker dtpReturnDate;
        private DateTimePicker dtpLoanDate;
        private Label label5;
        private Label label4;
        private Label label6;
        private TextBox txtRefCode;
        private Label label8;
        private TextBox txtFine;
        private ComboBox cbbStatus;
        private Label label7;
    }
}
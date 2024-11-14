namespace LibraryManagementSystem
{
    partial class ManageReservation
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
            dgvReservation = new DataGridView();
            label6 = new Label();
            txtRefCode = new TextBox();
            panel2 = new Panel();
            cbbStatus = new ComboBox();
            label3 = new Label();
            dtpReservationDate = new DateTimePicker();
            label4 = new Label();
            cbbBook = new ComboBox();
            label2 = new Label();
            cbbUser = new ComboBox();
            label1 = new Label();
            btnDelete = new Button();
            btnEdit = new Button();
            btnExport = new Button();
            btnCancel = new Button();
            btnAdd = new Button();
            btnSave = new Button();
            groupBox1 = new GroupBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservation).BeginInit();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvReservation);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(469, 426);
            panel1.TabIndex = 6;
            // 
            // dgvReservation
            // 
            dgvReservation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservation.Location = new Point(12, 6);
            dgvReservation.Name = "dgvReservation";
            dgvReservation.Size = new Size(446, 406);
            dgvReservation.TabIndex = 0;
            dgvReservation.CellContentClick += dgvReservation_CellContentClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 259);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 35;
            label6.Text = "REF Code";
            // 
            // txtRefCode
            // 
            txtRefCode.Location = new Point(94, 256);
            txtRefCode.Name = "txtRefCode";
            txtRefCode.Size = new Size(184, 23);
            txtRefCode.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Controls.Add(cbbStatus);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(dtpReservationDate);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(txtRefCode);
            panel2.Controls.Add(cbbBook);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(cbbUser);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(487, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(301, 426);
            panel2.TabIndex = 7;
            // 
            // cbbStatus
            // 
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Location = new Point(94, 205);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(184, 23);
            cbbStatus.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 208);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 36;
            label3.Text = "Status";
            // 
            // dtpReservationDate
            // 
            dtpReservationDate.Location = new Point(19, 152);
            dtpReservationDate.Name = "dtpReservationDate";
            dtpReservationDate.Size = new Size(259, 23);
            dtpReservationDate.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 119);
            label4.Name = "label4";
            label4.Size = new Size(95, 15);
            label4.TabIndex = 25;
            label4.Text = "Reservation Date";
            // 
            // cbbBook
            // 
            cbbBook.FormattingEnabled = true;
            cbbBook.Location = new Point(96, 57);
            cbbBook.Name = "cbbBook";
            cbbBook.Size = new Size(184, 23);
            cbbBook.TabIndex = 2;
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
            // btnDelete
            // 
            btnDelete.Location = new Point(375, 22);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(89, 39);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(149, 22);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(89, 39);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(601, 22);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(89, 39);
            btnExport.TabIndex = 11;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(488, 22);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(89, 39);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(36, 22);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(89, 39);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(262, 22);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(89, 39);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnExport);
            groupBox1.Controls.Add(btnCancel);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(btnEdit);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Location = new Point(12, 447);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 67);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Function";
            // 
            // ManageReservation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 526);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(groupBox1);
            Name = "ManageReservation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ManageReservation";
            Load += ManageReservation_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReservation).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvReservation;
        private Label label6;
        private TextBox txtRefCode;
        private Panel panel2;
        private ComboBox cbbBook;
        private Label label2;
        private ComboBox cbbUser;
        private Label label1;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnExport;
        private Button btnCancel;
        private Button btnAdd;
        private Button btnSave;
        private GroupBox groupBox1;
        private DateTimePicker dtpReservationDate;
        private Label label4;
        private ComboBox cbbStatus;
        private Label label3;
    }
}
namespace LibraryManagementSystem
{
    partial class BookManagementForm
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
            dgvBooks = new DataGridView();
            panel2 = new Panel();
            cbbStatus = new ComboBox();
            txtPublicationYear = new TextBox();
            label8 = new Label();
            txtTotalCopies = new TextBox();
            cbbGenre = new ComboBox();
            label7 = new Label();
            txtLocation = new TextBox();
            label6 = new Label();
            label5 = new Label();
            txtISBN = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtAuthor = new TextBox();
            label1 = new Label();
            txtTitle = new TextBox();
            groupBox1 = new GroupBox();
            btnExport = new Button();
            btnCancel = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvBooks);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(469, 426);
            panel1.TabIndex = 0;
            // 
            // dgvBooks
            // 
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(12, 6);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.Size = new Size(446, 406);
            dgvBooks.TabIndex = 0;
            dgvBooks.CellContentClick += dgvBooks_CellContentClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(cbbStatus);
            panel2.Controls.Add(txtPublicationYear);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtTotalCopies);
            panel2.Controls.Add(cbbGenre);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtLocation);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtISBN);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtAuthor);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtTitle);
            panel2.Location = new Point(487, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(301, 426);
            panel2.TabIndex = 1;
            // 
            // cbbStatus
            // 
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Location = new Point(96, 248);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(184, 23);
            cbbStatus.TabIndex = 6;
            // 
            // txtPublicationYear
            // 
            txtPublicationYear.Location = new Point(141, 116);
            txtPublicationYear.Name = "txtPublicationYear";
            txtPublicationYear.Size = new Size(139, 23);
            txtPublicationYear.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(19, 339);
            label8.Name = "label8";
            label8.Size = new Size(69, 15);
            label8.TabIndex = 22;
            label8.Text = "Total copies";
            // 
            // txtTotalCopies
            // 
            txtTotalCopies.Location = new Point(96, 336);
            txtTotalCopies.Name = "txtTotalCopies";
            txtTotalCopies.Size = new Size(184, 23);
            txtTotalCopies.TabIndex = 8;
            // 
            // cbbGenre
            // 
            cbbGenre.FormattingEnabled = true;
            cbbGenre.Location = new Point(96, 160);
            cbbGenre.Name = "cbbGenre";
            cbbGenre.Size = new Size(184, 23);
            cbbGenre.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 295);
            label7.Name = "label7";
            label7.Size = new Size(53, 15);
            label7.TabIndex = 18;
            label7.Text = "Location";
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(96, 292);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(184, 23);
            txtLocation.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 251);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 16;
            label6.Text = "Status";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 207);
            label5.Name = "label5";
            label5.Size = new Size(32, 15);
            label5.TabIndex = 14;
            label5.Text = "ISBN";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(96, 204);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(184, 23);
            txtISBN.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 163);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 12;
            label4.Text = "Genre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 119);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 10;
            label3.Text = "Publication Year";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 75);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 8;
            label2.Text = "Author";
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(96, 72);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(184, 23);
            txtAuthor.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 31);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 6;
            label1.Text = "Title";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(96, 28);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(184, 23);
            txtTitle.TabIndex = 1;
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
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Function";
            // 
            // btnExport
            // 
            btnExport.Location = new Point(601, 22);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(89, 39);
            btnExport.TabIndex = 14;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(488, 22);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(89, 39);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(375, 22);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(89, 39);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(262, 22);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(89, 39);
            btnSave.TabIndex = 11;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(149, 22);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(89, 39);
            btnEdit.TabIndex = 10;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(36, 22);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(89, 39);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // BookManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 538);
            Controls.Add(groupBox1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "BookManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BookManagementForm";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvBooks;
        private Panel panel2;
        private ComboBox cbbGenre;
        private Label label7;
        private TextBox txtLocation;
        private Label label6;
        private Label label5;
        private TextBox txtISBN;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtAuthor;
        private Label label1;
        private TextBox txtTitle;
        private Label label8;
        private TextBox txtTotalCopies;
        private GroupBox groupBox1;
        private Button btnExport;
        private Button btnCancel;
        private Button btnDelete;
        private Button btnSave;
        private Button btnEdit;
        private Button btnAdd;
        private ComboBox cbbStatus;
        private TextBox txtPublicationYear;
    }
}
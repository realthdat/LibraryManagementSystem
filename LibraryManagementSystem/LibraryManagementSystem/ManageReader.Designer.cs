namespace LibraryManagementSystem
{
    partial class ManageReader
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
            dgvUsers = new DataGridView();
            panel2 = new Panel();
            cbbStatus = new ComboBox();
            txtUsername = new TextBox();
            txtFullName = new TextBox();
            label1 = new Label();
            label8 = new Label();
            txtPassword = new TextBox();
            txtAddress = new TextBox();
            label2 = new Label();
            cbbRole = new ComboBox();
            label3 = new Label();
            label7 = new Label();
            label4 = new Label();
            txtPhoneNo = new TextBox();
            txtEmail = new TextBox();
            label6 = new Label();
            label5 = new Label();
            groupBox1 = new GroupBox();
            btnExport = new Button();
            btnCancel = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvUsers);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(469, 426);
            panel1.TabIndex = 6;
            // 
            // dgvUsers
            // 
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(12, 6);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.Size = new Size(446, 406);
            dgvUsers.TabIndex = 0;
            dgvUsers.CellContentClick += dgvUsers_CellContentClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(cbbStatus);
            panel2.Controls.Add(txtUsername);
            panel2.Controls.Add(txtFullName);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtPassword);
            panel2.Controls.Add(txtAddress);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(cbbRole);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtPhoneNo);
            panel2.Controls.Add(txtEmail);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(487, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(301, 426);
            panel2.TabIndex = 7;
            // 
            // cbbStatus
            // 
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Location = new Point(95, 338);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(184, 23);
            cbbStatus.TabIndex = 8;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(95, 18);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(184, 23);
            txtUsername.TabIndex = 1;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(95, 106);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(184, 23);
            txtFullName.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 21);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 29;
            label1.Text = "Username";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 290);
            label8.Name = "label8";
            label8.Size = new Size(49, 15);
            label8.TabIndex = 38;
            label8.Text = "Address";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(95, 62);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(184, 23);
            txtPassword.TabIndex = 2;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(95, 287);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(184, 23);
            txtAddress.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 65);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 32;
            label2.Text = "Password";
            // 
            // cbbRole
            // 
            cbbRole.FormattingEnabled = true;
            cbbRole.Location = new Point(95, 150);
            cbbRole.Name = "cbbRole";
            cbbRole.Size = new Size(184, 23);
            cbbRole.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 109);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 33;
            label3.Text = "Full Name";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 242);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 37;
            label7.Text = "Phone No";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 153);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 34;
            label4.Text = "Role";
            // 
            // txtPhoneNo
            // 
            txtPhoneNo.Location = new Point(95, 239);
            txtPhoneNo.Name = "txtPhoneNo";
            txtPhoneNo.Size = new Size(184, 23);
            txtPhoneNo.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(95, 194);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(184, 23);
            txtEmail.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 341);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 36;
            label6.Text = "Status";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 197);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 35;
            label5.Text = "Email";
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
            // ManageReader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(811, 527);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(groupBox1);
            Name = "ManageReader";
            Text = "ManageReader";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvUsers;
        private Panel panel2;
        private GroupBox groupBox1;
        private Button btnExport;
        private Button btnCancel;
        private Button btnDelete;
        private Button btnSave;
        private Button btnEdit;
        private Button btnAdd;
        private ComboBox cbbStatus;
        private TextBox txtUsername;
        private TextBox txtFullName;
        private Label label1;
        private Label label8;
        private TextBox txtPassword;
        private TextBox txtAddress;
        private Label label2;
        private ComboBox cbbRole;
        private Label label3;
        private Label label7;
        private Label label4;
        private TextBox txtPhoneNo;
        private TextBox txtEmail;
        private Label label6;
        private Label label5;
    }
}
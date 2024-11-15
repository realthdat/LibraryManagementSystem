namespace LibraryManagementSystem
{
    partial class UserForm
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
            panel = new Panel();
            lblWelcomeBack = new Label();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            btnManageReservation = new Button();
            btnManageLoan = new Button();
            btnLogout = new Button();
            btnReservation = new Button();
            btnReturn = new Button();
            btnBorrow = new Button();
            btnEditProfile = new Button();
            pictureBox1 = new PictureBox();
            btnManageReader = new Button();
            panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Controls.Add(lblWelcomeBack);
            panel.Controls.Add(pictureBox2);
            panel.Location = new Point(293, 8);
            panel.Name = "panel";
            panel.Size = new Size(802, 640);
            panel.TabIndex = 3;
            // 
            // lblWelcomeBack
            // 
            lblWelcomeBack.AutoSize = true;
            lblWelcomeBack.Font = new Font("Segoe UI", 15F);
            lblWelcomeBack.Location = new Point(25, 78);
            lblWelcomeBack.Name = "lblWelcomeBack";
            lblWelcomeBack.Size = new Size(139, 28);
            lblWelcomeBack.TabIndex = 3;
            lblWelcomeBack.Text = "Welcome back";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.library_reading;
            pictureBox2.Location = new Point(25, 139);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(752, 423);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnManageReader);
            panel1.Controls.Add(btnManageReservation);
            panel1.Controls.Add(btnManageLoan);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(btnReservation);
            panel1.Controls.Add(btnReturn);
            panel1.Controls.Add(btnBorrow);
            panel1.Controls.Add(btnEditProfile);
            panel1.Location = new Point(12, 147);
            panel1.Name = "panel1";
            panel1.Size = new Size(275, 559);
            panel1.TabIndex = 2;
            // 
            // btnManageReservation
            // 
            btnManageReservation.Location = new Point(7, 417);
            btnManageReservation.Name = "btnManageReservation";
            btnManageReservation.Size = new Size(265, 63);
            btnManageReservation.TabIndex = 7;
            btnManageReservation.Text = "Manage Reservation";
            btnManageReservation.UseVisualStyleBackColor = true;
            btnManageReservation.Click += btnManageReservation_Click;
            // 
            // btnManageLoan
            // 
            btnManageLoan.Location = new Point(7, 348);
            btnManageLoan.Name = "btnManageLoan";
            btnManageLoan.Size = new Size(265, 63);
            btnManageLoan.TabIndex = 6;
            btnManageLoan.Text = "Manage Loan";
            btnManageLoan.UseVisualStyleBackColor = true;
            btnManageLoan.Click += btnManageLoan_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(7, 486);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(265, 63);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnReservation
            // 
            btnReservation.Location = new Point(7, 141);
            btnReservation.Name = "btnReservation";
            btnReservation.Size = new Size(265, 63);
            btnReservation.TabIndex = 3;
            btnReservation.Text = "Reservation";
            btnReservation.UseVisualStyleBackColor = true;
            btnReservation.Click += btnReservation_Click;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(7, 210);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(265, 63);
            btnReturn.TabIndex = 4;
            btnReturn.Text = "Return Book";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnBorrow
            // 
            btnBorrow.Location = new Point(7, 72);
            btnBorrow.Name = "btnBorrow";
            btnBorrow.Size = new Size(265, 63);
            btnBorrow.TabIndex = 2;
            btnBorrow.Text = "Borrow book";
            btnBorrow.UseVisualStyleBackColor = true;
            btnBorrow.Click += btnBorrow_Click;
            // 
            // btnEditProfile
            // 
            btnEditProfile.Location = new Point(7, 3);
            btnEditProfile.Name = "btnEditProfile";
            btnEditProfile.Size = new Size(265, 63);
            btnEditProfile.TabIndex = 1;
            btnEditProfile.Text = "Edit Profile";
            btnEditProfile.UseVisualStyleBackColor = true;
            btnEditProfile.Click += btnEditProfile_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.librarian1;
            pictureBox1.Location = new Point(18, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(265, 144);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnManageReader
            // 
            btnManageReader.Location = new Point(7, 279);
            btnManageReader.Name = "btnManageReader";
            btnManageReader.Size = new Size(265, 63);
            btnManageReader.TabIndex = 8;
            btnManageReader.Text = "Manage Reader";
            btnManageReader.UseVisualStyleBackColor = true;
            btnManageReader.Click += btnManageReader_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 702);
            Controls.Add(panel);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UserForm";
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel;
        private Panel panel1;
        private Button btnLogout;
        private Button btnReservation;
        private Button btnReturn;
        private Button btnBorrow;
        private Button btnEditProfile;
        private PictureBox pictureBox1;
        private Label lblWelcomeBack;
        private PictureBox pictureBox2;
        private Button btnManageReservation;
        private Button btnManageLoan;
        private Button btnManageReader;
    }
}
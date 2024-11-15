namespace LibraryManagementSystem
{
    partial class AdminForm
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
            btnLogout = new Button();
            btnManageReport = new Button();
            btnManageReservation = new Button();
            btnManageLoan = new Button();
            btnInventory = new Button();
            btnManageUser = new Button();
            btnDashboard = new Button();
            pictureBox1 = new PictureBox();
            panel = new Panel();
            lblWelcomeBack = new Label();
            pictureBox2 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(btnManageReport);
            panel1.Controls.Add(btnManageReservation);
            panel1.Controls.Add(btnManageLoan);
            panel1.Controls.Add(btnInventory);
            panel1.Controls.Add(btnManageUser);
            panel1.Controls.Add(btnDashboard);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(275, 640);
            panel1.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(6, 571);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(265, 63);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnManageReport
            // 
            btnManageReport.Location = new Point(7, 502);
            btnManageReport.Name = "btnManageReport";
            btnManageReport.Size = new Size(265, 63);
            btnManageReport.TabIndex = 6;
            btnManageReport.Text = "Generate Report";
            btnManageReport.UseVisualStyleBackColor = true;
            btnManageReport.Click += btnManageReport_Click;
            // 
            // btnManageReservation
            // 
            btnManageReservation.Location = new Point(7, 433);
            btnManageReservation.Name = "btnManageReservation";
            btnManageReservation.Size = new Size(265, 63);
            btnManageReservation.TabIndex = 5;
            btnManageReservation.Text = "Manage Reservation";
            btnManageReservation.UseVisualStyleBackColor = true;
            btnManageReservation.Click += btnManageReservation_Click;
            // 
            // btnManageLoan
            // 
            btnManageLoan.Location = new Point(7, 364);
            btnManageLoan.Name = "btnManageLoan";
            btnManageLoan.Size = new Size(265, 63);
            btnManageLoan.TabIndex = 4;
            btnManageLoan.Text = "Manage Loan";
            btnManageLoan.UseVisualStyleBackColor = true;
            btnManageLoan.Click += btnManageLoan_Click;
            // 
            // btnInventory
            // 
            btnInventory.Location = new Point(6, 295);
            btnInventory.Name = "btnInventory";
            btnInventory.Size = new Size(265, 63);
            btnInventory.TabIndex = 3;
            btnInventory.Text = "Manage Book Inventory";
            btnInventory.UseVisualStyleBackColor = true;
            btnInventory.Click += btnInventory_Click_1;
            // 
            // btnManageUser
            // 
            btnManageUser.Location = new Point(7, 226);
            btnManageUser.Name = "btnManageUser";
            btnManageUser.Size = new Size(265, 63);
            btnManageUser.TabIndex = 2;
            btnManageUser.Text = "Manage User";
            btnManageUser.UseVisualStyleBackColor = true;
            btnManageUser.Click += btnManageUser_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Location = new Point(6, 157);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(265, 63);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.admin1;
            pictureBox1.Location = new Point(7, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(265, 144);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel
            // 
            panel.Controls.Add(lblWelcomeBack);
            panel.Controls.Add(pictureBox2);
            panel.Location = new Point(293, 12);
            panel.Name = "panel";
            panel.Size = new Size(828, 640);
            panel.TabIndex = 1;
            // 
            // lblWelcomeBack
            // 
            lblWelcomeBack.AutoSize = true;
            lblWelcomeBack.Font = new Font("Segoe UI", 15F);
            lblWelcomeBack.Location = new Point(38, 78);
            lblWelcomeBack.Name = "lblWelcomeBack";
            lblWelcomeBack.Size = new Size(213, 28);
            lblWelcomeBack.TabIndex = 5;
            lblWelcomeBack.Text = "Welcome back, ADMIN";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.MainGate;
            pictureBox2.Location = new Point(38, 139);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(782, 462);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 664);
            Controls.Add(panel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminForm";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel;
        private Button btnManageReport;
        private Button btnManageReservation;
        private Button btnManageLoan;
        private Button btnInventory;
        private Button btnManageUser;
        private Button btnDashboard;
        private Button btnLogout;
        private Label lblWelcomeBack;
        private PictureBox pictureBox2;
    }
}
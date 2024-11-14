namespace LibraryManagementSystem
{
    partial class ReaderForm
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
            button7 = new Button();
            btnYourReservation = new Button();
            btnYourLoan = new Button();
            btnEditProfile = new Button();
            pictureBox1 = new PictureBox();
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
            panel.Location = new Point(293, 12);
            panel.Name = "panel";
            panel.Size = new Size(802, 640);
            panel.TabIndex = 5;
            // 
            // lblWelcomeBack
            // 
            lblWelcomeBack.AutoSize = true;
            lblWelcomeBack.Font = new Font("Segoe UI", 15F);
            lblWelcomeBack.Location = new Point(22, 96);
            lblWelcomeBack.Name = "lblWelcomeBack";
            lblWelcomeBack.Size = new Size(139, 28);
            lblWelcomeBack.TabIndex = 1;
            lblWelcomeBack.Text = "Welcome back";
            lblWelcomeBack.Click += lblWelcomeBack_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.library_reading;
            pictureBox2.Location = new Point(22, 157);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(752, 423);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(button7);
            panel1.Controls.Add(btnYourReservation);
            panel1.Controls.Add(btnYourLoan);
            panel1.Controls.Add(btnEditProfile);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(275, 640);
            panel1.TabIndex = 4;
            // 
            // button7
            // 
            button7.Location = new Point(6, 571);
            button7.Name = "button7";
            button7.Size = new Size(265, 63);
            button7.TabIndex = 4;
            button7.Text = "Logout";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // btnYourReservation
            // 
            btnYourReservation.Location = new Point(6, 295);
            btnYourReservation.Name = "btnYourReservation";
            btnYourReservation.Size = new Size(265, 63);
            btnYourReservation.TabIndex = 3;
            btnYourReservation.Text = "Your Reservation";
            btnYourReservation.UseVisualStyleBackColor = true;
            btnYourReservation.Click += btnYourReservation_Click;
            // 
            // btnYourLoan
            // 
            btnYourLoan.Location = new Point(7, 226);
            btnYourLoan.Name = "btnYourLoan";
            btnYourLoan.Size = new Size(265, 63);
            btnYourLoan.TabIndex = 2;
            btnYourLoan.Text = "Your Loan";
            btnYourLoan.UseVisualStyleBackColor = true;
            btnYourLoan.Click += btnYourLoan_Click;
            // 
            // btnEditProfile
            // 
            btnEditProfile.Location = new Point(6, 157);
            btnEditProfile.Name = "btnEditProfile";
            btnEditProfile.Size = new Size(265, 63);
            btnEditProfile.TabIndex = 1;
            btnEditProfile.Text = "Edit Profile";
            btnEditProfile.UseVisualStyleBackColor = true;
            btnEditProfile.Click += btnEditProfile_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Readers;
            pictureBox1.Location = new Point(7, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(265, 144);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // ReaderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1106, 659);
            Controls.Add(panel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReaderForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReaderForm";
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
        private Button button7;
        private Button btnYourReservation;
        private Button btnYourLoan;
        private Button btnEditProfile;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label lblWelcomeBack;
    }
}
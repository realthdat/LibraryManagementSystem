namespace LibraryManagementSystem
{
    partial class UserProfileForm
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
            panel2 = new Panel();
            btnSave = new Button();
            label5 = new Label();
            txtReEnterPassword = new TextBox();
            txtFullName = new TextBox();
            label8 = new Label();
            txtPhoneNo = new TextBox();
            label7 = new Label();
            txtAddress = new TextBox();
            txtEmail = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtPassword = new TextBox();
            label1 = new Label();
            txtUsername = new TextBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSave);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtReEnterPassword);
            panel2.Controls.Add(txtFullName);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtPhoneNo);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtAddress);
            panel2.Controls.Add(txtEmail);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtPassword);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtUsername);
            panel2.Location = new Point(414, 42);
            panel2.Name = "panel2";
            panel2.Size = new Size(301, 442);
            panel2.TabIndex = 7;
            panel2.Paint += panel2_Paint;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(102, 392);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(89, 39);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 124);
            label5.Name = "label5";
            label5.Size = new Size(105, 15);
            label5.TabIndex = 26;
            label5.Text = "Re-enter password";
            // 
            // txtReEnterPassword
            // 
            txtReEnterPassword.Location = new Point(21, 146);
            txtReEnterPassword.Name = "txtReEnterPassword";
            txtReEnterPassword.Size = new Size(250, 23);
            txtReEnterPassword.TabIndex = 2;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(87, 187);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(184, 23);
            txtFullName.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(21, 290);
            label8.Name = "label8";
            label8.Size = new Size(60, 15);
            label8.TabIndex = 22;
            label8.Text = "Phone No";
            // 
            // txtPhoneNo
            // 
            txtPhoneNo.Location = new Point(87, 287);
            txtPhoneNo.Name = "txtPhoneNo";
            txtPhoneNo.Size = new Size(184, 23);
            txtPhoneNo.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 340);
            label7.Name = "label7";
            label7.Size = new Size(49, 15);
            label7.TabIndex = 18;
            label7.Text = "Address";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(87, 337);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(184, 23);
            txtAddress.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(87, 237);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(184, 23);
            txtEmail.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 240);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 12;
            label4.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 190);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 10;
            label3.Text = "Full name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 67);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 8;
            label2.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(21, 85);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(250, 23);
            txtPassword.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 31);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 6;
            label1.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(87, 28);
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new Size(184, 23);
            txtUsername.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(37, 39);
            panel1.Name = "panel1";
            panel1.Size = new Size(361, 442);
            panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.library2;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(337, 436);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // UserProfileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(757, 504);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UserProfileForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UserProfileForm";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label label5;
        private TextBox txtReEnterPassword;
        private TextBox txtFullName;
        private Label label8;
        private TextBox txtPhoneNo;
        private Label label7;
        private TextBox txtAddress;
        private TextBox txtEmail;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtPassword;
        private Label label1;
        private TextBox txtUsername;
        private Panel panel1;
        private Button btnSave;
        private PictureBox pictureBox1;
    }
}
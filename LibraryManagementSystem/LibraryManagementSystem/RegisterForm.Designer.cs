namespace LibraryManagementSystem
{
    partial class RegisterForm
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
            pictureBox = new PictureBox();
            panel2 = new Panel();
            chkShowPassword = new CheckBox();
            btnReturn = new Button();
            btnRegister = new Button();
            label4 = new Label();
            txtConfirmPassword = new TextBox();
            txtFullName = new TextBox();
            label8 = new Label();
            txtAddress = new TextBox();
            label7 = new Label();
            txtPhoneNo = new TextBox();
            label5 = new Label();
            txtEmail = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtPassword = new TextBox();
            label1 = new Label();
            txtUsername = new TextBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Image = Properties.Resources._out;
            pictureBox.Location = new Point(869, 0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(37, 34);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 8;
            pictureBox.TabStop = false;
            pictureBox.Click += pictureBox_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(chkShowPassword);
            panel2.Controls.Add(btnReturn);
            panel2.Controls.Add(btnRegister);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtConfirmPassword);
            panel2.Controls.Add(txtFullName);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtAddress);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtPhoneNo);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtEmail);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtPassword);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtUsername);
            panel2.Location = new Point(542, 39);
            panel2.Name = "panel2";
            panel2.Size = new Size(332, 470);
            panel2.TabIndex = 9;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new Point(115, 143);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(108, 19);
            chkShowPassword.TabIndex = 11;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(59, 419);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(211, 38);
            btnReturn.TabIndex = 26;
            btnReturn.Text = "Return Login Form";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(115, 360);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(91, 38);
            btnRegister.TabIndex = 25;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 111);
            label4.Name = "label4";
            label4.Size = new Size(104, 15);
            label4.TabIndex = 24;
            label4.Text = "Confirm Password";
            label4.Click += label4_Click;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(115, 108);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(184, 23);
            txtConfirmPassword.TabIndex = 23;
            txtConfirmPassword.TextChanged += textBox1_TextChanged;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(115, 178);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(184, 23);
            txtFullName.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(37, 319);
            label8.Name = "label8";
            label8.Size = new Size(49, 15);
            label8.TabIndex = 22;
            label8.Text = "Address";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(115, 316);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(184, 23);
            txtAddress.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(31, 271);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 18;
            label7.Text = "Phone No";
            // 
            // txtPhoneNo
            // 
            txtPhoneNo.Location = new Point(115, 268);
            txtPhoneNo.Name = "txtPhoneNo";
            txtPhoneNo.Size = new Size(184, 23);
            txtPhoneNo.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(43, 226);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 14;
            label5.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(115, 223);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(184, 23);
            txtEmail.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 181);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 10;
            label3.Text = "Full Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 72);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 8;
            label2.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(115, 69);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(184, 23);
            txtPassword.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 31);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 6;
            label1.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(115, 28);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(184, 23);
            txtUsername.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(pictureBox2);
            panel1.Location = new Point(16, 39);
            panel1.Name = "panel1";
            panel1.Size = new Size(514, 470);
            panel1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LibraryRule;
            pictureBox1.Location = new Point(174, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(340, 470);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.LMS;
            pictureBox2.Location = new Point(-17, -15);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(224, 485);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(906, 521);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(pictureBox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterForm";
            Load += RegisterForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox;
        private Panel panel2;
        private TextBox txtFullName;
        private Label label8;
        private TextBox txtAddress;
        private Label label7;
        private TextBox txtPhoneNo;
        private Label label5;
        private TextBox txtEmail;
        private Label label3;
        private Label label2;
        private TextBox txtPassword;
        private Label label1;
        private TextBox txtUsername;
        private Label label4;
        private TextBox txtConfirmPassword;
        private Button btnRegister;
        private Panel panel1;
        private Button btnReturn;
        private CheckBox chkShowPassword;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
            {
                return; // Stop if validation fails
            }

            if (IsDuplicateUser(txtUsername.Text.Trim(), txtEmail.Text.Trim()))
            {
                return; // Stop if duplicate username or email is found
            }

            // Hash the password
            string hashedPassword = HashPassword(txtPassword.Text);

            // Insert user data into the database with default values for Role and Status
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO [User] (Username, PasswordHash, Role, FullName, Email, PhoneNo, Address, Status) " +
                               "VALUES (@Username, @PasswordHash, 'reader', @FullName, @Email, @PhoneNo, @Address, 'active')";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    command.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                    command.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    command.Parameters.AddWithValue("@PhoneNo", txtPhoneNo.Text.Trim());
                    command.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());

                    try
                    {
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("User registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Failed to register user. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Method to validate input fields
        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()) ||
                string.IsNullOrEmpty(txtPassword.Text) ||
                string.IsNullOrEmpty(txtConfirmPassword.Text) ||
                string.IsNullOrEmpty(txtFullName.Text.Trim()) ||
                string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return false;
            }

            // Validate email format
            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Validate phone number format
            if (!IsValidPhoneNumber(txtPhoneNo.Text.Trim()))
            {
                MessageBox.Show("Phone number can only contain numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNo.Focus();
                return false;
            }

            return true;
        }

        // Method to validate email format
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Method to validate phone number format
        private bool IsValidPhoneNumber(string phoneNo)
        {
            string phonePattern = @"^\d+$";
            return Regex.IsMatch(phoneNo, phonePattern);
        }

        // Method to check if the username or email is already in use
        private bool IsDuplicateUser(string username, string email)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM [User] WHERE Username = @Username OR Email = @Email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Email", email);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        // Check which field is duplicated and focus on it
                        if (IsUsernameDuplicate(username))
                        {
                            MessageBox.Show("Username is already in use. Please choose another.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtUsername.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Email is already in use. Please use another email.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtEmail.Focus();
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        // Helper method to determine if the duplicate was the username
        private bool IsUsernameDuplicate(string username)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM [User] WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Method to clear input fields after successful registration
        private void ClearFields()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtPhoneNo.Text = "";
            txtAddress.Text = "";
        }

        private string HashPassword(string password)
        {
            using (MD5 md5 = MD5.Create()) // Thay SHA256 bằng MD5
            {
                byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            txtConfirmPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            LoginForm Login = new LoginForm();
            Login.Show();
            this.Close();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Thoát ứng dụng nếu người dùng chọn "Yes"
            }
        }
    }
}

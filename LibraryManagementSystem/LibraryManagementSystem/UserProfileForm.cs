using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace LibraryManagementSystem
{
    public partial class UserProfileForm : Form
    {
        private string loggedInUsername;

        public UserProfileForm(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            LoadUserData();

            txtPassword.UseSystemPasswordChar = true;
            txtReEnterPassword.UseSystemPasswordChar = true;
        }

        private void LoadUserData()
        {
            txtUsername.Text = loggedInUsername;
            txtUsername.Enabled = false; // Không cho phép chỉnh sửa Username

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT FullName, Email, PhoneNo, Address FROM [User] WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", loggedInUsername);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtFullName.Text = reader["FullName"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            txtPhoneNo.Text = reader["PhoneNo"].ToString();
                            txtAddress.Text = reader["Address"].ToString();
                        }
                    }
                }
            }
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string errorMessage;
            if (!ValidateInput(out errorMessage))
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phoneNo = txtPhoneNo.Text.Trim();
            string address = txtAddress.Text.Trim();
            string password = txtPassword.Text;
            string reEnterPassword = txtReEnterPassword.Text;

            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Full name and email are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mật khẩu có khớp không
            if (!string.IsNullOrEmpty(password) && password != reEnterPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu người dùng nhập mật khẩu mới, băm mật khẩu đó
            string hashedPassword = string.IsNullOrEmpty(password) ? null : HashPassword(password);

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string updateQuery = "UPDATE [User] SET FullName = @FullName, Email = @Email, PhoneNo = @PhoneNo, Address = @Address" +
                                     (hashedPassword != null ? ", PasswordHash = @PasswordHash" : "") +
                                     " WHERE Username = @Username";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", loggedInUsername);
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PhoneNo", phoneNo);
                    command.Parameters.AddWithValue("@Address", address);

                    if (hashedPassword != null)
                    {
                        command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    }

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool ValidateInput(out string errorMessage)
        {
            errorMessage = string.Empty;

            // Kiểm tra họ tên
            if (string.IsNullOrEmpty(txtFullName.Text.Trim()))
            {
                errorMessage = "Full name is required.";
                return false;
            }

            // Kiểm tra email
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                errorMessage = "Email is required.";
                return false;
            }
            else if (!IsValidEmail(email))
            {
                errorMessage = "Invalid email format.";
                return false;
            }

            // Kiểm tra số điện thoại
            string phoneNo = txtPhoneNo.Text.Trim();
            if (!string.IsNullOrEmpty(phoneNo) && !IsValidPhoneNumber(phoneNo))
            {
                errorMessage = "Invalid phone number format.";
                return false;
            }

            // Kiểm tra địa chỉ (nếu cần, không bắt buộc)
            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                errorMessage = "Address is required.";
                return false;
            }

            // Kiểm tra mật khẩu và khớp mật khẩu
            string password = txtPassword.Text;
            string reEnterPassword = txtReEnterPassword.Text;
            if (!string.IsNullOrEmpty(password) && password != reEnterPassword)
            {
                errorMessage = "Passwords do not match.";
                return false;
            }

            // Nếu không có lỗi
            return true;
        }

        // Hàm kiểm tra định dạng email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Hàm kiểm tra định dạng số điện thoại
        private bool IsValidPhoneNumber(string phoneNo)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNo, @"^\d{10,15}$");
        }
    }
}

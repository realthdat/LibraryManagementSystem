using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace LibraryManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Kiểm tra các trường nhập liệu
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            // Băm mật khẩu nhập vào bằng MD5
            string hashedPassword = CreateMD5Hash(password);

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                // Lấy cả PasswordHash và Role từ bảng User
                string query = "SELECT PasswordHash, Role, Status  FROM [User] WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader["PasswordHash"].ToString();
                            string role = reader["Role"].ToString();
                            string status = reader["Status"].ToString();

                            // Kiểm tra trạng thái của người dùng
                            if (status == "active")
                            {
                                // So sánh mật khẩu đã băm
                                if (hashedPassword == storedHash)
                                {
                                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    OpenMainForm(username, role); // Mở form chính dựa trên vai trò của người dùng
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else if (status == "deactive")
                            {
                                MessageBox.Show("Your account is deactivated. Please contact the administrator.", "Account Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if (status == "suspended")
                            {
                                MessageBox.Show("Your account is suspended. Please contact the administrator.", "Account Suspended", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username not found. Please check your username or register for a new account.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
        }

        public string CreateMD5Hash(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Chuyển đổi byte array sang chuỗi hex
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        // Hàm kiểm tra mật khẩu 
        public bool VerifyPasswordHash(string inputPassword, string storedHash)
        {
            // Băm mật khẩu nhập vào
            string hashOfInput = CreateMD5Hash(inputPassword);

            // So sánh băm của mật khẩu nhập vào với băm đã lưu
            return string.Equals(hashOfInput, storedHash, StringComparison.OrdinalIgnoreCase);
        }

        // Hàm mở form chính dựa trên vai trò người dùng
        private void OpenMainForm(string username, string role)
        {
            Form formToOpen = null;

            switch (role.ToLower())
            {
                case "admin":
                    formToOpen = new AdminForm();
                    break;
                case "librarian":
                    formToOpen = new UserForm(username);
                    break;
                case "reader":
                    formToOpen = new ReaderForm(username);
                    break;
                default:
                    MessageBox.Show("Invalid role!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            if (formToOpen != null)
            {
                formToOpen.Show();
                this.Hide(); // Ẩn form đăng nhập
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Thoát ứng dụng nếu người dùng chọn "Yes"
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm frm = new RegisterForm();
            frm.Show();
            this.Hide();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace LibraryManagementSystem
{
    public partial class UserManagementForm : Form
    {

        private bool isEditMode = false;
        private string selectedUsername = string.Empty;

        public UserManagementForm()
        {
            InitializeComponent();
            LoadUsersToGridView();
            LoadRole();
            LoadStatus();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {

        }

        // Hàm để tải dữ liệu Role vào ComboBox
        private void LoadRole()
        {
            List<string> roles = new List<string> { "admin", "librarian", "reader" };
            cbbRole.DataSource = roles;
        }

        // Hàm để tải dữ liệu Status vào ComboBox
        private void LoadStatus()
        {
            List<string> statuses = new List<string> { "active", "deactive", "suspended" };
            cbbStatus.DataSource = statuses;
        }

        // Hàm để tải dữ liệu người dùng vào DataGridView
        private void LoadUsersToGridView()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT UserID, Username, FullName, Role, Email, PhoneNo, Address, Status FROM [User]";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable userTable = new DataTable();
                    adapter.Fill(userTable);
                    dgvUsers.DataSource = userTable;
                }
            }
        }

        // Hàm ClearFields để làm sạch các trường dữ liệu
        private void ClearFields()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtFullName.Text = string.Empty;
            cbbRole.SelectedIndex = -1;
            txtEmail.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            txtAddress.Text = string.Empty;
            cbbStatus.SelectedIndex = -1;
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

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

                // Điền dữ liệu từ hàng đã chọn vào các trường trên form
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhoneNo.Text = row.Cells["PhoneNo"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();

                // Thiết lập giá trị cho ComboBox Role
                string role = row.Cells["Role"].Value.ToString();
                cbbRole.SelectedIndex = cbbRole.FindStringExact(role);

                // Thiết lập giá trị cho ComboBox Status
                string status = row.Cells["Status"].Value.ToString();
                cbbStatus.SelectedIndex = cbbStatus.FindStringExact(status);

                // Lưu lại Username của người dùng đang chỉnh sửa
                selectedUsername = row.Cells["Username"].Value.ToString();
                isEditMode = true; // Đặt chế độ chỉnh sửa
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text; // Lấy mật khẩu mới từ txtPassword
            string role = cbbRole.SelectedItem?.ToString();
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string phoneNo = txtPhoneNo.Text;
            string address = txtAddress.Text;
            string status = cbbStatus.SelectedItem?.ToString();

            // Kiểm tra xem tất cả các trường bắt buộc đã được điền chưa
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(role) || string.IsNullOrEmpty(fullName) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu thiếu thông tin
            }

            // Nếu tất cả các trường bắt buộc đã được điền, tiếp tục xử lý
            string hashedPassword = HashPassword(password); // Băm mật khẩu mới

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                SqlCommand command;

                if (isEditMode && !string.IsNullOrEmpty(selectedUsername))
                {
                    // Cập nhật người dùng dựa trên Username, bao gồm mật khẩu mới đã băm
                    string updateQuery = "UPDATE [User] SET PasswordHash = @PasswordHash, Role = @Role, FullName = @FullName, Email = @Email, PhoneNo = @PhoneNo, Address = @Address, Status = @Status WHERE Username = @Username";
                    command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@Username", selectedUsername); // Sử dụng selectedUsername cho cập nhật
                }
                else
                {
                    // Thêm người dùng mới
                    string insertQuery = "INSERT INTO [User] (Username, PasswordHash, Role, FullName, Email, PhoneNo, Address, Status) VALUES (@Username, @PasswordHash, @Role, @FullName, @Email, @PhoneNo, @Address, @Status)";
                    command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@Username", username);
                }

                // Gán các giá trị khác vào command
                command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                command.Parameters.AddWithValue("@Role", role);
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PhoneNo", phoneNo);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Status", status);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("User saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadUsersToGridView(); // Làm mới DataGridView sau khi lưu
                    isEditMode = false;
                    selectedUsername = string.Empty;
                }
                else
                {
                    MessageBox.Show("Failed to save user. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearFields();
            isEditMode = false; // Đặt về chế độ thêm mới
            selectedUsername = string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedUsername)) // Kiểm tra xem có Username nào được chọn không
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this user?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    using (SqlConnection connection = DatabaseConnection.GetConnection())
                    {
                        connection.Open();
                        string deleteQuery = "DELETE FROM [User] WHERE Username = @Username";
                        SqlCommand command = new SqlCommand(deleteQuery, connection);
                        command.Parameters.AddWithValue("@Username", selectedUsername);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                            LoadUsersToGridView(); // Làm mới DataGridView sau khi xóa
                            selectedUsername = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete user. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0) // Kiểm tra nếu có hàng nào được chọn
            {
                DataGridViewRow selectedRow = dgvUsers.SelectedRows[0]; // Lấy hàng đã chọn

                // Điền dữ liệu từ hàng đã chọn vào các trường trên form
                txtUsername.Text = selectedRow.Cells["Username"].Value.ToString();
                txtFullName.Text = selectedRow.Cells["FullName"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                txtPhoneNo.Text = selectedRow.Cells["PhoneNo"].Value.ToString();
                txtAddress.Text = selectedRow.Cells["Address"].Value.ToString();

                // Gán giá trị cho ComboBox Role và Status
                cbbRole.SelectedItem = selectedRow.Cells["Role"].Value.ToString();
                cbbStatus.SelectedItem = selectedRow.Cells["Status"].Value.ToString();

                // Lưu Username của người dùng đang được chỉnh sửa
                selectedUsername = selectedRow.Cells["Username"].Value.ToString();

                // Đặt isEditMode thành true để xác định đang ở chế độ chỉnh sửa
                isEditMode = true;

                MessageBox.Show("You can now edit the user information. Click 'Save' when done.", "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a user to edit.", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvUsers.Rows.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV (*.csv)|*.csv";
                    sfd.FileName = "UserData.csv";
                    bool fileError = false;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(sfd.FileName))
                        {
                            try
                            {
                                File.Delete(sfd.FileName);
                            }
                            catch (IOException ex)
                            {
                                fileError = true;
                                MessageBox.Show("It wasn't possible to write the data to the disk. " + ex.Message);
                            }
                        }

                        if (!fileError)
                        {
                            try
                            {
                                int columnCount = dgvUsers.Columns.Count;
                                string columnNames = "";
                                string[] outputCsv = new string[dgvUsers.Rows.Count + 1];

                                // Get column headers
                                for (int i = 0; i < columnCount; i++)
                                {
                                    columnNames += dgvUsers.Columns[i].HeaderText.ToString() + ",";
                                }
                                outputCsv[0] = columnNames.TrimEnd(',');

                                // Get rows data
                                for (int i = 1; (i - 1) < dgvUsers.Rows.Count; i++)
                                {
                                    string rowText = "";
                                    for (int j = 0; j < columnCount; j++)
                                    {
                                        var cellValue = dgvUsers.Rows[i - 1].Cells[j].Value;
                                        rowText += (cellValue != null ? cellValue.ToString() : "") + ",";
                                    }
                                    outputCsv[i] = rowText.TrimEnd(',');
                                }

                                File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                                MessageBox.Show("User data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: " + ex.Message);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No records to export.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}

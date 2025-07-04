﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class ManageLoan : Form
    {

        private bool isEditMode = false;
        private string selectedRefCode;

        public ManageLoan()
        {
            InitializeComponent();
            LoadUsers();
            LoadBooks();
            LoadLoanData();
            LoadStatusOptions();
        }

        // Load dữ liệu UserID -> UserName vào ComboBox
        private void LoadUsers()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT UserID, Username FROM [User]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var userList = new List<KeyValuePair<int, string>>();
                        while (reader.Read())
                        {
                            userList.Add(new KeyValuePair<int, string>((int)reader["UserID"], reader["Username"].ToString()));
                        }
                        cbbUser.DataSource = new BindingSource(userList, null);
                        cbbUser.DisplayMember = "Value";
                        cbbUser.ValueMember = "Key";
                    }
                }
            }
        }

        // Load dữ liệu BookID -> Title vào ComboBox
        private void LoadBooks()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT BookID, Title FROM [Book]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var userList = new List<KeyValuePair<int, string>>();
                        while (reader.Read())
                        {
                            userList.Add(new KeyValuePair<int, string>((int)reader["BookID"], reader["Title"].ToString()));
                        }
                        cbbBook.DataSource = new BindingSource(userList, null);
                        cbbBook.DisplayMember = "Value";
                        cbbBook.ValueMember = "Key";
                    }
                }
            }
        }

        private void LoadStatusOptions()
        {
            cbbStatus.Items.Add("active");
            cbbStatus.Items.Add("pending");
            cbbStatus.Items.Add("completed");
        }

        // Load dữ liệu từ bảng Loan vào DataGridView
        private void LoadLoanData()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT LoanID, UserID, BookID, LoanDate, ReturnDate, ActualReturnDate, Fine, Status, RefCode FROM Loan";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable loanTable = new DataTable();
                    adapter.Fill(loanTable);
                    dgvLoan.DataSource = loanTable;
                }
            }
        }


        // Hàm ClearFields để làm sạch các trường dữ liệu
        private void ClearFields()
        {
            cbbUser.SelectedIndex = -1;
            cbbBook.SelectedIndex = -1;
            dtpLoanDate.Value = DateTime.Now;
            dtpReturnDate.Value = DateTime.Now;
            dtpActualReturnDate.Value = DateTime.Now;
            cbbStatus.SelectedIndex = -1;
            txtFine.Text = string.Empty;
            txtRefCode.Text = string.Empty;
        }

        // Hàm GenerateRefCode để tạo RefCode tự động
        private string GenerateRefCode()
        {
            string newRefCode = "REFLN0001";
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT TOP 1 RefCode FROM Loan ORDER BY RefCode DESC";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        string lastRefCode = result.ToString();
                        int numericPart = int.Parse(lastRefCode.Substring(5)) + 1;
                        newRefCode = "REFLN" + numericPart.ToString("D4");
                    }
                }
            }
            return newRefCode;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearFields();
            isEditMode = false;
            txtRefCode.Text = GenerateRefCode();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvLoan.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvLoan.SelectedRows[0];
                selectedRefCode = selectedRow.Cells["RefCode"].Value.ToString();

                // Điền dữ liệu từ hàng đã chọn vào các trường
                cbbUser.SelectedValue = selectedRow.Cells["UserID"].Value;
                cbbBook.SelectedValue = selectedRow.Cells["BookID"].Value;
                dtpLoanDate.Value = Convert.ToDateTime(selectedRow.Cells["LoanDate"].Value);
                dtpReturnDate.Value = Convert.ToDateTime(selectedRow.Cells["ReturnDate"].Value);
                dtpActualReturnDate.Value = selectedRow.Cells["ActualReturnDate"].Value == DBNull.Value ? DateTime.Now : Convert.ToDateTime(selectedRow.Cells["ActualReturnDate"].Value);
                cbbStatus.SelectedValue = selectedRow.Cells["Status"].Value;
                txtFine.Text = selectedRow.Cells["Fine"].Value.ToString();
                txtRefCode.Text = selectedRefCode;

                isEditMode = true;
            }
            else
            {
                MessageBox.Show("Please select a loan record to edit.", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbbUser.SelectedItem is KeyValuePair<int, string> selectedUser && cbbBook.SelectedItem is KeyValuePair<int, string> selectedBook)
            {
                int userID = selectedUser.Key;
                int bookID = selectedBook.Key;
                DateTime loanDate = dtpLoanDate.Value;
                DateTime returnDate = dtpReturnDate.Value;
                string status = cbbStatus.SelectedItem?.ToString();
                decimal fine = string.IsNullOrEmpty(txtFine.Text) ? 0 : Convert.ToDecimal(txtFine.Text);
                string refCode = txtRefCode.Text;

                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand command;

                    DateTime? actualReturnDate = null;

                    if (isEditMode)
                    {
                        // Lấy giá trị ActualReturnDate từ cơ sở dữ liệu để kiểm tra
                        string selectQuery = "SELECT ActualReturnDate FROM Loan WHERE RefCode = @RefCode";
                        using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                        {
                            selectCommand.Parameters.AddWithValue("@RefCode", refCode);
                            object dbActualReturnDate = selectCommand.ExecuteScalar();
                            actualReturnDate = dbActualReturnDate != DBNull.Value ? (DateTime?)dbActualReturnDate : null;
                        }

                        // Nếu giá trị hiện tại khác null, cập nhật bằng giá trị từ DateTimePicker
                        if (actualReturnDate != null)
                        {
                            actualReturnDate = dtpActualReturnDate.Checked ? (DateTime?)dtpActualReturnDate.Value : actualReturnDate;
                        }

                        string updateQuery = "UPDATE Loan SET UserID = @UserID, BookID = @BookID, LoanDate = @LoanDate, ReturnDate = @ReturnDate, ActualReturnDate = @ActualReturnDate, Fine = @Fine, Status = @Status WHERE RefCode = @RefCode";
                        command = new SqlCommand(updateQuery, connection);
                    }
                    else
                    {
                        // Thêm mới
                        actualReturnDate = dtpActualReturnDate.Checked ? (DateTime?)dtpActualReturnDate.Value : null;

                        string insertQuery = "INSERT INTO Loan (UserID, BookID, LoanDate, ReturnDate, ActualReturnDate, Fine, Status, RefCode) VALUES (@UserID, @BookID, @LoanDate, @ReturnDate, @ActualReturnDate, @Fine, @Status, @RefCode)";
                        command = new SqlCommand(insertQuery, connection);
                    }

                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@BookID", bookID);
                    command.Parameters.AddWithValue("@LoanDate", loanDate);
                    command.Parameters.AddWithValue("@ReturnDate", returnDate);
                    command.Parameters.AddWithValue("@ActualReturnDate", actualReturnDate ?? (object)DBNull.Value); // Gán DBNull.Value nếu ActualReturnDate là null
                    command.Parameters.AddWithValue("@Status", status ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Fine", fine);
                    command.Parameters.AddWithValue("@RefCode", refCode);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        UpdateBookStock(bookID, status, connection);
                        UpdateReservationStatus(userID, bookID, status, connection);

                        MessageBox.Show("Loan record saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        LoadLoanData();
                        isEditMode = false;
                    }
                    else
                    {
                        MessageBox.Show("Failed to save loan record. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select valid User and Book.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void UpdateBookStock(int bookID, string status, SqlConnection connection)
        {
            string updateStockQuery = "";
            if (status == "active")
            {
                // Nếu trạng thái loan là active, giảm số lượng sách đi 1
                updateStockQuery = "UPDATE Book SET Totalcopies = Totalcopies - 1 WHERE BookID = @BookID";
            }
            else if (status == "completed" || status == "pending")
            {
                // Nếu trạng thái loan là completed hoặc pending, tăng số lượng sách lên 1
                updateStockQuery = "UPDATE Book SET Totalcopies = Totalcopies + 1 WHERE BookID = @BookID";
            }

            if (!string.IsNullOrEmpty(updateStockQuery))
            {
                using (SqlCommand updateStockCommand = new SqlCommand(updateStockQuery, connection))
                {
                    updateStockCommand.Parameters.AddWithValue("@BookID", bookID);
                    updateStockCommand.ExecuteNonQuery();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLoan.SelectedRows.Count > 0)
            {
                selectedRefCode = dgvLoan.SelectedRows[0].Cells["RefCode"].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this loan record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    using (SqlConnection connection = DatabaseConnection.GetConnection())
                    {
                        connection.Open();
                        string deleteQuery = "DELETE FROM Loan WHERE RefCode = @RefCode";
                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@RefCode", selectedRefCode);
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Loan record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLoanData();
                }
            }
            else
            {
                MessageBox.Show("Please select a loan record to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvLoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvLoan.Rows[e.RowIndex];
                cbbUser.SelectedValue = selectedRow.Cells["UserID"].Value;
                cbbBook.SelectedValue = selectedRow.Cells["BookID"].Value;
                dtpLoanDate.Value = Convert.ToDateTime(selectedRow.Cells["LoanDate"].Value);
                dtpReturnDate.Value = Convert.ToDateTime(selectedRow.Cells["ReturnDate"].Value);

                if (selectedRow.Cells["ActualReturnDate"].Value != DBNull.Value)
                {
                    dtpActualReturnDate.Value = Convert.ToDateTime(selectedRow.Cells["ActualReturnDate"].Value);
                }
                else
                {
                    dtpActualReturnDate.Value = DateTime.Now;
                }

                // Ensure Status is set correctly
                cbbStatus.SelectedItem = selectedRow.Cells["Status"].Value.ToString();

                txtFine.Text = selectedRow.Cells["Fine"].Value.ToString();
                txtRefCode.Text = selectedRow.Cells["RefCode"].Value.ToString();
                isEditMode = true;
                selectedRefCode = txtRefCode.Text;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvLoan.Rows.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV (*.csv)|*.csv";
                    sfd.FileName = "LoanRecords.csv";
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
                                int columnCount = dgvLoan.Columns.Count;
                                string columnNames = "";
                                string[] outputCsv = new string[dgvLoan.Rows.Count + 1];

                                // Get column headers
                                for (int i = 0; i < columnCount; i++)
                                {
                                    columnNames += dgvLoan.Columns[i].HeaderText.ToString() + ",";
                                }
                                outputCsv[0] = columnNames.TrimEnd(',');

                                // Get rows data
                                for (int i = 1; (i - 1) < dgvLoan.Rows.Count; i++)
                                {
                                    string rowText = "";
                                    for (int j = 0; j < columnCount; j++)
                                    {
                                        var cellValue = dgvLoan.Rows[i - 1].Cells[j].Value;
                                        rowText += (cellValue != null ? cellValue.ToString() : "") + ",";
                                    }
                                    outputCsv[i] = rowText.TrimEnd(',');
                                }

                                File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                                MessageBox.Show("Loan records exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void UpdateReservationStatus(int userID, int bookID, string loanStatus, SqlConnection connection)
        {
            string reservationStatus = loanStatus switch
            {
                "completed" => "completed",
                "active" => "completed",
                "pending" => "active",
                _ => null // Không thay đổi nếu trạng thái không khớp
            };

            if (reservationStatus != null)
            {
                string updateQuery = "UPDATE Reservation SET Status = @ReservationStatus " +
                                     "WHERE UserID = @UserID AND BookID = @BookID AND Status != 'completed' " +
                                     "AND ReservationDate = (SELECT MAX(ReservationDate) FROM Reservation WHERE UserID = @UserID AND BookID = @BookID)";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@ReservationStatus", reservationStatus);
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@BookID", bookID);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}

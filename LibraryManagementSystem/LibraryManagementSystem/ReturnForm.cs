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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LibraryManagementSystem
{
    public partial class ReturnForm : Form
    {
        public ReturnForm()
        {
            InitializeComponent();
            LoadAllLoans();
        }


        private void LoadAllLoans()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = @"SELECT 
                            Loan.LoanID,
                            [User].Username,
                            Book.Title,
                            Loan.LoanDate,
                            Loan.ReturnDate,
                            Loan.ActualReturnDate,
                            Loan.Fine,
                            Loan.RefCode
                         FROM Loan
                         JOIN [User] ON Loan.UserID = [User].UserID
                         JOIN Book ON Loan.BookID = Book.BookID";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable loanTable = new DataTable();
                    adapter.Fill(loanTable);
                    dgv.DataSource = loanTable;
                }
            }
        }


        private int GetUserIDFromUsername(string username)
        {
            int userID = -1;
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT UserID FROM [User] WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        userID = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Username not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return userID;
        }

        private int GetBookIDFromISBN(string isbn)
        {
            int bookID = -1;
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT BookID FROM [Book] WHERE ISBN = @ISBN";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ISBN", isbn);
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        bookID = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Book ISBN not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return bookID;
        }

        private decimal CalculateOverdueFee(int userID, int bookID, DateTime actualReturnDate)
        {
            decimal overdueFee = 0m;

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT ReturnDate FROM [Loan] WHERE UserID = @UserID AND BookID = @BookID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@BookID", bookID);
                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        DateTime returnDate = Convert.ToDateTime(result);
                        int overdueDays = (actualReturnDate - returnDate).Days;

                        if (overdueDays > 0)
                        {
                            overdueFee = overdueDays * 0.5m; // Ví dụ: tính phí trễ hạn là 0.5 mỗi ngày
                        }
                    }
                    else
                    {
                        MessageBox.Show("No loan record found for this user and book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return overdueFee;
        }


        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string isbn = txtISBN.Text;
            DateTime actualReturnDate = dtpActualReturnDate.Value;

            // Lấy UserID và BookID
            int userID = GetUserIDFromUsername(username);
            int bookID = GetBookIDFromISBN(isbn);

            // Kiểm tra UserID và BookID có hợp lệ không
            if (userID == -1 || bookID == -1)
            {
                MessageBox.Show("Invalid Username or ISBN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tìm lần mượn sách gần nhất chưa được trả cho UserID và BookID
            int loanID = -1;
            DateTime returnDate;
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT TOP 1 LoanID, ReturnDate FROM Loan WHERE UserID = @UserID AND BookID = @BookID AND ActualReturnDate IS NULL ORDER BY LoanDate DESC";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@BookID", bookID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            loanID = reader.GetInt32(reader.GetOrdinal("LoanID"));
                            returnDate = reader.GetDateTime(reader.GetOrdinal("ReturnDate"));
                        }
                        else
                        {
                            MessageBox.Show("No active loan record found for this user and book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }

            // Tính phí trễ hạn nếu có
            decimal overdueFee = 0m;
            int overdueDays = (actualReturnDate - returnDate).Days;
            if (overdueDays > 0)
            {
                overdueFee = overdueDays * 0.5m; // Ví dụ: tính phí trễ hạn là 0.5 mỗi ngày trễ
                txtOverdueFee.Text = overdueFee.ToString("F2");

                // Hiển thị thông báo cho người dùng về phí phạt
                MessageBox.Show($"You have to pay this fee: {overdueFee:C}", "Overdue Fee", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                txtOverdueFee.Text = "0.00";
                MessageBox.Show("No overdue fee to pay.", "Return Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Cập nhật ngày trả, phí phạt và trạng thái vào bảng Loan
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string updateLoanQuery = "UPDATE Loan SET ActualReturnDate = @ActualReturnDate, Fine = @Fine, Status = @Status WHERE LoanID = @LoanID";
                        using (SqlCommand command = new SqlCommand(updateLoanQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@ActualReturnDate", actualReturnDate);
                            command.Parameters.AddWithValue("@Fine", overdueFee);
                            command.Parameters.AddWithValue("@Status", "completed"); // Update status to "Completed"
                            command.Parameters.AddWithValue("@LoanID", loanID);

                            int result = command.ExecuteNonQuery();
                            if (result > 0)
                            {
                                // Bước 2: Cập nhật lại TotalCopies trong bảng Book
                                string updateBookCopiesQuery = "UPDATE Book SET Totalcopies = Totalcopies + 1 WHERE BookID = @BookID";
                                using (SqlCommand updateCopiesCommand = new SqlCommand(updateBookCopiesQuery, connection, transaction))
                                {
                                    updateCopiesCommand.Parameters.AddWithValue("@BookID", bookID);
                                    updateCopiesCommand.ExecuteNonQuery();
                                }

                                // Xác nhận giao dịch
                                transaction.Commit();
                                MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearFields();
                                LoadAllLoans();
                            }
                            else
                            {
                                transaction.Rollback();
                                MessageBox.Show("Failed to update return information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Rollback giao dịch nếu có lỗi
                        transaction.Rollback();
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearFields();
                    }
                }
            }

        }

        private void ReturnForm_Load(object sender, EventArgs e)
        {
            dtpActualReturnDate.Value = DateTime.Now;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string refCode = txtRefCode.Text.Trim();

            if (string.IsNullOrEmpty(refCode))
            {
                MessageBox.Show("Please enter a valid RefCode.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FillLoanDetails(refCode); // Gọi hàm để hiển thị thông tin
        }


        private void ClearFields()
        {
            // Xóa nội dung của TextBox
            txtUsername.Text = string.Empty;
            txtBookTitle.Text = string.Empty;
            txtISBN.Text = string.Empty;
            txtOverdueFee.Text = string.Empty;

            // Đặt lại DateTimePicker về ngày hôm nay
            dtpActualReturnDate.Value = DateTime.Now;
        }

        private void txtRefCode_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void FillLoanDetails(string refCode)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = @"SELECT 
                            [User].Username,
                            Book.Title,
                            Book.ISBN
                         FROM Loan
                         JOIN [User] ON Loan.UserID = [User].UserID
                         JOIN Book ON Loan.BookID = Book.BookID
                         WHERE Loan.RefCode = @RefCode";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RefCode", refCode);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtUsername.Text = reader["Username"].ToString();
                            txtBookTitle.Text = reader["Title"].ToString();
                            txtISBN.Text = reader["ISBN"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("RefCode not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ClearFields();
                        }
                    }
                }
            }
        }
    }

}

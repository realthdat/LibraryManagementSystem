using Microsoft.VisualBasic.ApplicationServices;
using Org.BouncyCastle.Asn1.Cmp;
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
    public partial class BorrowRequest : Form
    {
        private string loggedInUsername;

        public BorrowRequest(string username)
        {
            InitializeComponent();
            loggedInUsername = username;

            LoadGenres();
            LoadAllBooks();
            LoadBooks();
            txtUsername.Text = loggedInUsername;
        }

        private void LoadAllBooks()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT Title, Author, PublicationYear, Genre, ISBN, Status, Location, Totalcopies, Price FROM Book";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable bookTable = new DataTable();
                    adapter.Fill(bookTable);
                    dgv.DataSource = bookTable;
                }
            }
        }

        private void LoadGenres()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT DISTINCT Genre FROM Book";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbbGenre.Items.Add(reader["Genre"].ToString());
                        }
                    }
                }
            }
            cbbGenre.Items.Insert(0, "All"); // Optionally add 'All' to reset the filter
            cbbGenre.SelectedIndex = 0; // Default selection
        }



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
                        while (reader.Read())
                        {
                            cbbBookTitle.Items.Add(new KeyValuePair<int, string>((int)reader["BookID"], reader["Title"].ToString()));
                        }
                    }
                }
            }
            cbbBookTitle.DisplayMember = "Value";
            cbbBookTitle.ValueMember = "Key";
        }

        // Hàm tạo ref code tự động
        private string GenerateRefCode(SqlConnection connection, SqlTransaction transaction)
        {
            string latestRefCode = "";
            string query = "SELECT TOP 1 RefCode FROM Loan ORDER BY RefCode DESC";
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    latestRefCode = result.ToString();
                }
            }

            // Kiểm tra và tạo mã mới
            if (!string.IsNullOrEmpty(latestRefCode) && latestRefCode.StartsWith("REFLN"))
            {
                // Tách phần số cuối cùng và tăng thêm 1
                int currentNumber = int.Parse(latestRefCode.Substring(6));
                int newNumber = currentNumber + 1;
                return $"REFLN{newNumber:D4}";
            }
            else
            {
                // Nếu chưa có mã nào, bắt đầu từ REF + LN + 0001
                return "REFLN0001";
            }
        }

        private void ClearFields()
        {
            if (cbbBookTitle.Items.Count > 0)
                cbbBookTitle.SelectedIndex = -1;

            // Xóa nội dung các TextBox
            txtISBN.Text = string.Empty;
            txtPrice.Text = string.Empty;

            // Đặt lại DateTimePicker về ngày hiện tại
            dtpLoanDate.Value = DateTime.Now;
            dtpReturnDate.Value = DateTime.Now;
        }

        private void buttonRequest_Click(object sender, EventArgs e)
        {
            // Validate fields before proceeding
            if (!ValidateFields())
            {
                return; // Stop if validation fails
            }



            if (cbbBookTitle.SelectedItem is KeyValuePair<int, string> selectedBook)
            {
                int bookID = selectedBook.Key;
                DateTime loanDate = DateTime.Now; // Loan date is the current date
                DateTime returnDate = dtpReturnDate.Value; // Return date is chosen by the user
                string refCode;

                int userID;
                string username = txtUsername.Text;



                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    using (SqlCommand getUserIdCommand = new SqlCommand("SELECT UserID FROM [User] WHERE Username = @Username", connection))
                    {
                        getUserIdCommand.Parameters.AddWithValue("@Username", username);

                        object result = getUserIdCommand.ExecuteScalar();
                        if (result != null)
                        {
                            userID = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Dừng quá trình nếu không tìm thấy user
                        }
                    }

                    // Check if the book is available
                    string checkCopiesQuery = "SELECT Totalcopies, ISBN, Author, Genre, Price FROM Book WHERE BookID = @BookID";
                    string isbn = "";
                    string author = "";
                    string genre = "";
                    decimal price = 0;

                    using (SqlCommand checkCopiesCommand = new SqlCommand(checkCopiesQuery, connection))
                    {
                        checkCopiesCommand.Parameters.AddWithValue("@BookID", bookID);
                        using (SqlDataReader reader = checkCopiesCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int totalCopies = reader.GetInt32(0);
                                isbn = reader.GetString(1);
                                author = reader.GetString(2);
                                genre = reader.GetString(3);
                                price = reader.GetDecimal(4);

                                if (totalCopies <= 0)
                                {
                                    MessageBox.Show("This book is currently unavailable for borrowing (no copies left).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    ClearFields();
                                    return; // Stop the process if no copies are available
                                }
                            }
                        }
                    }

                    // Begin transaction to ensure all steps succeed or fail together
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Step 1: Update reservation status to 'completed' (if applicable)
                            string updateReservationQuery = "UPDATE Reservation SET Status = 'completed' WHERE UserID = @UserID AND BookID = @BookID AND Status = 'active'";
                            using (SqlCommand updateCommand = new SqlCommand(updateReservationQuery, connection, transaction))
                            {
                                updateCommand.Parameters.AddWithValue("@UserID", userID);
                                updateCommand.Parameters.AddWithValue("@BookID", bookID);
                                updateCommand.ExecuteNonQuery();
                            }

                            // Step 2: Generate new ref code
                            refCode = GenerateRefCode(connection, transaction);

                            // Step 3: Insert a new record into the Loan table with the ref code
                            string insertLoanQuery = "INSERT INTO Loan (UserID, BookID, LoanDate, ReturnDate, RefCode) VALUES (@UserID, @BookID, @LoanDate, @ReturnDate, @RefCode)";
                            using (SqlCommand insertCommand = new SqlCommand(insertLoanQuery, connection, transaction))
                            {
                                insertCommand.Parameters.AddWithValue("@UserID", userID);
                                insertCommand.Parameters.AddWithValue("@BookID", bookID);
                                insertCommand.Parameters.AddWithValue("@LoanDate", loanDate);
                                insertCommand.Parameters.AddWithValue("@ReturnDate", returnDate);
                                insertCommand.Parameters.AddWithValue("@RefCode", refCode);

                                insertCommand.ExecuteNonQuery();
                            }

                            // Step 4: Decrement the TotalCopies in the Book table
                            //string updateBookCopiesQuery = "UPDATE Book SET Totalcopies = Totalcopies - 1 WHERE BookID = @BookID";
                            //using (SqlCommand updateCopiesCommand = new SqlCommand(updateBookCopiesQuery, connection, transaction))
                            //{
                            //    updateCopiesCommand.Parameters.AddWithValue("@BookID", bookID);
                            //    updateCopiesCommand.ExecuteNonQuery();
                            //}

                            // Commit the transaction
                            transaction.Commit();

                            // Retrieve user details for the receipt
                            string fullName = "";
                            string email = "";
                            string phoneNo = "";
                            string bookTitle = "";

                            if (cbbBookTitle.SelectedItem is KeyValuePair<int, string> selectedBookItem)
                            {
                                // Get the display value (title) from the selected item
                                bookTitle = selectedBookItem.Value;
                            }

                            string userQuery = "SELECT FullName, Email, PhoneNo FROM [User] WHERE UserID = @UserID";
                            using (SqlCommand userCommand = new SqlCommand(userQuery, connection))
                            {
                                userCommand.Parameters.AddWithValue("@UserID", userID);
                                using (SqlDataReader userReader = userCommand.ExecuteReader())
                                {
                                    if (userReader.Read())
                                    {
                                        fullName = userReader["FullName"].ToString();
                                        email = userReader["Email"].ToString();
                                        phoneNo = userReader["PhoneNo"].ToString();
                                    }
                                }
                            }

                            // Show success message
                            MessageBox.Show($"Loan confirmed successfully!\nYour Loan RefCode is: {refCode}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear fields and refresh book list
                            ClearFields();
                            LoadAllBooks();
                        }
                        catch (Exception ex)
                        {
                            // Roll back the transaction if there is an error
                            transaction.Rollback();
                            MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a valid user and book.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearFields();
            }
        }

        private bool ValidateFields()
        {
            // Username Validation
            if (txtUsername.Text == null)
            {
                MessageBox.Show("Please input a Username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return false;
            }

            // Book Title Validation
            if (cbbBookTitle.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Book Title.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbBookTitle.Focus();
                return false;
            }


            // Loan Date Validation
            if (dtpLoanDate.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Loan Date cannot be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpLoanDate.Focus();
                return false;
            }

            // Return Date Validation
            if (dtpReturnDate.Value.Date <= dtpLoanDate.Value.Date)
            {
                MessageBox.Show("Return Date should be after the Loan Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpReturnDate.Focus();
                return false;
            }

            return true; // All validations passed
        }


        private void cbbBookTitle_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Lấy BookID từ sách đã chọn
            if (cbbBookTitle.SelectedItem is KeyValuePair<int, string> selectedBook)
            {
                int bookID = selectedBook.Key;

                // Kết nối đến cơ sở dữ liệu để lấy ISBN và Price của sách
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT ISBN, Price FROM [Book] WHERE BookID = @BookID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookID", bookID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Hiển thị ISBN trong txtISBN
                                txtISBN.Text = reader["ISBN"].ToString();

                                // Hiển thị Price trong txtPrice
                                txtPrice.Text = reader["Price"].ToString();
                            }
                            else
                            {
                                // Nếu không tìm thấy sách, xóa các trường
                                txtISBN.Text = "";
                                txtPrice.Text = "";
                            }
                        }
                    }
                }
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem có hàng nào được chọn không
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                cbbBookTitle.SelectedItem = row.Cells["Title"].Value.ToString();
                txtISBN.Text = row.Cells["ISBN"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                txtStatus.Text = row.Cells["Status"].Value.ToString();

                // Thiết lập giá trị cho ComboBox Genre
                string title = row.Cells["Title"].Value.ToString();
                cbbBookTitle.SelectedIndex = cbbBookTitle.FindStringExact(title);

            }
        }

        private void LoadBooksByGenre(string genre)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT Title, Author, PublicationYear, Genre, ISBN, Status, Location, Totalcopies, Price " +
                               "FROM Book WHERE Genre = @Genre";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@Genre", genre);
                    DataTable bookTable = new DataTable();
                    adapter.Fill(bookTable);
                    dgv.DataSource = bookTable;
                }
            }
        }

        private void cbbGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbGenre.SelectedItem != "All")
            {
                string selectedGenre = cbbGenre.SelectedItem.ToString();
                LoadBooksByGenre(selectedGenre);
            }
            else
            {
                LoadAllBooks();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string bookTitle = txtBookTitle.Text.Trim();

            if (string.IsNullOrEmpty(bookTitle))
            {
                MessageBox.Show("Please enter a book title to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SearchBooksByTitle(bookTitle);
        }

        private void SearchBooksByTitle(string title)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT Title, Author, PublicationYear, Genre, ISBN, Status, Location, Totalcopies, Price " +
                               "FROM Book WHERE Title LIKE @Title";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@Title", $"%{title}%"); // Use wildcard for partial matching
                    DataTable bookTable = new DataTable();
                    adapter.Fill(bookTable);
                    dgv.DataSource = bookTable;
                }
            }
        }
    }
}

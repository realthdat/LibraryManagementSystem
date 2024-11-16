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

namespace LibraryManagementSystem
{

    public partial class ReservationRequest : Form
    {
        private string loggedInUsername;

        public ReservationRequest(string username)
        {
            InitializeComponent();
            loggedInUsername = username;

            txtUsername.Text = loggedInUsername;

            LoadAllBooks();
            LoadBooks();

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

        private string GenerateRefCode(SqlConnection connection, SqlTransaction transaction)
        {
            string latestRefCode = "";
            string query = "SELECT TOP 1 RefCode FROM Reservation ORDER BY RefCode DESC";
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    latestRefCode = result.ToString();
                }
            }

            if (!string.IsNullOrEmpty(latestRefCode) && latestRefCode.StartsWith("REFRS"))
            {
                int currentNumber = int.Parse(latestRefCode.Substring(5));
                int newNumber = currentNumber + 1;
                return $"REFRS{newNumber:D4}";
            }
            else
            {
                return "REFRS0001";
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
            dtpReservationDate.Value = DateTime.Now;
        }

        private void buttonRequest_Click(object sender, EventArgs e)
        {
            if (cbbBookTitle.SelectedItem is KeyValuePair<int, string> selectedBook)
            {
                int bookID = selectedBook.Key;
                DateTime reservationDate = dtpReservationDate.Value;
                string status = "cancelled";

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

                    // Check TotalCopies before placing reservation
                    string checkCopiesQuery = "SELECT Totalcopies, ISBN, Author, Genre FROM Book WHERE BookID = @BookID";
                    string isbn = "";
                    string author = "";
                    string genre = "";
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

                                // If no copies are available, set status to 'canceled'; otherwise, 'active'
                                status = totalCopies <= 0 ? "canceled" : "active";

                                if (status == "canceled")
                                {
                                    MessageBox.Show("This book is currently unavailable for reservation (no copies left). The reservation will be set as 'canceled'.",
                                                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }

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

                    // Begin a transaction to ensure data integrity
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Generate new reservation reference code
                            string refCode = GenerateRefCode(connection, transaction);

                            // Insert record into Reservation table with ref code and status
                            string query = "INSERT INTO Reservation (UserID, BookID, ReservationDate, Status, RefCode) VALUES (@UserID, @BookID, @ReservationDate, @Status, @RefCode)";
                            using (SqlCommand command = new SqlCommand(query, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@UserID", userID);
                                command.Parameters.AddWithValue("@BookID", bookID);
                                command.Parameters.AddWithValue("@ReservationDate", reservationDate);
                                command.Parameters.AddWithValue("@Status", status);  // 'canceled' or 'active' based on TotalCopies
                                command.Parameters.AddWithValue("@RefCode", refCode);

                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    transaction.Commit(); // Commit transaction
                                    MessageBox.Show($"Reservation placed successfully!\nYour Reservation Code is: {refCode}\nStatus: {status}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ClearFields();
                                }
                                else
                                {
                                    transaction.Rollback(); // Rollback if an error occurs
                                    MessageBox.Show("Failed to place reservation. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); // Rollback transaction if an error occurs
                            MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a valid user and book.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbbBookTitle_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}

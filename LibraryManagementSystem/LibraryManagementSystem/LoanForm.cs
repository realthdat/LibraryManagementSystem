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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace LibraryManagementSystem
{
    public partial class LoanForm : Form
    {

        public LoanForm()
        {
            InitializeComponent();
            LoadAllBooks();
            LoadUsers();
            LoadBooks();

        }

        private void LoadAllBooks()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT BookID, Title, Author, PublicationYear, Genre, ISBN, Status, Location, Totalcopies, Price FROM Book";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable bookTable = new DataTable();
                    adapter.Fill(bookTable);
                    dgv.DataSource = bookTable;
                }
            }
        }

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
                        while (reader.Read())
                        {
                            cbbUsername.Items.Add(new KeyValuePair<int, string>((int)reader["UserID"], reader["Username"].ToString()));
                        }
                    }
                }
            }
            cbbUsername.DisplayMember = "Value";
            cbbUsername.ValueMember = "Key";
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
            // Đặt lại ComboBox về trạng thái không chọn
            if (cbbUsername.Items.Count > 0)
                cbbUsername.SelectedIndex = -1;

            if (cbbBookTitle.Items.Count > 0)
                cbbBookTitle.SelectedIndex = -1;

            // Xóa nội dung các TextBox
            txtISBN.Text = string.Empty;
            txtPrice.Text = string.Empty;

            // Đặt lại DateTimePicker về ngày hiện tại
            dtpLoanDate.Value = DateTime.Now;
            dtpReturnDate.Value = DateTime.Now;
        }

            // Borrow click
        private void button7_Click(object sender, EventArgs e)
        {
            // Validate fields before proceeding
            if (!ValidateFields())
            {
                return; // Stop if validation fails
            }

            if (cbbUsername.SelectedItem is KeyValuePair<int, string> selectedUser && cbbBookTitle.SelectedItem is KeyValuePair<int, string> selectedBook)
            {
                int userID = selectedUser.Key;
                int bookID = selectedBook.Key;
                DateTime loanDate = DateTime.Now; // Loan date is the current date
                DateTime returnDate = dtpReturnDate.Value; // Return date is chosen by the user
                string refCode;

                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

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
                            string insertLoanQuery = "INSERT INTO Loan (UserID, BookID, LoanDate, ReturnDate, Status, RefCode) VALUES (@UserID, @BookID, @LoanDate, @ReturnDate, @Status, @RefCode)";
                            using (SqlCommand insertCommand = new SqlCommand(insertLoanQuery, connection, transaction))
                            {
                                insertCommand.Parameters.AddWithValue("@UserID", userID);
                                insertCommand.Parameters.AddWithValue("@BookID", bookID);
                                insertCommand.Parameters.AddWithValue("@LoanDate", loanDate);
                                insertCommand.Parameters.AddWithValue("@ReturnDate", returnDate);
                                insertCommand.Parameters.AddWithValue("@Status", "active");
                                insertCommand.Parameters.AddWithValue("@RefCode", refCode);

                                insertCommand.ExecuteNonQuery();
                            }

                            // Step 4: Decrement the TotalCopies in the Book table
                            string updateBookCopiesQuery = "UPDATE Book SET Totalcopies = Totalcopies - 1 WHERE BookID = @BookID";
                            using (SqlCommand updateCopiesCommand = new SqlCommand(updateBookCopiesQuery, connection, transaction))
                            {
                                updateCopiesCommand.Parameters.AddWithValue("@BookID", bookID);
                                updateCopiesCommand.ExecuteNonQuery();
                            }

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

                            // Generate PDF receipt
                            ExportLoanReceiptToPdf(refCode, fullName, email, phoneNo, bookTitle, author, genre, isbn, price);
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
            if (cbbUsername.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbUsername.Focus();
                return false;
            }

            // Book Title Validation
            if (cbbBookTitle.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Book Title.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbBookTitle.Focus();
                return false;
            }

            // ISBN Validation
            if (string.IsNullOrWhiteSpace(txtISBN.Text) || txtISBN.Text.Length != 13)
            {
                MessageBox.Show("ISBN must be 13 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtISBN.Focus();
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

            // Price Validation
            if (string.IsNullOrWhiteSpace(txtPrice.Text) || !decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Please enter a valid non-negative price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return false;
            }

            return true; // All validations passed
        }

        private void ExportLoanReceiptToPdf(string refCode, string fullName, string email, string phoneNo,
                                    string bookTitle, string author, string genre, string isbn, decimal price)
        {

            DateTime loanDate = DateTime.Now;

            // Use SaveFileDialog to allow the user to select a save location
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF file (*.pdf)|*.pdf",  // Allow saving only as .pdf
                Title = "Save Loan Receipt as PDF",
                FileName = $"LoanReceipt_{refCode}.pdf"  // Default file name suggestion
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the file path selected by the user
                string filePath = saveFileDialog.FileName;

                // Create a PDF document using iTextSharp
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25f, 25f, 30f, 30f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // Add company or library name (optional)
                    iTextSharp.text.Paragraph libraryName = new iTextSharp.text.Paragraph(".Net Engineering Library",
                        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 24f, iTextSharp.text.Font.BOLD));
                    libraryName.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(libraryName);

                    // Add title
                    iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("Loan Receipt",
                        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18f, iTextSharp.text.Font.BOLD));
                    title.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(title);

                    // Add space between title and content
                    pdfDoc.Add(new Paragraph(" "));

                    // Add loan information table
                    PdfPTable infoTable = new PdfPTable(2);
                    infoTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    infoTable.SpacingBefore = 10f;
                    infoTable.SpacingAfter = 10f;
                    infoTable.WidthPercentage = 100;
                    infoTable.SetWidths(new float[] { 30f, 70f }); // Set column widths

                    // Add empty row for spacing
                    PdfPCell emptyRow = new PdfPCell(new Phrase(" "));
                    emptyRow.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    emptyRow.Colspan = 2; // Spans across both columns

                    // Loan Date
                    infoTable.AddCell(new PdfPCell(new Phrase("Loan Date:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(new PdfPCell(new Phrase(loanDate.ToString("dd/MM/yyyy"), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(emptyRow);

                    // Loan Reference Code
                    infoTable.AddCell(new PdfPCell(new Phrase("Loan Reference Code:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(new PdfPCell(new Phrase(refCode, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(emptyRow);

                    pdfDoc.Add(new Paragraph(" "));
                    // Client Information
                    infoTable.AddCell(new PdfPCell(new Phrase("Full Name:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(new PdfPCell(new Phrase(fullName, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))) { Border = iTextSharp.text.Rectangle.NO_BORDER });

                    infoTable.AddCell(new PdfPCell(new Phrase("Email:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(new PdfPCell(new Phrase(email, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))) { Border = iTextSharp.text.Rectangle.NO_BORDER });

                    infoTable.AddCell(new PdfPCell(new Phrase("Phone No:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(new PdfPCell(new Phrase(phoneNo, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))) { Border = iTextSharp.text.Rectangle.NO_BORDER });


                    infoTable.AddCell(emptyRow);
                    // Book Information
                    infoTable.AddCell(new PdfPCell(new Phrase("Book Title:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(new PdfPCell(new Phrase(bookTitle, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))) { Border = iTextSharp.text.Rectangle.NO_BORDER });

                    infoTable.AddCell(new PdfPCell(new Phrase("Author:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(new PdfPCell(new Phrase(author, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))) { Border = iTextSharp.text.Rectangle.NO_BORDER });

                    infoTable.AddCell(new PdfPCell(new Phrase("Genre:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(new PdfPCell(new Phrase(genre, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))) { Border = iTextSharp.text.Rectangle.NO_BORDER });

                    infoTable.AddCell(new PdfPCell(new Phrase("ISBN:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(new PdfPCell(new Phrase(isbn, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))) { Border = iTextSharp.text.Rectangle.NO_BORDER });

                    infoTable.AddCell(new PdfPCell(new Phrase("Price:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(new PdfPCell(new Phrase(price.ToString("C2"), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))) { Border = iTextSharp.text.Rectangle.NO_BORDER });

                    pdfDoc.Add(infoTable);

                    // Add some space before thank you note
                    pdfDoc.Add(new Paragraph(" "));

                    // Add thank you note
                    iTextSharp.text.Paragraph thankYouNote = new iTextSharp.text.Paragraph("Thank you for using our library services!", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14f, iTextSharp.text.Font.BOLDITALIC));
                    thankYouNote.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(thankYouNote);

                    // Close the document
                    pdfDoc.Close();
                }

                // Show a message indicating the PDF was saved successfully
                MessageBox.Show($"Loan receipt generated and saved to {filePath}", "Loan Receipt Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Notify if user cancels the file save process
                MessageBox.Show("File saving was canceled.", "Save Canceled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

using iTextSharp.text.pdf;
using iTextSharp.text;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LibraryManagementSystem
{
    public partial class ReservationForm : Form
    {
        public ReservationForm()
        {
            InitializeComponent();
            LoadAllReservations();
            LoadUsers();
            LoadBooks();
        }


        private void ReservationForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadAllReservations()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = @"SELECT 
                            Reservation.RefCode,
                            [User].Username,
                            Book.Title,
                            Reservation.ReservationDate,
                            Reservation.Status
                         FROM Reservation
                         JOIN [User] ON Reservation.UserID = [User].UserID
                         JOIN Book ON Reservation.BookID = Book.BookID";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable reservationTable = new DataTable();
                    adapter.Fill(reservationTable);
                    dgv.DataSource = reservationTable;
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



        private string GenerateReservationRefCode(SqlConnection connection, SqlTransaction transaction)
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

            // Kiểm tra và tạo mã mới
            if (!string.IsNullOrEmpty(latestRefCode) && latestRefCode.StartsWith("REFRS"))
            {
                // Tách phần số cuối cùng và tăng thêm 1
                int currentNumber = int.Parse(latestRefCode.Substring(5));
                int newNumber = currentNumber + 1;
                return $"REFRS{newNumber:D4}";
            }
            else
            {
                // Nếu chưa có mã nào, bắt đầu từ REFRS0001
                return "REFRS0001";
            }
        }

        private void btnPlaceHold_Click(object sender, EventArgs e)
        {
            if (cbbUsername.SelectedItem is KeyValuePair<int, string> selectedUser && cbbBookTitle.SelectedItem is KeyValuePair<int, string> selectedBook)
            {
                int userID = selectedUser.Key;
                int bookID = selectedBook.Key;
                DateTime reservationDate = dtpReservationDate.Value;
                string status = "cancelled";

                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

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
                            string refCode = GenerateReservationRefCode(connection, transaction);

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
                                    LoadAllReservations();

                                    // Generate PDF receipt
                                    ExportReservationReceiptToPdf(refCode, fullName, email, phoneNo, bookTitle, author, genre, isbn, status);
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


        private void LoadReservationDetails(string refCode)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = @"SELECT 
                            [User].Username,
                            Book.Title,
                            Book.ISBN,
                            Reservation.ReservationDate,
                            Reservation.Status
                         FROM Reservation
                         JOIN [User] ON Reservation.UserID = [User].UserID
                         JOIN Book ON Reservation.BookID = Book.BookID
                         WHERE Reservation.RefCode = @RefCode";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RefCode", refCode);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Điền thông tin vào các TextBox
                            txtUsername.Text = reader["Username"].ToString();
                            txtBookTitle.Text = reader["Title"].ToString();
                            txtISBN1.Text = reader["ISBN"].ToString();
                            dtpReservationDate1.Value = Convert.ToDateTime(reader["ReservationDate"]);
                            txtStatus.Text = reader["Status"].ToString();
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

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string refCode = txtRefCode.Text.Trim();

            if (string.IsNullOrEmpty(refCode))
            {
                MessageBox.Show("Please enter a valid RefCode.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadReservationDetails(refCode); // Gọi hàm để hiển thị thông tin
        }

        private void ClearFields()
        {
            txtUsername.Text = string.Empty;
            txtBookTitle.Text = string.Empty;
            txtISBN1.Text = string.Empty;
            txtStatus.Text = string.Empty;
            dtpReservationDate1.Value = DateTime.Now; // Đặt lại về ngày hiện tại
        }


        private void ExportReservationReceiptToPdf(string refCode, string fullName, string email, string phoneNo,
                                    string bookTitle, string author, string genre, string isbn, string status)
        {

            DateTime reservationDate = DateTime.Now;

            // Use SaveFileDialog to let the user choose where to save the file
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF file (*.pdf)|*.pdf",
                Title = "Save Reservation Receipt as PDF",
                FileName = $"ReservationReceipt_{refCode}.pdf"
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
                    iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("Reservation Receipt",
                        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18f, iTextSharp.text.Font.BOLD));
                    title.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(title);

                    // Add space between title and content
                    pdfDoc.Add(new Paragraph(" "));

                    // Add reservation information table
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

                    // Reservation Date
                    infoTable.AddCell(new PdfPCell(new Phrase("Reservation Date:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(new PdfPCell(new Phrase(reservationDate.ToString("dd/MM/yyyy"), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(emptyRow);

                    // Reservation Reference Code
                    infoTable.AddCell(new PdfPCell(new Phrase("Reservation RefCode:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(new PdfPCell(new Phrase(refCode, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(emptyRow);

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

                    // Status
                    infoTable.AddCell(new PdfPCell(new Phrase("Status:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD))) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    infoTable.AddCell(new PdfPCell(new Phrase(status, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f))) { Border = iTextSharp.text.Rectangle.NO_BORDER });

                    pdfDoc.Add(infoTable);

                    // Add some space before thank you note
                    pdfDoc.Add(new Paragraph(" "));

                    // Add thank you note
                    iTextSharp.text.Paragraph thankYouNote = new iTextSharp.text.Paragraph("Thank you for using our library services!",
                        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14f, iTextSharp.text.Font.BOLDITALIC));
                    thankYouNote.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(thankYouNote);

                    // Close the document
                    pdfDoc.Close();
                }

                // Show a message indicating the PDF was saved successfully
                MessageBox.Show($"Reservation receipt generated and saved to {filePath}", "Reservation Receipt Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Notify if user cancels the file save process
                MessageBox.Show("File saving was canceled.", "Save Canceled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}

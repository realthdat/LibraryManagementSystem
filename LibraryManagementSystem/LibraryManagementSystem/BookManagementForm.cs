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
    public partial class BookManagementForm : Form
    {
        private bool isEditMode = false;
        private string selectedISBN = string.Empty;

        public BookManagementForm()
        {
            InitializeComponent();
            LoadBooksToGridView();
            LoadGenre();
            LoadStatus();
        }

        private void ClearFields()
        {
            txtTitle.Text = string.Empty;
            txtAuthor.Text = string.Empty;
            txtPublicationYear.Text = string.Empty;
            cbbGenre.SelectedIndex = -1;
            txtISBN.Text = string.Empty;
            cbbStatus.SelectedIndex = -1;
            txtLocation.Text = string.Empty;
            txtTotalCopies.Text = string.Empty;
        }

        private void LoadGenre()
        {
            // Ví dụ về việc tải dữ liệu Genre tĩnh
            // Nếu cần tải từ cơ sở dữ liệu, thay thế danh sách này bằng câu lệnh SQL
            List<string> genres = new List<string> { "Dystopian", "Fiction", "Romance", "Classic", "Adventure" };

            cbbGenre.DataSource = genres;
        }

        private void LoadStatus()
        {
            // Ví dụ về việc tải dữ liệu Status tĩnh
            List<string> statuses = new List<string> { "Available", "Unavailable" };

            cbbStatus.DataSource = statuses;
        }

        private void LoadBooksToGridView()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT BookID, Title, Author, PublicationYear, Genre, ISBN, Status, Location, TotalCopies FROM Book";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable bookTable = new DataTable();
                    adapter.Fill(bookTable);
                    dgvBooks.DataSource = bookTable;  // dgvBooks là tên của DataGridView
                }
            }
        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem có hàng nào được chọn không
            {
                DataGridViewRow row = dgvBooks.Rows[e.RowIndex];

                // Điền dữ liệu từ hàng đã chọn vào các trường nhập liệu
                txtTitle.Text = row.Cells["Title"].Value.ToString();
                txtAuthor.Text = row.Cells["Author"].Value.ToString();
                txtPublicationYear.Text = row.Cells["PublicationYear"].Value.ToString();
                cbbGenre.SelectedItem = row.Cells["Genre"].Value.ToString();
                txtISBN.Text = row.Cells["ISBN"].Value.ToString();
                cbbStatus.SelectedItem = row.Cells["Status"].Value.ToString();
                txtLocation.Text = row.Cells["Location"].Value.ToString();
                txtTotalCopies.Text = row.Cells["TotalCopies"].Value.ToString();

                // Thiết lập giá trị cho ComboBox Genre
                string genre = row.Cells["Genre"].Value.ToString();
                cbbGenre.SelectedIndex = cbbGenre.FindStringExact(genre);

                // Thiết lập giá trị cho ComboBox Status
                string status = row.Cells["Status"].Value.ToString();
                cbbStatus.SelectedIndex = cbbStatus.FindStringExact(status);


                selectedISBN = row.Cells["ISBN"].Value.ToString();
                isEditMode = true; // Đặt isEditMode là true để biết đang ở chế độ chỉnh sửa
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedISBN)) // Kiểm tra xem có ISBN nào được chọn không
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this book?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    using (SqlConnection connection = DatabaseConnection.GetConnection())
                    {
                        connection.Open();
                        string deleteQuery = "DELETE FROM Book WHERE ISBN = @ISBN";
                        SqlCommand command = new SqlCommand(deleteQuery, connection);
                        command.Parameters.AddWithValue("@ISBN", selectedISBN);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                            LoadBooksToGridView(); // Làm mới DataGridView sau khi xóa
                            selectedISBN = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete book. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a book to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
            {
                return; // Stop if validation fails
            }

            string isbn = txtISBN.Text;
            string title = txtTitle.Text;
            string author = txtAuthor.Text;
            int publicationYear = int.Parse(txtPublicationYear.Text);
            string genre = cbbGenre.SelectedItem?.ToString();
            string status = cbbStatus.SelectedItem?.ToString();
            string location = txtLocation.Text;
            int totalCopies = int.Parse(txtTotalCopies.Text);

            // Kiểm tra nếu số lượng sách < 0
            if (totalCopies < 0)
            {
                MessageBox.Show("Total copies cannot be less than 0.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng lại nếu số lượng sách không hợp lệ
            }

            // Xác định trạng thái của sách dựa trên số lượng
            if (totalCopies > 0)
            {
                status = "available";
            }
            else
            {
                status = "unavailable";
            }

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                SqlCommand command;

                if (isEditMode && !string.IsNullOrEmpty(selectedISBN))
                {
                    // Cập nhật sách hiện có dựa trên ISBN
                    string updateQuery = "UPDATE Book SET Title = @Title, Author = @Author, PublicationYear = @PublicationYear, Genre = @Genre, Status = @Status, Location = @Location, TotalCopies = @TotalCopies WHERE ISBN = @ISBN";
                    command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@ISBN", selectedISBN);
                }
                else
                {
                    // Thêm mới một cuốn sách
                    string insertQuery = "INSERT INTO Book (ISBN, Title, Author, PublicationYear, Genre, Status, Location, TotalCopies) VALUES (@ISBN, @Title, @Author, @PublicationYear, @Genre, @Status, @Location, @TotalCopies)";
                    command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@ISBN", isbn);
                }

                // Gán giá trị các tham số còn lại
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Author", author);
                command.Parameters.AddWithValue("@PublicationYear", publicationYear);
                command.Parameters.AddWithValue("@Genre", genre);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@Location", location);
                command.Parameters.AddWithValue("@TotalCopies", totalCopies);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Book saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadBooksToGridView(); // Làm mới DataGridView sau khi lưu
                    isEditMode = false;
                    selectedISBN = string.Empty;
                }
                else
                {
                    MessageBox.Show("Failed to save book. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0) // Kiểm tra nếu có hàng nào được chọn
            {
                DataGridViewRow selectedRow = dgvBooks.SelectedRows[0]; // Lấy hàng đã chọn

                // Điền dữ liệu từ hàng đã chọn vào các trường trên form
                txtTitle.Text = selectedRow.Cells["Title"].Value.ToString();
                txtAuthor.Text = selectedRow.Cells["Author"].Value.ToString();
                txtPublicationYear.Text = selectedRow.Cells["PublicationYear"].Value.ToString();
                cbbGenre.SelectedItem = selectedRow.Cells["Genre"].Value.ToString();
                txtISBN.Text = selectedRow.Cells["ISBN"].Value.ToString();
                cbbStatus.SelectedItem = selectedRow.Cells["Status"].Value.ToString();
                txtLocation.Text = selectedRow.Cells["Location"].Value.ToString();
                txtTotalCopies.Text = selectedRow.Cells["TotalCopies"].Value.ToString();

                // Lưu ISBN của sách đang được chỉnh sửa
                selectedISBN = selectedRow.Cells["ISBN"].Value.ToString();

                // Đặt isEditMode thành true để xác định đang ở chế độ chỉnh sửa
                isEditMode = true;
            }
            else
            {
                MessageBox.Show("Please select a book to edit.", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Xóa toàn bộ các trường để nhập thông tin sách mới
            ClearFields();

            // Đặt isEditMode thành false để cho biết đây là thao tác thêm mới
            isEditMode = false;

            // Đặt selectedISBN là rỗng, vì chúng ta đang thêm sách mới
            selectedISBN = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private bool ValidateFields()
        {
            // Title Validation
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitle.Focus();
                return false;
            }

            // Author Validation
            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Author is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAuthor.Focus();
                return false;
            }

            // Publication Year Validation
            if (!int.TryParse(txtPublicationYear.Text, out int publicationYear) || publicationYear < 0 || publicationYear > DateTime.Now.Year)
            {
                MessageBox.Show("Please enter a valid Publication Year.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPublicationYear.Focus();
                return false;
            }

            // Genre Validation
            if (cbbGenre.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Genre.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbGenre.Focus();
                return false;
            }

            // ISBN Validation
            if (string.IsNullOrWhiteSpace(txtISBN.Text) || txtISBN.Text.Length != 13)
            {
                MessageBox.Show("ISBN must be 13 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtISBN.Focus();
                return false;
            }

            // Status Validation
            if (cbbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbStatus.Focus();
                return false;
            }

            // Location Validation
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Location is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocation.Focus();
                return false;
            }

            // Total Copies Validation
            if (!int.TryParse(txtTotalCopies.Text, out int totalCopies) || totalCopies < 0)
            {
                MessageBox.Show("Please enter a valid number for Total Copies.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTotalCopies.Focus();
                return false;
            }

            return true; // All validations passed
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvBooks.Rows.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV (*.csv)|*.csv";
                    sfd.FileName = "Books.csv";
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
                                int columnCount = dgvBooks.Columns.Count;
                                string columnNames = "";
                                string[] outputCsv = new string[dgvBooks.Rows.Count + 1];

                                // Add column headers
                                for (int i = 0; i < columnCount; i++)
                                {
                                    columnNames += dgvBooks.Columns[i].HeaderText.ToString() + ",";
                                }
                                outputCsv[0] = columnNames.TrimEnd(',');

                                // Add rows data
                                for (int i = 1; (i - 1) < dgvBooks.Rows.Count; i++)
                                {
                                    string rowText = "";
                                    for (int j = 0; j < columnCount; j++)
                                    {
                                        var cellValue = dgvBooks.Rows[i - 1].Cells[j].Value;
                                        rowText += (cellValue != null ? cellValue.ToString() : "") + ",";
                                    }
                                    outputCsv[i] = rowText.TrimEnd(',');
                                }

                                File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                                MessageBox.Show("Data Exported Successfully!", "Info");
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
                MessageBox.Show("No Record To Export!", "Info");
            }
        }
    }
}

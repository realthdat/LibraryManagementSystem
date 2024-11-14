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
    public partial class ManageReservation : Form
    {

        private bool isEditMode = false;
        private string selectedRefCode;

        public ManageReservation()
        {
            InitializeComponent();
            LoadReservationsToGridView();
            LoadUsers();
            LoadBooks();
            LoadStatus();

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
                        var bookList = new List<KeyValuePair<int, string>>();
                        while (reader.Read())
                        {
                            bookList.Add(new KeyValuePair<int, string>((int)reader["BookID"], reader["Title"].ToString()));
                        }
                        cbbBook.DataSource = new BindingSource(bookList, null);
                        cbbBook.DisplayMember = "Value";
                        cbbBook.ValueMember = "Key";
                    }
                }
            }
        }

        private void LoadStatus()
        {
            List<string> statuses = new List<string> { "active", "completed", "canceled" };
            cbbStatus.DataSource = statuses;
        }

        private void LoadReservationsToGridView()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT ReservationID, UserID, BookID, ReservationDate, Status, RefCode FROM Reservation";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable reservationTable = new DataTable();
                    adapter.Fill(reservationTable);
                    dgvReservation.DataSource = reservationTable;
                }
            }
        }


        private void ClearFields()
        {
            cbbUser.SelectedIndex = -1;
            cbbBook.SelectedIndex = -1;
            dtpReservationDate.Value = DateTime.Now;
            cbbStatus.SelectedIndex = -1;
            txtRefCode.Text = string.Empty;
            isEditMode = false;
            selectedRefCode = string.Empty;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearFields();
            isEditMode = false;
            txtRefCode.Text = GenerateRefCode(DatabaseConnection.GetConnection(), null);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvReservation.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvReservation.SelectedRows[0];

                cbbUser.SelectedValue = selectedRow.Cells["UserID"].Value;
                cbbBook.SelectedValue = selectedRow.Cells["BookID"].Value;
                dtpReservationDate.Value = Convert.ToDateTime(selectedRow.Cells["ReservationDate"].Value);
                cbbStatus.SelectedItem = selectedRow.Cells["Status"].Value.ToString();
                txtRefCode.Text = selectedRow.Cells["RefCode"].Value.ToString();

                selectedRefCode = txtRefCode.Text;
                isEditMode = true;
            }
            else
            {
                MessageBox.Show("Please select a reservation to edit.", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int userID = ((KeyValuePair<int, string>)cbbUser.SelectedItem).Key;
            int bookID = ((KeyValuePair<int, string>)cbbBook.SelectedItem).Key;
            DateTime reservationDate = dtpReservationDate.Value;
            string refCode = txtRefCode.Text;
            string status = cbbStatus.SelectedItem?.ToString();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                SqlCommand command;

                if (isEditMode)
                {
                    string updateQuery = "UPDATE Reservation SET UserID = @UserID, BookID = @BookID, ReservationDate = @ReservationDate, Status = @Status WHERE RefCode = @RefCode";
                    command = new SqlCommand(updateQuery, connection);
                }
                else
                {
                    string insertQuery = "INSERT INTO Reservation (UserID, BookID, ReservationDate, Status, RefCode) VALUES (@UserID, @BookID, @ReservationDate, @Status, @RefCode)";
                    command = new SqlCommand(insertQuery, connection);
                }

                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@BookID", bookID);
                command.Parameters.AddWithValue("@ReservationDate", reservationDate);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@RefCode", refCode);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Reservation saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadReservationsToGridView();
                }
                else
                {
                    MessageBox.Show("Failed to save reservation. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedRefCode))
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this reservation?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    using (SqlConnection connection = DatabaseConnection.GetConnection())
                    {
                        connection.Open();
                        string deleteQuery = "DELETE FROM Reservation WHERE RefCode = @RefCode";
                        SqlCommand command = new SqlCommand(deleteQuery, connection);
                        command.Parameters.AddWithValue("@RefCode", selectedRefCode);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Reservation deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadReservationsToGridView();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete reservation. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a reservation to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvReservation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvReservation.Rows[e.RowIndex];

                cbbUser.SelectedValue = selectedRow.Cells["UserID"].Value;
                cbbBook.SelectedValue = selectedRow.Cells["BookID"].Value;
                dtpReservationDate.Value = Convert.ToDateTime(selectedRow.Cells["ReservationDate"].Value);
                cbbStatus.SelectedItem = selectedRow.Cells["Status"].Value.ToString();
                txtRefCode.Text = selectedRow.Cells["RefCode"].Value.ToString();

                selectedRefCode = txtRefCode.Text;
                isEditMode = true;
            }
        }

        private void ManageReservation_Load(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvReservation.Rows.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV (*.csv)|*.csv";
                    sfd.FileName = "Reservations.csv";
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
                                int columnCount = dgvReservation.Columns.Count;
                                string columnNames = "";
                                string[] outputCsv = new string[dgvReservation.Rows.Count + 1];

                                // Get column headers
                                for (int i = 0; i < columnCount; i++)
                                {
                                    columnNames += dgvReservation.Columns[i].HeaderText.ToString() + ",";
                                }
                                outputCsv[0] = columnNames.TrimEnd(',');

                                // Get rows data
                                for (int i = 1; (i - 1) < dgvReservation.Rows.Count; i++)
                                {
                                    string rowText = "";
                                    for (int j = 0; j < columnCount; j++)
                                    {
                                        var cellValue = dgvReservation.Rows[i - 1].Cells[j].Value;
                                        rowText += (cellValue != null ? cellValue.ToString() : "") + ",";
                                    }
                                    outputCsv[i] = rowText.TrimEnd(',');
                                }

                                File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                                MessageBox.Show("Reservations exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

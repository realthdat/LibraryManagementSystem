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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            LoadReportsToGridView();
            LoadReportTypes();
        }

        private void LoadReportTypes()
        {
            cbbReportType.Items.Add("daily");
            cbbReportType.Items.Add("weekly");
            cbbReportType.Items.Add("monthly");
        }

        private void LoadReportsToGridView()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT ReportID, ReportDate, ReportType, TotalLoans, TotalReservations, TotalUsers FROM Report";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable reportTable = new DataTable();
                    adapter.Fill(reportTable);
                    dgvReports.DataSource = reportTable;
                }
            }
        }


        private int GetTotalLoans(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Loan WHERE LoanDate BETWEEN @StartDate AND @EndDate";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    return (int)command.ExecuteScalar();
                }
            }
        }

        private int GetTotalReservations(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Reservation WHERE ReservationDate BETWEEN @StartDate AND @EndDate";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    return (int)command.ExecuteScalar();
                }
            }
        }

        private int GetTotalUsers()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM [User]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;
            string reportType = cbbReportType.SelectedItem?.ToString();

            int totalLoans = GetTotalLoans(startDate, endDate);
            int totalReservations = GetTotalReservations(startDate, endDate);
            int totalUsers = GetTotalUsers();

            txtTotalLoans.Text = totalLoans.ToString();
            txtTotalReservations.Text = totalReservations.ToString();
            txtTotalUsers.Text = totalUsers.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime reportDate = DateTime.Now;
            string reportType = cbbReportType.SelectedItem?.ToString();
            int totalLoans = int.Parse(txtTotalLoans.Text);
            int totalReservations = int.Parse(txtTotalReservations.Text);
            int totalUsers = int.Parse(txtTotalUsers.Text);

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string insertQuery = "INSERT INTO Report (ReportDate, ReportType, TotalLoans, TotalReservations, TotalUsers) VALUES (@ReportDate, @ReportType, @TotalLoans, @TotalReservations, @TotalUsers)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@ReportDate", reportDate);
                    command.Parameters.AddWithValue("@ReportType", reportType);
                    command.Parameters.AddWithValue("@TotalLoans", totalLoans);
                    command.Parameters.AddWithValue("@TotalReservations", totalReservations);
                    command.Parameters.AddWithValue("@TotalUsers", totalUsers);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Report saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadReportsToGridView();
                    }
                    else
                    {
                        MessageBox.Show("Failed to save report. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the selected cell is not a header cell
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgvReports.Rows[e.RowIndex];

                // Populate the form fields with data from the selected row
                dtpReportDate.Value = Convert.ToDateTime(selectedRow.Cells["ReportDate"].Value);

                // Update ComboBox selection based on the ReportType value
                string reportType = selectedRow.Cells["ReportType"].Value.ToString();
                if (cbbReportType.Items.Contains(reportType))
                {
                    cbbReportType.SelectedItem = reportType;
                }
                else
                {
                    MessageBox.Show("Report type not found in ComboBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                txtTotalLoans.Text = selectedRow.Cells["TotalLoans"].Value.ToString();
                txtTotalReservations.Text = selectedRow.Cells["TotalReservations"].Value.ToString();
                txtTotalUsers.Text = selectedRow.Cells["TotalUsers"].Value.ToString();


            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvReports.Rows.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV (*.csv)|*.csv";
                    sfd.FileName = "ReportData.csv";
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
                                int columnCount = dgvReports.Columns.Count;
                                string columnNames = "";
                                string[] outputCsv = new string[dgvReports.Rows.Count + 1];

                                // Get column headers
                                for (int i = 0; i < columnCount; i++)
                                {
                                    columnNames += dgvReports.Columns[i].HeaderText.ToString() + ",";
                                }
                                outputCsv[0] = columnNames.TrimEnd(',');

                                // Get rows data
                                for (int i = 1; (i - 1) < dgvReports.Rows.Count; i++)
                                {
                                    string rowText = "";
                                    for (int j = 0; j < columnCount; j++)
                                    {
                                        var cellValue = dgvReports.Rows[i - 1].Cells[j].Value;
                                        rowText += (cellValue != null ? cellValue.ToString() : "") + ",";
                                    }
                                    outputCsv[i] = rowText.TrimEnd(',');
                                }

                                // Write to file
                                File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                                MessageBox.Show("Report data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

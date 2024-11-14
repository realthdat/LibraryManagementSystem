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
    public partial class YourReservation : Form
    {
        private string username;

        public YourReservation(string username)
        {
            InitializeComponent();
            this.username = username;
            LoadReservationsByUsername(username);
        }

        private void dgvLoans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void LoadReservationsByUsername(string username)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = @"SELECT 
                            Reservation.RefCode,
                            [User].Username,
                            Book.Title AS BookTitle,
                            Book.ISBN,
                            Reservation.ReservationDate,
                            Reservation.Status
                         FROM Reservation
                         JOIN [User] ON Reservation.UserID = [User].UserID
                         JOIN Book ON Reservation.BookID = Book.BookID
                         WHERE [User].Username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable reservationTable = new DataTable();
                        adapter.Fill(reservationTable);
                        dgvReservation.DataSource = reservationTable; // dgvReservations là DataGridView hiển thị danh sách Reservation
                    }
                }
            }
        }
    }
}

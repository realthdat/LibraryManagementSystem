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
    public partial class YourLoan : Form
    {

        private string username;

        public YourLoan(string username)
        {
            InitializeComponent();
            this.username = username;

            LoadLoansByUsername(username);
        }


        private void LoadLoansByUsername(string username)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = @"SELECT 
                            Loan.RefCode,
                            [User].Username,
                            Book.Title AS BookTitle,
                            Book.ISBN,
                            Loan.LoanDate,
                            Loan.ReturnDate,
                            Loan.ActualReturnDate,
                            Loan.Fine,
                            Loan.Status
                         FROM Loan
                         JOIN [User] ON Loan.UserID = [User].UserID
                         JOIN Book ON Loan.BookID = Book.BookID
                         WHERE [User].Username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable loanTable = new DataTable();
                        adapter.Fill(loanTable);
                        dgvLoans.DataSource = loanTable;
                    }
                }
            }
        }

    }
}

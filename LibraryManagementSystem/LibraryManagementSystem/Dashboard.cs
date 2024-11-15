using FastReport.DataVisualization.Charting;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Dashboard : Form
    {

        public Dashboard()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            // Retrieve data for loans and reservations
            int totalLoansToday = GetTotalCount("Loan", "LoanDate", true);
            int totalLoansAllTime = GetTotalCount("Loan", "LoanDate", false);
            int totalReservationsToday = GetTotalCount("Reservation", "ReservationDate", true);
            int totalReservationsAllTime = GetTotalCount("Reservation", "ReservationDate", false);

            // Generate and display charts
            GenerateLoanChart(totalLoansToday, totalLoansAllTime);
            GenerateReservationChart(totalReservationsToday, totalReservationsAllTime);
        }

        private int GetTotalCount(string tableName, string dateColumn, bool isToday)
        {
            int count = 0;
            string query = isToday ?
                $"SELECT COUNT(*) FROM {tableName} WHERE CAST({dateColumn} AS DATE) = CAST(GETDATE() AS DATE)" :
                $"SELECT COUNT(*) FROM {tableName}";

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    count = (int)command.ExecuteScalar();
                }
            }
            return count;
        }

        private void GenerateLoanChart(int todayCount, int allTimeCount)
        {
            // Clear previous data
            loanChartViewer.Series.Clear();
            loanChartViewer.ChartAreas.Clear();

            // Set up chart area for pie chart
            ChartArea loanArea = new ChartArea("LoanArea");
            loanChartViewer.ChartAreas.Add(loanArea);
            loanChartViewer.Titles.Clear();
            loanChartViewer.Titles.Add("Loan Overview");

            // Create and configure series for pie chart
            Series loanSeries = new Series
            {
                ChartType = SeriesChartType.Pie,
                ChartArea = "LoanArea",
                Name = "LoanData"
            };

            // Adding data points with labels
            loanSeries.Points.Add(new DataPoint
            {
                AxisLabel = "Today",
                YValues = new double[] { todayCount },
                Label = $"Today: {todayCount}"
            });

            loanSeries.Points.Add(new DataPoint
            {
                AxisLabel = "All Time",
                YValues = new double[] { allTimeCount },
                Label = $"All Time: {allTimeCount}"
            });

            loanChartViewer.Series.Add(loanSeries);
            loanChartViewer.Invalidate(); // Refresh the chart
        }

        private void GenerateReservationChart(int todayCount, int allTimeCount)
        {
            // Clear previous data
            reservationChartViewer.Series.Clear();
            reservationChartViewer.ChartAreas.Clear();

            // Set up chart area for bar chart
            ChartArea reservationArea = new ChartArea("ReservationArea");
            reservationChartViewer.ChartAreas.Add(reservationArea);
            reservationChartViewer.Titles.Clear();
            reservationChartViewer.Titles.Add("Reservation Overview");

            // Create and configure series for bar chart
            Series reservationSeries = new Series
            {
                ChartType = SeriesChartType.Bar,
                ChartArea = "ReservationArea",
                Name = "ReservationData",
                IsValueShownAsLabel = true // Display value as label
            };

            // Adding data points with labels
            reservationSeries.Points.Add(new DataPoint
            {
                AxisLabel = "Today",
                YValues = new double[] { todayCount },
                Label = $"Today: {todayCount}"
            });

            reservationSeries.Points.Add(new DataPoint
            {
                AxisLabel = "All Time",
                YValues = new double[] { allTimeCount },
                Label = $"All Time: {allTimeCount}"
            });

            reservationChartViewer.Series.Add(reservationSeries);
            reservationChartViewer.Invalidate(); // Refresh the chart
        }
    }
}

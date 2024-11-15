using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class ReaderForm : Form
    {
        private Form activeForm = null;

        private string username;

        public ReaderForm(string username)
        {
            InitializeComponent();
            this.username = username;

            lblWelcomeBack.Text = $"Welcome back, {username}!";
        }

        private void openForm(Form newForm)
        {
            if (activeForm != null) { activeForm.Close(); }
            activeForm = newForm;
            newForm.TopLevel = false;
            newForm.Dock = DockStyle.Fill;
            newForm.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(newForm);
            newForm.BringToFront();
            newForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra nếu người dùng chọn "Yes"
            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide(); // Ẩn form hiện tại
            }
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            openForm(new UserProfileForm(username));
        }

        private void btnYourLoan_Click(object sender, EventArgs e)
        {
            openForm(new YourLoan(username));
        }

        private void btnYourReservation_Click(object sender, EventArgs e)
        {
            openForm(new YourReservation(username));
        }

        private void lblWelcomeBack_Click(object sender, EventArgs e)
        {

        }

        private void btnRequestBorrow_Click(object sender, EventArgs e)
        {
            openForm(new BorrowRequest(username));
        }

        private void btnRequestReservation_Click(object sender, EventArgs e)
        {
            openForm(new ReservationRequest(username));
        }
    }
}

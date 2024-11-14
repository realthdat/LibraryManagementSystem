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
    public partial class UserForm : Form
    {

        private Form activeForm = null;
        private string username;

        public UserForm(string username)
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


        private void btnBorrow_Click(object sender, EventArgs e)
        {
            openForm(new LoanForm());
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            openForm(new ReservationForm());
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            openForm(new ReturnForm());
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            openForm(new UserProfileForm(username));
        }

        private void btnLogout_Click(object sender, EventArgs e)
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
    }
}

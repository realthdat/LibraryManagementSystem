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
    public partial class AdminForm : Form
    {

        private Form activeForm = null;

        public AdminForm()
        {
            InitializeComponent();
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            openForm(new Dashboard());
        }

        private void btnManageUser_Click(object sender, EventArgs e)
        {
            openForm(new UserManagementForm());
        }

        private void btnInventory_Click_1(object sender, EventArgs e)
        {
            openForm(new BookManagementForm());
        }

        private void btnManageLoan_Click(object sender, EventArgs e)
        {
            openForm(new ManageLoan());
        }

        private void btnManageReservation_Click(object sender, EventArgs e)
        {
            openForm(new ManageReservation());
        }

        private void btnManageReport_Click(object sender, EventArgs e)
        {
            openForm(new Report());
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

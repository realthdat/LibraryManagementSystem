namespace LibraryManagementSystem
{
    partial class Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            dgvReports = new DataGridView();
            panel2 = new Panel();
            dtpReportDate = new DateTimePicker();
            label6 = new Label();
            label5 = new Label();
            txtTotalUsers = new TextBox();
            label4 = new Label();
            txtTotalReservations = new TextBox();
            label8 = new Label();
            txtTotalLoans = new TextBox();
            label1 = new Label();
            cbbReportType = new ComboBox();
            dtpStartDate = new DateTimePicker();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            dtpEndDate = new DateTimePicker();
            label2 = new Label();
            btnExport = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvReports);
            panel1.Location = new Point(17, 51);
            panel1.Name = "panel1";
            panel1.Size = new Size(526, 273);
            panel1.TabIndex = 0;
            // 
            // dgvReports
            // 
            dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReports.Location = new Point(13, 15);
            dgvReports.Name = "dgvReports";
            dgvReports.Size = new Size(500, 242);
            dgvReports.TabIndex = 0;
            dgvReports.CellContentClick += dgvReports_CellContentClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(dtpReportDate);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtTotalUsers);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtTotalReservations);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtTotalLoans);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(cbbReportType);
            panel2.Location = new Point(549, 51);
            panel2.Name = "panel2";
            panel2.Size = new Size(293, 273);
            panel2.TabIndex = 1;
            // 
            // dtpReportDate
            // 
            dtpReportDate.Location = new Point(13, 97);
            dtpReportDate.Name = "dtpReportDate";
            dtpReportDate.Size = new Size(260, 23);
            dtpReportDate.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 70);
            label6.Name = "label6";
            label6.Size = new Size(69, 15);
            label6.TabIndex = 44;
            label6.Text = "Report Date";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 149);
            label5.Name = "label5";
            label5.Size = new Size(66, 15);
            label5.TabIndex = 43;
            label5.Text = "Total Users ";
            // 
            // txtTotalUsers
            // 
            txtTotalUsers.Location = new Point(120, 146);
            txtTotalUsers.Name = "txtTotalUsers";
            txtTotalUsers.Size = new Size(151, 23);
            txtTotalUsers.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 241);
            label4.Name = "label4";
            label4.Size = new Size(104, 15);
            label4.TabIndex = 41;
            label4.Text = "Total Reservations ";
            // 
            // txtTotalReservations
            // 
            txtTotalReservations.Location = new Point(119, 238);
            txtTotalReservations.Name = "txtTotalReservations";
            txtTotalReservations.Size = new Size(151, 23);
            txtTotalReservations.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(9, 194);
            label8.Name = "label8";
            label8.Size = new Size(69, 15);
            label8.TabIndex = 37;
            label8.Text = "Total Loans ";
            // 
            // txtTotalLoans
            // 
            txtTotalLoans.Location = new Point(119, 191);
            txtTotalLoans.Name = "txtTotalLoans";
            txtTotalLoans.Size = new Size(151, 23);
            txtTotalLoans.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 30);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 1;
            label1.Text = "Report Type";
            // 
            // cbbReportType
            // 
            cbbReportType.FormattingEnabled = true;
            cbbReportType.Location = new Point(106, 27);
            cbbReportType.Name = "cbbReportType";
            cbbReportType.Size = new Size(166, 23);
            cbbReportType.TabIndex = 1;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(549, 374);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(260, 23);
            dtpStartDate.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(549, 347);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 34;
            label3.Text = "Start Date";
            // 
            // button1
            // 
            button1.Location = new Point(30, 357);
            button1.Name = "button1";
            button1.Size = new Size(111, 47);
            button1.TabIndex = 8;
            button1.Text = "Generate Report";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(179, 357);
            button2.Name = "button2";
            button2.Size = new Size(111, 47);
            button2.TabIndex = 9;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(549, 442);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(260, 23);
            dtpEndDate.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(549, 415);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 36;
            label2.Text = "End Date";
            // 
            // btnExport
            // 
            btnExport.Location = new Point(419, 357);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(111, 47);
            btnExport.TabIndex = 37;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // Report
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(857, 504);
            Controls.Add(btnExport);
            Controls.Add(dtpEndDate);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dtpStartDate);
            Controls.Add(label3);
            Name = "Report";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Report";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvReports;
        private Panel panel2;
        private Label label1;
        private ComboBox cbbReportType;
        private Button button1;
        private Button button2;
        private Label label5;
        private TextBox txtTotalUsers;
        private Label label4;
        private TextBox txtTotalReservations;
        private Label label8;
        private TextBox txtTotalLoans;
        private DateTimePicker dtpStartDate;
        private Label label3;
        private DateTimePicker dtpReportDate;
        private Label label6;
        private DateTimePicker dtpEndDate;
        private Label label2;
        private Button btnExport;
    }
}
namespace LibraryManagementSystem
{
    partial class YourReservation
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
            label1 = new Label();
            dgvReservation = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReservation).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(219, 30);
            label1.Name = "label1";
            label1.Size = new Size(267, 28);
            label1.TabIndex = 3;
            label1.Text = "YOUR RESERVATION DETAILS";
            label1.Click += label1_Click;
            // 
            // dgvReservation
            // 
            dgvReservation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservation.Location = new Point(50, 93);
            dgvReservation.Name = "dgvReservation";
            dgvReservation.Size = new Size(605, 331);
            dgvReservation.TabIndex = 2;
            dgvReservation.CellContentClick += dgvLoans_CellContentClick;
            // 
            // YourReservation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(769, 450);
            Controls.Add(label1);
            Controls.Add(dgvReservation);
            Name = "YourReservation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "YourReservation";
            ((System.ComponentModel.ISupportInitialize)dgvReservation).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvReservation;
    }
}
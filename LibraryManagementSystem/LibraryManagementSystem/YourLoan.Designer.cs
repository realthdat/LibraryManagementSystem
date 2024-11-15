namespace LibraryManagementSystem
{
    partial class YourLoan
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
            dgvLoans = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLoans).BeginInit();
            SuspendLayout();
            // 
            // dgvLoans
            // 
            dgvLoans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLoans.Location = new Point(50, 93);
            dgvLoans.Name = "dgvLoans";
            dgvLoans.Size = new Size(605, 331);
            dgvLoans.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(255, 30);
            label1.Name = "label1";
            label1.Size = new Size(195, 28);
            label1.TabIndex = 1;
            label1.Text = "YOUR LOAN DETAILS";
            // 
            // YourLoan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(769, 450);
            Controls.Add(label1);
            Controls.Add(dgvLoans);
            Name = "YourLoan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "YourLoan";
            ((System.ComponentModel.ISupportInitialize)dgvLoans).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLoans;
        private Label label1;
    }
}
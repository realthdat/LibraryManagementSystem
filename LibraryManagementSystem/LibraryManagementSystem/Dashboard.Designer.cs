namespace LibraryManagementSystem
{
    partial class Dashboard
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
            loanChartViewer = new FastReport.DataVisualization.Charting.Chart();
            reservationChartViewer = new FastReport.DataVisualization.Charting.Chart();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)loanChartViewer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reservationChartViewer).BeginInit();
            SuspendLayout();
            // 
            // loanChartViewer
            // 
            loanChartViewer.Location = new Point(94, 79);
            loanChartViewer.Name = "loanChartViewer";
            loanChartViewer.Size = new Size(300, 300);
            loanChartViewer.TabIndex = 0;
            loanChartViewer.Text = "chart1";
            // 
            // reservationChartViewer
            // 
            reservationChartViewer.Location = new Point(480, 79);
            reservationChartViewer.Name = "reservationChartViewer";
            reservationChartViewer.Size = new Size(300, 300);
            reservationChartViewer.TabIndex = 1;
            reservationChartViewer.Text = "chart2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(162, 416);
            label1.Name = "label1";
            label1.Size = new Size(164, 28);
            label1.TabIndex = 2;
            label1.Text = "LOAN PIE CHART ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(507, 416);
            label2.Name = "label2";
            label2.Size = new Size(246, 28);
            label2.TabIndex = 3;
            label2.Text = "RESERVATION BAR CHART ";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(863, 545);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(reservationChartViewer);
            Controls.Add(loanChartViewer);
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)loanChartViewer).EndInit();
            ((System.ComponentModel.ISupportInitialize)reservationChartViewer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FastReport.DataVisualization.Charting.Chart loanChartViewer;
        private FastReport.DataVisualization.Charting.Chart reservationChartViewer;
        private Label label1;
        private Label label2;
    }
}
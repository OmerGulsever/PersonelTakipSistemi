namespace Personel_Kayıt
{
    partial class frmReports
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
            this.reportViewerXX = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerXX
            // 
            this.reportViewerXX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerXX.LocalReport.ReportEmbeddedResource = "Personel_Kayıt.Report1.rdlc";
            this.reportViewerXX.Location = new System.Drawing.Point(0, 0);
            this.reportViewerXX.Name = "reportViewerXX";
            this.reportViewerXX.ServerReport.BearerToken = null;
            this.reportViewerXX.Size = new System.Drawing.Size(895, 534);
            this.reportViewerXX.TabIndex = 0;
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 534);
            this.Controls.Add(this.reportViewerXX);
            this.Name = "frmReports";
            this.Text = "frmReports";
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerXX;
    }
}
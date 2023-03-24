namespace DistributionManager
{
    partial class DraftDistributionRequests
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
            this.draftDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.draftDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // draftDataGridView
            // 
            this.draftDataGridView.AllowUserToOrderColumns = true;
            this.draftDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.draftDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.draftDataGridView.Location = new System.Drawing.Point(0, 0);
            this.draftDataGridView.Name = "draftDataGridView";
            this.draftDataGridView.Size = new System.Drawing.Size(800, 450);
            this.draftDataGridView.TabIndex = 0;
            // 
            // DraftDistributionRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.draftDataGridView);
            this.Name = "DraftDistributionRequests";
            this.Text = "DraftDistributionRequests";
            this.Load += new System.EventHandler(this.DraftDistributionRequests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.draftDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView draftDataGridView;
    }
}
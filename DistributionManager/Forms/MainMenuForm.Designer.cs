
namespace DistributionManager
{
    partial class MainMenuForm
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
            this.newDistributionRequestBtn = new System.Windows.Forms.Button();
            this.showDraftRequestsBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newDistributionRequestBtn
            // 
            this.newDistributionRequestBtn.Location = new System.Drawing.Point(341, 44);
            this.newDistributionRequestBtn.Name = "newDistributionRequestBtn";
            this.newDistributionRequestBtn.Size = new System.Drawing.Size(133, 64);
            this.newDistributionRequestBtn.TabIndex = 2;
            this.newDistributionRequestBtn.Text = "New Distribution Request";
            this.newDistributionRequestBtn.UseVisualStyleBackColor = true;
            this.newDistributionRequestBtn.Click += new System.EventHandler(this.NewDistributionRequestBtn_Click);
            // 
            // showDraftRequestsBtn
            // 
            this.showDraftRequestsBtn.Location = new System.Drawing.Point(341, 156);
            this.showDraftRequestsBtn.Name = "showDraftRequestsBtn";
            this.showDraftRequestsBtn.Size = new System.Drawing.Size(133, 64);
            this.showDraftRequestsBtn.TabIndex = 3;
            this.showDraftRequestsBtn.Text = "Draft Distribution Requests";
            this.showDraftRequestsBtn.UseVisualStyleBackColor = true;
            this.showDraftRequestsBtn.Click += new System.EventHandler(this.ShowDraftRequestsBtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(341, 272);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 64);
            this.button3.TabIndex = 4;
            this.button3.Text = "Completed Distribution Request";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.showDraftRequestsBtn);
            this.Controls.Add(this.newDistributionRequestBtn);
            this.Name = "MainMenuForm";
            this.Text = "MainMenuForm";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button newDistributionRequestBtn;
        private System.Windows.Forms.Button showDraftRequestsBtn;
        private System.Windows.Forms.Button button3;
    }
}
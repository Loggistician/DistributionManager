using System;
using System.Windows.Forms;

namespace DistributionManager
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void NewDistributionRequestBtn_Click(object sender, EventArgs e)
        {
            new RecipientSelectionForm().Show();
            Hide();
        }

        private void ShowDraftRequestsBtn_Click(object sender, EventArgs e)
        {
            new DraftRequestsForm().Show();
        }
    }
}

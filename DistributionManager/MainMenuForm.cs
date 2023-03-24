using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            new RecipientSelection().Show();
            Hide();
        }

        private void ShowDraftRequestsBtn_Click(object sender, EventArgs e)
        {
            new DraftDistributionRequests().Show();
        }
    }
}

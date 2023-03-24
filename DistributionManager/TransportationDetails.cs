using System;
using System.Windows.Forms;

namespace DistributionManager
{
    public partial class TransportationDetails : Form
    {
        public TransportationDetails()
        {
            InitializeComponent();
        }

        private void Yes_CheckedChanged(object sender, EventArgs e)
        {
            factualDeliveryLbl.Visible = true;
            factualDeliveryAddressTextBox.Visible = true;
        }

        private void Transportation_Details_Load(object sender, EventArgs e)
        {
            deliveryTextBox.Visible = false;
            factualDeliveryLbl.Visible = false;
            factualDeliveryAddressTextBox.Visible = false;
        }

        private void OtherRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            deliveryTextBox.Visible = true;
        }
    }
}

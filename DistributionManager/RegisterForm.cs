using DistributionManager.Connection;
using System;
using System.Windows.Forms;

namespace DistributionManager
{
    public partial class RegisterForm : Form
    {
        public static string Email { get; set; }

        public RegisterForm()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await Connector.Sql_Connection.OpenAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            //Email = emailBox.Text; TODO
            Email = "test@gmail.com";
        }

        private void nameLbl_Click(object sender, EventArgs e)
        {

        }
    }
}

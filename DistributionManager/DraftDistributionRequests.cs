using DistributionManager.Connection;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DistributionManager
{
    public partial class DraftDistributionRequests : Form
    {
        public DraftDistributionRequests()
        {
            InitializeComponent();
        }

        private void FillGridWithDraftsByUserEmail(string email)
        {
            SqlCommand allDraftsCommand = new SqlCommand($"SELECT RequestNumber, Status FROM DistributionRequest INNER JOIN Employee ON DistributionRequest.EmployeeId = Employee.EmployeeId WHERE Email = '{email}'", Connector.Sql_Connection);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(allDraftsCommand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                draftDataGridView.DataSource = dt;
                draftDataGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DraftDistributionRequests_Load(object sender, EventArgs e)
        {
            Connector.CheckForConnection();
            FillGridWithDraftsByUserEmail(RegisterForm.Email);
        }


    }
}

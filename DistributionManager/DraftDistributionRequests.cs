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
            try
            {
                SqlDataAdapter da = new SqlDataAdapter($"SELECT RequestNumber, Status FROM DistributionRequest INNER JOIN Employee ON DistributionRequest.EmployeeId = Employee.EmployeeId WHERE Email = '{email}'", Connector.Sql_Connection);
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
            FillGridWithDraftsByUserEmail("test@gmail.com");
        }
    }
}

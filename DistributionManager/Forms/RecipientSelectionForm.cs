using DistributionManager.Connection;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace DistributionManager
{
    public partial class RecipientSelectionForm : Form
    {
        private int edrpouNumber;
        private string requestNumber;

        public RecipientSelectionForm()
        {
            InitializeComponent();
        }

        private (string, string, string, int?) GetUserDataByEmail(string email)
        {
            SqlCommand userDataCommand = new SqlCommand($"SELECT Employee.EmployeeId, Employee.Name, Surname, Position.Name AS PositionName FROM Employee INNER JOIN Position ON Employee.PositionId = Position.PositionId WHERE Email LIKE '{email}'",
            Connector.Sql_Connection);

            SqlDataReader userDataReader = null;

            string name = "", surname = "", position = "";
            int? employeeId = null;

            try
            {
                userDataReader = userDataCommand.ExecuteReader();
                if (userDataReader.Read())
                {
                    name = Convert.ToString(userDataReader["Name"]);
                    surname = Convert.ToString(userDataReader["Surname"]);
                    position = Convert.ToString(userDataReader["PositionName"]);
                    employeeId = Convert.ToInt32(userDataReader["EmployeeId"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                userDataReader?.Close();
            }

            return (name, surname, position, employeeId);
        }

        private string GetLastRequestNumber()
        {
            SqlCommand lastRequestNumberCommand = new SqlCommand("SELECT TOP 1 RequestNumber FROM DistributionRequest ORDER BY RequestNumber DESC", Connector.Sql_Connection);
            SqlDataReader lastRequestNumberReader = null;

            string lastRequestNumber = "";

            try
            {
                lastRequestNumberReader = lastRequestNumberCommand.ExecuteReader();
                if (lastRequestNumberReader.Read())
                {
                    lastRequestNumber = Convert.ToString(lastRequestNumberReader["RequestNumber"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lastRequestNumberReader?.Close();
            }

            return lastRequestNumber;
        }

        private string GenerateRequestNumber()
        {
            int currentYear = DateTime.Now.Year % 100;
            string lastNumber = GetLastRequestNumber();
            return lastNumber == "" ? $"1-{currentYear}" : $"{Convert.ToInt32(GetLastRequestNumber().Split('-').First()) + 1}-{currentYear}";
        }

        public int? GetRecipientIdByRequestNumber(int edrpou)
        {
            SqlCommand recipientIdCommand = new SqlCommand($"SELECT RecipientId FROM Recipient WHERE EDRPOUcode = {edrpou}", Connector.Sql_Connection);
            SqlDataReader recipientIdReader = null;

            int? recipientId = null;

            try
            {
                recipientIdReader = recipientIdCommand.ExecuteReader();
                if (recipientIdReader.Read())
                {
                    recipientId = Convert.ToInt32(recipientIdReader["RecipientId"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                recipientIdReader?.Close();
            }

            return recipientId;
        }

        public void SaveDistributionRequestData(string requestNumber, int? employeeId, string status)
        {
            SqlCommand newRequestCommand = new SqlCommand($"INSERT INTO DistributionRequest(RequestNumber, EmployeeId, Status) VALUES (@RequestNumber, @EmployeeId, @Status)", Connector.Sql_Connection);

            SqlDataReader newRequestReader = null;

            try
            {
                newRequestCommand.Parameters.AddWithValue("RequestNumber", requestNumber);
                newRequestCommand.Parameters.AddWithValue("EmployeeId", employeeId);
                newRequestCommand.Parameters.AddWithValue("Status", status);

                newRequestReader = newRequestCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                newRequestReader?.Close();
            }
        }

        private void Recipient_Selection_Load(object sender, EventArgs e)
        {
            Connector.CheckForConnection();

            var testEmail = "test@gmail.com";
            /*{ testEmail*//*RegisterForm.Email*//*}*/ //TODO
            (string name, string surname, string position, int? employeeId) = GetUserDataByEmail(testEmail);
            requestNumber = GenerateRequestNumber();

            nameLbl.Text = name;
            surnameLbl.Text = surname;
            positionLbl.Text = position;
            requestNumberLbl.Text = requestNumber;

            SaveDistributionRequestData(requestNumber, employeeId, "");
        }

        private (string, string, string, string) FindLegalDataByEdrpou(int edrpou)
        {
            SqlCommand legalDataCommand = new SqlCommand($"SELECT LegalNameEnglish, LegalNameUkr, LegalAddressEnglish, LegalAddressUkr FROM Recipient WHERE EDRPOUcode = {edrpou}", Connector.Sql_Connection);
            SqlDataReader legalDataReader = null;

            string legalNameEng = "", legalNameUkr = "", legalAddressEng = "", legalAddressUkr = "";

            try
            {
                legalDataReader = legalDataCommand.ExecuteReader();
                if (legalDataReader.Read())
                {
                    legalNameEng = Convert.ToString(legalDataReader["LegalNameEnglish"]);
                    legalNameUkr = Convert.ToString(legalDataReader["LegalNameUkr"]);
                    legalAddressEng = Convert.ToString(legalDataReader["LegalAddressEnglish"]);
                    legalAddressUkr = Convert.ToString(legalDataReader["LegalAddressUkr"]);
                }
                else
                    MessageBox.Show("EDRPOUcode not found. Please fill in comment field with recipient info so that database would be updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (legalDataReader != null)
                    legalDataReader.Close();
            }

            return (legalNameEng, legalNameUkr, legalAddressEng, legalAddressUkr);
        }

        private void UpdateRecipientIdByRequestNumber(int? recipientId)
        {
            try
            {
                SqlDataAdapter setRecipientId = new SqlDataAdapter($"UPDATE DistributionRequest SET RecipientId = {recipientId} WHERE RequestNumber = '{requestNumber}'", Connector.Sql_Connection);
                DataSet recipientIdDataSet = new DataSet();
                setRecipientId.Fill(recipientIdDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindLegalDataBtn_Click(object sender, EventArgs e)
        {
            int.TryParse(edrpouTextBox.Text, out int edrpou);
            (string legalNameEng, string legalNameUkr, string legalAddressEng, string legalAddressUkr) = FindLegalDataByEdrpou(edrpou);
            edrpouNumber = edrpou;

            legalNameEngTextBox.Text = legalNameEng;
            legalNameUkrTextBox.Text = legalNameUkr;
            legalAddressEngTextBox.Text = legalAddressEng;
            legalAddressUkrTextBox.Text = legalAddressUkr;

            int? recipientId = GetRecipientIdByRequestNumber(edrpouNumber);
            UpdateRecipientIdByRequestNumber(recipientId);
        }

        private void BackToMenuBtn_Click(object sender, EventArgs e)
        {
            new MainMenuForm().Show();
            //Hide();
        }

        private void ToTransportationFormBtn_Click(object sender, EventArgs e)
        {
            new Tra
        }
    }
}

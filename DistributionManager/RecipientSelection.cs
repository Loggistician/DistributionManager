using DistributionManager.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributionManager
{
    public partial class RecipientSelection : Form
    {
        public RecipientSelection()
        {
            InitializeComponent();
        }

        private (string, string, string) getUserDataByEmail(string email)
        {
            SqlCommand userDataCommand = new SqlCommand($"SELECT Employee.Name, Surname, Position.Name AS PositionName FROM Employee INNER JOIN Position ON Employee.PositionId = Position.PositionId WHERE Email LIKE '{email}'",
            Connector.Sql_Connection);

            SqlDataReader userDataReader = null;

            string name = "", surname = "", position = "";

            try
            {
                userDataReader = userDataCommand.ExecuteReader();
                if (userDataReader.Read())
                {
                    name = Convert.ToString(userDataReader["Name"]);
                    surname = Convert.ToString(userDataReader["Surname"]);
                    position = Convert.ToString(userDataReader["PositionName"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (userDataReader != null)
                    userDataReader.Close();
            }

            return (name, surname, position);
        }

        private void Recipient_Selection_Load(object sender, EventArgs e)
        {
            Connector.CheckForConnection();

            var testEmail = "test@gmail.com";
            /*{ testEmail*//*RegisterForm.Email*//*}*/ //TODO
            (string name, string surname, string position) = getUserDataByEmail(testEmail);

            nameLbl.Text = name;
            surnameLbl.Text = surname;
            positionLbl.Text = position;
        }

        private (string, string) FindLegalDataByEdrpou(int edrpou)
        {
            SqlCommand legalDataCommand = new SqlCommand($"SELECT LegalNameEnglish, LegalAddressUkr FROM Recipient WHERE EDRPOUcode = {edrpou}", Connector.Sql_Connection);
            SqlDataReader legalDataReader = null;

            string legalNameEng = "", legalAddressUkr = "";

            try
            {
                legalDataReader = legalDataCommand.ExecuteReader();
                if (legalDataReader.Read())
                {
                    legalNameEng = Convert.ToString(legalDataReader["LegalNameEnglish"]);
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

            return (legalNameEng, legalAddressUkr);
        }

        private void FindLegalDataBtn_Click(object sender, EventArgs e)
        {
            int.TryParse(edrpouTextBox.Text, out int edrpou);
            (string legalNameEng, string legalAddressUkr) = FindLegalDataByEdrpou(edrpou);
            legalNameEngTextBox.Text = legalNameEng;
            legalAddressUkrTextBox.Text = legalAddressUkr;
        }
    }
}

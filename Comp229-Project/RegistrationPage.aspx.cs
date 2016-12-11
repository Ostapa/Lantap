using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using System.Web.Configuration;
using System.Globalization;

namespace Comp229_Project
{
    public partial class RegistrationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void metricBtn_Click(object sender, EventArgs e)
        {
            // Clearing existing drop down lists
            HeightDropDownList.Items.Clear();
            WeightDropDownList.Items.Clear();

            imperialBtn.Enabled = true;

            // Loop for Metric HeightDropDownList
            for (double i = 30.0; i <= 250; i +=0.5)
            {
                ListItem item = new ListItem(i.ToString(), i.ToString());
                HeightDropDownList.Items.Add(item);
            }

            // Loop for Metric WeightDropDownList
            for (double i = 20.0; i <= 300; i += 0.5)
            {
                ListItem item = new ListItem(i.ToString(), i.ToString());
                WeightDropDownList.Items.Add(item);
            }

            metricBtn.Enabled = false;
        }

        protected void imperialBtn_Click(object sender, EventArgs e)
        {
            // Clearing existing drop down lists
            HeightDropDownList.Items.Clear();
            WeightDropDownList.Items.Clear();

            metricBtn.Enabled = true;

            // Loop for Imperial HeightDropDownList
            for (double i = 1; i <= 80; i ++)
            {
                double result;
                result = (double)i / 10;
                ListItem item = new ListItem(result.ToString(), result.ToString());
                HeightDropDownList.Items.Add(item);
            }

            // Loop for Imperial WeightDropDownList
            for (double i = 44.0; i <= 661; i += 1.0)
            {
                ListItem item = new ListItem(i.ToString(), i.ToString());
                WeightDropDownList.Items.Add(item);
            }

            imperialBtn.Enabled = false;
        }
            
        protected void registerBtn_Click(object sender, EventArgs e)
        {
            // add email verifying later

            OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            OracleCommand insertIntoPatients = new OracleCommand("INSERT INTO Patients (FirstMidName, LastName,Email, DateOfBirth,City, PostalCode, Address,Province, Gender,Height, Weight) VALUES (:FirstName, :LastName, :Email, :DateOfBirth, :City, :PostalCode, :Address, :Province, :Gender, :Height, :Weight)", connection);
            OracleCommand insertIntoAccounts = new OracleCommand("INSERT INTO Accounts (Username, Password) VALUES (:Username, :Password)", connection);

            //:FirstName, :LastName, :Email, :DateOfBirth, :City, :PostalCode, :Address, :Province, :Gender, :Height, :Weight
            insertIntoPatients.Parameters.Add(new OracleParameter(":FirstName", OracleDbType.Varchar2));
            insertIntoPatients.Parameters.Add(new OracleParameter(":LastName", OracleDbType.Varchar2));
            insertIntoPatients.Parameters.Add(new OracleParameter(":Email", OracleDbType.Varchar2));
            insertIntoPatients.Parameters.Add(new OracleParameter(":DateOfBirth", OracleDbType.Date));
            insertIntoPatients.Parameters.Add(new OracleParameter(":City", OracleDbType.Varchar2));
            insertIntoPatients.Parameters.Add(new OracleParameter(":PostalCode", OracleDbType.Char));
            insertIntoPatients.Parameters.Add(new OracleParameter(":Address", OracleDbType.Varchar2));
            insertIntoPatients.Parameters.Add(new OracleParameter(":Province", OracleDbType.Char));
            insertIntoPatients.Parameters.Add(new OracleParameter(":Gender", OracleDbType.Varchar2));
            insertIntoPatients.Parameters.Add(new OracleParameter(":Height", OracleDbType.Decimal));
            insertIntoPatients.Parameters.Add(new OracleParameter(":Weight", OracleDbType.Decimal));


            //:Username, :Password
            insertIntoAccounts.Parameters.Add(new OracleParameter(":Username", OracleDbType.Varchar2));
            insertIntoAccounts.Parameters.Add(new OracleParameter(":Password", OracleDbType.Varchar2));
            

            //:FirstName, :LastName, :Email, :DateOfBirth, :City, :PostalCode, :Address, :Province, :Gender, :Height, :Weight
            insertIntoPatients.Parameters[":FirstName"].Value = txtFirstName.Text;
            insertIntoPatients.Parameters[":LastName"].Value = txtLastName.Text;
            insertIntoPatients.Parameters[":Email"].Value = txtEmail.Text;
            insertIntoPatients.Parameters[":DateOfBirth"].Value = txtBirthDate.Text;
            insertIntoPatients.Parameters[":City"].Value = txtCity.Text;
            insertIntoPatients.Parameters[":PostalCode"].Value = txtPostalCode.Text;
            insertIntoPatients.Parameters[":Address"].Value = txtAddress.Text;
            insertIntoPatients.Parameters[":Province"].Value = ProvinceDropDownList.Text;

            // if user choses Metric
            if (metricBtn.Enabled == false)
            {
                insertIntoPatients.Parameters[":Height"].Value = HeightDropDownList.Text;
                insertIntoPatients.Parameters[":Weight"].Value = WeightDropDownList.Text;
            }

            // if user choses Imperial
            if (imperialBtn.Enabled==false)
            {
                try
                {               
                    double heightImperial = Convert.ToDouble(HeightDropDownList.Text.ToString());
                    double weightImperial = Convert.ToDouble(WeightDropDownList.Text.ToString());

                    // Converting from ft to cm
                    double height = heightImperial * 30.5;

                    // Converting from lb to kg
                    double weight = weightImperial / 2.204622;

                    insertIntoPatients.Parameters[":Height"].Value = height;
                    insertIntoPatients.Parameters[":Weight"].Value = weight;
                }
                catch (Exception error)
                {
                    Response.Write("Error occures:"+error);
                }
            }

            //:Username, :Password
            insertIntoAccounts.Parameters[":Username"].Value = txtUsername.Text;
            insertIntoAccounts.Parameters[":Password"].Value = txtPassword.Text;


            if (maleRdb.Checked == true)
            {
                insertIntoPatients.Parameters[":Gender"].Value = "Male";
            }
            else
            {
                insertIntoPatients.Parameters[":Gender"].Value = "Female";
            }

            try
            {
                connection.Open();
                insertIntoPatients.ExecuteNonQuery();
                insertIntoAccounts.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception error)
            {
                Response.Write("Error occurred: " + error.Message);
                Page.Title = "ERROR";
            }
            finally
            {
                connection.Close();
                Response.Redirect("~/HomePage.aspx");
            }
        }
    }
}
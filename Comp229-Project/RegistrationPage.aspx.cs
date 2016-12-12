using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using System.Web.Configuration;
using System.Globalization;
using System.Data;

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
            OracleCommand comm = new OracleCommand("newPatient", connection);
            comm.CommandType = CommandType.StoredProcedure;

            //:FirstName, :LastName, :Email, :DateOfBirth, :City, :PostalCode, :Address, :Province, :Gender, :Height, :Weight
            comm.Parameters.Add("First_Name", OracleDbType.Varchar2, ParameterDirection.Input);
            comm.Parameters.Add("Last_Name", OracleDbType.Varchar2, ParameterDirection.Input);
            comm.Parameters.Add("an_email", OracleDbType.Varchar2, ParameterDirection.Input);
            comm.Parameters.Add("date_of_birth", OracleDbType.Varchar2, ParameterDirection.Input);
            comm.Parameters.Add("a_city", OracleDbType.Varchar2, ParameterDirection.Input);
            comm.Parameters.Add("postal_code", OracleDbType.Varchar2, ParameterDirection.Input);
            comm.Parameters.Add("an_address", OracleDbType.Varchar2, ParameterDirection.Input);
            comm.Parameters.Add("a_province", OracleDbType.Varchar2, ParameterDirection.Input);
            comm.Parameters.Add("a_gender", OracleDbType.Varchar2, ParameterDirection.Input);
            comm.Parameters.Add("a_height", OracleDbType.Decimal, ParameterDirection.Input);
            comm.Parameters.Add("a_weight", OracleDbType.Decimal, ParameterDirection.Input);

            //:FirstName, :LastName, :Email, :DateOfBirth, :City, :PostalCode, :Address, :Province, :Gender, :Height, :Weight
            comm.Parameters["First_Name"].Value = txtFirstName.Text;
            comm.Parameters["Last_Name"].Value = txtLastName.Text;
            comm.Parameters["an_email"].Value = txtEmail.Text;
            comm.Parameters["date_of_birth"].Value = txtBirthDate.Text;
            comm.Parameters["a_city"].Value = txtCity.Text;
            comm.Parameters["postal_code"].Value = txtPostalCode.Text;
            comm.Parameters["an_address"].Value = txtAddress.Text;
            comm.Parameters["a_province"].Value = ProvinceDropDownList.Text;

            // if user choses Metric
            if (metricBtn.Enabled == false)
            {
                comm.Parameters["a_height"].Value = Convert.ToDecimal(HeightDropDownList.Text);
                comm.Parameters["a_weight"].Value = Convert.ToDecimal(WeightDropDownList.Text);
            }

            // if user choses Imperial
            if (imperialBtn.Enabled==false)
            {
                try
                {               
                    double heightImperial = Convert.ToDouble(HeightDropDownList.Text);
                    double weightImperial = Convert.ToDouble(WeightDropDownList.Text);

                    // Converting from ft to cm
                    double height = heightImperial * 30.5;

                    // Converting from lb to kg
                    double weight = weightImperial / 2.204622;

                    comm.Parameters["a_height"].Value = height;
                    comm.Parameters["a_weight"].Value = weight;
                }
                catch (Exception error)
                {
                    Response.Write("Error occures:"+ error.Message);
                }
            }


            if (maleRdb.Checked == true)
            {
                comm.Parameters["a_gender"].Value = "Male";
            }
            else
            {
                comm.Parameters["a_gender"].Value = "Female";
            }

            try
            {
                connection.Open();
                comm.ExecuteNonQuery();
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
                //Response.Redirect("~/HomePage.aspx");
            }
        }
    }
}
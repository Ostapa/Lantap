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

// We tried hard, but couldn't get it to work
namespace Comp229_Project
{
    public partial class PatientPage : System.Web.UI.Page
    {
        public Patient patient = new Patient();
        TextBox firstMidName;
        TextBox lastName;
        TextBox email;
        TextBox dateOfBirth;
        TextBox gender;
        TextBox height;
        TextBox weight;
        TextBox address;
        TextBox city;
        TextBox postalCode;
        TextBox province;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                if (!IsPostBack)
                {
                    GetPersonalInfo();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        // gets patient's personal info from Patients and Accounts tables
        protected void GetPersonalInfo()
        {
            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings[Global.CONNECTION_STRING].ConnectionString))
            {
                OracleCommand command = new OracleCommand("getPersonalInfo", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new OracleParameter("aUsername", OracleDbType.Varchar2, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("resultSet", OracleDbType.RefCursor, ParameterDirection.Output));
                command.Parameters["aUsername"].Value = Session["username"];

                try
                {
                    connection.Open();
                    OracleDataReader rd = command.ExecuteReader();
                    personalInfo.DataSource = rd;
                    personalInfo.DataBind();
                    connection.Close();
                }
                catch (Exception err)
                {
                    Response.Write("ERROR: " + err.Message);
                }
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            firstMidName = (TextBox)personalInfo.Items[0].FindControl("FirstMidName");
            firstMidName.ReadOnly = false;
            firstMidName.CssClass = "form-control";
            lastName = (TextBox)personalInfo.Items[0].FindControl("LastName");
            lastName.ReadOnly = false;
            lastName.CssClass = "form-control";
            email = (TextBox)personalInfo.Items[0].FindControl("Email");
            email.ReadOnly = false;
            email.CssClass = "form-control";
            dateOfBirth = (TextBox)personalInfo.Items[0].FindControl("DateOfBirth");
            dateOfBirth.ReadOnly = false;
            dateOfBirth.CssClass = "form-control";
            gender = (TextBox)personalInfo.Items[0].FindControl("Gender");
            gender.ReadOnly = false;
            gender.CssClass = "form-control";
            height = (TextBox)personalInfo.Items[0].FindControl("Height");
            height.ReadOnly = false;
            height.CssClass = "form-control";
            weight = (TextBox)personalInfo.Items[0].FindControl("Weight");
            weight.ReadOnly = false;
            weight.CssClass = "form-control";
            address = (TextBox)personalInfo.Items[0].FindControl("Address");
            address.ReadOnly = false;
            address.CssClass = "form-control";
            city = (TextBox)personalInfo.Items[0].FindControl("City");
            city.ReadOnly = false;
            city.CssClass = "form-control";
            postalCode = (TextBox)personalInfo.Items[0].FindControl("PostalCode");
            postalCode.ReadOnly = false;
            postalCode.CssClass = "form-control";
            province = (TextBox)personalInfo.Items[0].FindControl("Province");
            province.ReadOnly = false;
            province.CssClass = "form-control";
            updateBtn.Visible = false;
            deleteBtn.Visible = false;
            saveBtn.Visible = true;
            cancleBtn.Visible = true;


        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            Label patientId = (Label)personalInfo.Items[0].FindControl("PatientID");
            patient.PatientId = Convert.ToInt32(patientId.Text);

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings[Global.CONNECTION_STRING].ConnectionString))
            {
                OracleCommand comm = new OracleCommand("deletePatient", connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new OracleParameter("patient_id", OracleDbType.Int32, ParameterDirection.Input));
                comm.Parameters["patient_id"].Value = Convert.ToInt32(patient.PatientId);

                try
                {
                    connection.Open();
                    comm.ExecuteNonQuery();
                    connection.Close();
                    Session["username"] = null;
                    Response.Redirect("HomePage.aspx");
                }
                catch (Exception err)
                {
                    Response.Write("ERROR:" + err.Message);
                }
            }

        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(WebConfigurationManager.ConnectionStrings[Global.CONNECTION_STRING].ConnectionString))
            {
                OracleCommand comm = new OracleCommand("updatePatient", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("patient_id", OracleDbType.Int32, ParameterDirection.Input);
                Label patientId = (Label)personalInfo.Items[0].FindControl("PatientID");
                comm.Parameters["patient_id"].Value = patientId.Text;
                //--------------------------------------------------------------------------\\
                comm.Parameters.Add("fName", OracleDbType.Varchar2, ParameterDirection.Input);
                firstMidName = (TextBox)personalInfo.Items[0].FindControl("FirstMidName");
                comm.Parameters["fName"].Value = firstMidName.Text;
                //--------------------------------------------------------------------------\\
                lastName = (TextBox)personalInfo.Items[0].FindControl("LastName");
                comm.Parameters.Add("lName", OracleDbType.Varchar2, ParameterDirection.Input);
                comm.Parameters["lName"].Value = lastName.Text;
                //--------------------------------------------------------------------------\\
                email = (TextBox)personalInfo.Items[0].FindControl("Email");
                comm.Parameters.Add("an_email", OracleDbType.Varchar2, ParameterDirection.Input);
                comm.Parameters["an_email"].Value = email.Text;
                //--------------------------------------------------------------------------\\
                dateOfBirth = (TextBox)personalInfo.Items[0].FindControl("DateOfBirth");
                comm.Parameters.Add("date_of_birth", OracleDbType.Date, ParameterDirection.Input);
                comm.Parameters["date_of_birth"].Value = dateOfBirth.Text;
                //--------------------------------------------------------------------------\\
                gender = (TextBox)personalInfo.Items[0].FindControl("Gender");
                comm.Parameters.Add("a_gender", OracleDbType.Varchar2, ParameterDirection.Input);
                comm.Parameters["a_gender"].Value = gender.Text;
                //--------------------------------------------------------------------------\\
                height = (TextBox)personalInfo.Items[0].FindControl("Height");
                comm.Parameters.Add("a_height", OracleDbType.Decimal, ParameterDirection.Input);
                comm.Parameters["a_height"].Value = Convert.ToDecimal(height.Text);
                //--------------------------------------------------------------------------\\
                weight = (TextBox)personalInfo.Items[0].FindControl("Weight");
                comm.Parameters.Add("a_weight", OracleDbType.Decimal, ParameterDirection.Input);
                comm.Parameters["a_weight"].Value = Convert.ToDecimal(weight.Text);
                //--------------------------------------------------------------------------\\
                address = (TextBox)personalInfo.Items[0].FindControl("Address");
                comm.Parameters.Add("an_address", OracleDbType.Varchar2, ParameterDirection.Input);
                comm.Parameters["an_address"].Value = address.Text;
                //--------------------------------------------------------------------------\\
                city = (TextBox)personalInfo.Items[0].FindControl("City");
                comm.Parameters.Add("a_city", OracleDbType.Varchar2, ParameterDirection.Input);
                comm.Parameters["a_city"].Value = city.Text;
                //--------------------------------------------------------------------------\\
                postalCode = (TextBox)personalInfo.Items[0].FindControl("PostalCode");
                comm.Parameters.Add("postal_code", OracleDbType.Varchar2, ParameterDirection.Input);
                comm.Parameters["postal_code"].Value = postalCode.Text;
                //--------------------------------------------------------------------------\\
                province = (TextBox)personalInfo.Items[0].FindControl("Province");
                comm.Parameters.Add("a_province", OracleDbType.Varchar2, ParameterDirection.Input);
                comm.Parameters["a_province"].Value = province.Text;
                //--------------------------------------------------------------------------\\

                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("PatientPage.aspx");

                }
                catch (Exception err)
                {

                    Response.Write("ERROR: " + err.Message);
                }


            }
        }

        protected void cancleBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientPage.aspx");
        }
    }

}

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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                GetPersonalInfo();
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
            Response.Redirect("UpdatePage.aspx");
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            Label patientId = new Label();
            patientId = (Label)personalInfo.Items[0].FindControl("PatientID");
            patient.FirstMidName = patientId.Text;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings[Global.CONNECTION_STRING].ConnectionString))
            {
                OracleCommand comm = new OracleCommand("deletePatient", connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new OracleParameter("patient_id", OracleDbType.Varchar2, ParameterDirection.Input));
            }

        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {

        }

        protected void cancleBtn_Click(object sender, EventArgs e)
        {

        }
    }

}

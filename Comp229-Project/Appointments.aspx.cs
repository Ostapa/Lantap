using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using Oracle.DataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace Comp229_Project
{
    public partial class Appointments : System.Web.UI.Page
    {
        List<string> listString = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            OracleDataReader reader;
            OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings[Global.CONNECTION_STRING].ConnectionString);
            OracleCommand command = new OracleCommand("SELECT AppointmentsID,Appointments.PatientID, Date, EmployeeID, DepartmentID FROM Appointments LEFT OUTER JOIN Accounts ON Appointments.PatientID = Accounts.PatientID WHERE Username = :Username", connection);
            command.Parameters.Add(new OracleParameter(":Username", Session["username"]));
            
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
                AppointmentList.DataSource = reader;
                AppointmentList.DataBind();
                reader.Close();
                connection.Close();
            }
            catch (Exception error)
            {
                Response.Write("Error occurred" + error.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void newAppBtn_Click(object sender, EventArgs e)
        {
            newAppForm.Visible = true;
            OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings[Global.CONNECTION_STRING].ConnectionString);
            string command = "SELECT SymptomName FROM Symptoms";
            try
            {
                List<string> listOfSymptoms = new List<string>();
                connection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter(command, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                symptomsListBox.DataSource = table;
                symptomsListBox.DataBind();
                symptomsListBox.DataTextField = "SymptomName";
                symptomsListBox.DataBind();
                connection.Close();
            }
            catch (Exception error)
            {
                Response.Write("Error occurred" + error.Message);
            }
            finally
            {
                connection.Close();
            }
            addSymptomBtn.Visible = true;
        }
        protected void addSymptomBtn_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in symptomsListBox.Items)
            {
                if (item.Selected)
                {
                    listString.Add(item.Text);
                }
            }


        }
    }
}
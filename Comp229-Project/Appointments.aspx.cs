using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using Oracle.DataAccess.Client;
using System.Data;

namespace Comp229_Project
{
    public partial class Appointments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OracleDataReader reader;
            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings[Global.CONNECTION_STRING].ConnectionString))
            {
                OracleCommand command = new OracleCommand("getAppointments", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("user_name", OracleDbType.Varchar2, ParameterDirection.Input);
                command.Parameters["user_name"].Value = Session["username"];
                command.Parameters.Add("details", OracleDbType.RefCursor, ParameterDirection.Output);

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
           
        }



        
    }
}
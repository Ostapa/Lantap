using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using System.Web.Configuration;

/* © LanTap Clinic Ostap Hamarnyk
    Comp229 Team Project */

namespace Comp229_Project
{
    public partial class Departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings[Global.CONNECTION_STRING].ConnectionString))
            {
                OracleCommand command = new OracleCommand("SELECT * FROM Departments", connection);
                OracleDataReader reader;
                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();
                    departmentList.DataSource = reader;
                    departmentList.DataBind();
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
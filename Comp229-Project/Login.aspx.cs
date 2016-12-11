using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;
using Oracle.DataAccess.Client;
using System.Data;

namespace Comp229_Project
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string sql = ConfigurationManager.ConnectionStrings[Global.CONNECTION_STRING].ConnectionString;
            using (OracleConnection conn = new OracleConnection(sql))
            {
                using (OracleCommand comm = new OracleCommand("logincheck"))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.Add(new OracleParameter("ausername", OracleDbType.Varchar2, ParameterDirection.Input));
                    comm.Parameters.Add(new OracleParameter("apassword", OracleDbType.Varchar2, ParameterDirection.Input));
                    comm.Parameters.Add(new OracleParameter("numOfRows", OracleDbType.Int32, ParameterDirection.Output));
                    comm.Parameters["ausername"].Value = loginUser.UserName;
                    comm.Parameters["apassword"].Value = loginUser.Password;
;
                    comm.Connection = conn;
                    conn.Open();

                    
                    try
                    {
                        comm.ExecuteScalar();
                        int result = Convert.ToInt32(comm.Parameters["numOfRows"].Value.ToString());

                        if (result == 0)
                        {
                            loginUser.FailureText = "FAILED";
                        }
                        else
                        {
                            Session["username"] = loginUser.UserName;
                            FormsAuthentication.RedirectFromLoginPage(loginUser.UserName, loginUser.RememberMeSet);
                        }
                    }
                    catch (Exception err)
                    {
                        Response.Write(err.Message);
                    }
                }
            }
        }
    }
}
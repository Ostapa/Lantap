using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using System.Web.Configuration;
using System.Data;

namespace Comp229_Project
{
    public partial class HomePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void regBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RegistrationPage.aspx");
        }

        
    }
}

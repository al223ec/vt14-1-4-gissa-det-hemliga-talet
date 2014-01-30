using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecretNumber
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "jquery", new ScriptResourceDefinition
                {
                    Path = "/Scripts/jquery-2.1.0.min.js",
                    DebugPath = "/Scripts/jquery-2.1.0.js",
                    CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.1.0.min.js",
                    CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.1.js",
                    CdnSupportsSecureConnection = true,
                    LoadSuccessExpression = "jQuery"
                });
        }
        protected void GuessButton_Click(object sender, EventArgs e)
        {
        }
    }
}
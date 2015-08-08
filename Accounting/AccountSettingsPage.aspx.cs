using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Accounting_AccountSettingsPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCalculateSemesterFee_Click(object sender, EventArgs e)
    {
        STD_FeesManager.GetStdCalculateSemesterFee();
    }
    protected void btnDataBaseBackup_Click(object sender, EventArgs e)
    {
        //ACC_AccountingCommonManager.ProcessDataBackup();
        Response.Redirect("http://web.mavrickit.com/cucdb/" + ACC_AccountingCommonManager.ProcessDataBackup());
    }
}
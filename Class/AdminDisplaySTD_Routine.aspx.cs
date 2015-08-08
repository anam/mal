using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
 

public partial class AdminDisplaySTD_Routine : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            STD_RoutineManager.LoadSTD_RoutinePage(gvSTD_Routine, rptPager, 1, ddlPageSize);
        }
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        STD_RoutineManager.LoadSTD_RoutinePage(gvSTD_Routine, rptPager, 1, ddlPageSize);
    }

    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        STD_RoutineManager.LoadSTD_RoutinePage(gvSTD_Routine, rptPager, pageIndex, ddlPageSize);
    }

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		Response.Redirect("AdminSTD_Routine.aspx?ID=0");
	}

	protected void lbSelect_Click(object sender, EventArgs e)
	{
        try
        {
            ImageButton linkButton = new ImageButton();
            linkButton = (ImageButton)sender;
            int id;
            id = Convert.ToInt32(linkButton.CommandArgument);
            Response.Redirect("AdminSTD_Routine.aspx?ID=" + id);
        }
        catch (Exception ex)
        {
        }
	}

	protected void lbDelete_Click(object sender, EventArgs e)
	{
        try
        {
            ImageButton linkButton = new ImageButton();
            linkButton = (ImageButton)sender;
            bool result = STD_RoutineManager.DeleteSTD_Routine(Convert.ToInt32(linkButton.CommandArgument));
            STD_RoutineManager.LoadSTD_RoutinePage(gvSTD_Routine, rptPager, 1, ddlPageSize);
        }
        catch (Exception ex)
        {
        }
  	}
}


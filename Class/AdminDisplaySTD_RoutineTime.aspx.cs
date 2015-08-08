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
 

public partial class AdminDisplaySTD_RoutineTime : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            STD_RoutineTimeManager.LoadSTD_RoutineTimePage(gvSTD_RoutineTime, rptPager, 1, ddlPageSize);
        }
    }
    protected void PageSize_Changed(object sender, EventArgs e)
    {
         STD_RoutineTimeManager.LoadSTD_RoutineTimePage(gvSTD_RoutineTime,rptPager, 1, ddlPageSize);
     }
    protected void Page_Changed(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            STD_RoutineTimeManager.LoadSTD_RoutineTimePage(gvSTD_RoutineTime, rptPager, pageIndex, ddlPageSize);
        }
        catch (Exception ex)
        {
        }
   }

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		Response.Redirect("AdminSTD_RoutineTime.aspx?ID=0");
	}

	protected void lbSelect_Click(object sender, EventArgs e)
	{
        try
        {
            ImageButton linkButton = new ImageButton();
            linkButton = (ImageButton)sender;
            int id;
            id = Convert.ToInt32(linkButton.CommandArgument);
            Response.Redirect("AdminSTD_RoutineTime.aspx?ID=" + id);
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
            bool result = STD_RoutineTimeManager.DeleteSTD_RoutineTime(Convert.ToInt32(linkButton.CommandArgument));
            STD_RoutineTimeManager.LoadSTD_RoutineTimePage(gvSTD_RoutineTime, rptPager, 1, ddlPageSize);
        }
        catch (Exception ex)
        {
        }
  	}
}


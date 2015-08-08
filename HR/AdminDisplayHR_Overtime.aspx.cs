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
 

public partial class AdminDisplayHR_Overtime : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            EmployeeIDLoad();
    {
       HR_OvertimeManager.LoadHR_OvertimePage(gvHR_Overtime, rptPager, 1, ddlPageSize);
      }
    }
     protected void PageSize_Changed(object sender, EventArgs e)
    {
   HR_OvertimeManager.LoadHR_OvertimePage(gvHR_Overtime,rptPager, 1, ddlPageSize);
 }
  protected void Page_Changed(object sender, EventArgs e)
    {
       int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
    HR_OvertimeManager.LoadHR_OvertimePage(gvHR_Overtime, rptPager, pageIndex, ddlPageSize);
   }
	protected void btnAdd_Click(object sender, EventArgs e)
	{
		Response.Redirect("AdminHR_Overtime.aspx?ID=0");
	}
	protected void lbSelect_Click(object sender, EventArgs e)
	{
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		int id;
		id = Convert.ToInt32(linkButton.CommandArgument);
		Response.Redirect("AdminHR_Overtime.aspx?ID=" + id);
	}
	protected void lbDelete_Click(object sender, EventArgs e)
	{ 
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		bool result = HR_OvertimeManager.DeleteHR_Overtime(Convert.ToInt32(linkButton.CommandArgument));
       HR_OvertimeManager.LoadHR_OvertimePage(gvHR_Overtime, rptPager, 1, ddlPageSize);
  	}

    private void EmployeeIDLoad()
    {
        try
        {
            DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();
            ddlEmployeeID.DataValueField = "EmployeeID";
            ddlEmployeeID.DataTextField = "EmployeeNameNo";
            ddlEmployeeID.DataSource = ds.Tables[0];
            ddlEmployeeID.DataBind();
            ddlEmployeeID.Items.Insert(0, new ListItem("Select Employee >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void ddlEmployeeID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEmployeeID.SelectedIndex != 0)
        {
            DataSet ds = HR_OvertimeManager.GetOverTimeEmployeeByEmployeeID(ddlEmployeeID.SelectedValue);
            gvHR_Overtime.DataSource = ds;
            gvHR_Overtime.DataBind();
        }
        else
        {
            HR_OvertimeManager.LoadHR_OvertimePage(gvHR_Overtime, rptPager, 1, ddlPageSize);
        }
    }
}


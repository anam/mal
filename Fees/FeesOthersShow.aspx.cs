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
 

public partial class AdminDisplaySTD_Fees : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
        StudentIDLoad();
       
      }
    }

    private void loadData()
    {
        if (radIsPaid.SelectedValue == "All")
        {
            STD_FeesManager.LoadSTD_FeesPageByStudentID(gvSTD_Fees, rptPager, 1, ddlPageSize, ddlStudentID.SelectedValue);
        }
        else
            STD_FeesManager.LoadSTD_FeesPageByStudentIDisPaid(gvSTD_Fees, rptPager, 1, ddlPageSize, ddlStudentID.SelectedValue, bool.Parse(radIsPaid.SelectedValue)); 
    }

    private void StudentIDLoad()
    {
        try
        {
            DataSet ds = STD_StudentManager.GetDropDownListAllSTD_Student();
            ddlStudentID.DataValueField = "StudentID";
            ddlStudentID.DataTextField = "StudentName";
            ddlStudentID.DataSource = ds.Tables[0];
            ddlStudentID.DataBind();
            ddlStudentID.Items.Insert(0, new ListItem("Select Student >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
     protected void PageSize_Changed(object sender, EventArgs e)
    {
        if (radIsPaid.SelectedValue == "All")
        {
            STD_FeesManager.LoadSTD_FeesPageByStudentID(gvSTD_Fees, rptPager, 1, ddlPageSize, ddlStudentID.SelectedValue);
        }else
        STD_FeesManager.LoadSTD_FeesPageByStudentIDisPaid(gvSTD_Fees, rptPager, 1, ddlPageSize,ddlStudentID.SelectedValue,bool.Parse(radIsPaid.SelectedValue));
 }
  protected void Page_Changed(object sender, EventArgs e)
    {
       int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
       if (radIsPaid.SelectedValue == "All")
       {
           STD_FeesManager.LoadSTD_FeesPageByStudentID(gvSTD_Fees, rptPager, pageIndex, ddlPageSize, ddlStudentID.SelectedValue);
       }
       else
           STD_FeesManager.LoadSTD_FeesPageByStudentIDisPaid(gvSTD_Fees, rptPager, pageIndex, ddlPageSize, ddlStudentID.SelectedValue,bool.Parse(radIsPaid.SelectedValue));
   }
	protected void btnAdd_Click(object sender, EventArgs e)
	{
		Response.Redirect("AdminSTD_Fees.aspx?ID=0");
	}
	protected void lbSelect_Click(object sender, EventArgs e)
	{
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		int id;
		id = Convert.ToInt32(linkButton.CommandArgument);
		Response.Redirect("AdminSTD_Fees.aspx?ID=" + id);
	}
	protected void lbDelete_Click(object sender, EventArgs e)
	{ 
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		bool result = STD_FeesManager.DeleteSTD_Fees(Convert.ToInt32(linkButton.CommandArgument));
        loadData();
  	}
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        loadData();
    }
}


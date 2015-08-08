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
public partial class AdminHR_ProvidentfundContribution : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EmployeeIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showHR_ProvidentfundContributionData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_ProvidentfundContribution hR_ProvidentfundContribution = new HR_ProvidentfundContribution();
        //	hR_ProvidentfundContribution.ProvidentfundContributionID=  int.Parse(ddlProvidentfundContributionID.SelectedValue);
        hR_ProvidentfundContribution.EmployeeID = ddlEmployeeID.SelectedValue;
        hR_ProvidentfundContribution.Amount = decimal.Parse(txtAmount.Text);
        string userID = Profile.card_id;
        hR_ProvidentfundContribution.AddedBy = userID;
        hR_ProvidentfundContribution.AddedDate = DateTime.Now;
        hR_ProvidentfundContribution.ModifiedBy = userID;
        hR_ProvidentfundContribution.ModifiedDate = DateTime.Now;
        int resutl = HR_ProvidentfundContributionManager.InsertHR_ProvidentfundContribution(hR_ProvidentfundContribution);
        Response.Redirect("AdminDisplayHR_ProvidentfundContribution.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_ProvidentfundContribution hR_ProvidentfundContribution = new HR_ProvidentfundContribution();
        hR_ProvidentfundContribution.ProvidentfundContributionID = int.Parse(Request.QueryString["ID"].ToString());
        hR_ProvidentfundContribution.EmployeeID = ddlEmployeeID.SelectedValue;
        hR_ProvidentfundContribution.Amount = decimal.Parse(txtAmount.Text);
        string userID = Profile.card_id;
        hR_ProvidentfundContribution.AddedBy = userID;
        hR_ProvidentfundContribution.AddedDate = DateTime.Now;
        hR_ProvidentfundContribution.ModifiedBy = userID;
        hR_ProvidentfundContribution.ModifiedDate = DateTime.Now;
        bool resutl = HR_ProvidentfundContributionManager.UpdateHR_ProvidentfundContribution(hR_ProvidentfundContribution);
        Response.Redirect("AdminDisplayHR_ProvidentfundContribution.aspx");
    }

    private void showHR_ProvidentfundContributionData()
    {
        HR_ProvidentfundContribution hR_ProvidentfundContribution = new HR_ProvidentfundContribution();
        hR_ProvidentfundContribution = HR_ProvidentfundContributionManager.GetHR_ProvidentfundContributionByProvidentfundContributionID(Int32.Parse(Request.QueryString["ID"]));
        ddlEmployeeID.SelectedValue = hR_ProvidentfundContribution.EmployeeID.ToString();
        txtAmount.Text = hR_ProvidentfundContribution.Amount.ToString();
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
}

